using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
	public class Librarian:User
	{
		public string LibrarianId { get; set; }
		public decimal Salary { get; set; }
		public DateOnly HireDate { get; set; }

		public Librarian(string name, string phone, string id, decimal salary,DateOnly hire):base(name,phone)
		{
			LibrarianId = id;
			Salary = salary;
			HireDate = hire;
		}
		public override string Display()
		{
			return $@"ID : {LibrarianId} | Name : {Name} | Phone : {Phone} | Salary : {Salary} | Hired : {HireDate}";
		}
	}
}
