using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace OOPProject
{
	public class BookCopy:IDisplay
	{
		public string  CopyId { get;private set; }
		public string Condition { get;private set; }
		public Status CopyStatus { get; set; }
		public Book Book { get; set; }
		public BorrowTransaction? ActiveTransaction { get; set; }	

		public BookCopy(string copyId,Book book, string condition)
		{
			CopyId = copyId;
			Book = book;
			Condition = condition;
		}
		public bool IsAvailable() => CopyStatus == Status.Available;
		
		public void Borrow(Member member, int loanDays = 14)
		{
			if (CopyStatus != Status.Available)
				throw new InvalidOperationException($"Copy {CopyId} is not available (Status : {CopyStatus})");
			CopyStatus = Status.Borrowed;
			ActiveTransaction = new BorrowTransaction(member, this, 14);
			member.AddTransaction(ActiveTransaction);
		}
		public decimal Return()
		{
			if (CopyStatus != Status.Borrowed)
				throw new InvalidOperationException($"Copy {CopyId} is not currently Borrowed");

			if (ActiveTransaction == null)
				throw new InvalidOperationException("No active transcation for this copy");

			ActiveTransaction.MarkReturned(DateOnly.FromDateTime(DateTime.Today));
			decimal fine = ActiveTransaction.CalculateFine();
			CopyStatus = Status.Available;
			ActiveTransaction = null;
			return fine;

		}

		public string Display()
		{
			return $"Copy [{CopyId}] - {Book.Title} - Condition: {Condition} - {CopyStatus}";
		}

	}
}
