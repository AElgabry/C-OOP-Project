using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
	public abstract class User: IDisplay
	{
		public string Name { get; protected set; }
		public string Phone { get; protected set; }

		public User(string name, string phone)
		{
			Name = name;
			Phone = phone;
		}
		public abstract string Display();
	}
}
