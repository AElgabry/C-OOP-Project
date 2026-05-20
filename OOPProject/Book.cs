using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
	public class Book:IDisplay
	{
		public string ISBN { get; private set; }
		public string Title { get;private set; }

		public string AuthorName { get;private set; }
		public string Category { get;private set; }
		public int PublicationYear { get;private set; }
	
		public Book(string isbn,string title,string authorName, string category, int year)
		{
			ISBN = isbn;
			Title = title;
			AuthorName = authorName;
			Category = category;
			PublicationYear = year;
		}
		public Book(string isbn, string title) : this(isbn, title, "Unknown" ,"General", 0){ }

		public string Display()
		{
			return $"[{ISBN}] \"{Title}\" by {AuthorName} ({PublicationYear}) — {Category}";
		}
	}
}
