using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
	public class Member: User , IDisplay 
	{
		private static int _counter;
		private readonly List<BorrowTransaction> _transaction = new();

		public string MemberShipId { get;private set; }
		public DateOnly? DateOfBirth { get;private set; }
		public string Email { get;private set; }
		public DateOnly MemberShipDate { get; private set; }

		public IReadOnlyList<BorrowTransaction> Transactions 
		{
			get { return _transaction; } 
		}

		public Member(string name, string phone, DateOnly? birthDate, string email, DateOnly memberShipDate) : base(name, phone)
		{
			MemberShipId = $"MEM-{++_counter}";
			DateOfBirth = birthDate;
			Email = email;
			MemberShipDate = memberShipDate;
		}
		public Member(string name, string phone) : base(name, phone)
		{
			MemberShipId = $"MEM-{++_counter}";
		}

		public void AddTransaction(BorrowTransaction transaction)
		{
			_transaction.Add(transaction);
		}

		public override string Display()
		{
			return $@"ID : {MemberShipId} | Name : {Name} | Joined : {MemberShipDate} | Phone : {Phone} | Email : {Email?? "N/A"}";
		}

		public string GetHistory()
		{
			if (Transactions.Count() == 0)
				return "No transaction found";

			StringBuilder result = new();
			for (int i = 0; i < Transactions.Count(); i++)
			{
				result.Append(_transaction[i].Display());
			}
			return result.ToString();
		}

	}
}
