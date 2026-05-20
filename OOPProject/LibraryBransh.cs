using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
	public class LibraryBransh:IDisplay
	{

		private readonly List<BookCopy> _copies=new();
		private readonly List<Member> _members = new();
		public string BranshId { get;private set; }
		public string BranshName { get;private set; }
		public string Address { get;private set; }
		public string  Phone { get;private set; }
		public string OpeningHours { get; set; }
		public Librarian Manager { get;private set; }

		public IReadOnlyList<BookCopy> Copies{ get { return _copies; } }
		public IReadOnlyList<Member> Members { get{ return _members; } }
		public IReadOnlyList<User> Users
		{
			get
			{
				List<User> users = new();
				users.Add(Manager);
				users.AddRange(_members);
				return users;
			}
		}

		public LibraryBransh(string branshid, string branshName, string address, string phone, string openingHours, Librarian manager)
		{
			BranshId = branshid;
			BranshName = branshName;
			Address = address;
			Phone = phone;
			OpeningHours = openingHours;
			Manager = manager;
		}

		public Member RegisterMember(string name, string phone)
		{
			Member mem = new(name, phone);
			_members.Add(mem);
			return mem;
		}
		public Member RegisterMember(string name, string phone, DateOnly? birthDate, string email, DateOnly memberShipDate)
		{
			Member mem = new(name, phone, birthDate, email, memberShipDate);
			_members.Add(mem);
			return mem;
		}
		public Member FindMember(string memberShipId)
		{
			for (int i = 0; i < _members.Count; i++)
			{
				if (_members[i].MemberShipId == memberShipId.Compare())
					return _members[i];
			}
			throw new InvalidOperationException("Member not found");
		}
		public void AddBookCopy(BookCopy copy)
		{
			_copies.Add(copy);
		}
		public BookCopy FindCopy(string id)
		{
			for (int i = 0; i < _copies.Count; i++)
			{
				if (_copies[i].CopyId == id.Compare())
					return _copies[i];
			}
			throw new InvalidOperationException("Book copy not found");
		}
		public List<BookCopy> GetAvailableCopies()
		{
			List<BookCopy> availableCopies = new();
			foreach (var copy in _copies)
			{
				if (copy.IsAvailable())
					availableCopies.Add(copy);
			}
			return availableCopies;
		}

		public string Display()
		{
			return $@"
ID : {BranshId}
Name : {BranshName}
Address : {Address}
Phone : {Phone}
Opening Hours : {OpeningHours}
Manager : {Manager}
Total Member : {_members.Count}
Total Book Copies : {_copies.Count}
			";
		}
	}
}
