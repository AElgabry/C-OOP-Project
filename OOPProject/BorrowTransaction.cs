using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
	public class BorrowTransaction:IDisplay
	{
		private static int _counter=1000;
		private const int finePerDay= 10;
		private string dateFormat = "dd/mmm/yyyy";

		public int  TransactionId { get;private set; }
		public Member Member { get; set; }
		public BookCopy BookCopy { get; set; }
		public DateOnly BorrowDate { get; set; }
		public DateOnly DueDate { get; set; }
		public DateOnly? ReturnDate { get; set; }

		public BorrowTransaction(Member member, BookCopy copy , int loanDays)
		{
			TransactionId = ++_counter;
			Member = member;
			BookCopy = copy;
			BorrowDate = DateOnly.FromDateTime(DateTime.Today);
			DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(loanDays));
		}
		public bool isReturned() => ReturnDate.HasValue;

		public void MarkReturned(DateOnly returnDate) => ReturnDate = returnDate;

		public decimal CalculateFine()
		{
			DateOnly today = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
			if (today.DayNumber - DueDate.DayNumber <= 0)
				return 0;
			return (today.DayNumber - DueDate.DayNumber) * finePerDay;
		}
		public decimal CalculateFine(DateOnly returnDate)
		{
			if (returnDate.DayNumber - DueDate.DayNumber <= 0)
				return 0;
			return (returnDate.DayNumber - DueDate.DayNumber) * finePerDay;
		}
		
		public string Display()
		{

			string isReturned = ReturnDate.HasValue ? "Returned" : "Not returned yet";
			string status = ReturnDate.HasValue ? "Returned" : "Active";
				
			return $@"--------------------Transaction{TransactionId}--------------------
Book : {BookCopy.Book.Title} 
Copy ID : { BookCopy.CopyId}
Borrowed : {BorrowDate}
Due : {DueDate}
Returned : {isReturned}
Status : {status}
Fine : {CalculateFine()}";
		}
	}
}
