using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTheme;

namespace OOPProject
{
	public class LibraryService
	{
		private LibraryBransh branch;
		private DisplayService display;
		public LibraryService(LibraryBransh branch, DisplayService display)
		{
			this.branch = branch;
			this.display = display;
		}
		public void HandleBorrow()
		{
			string memberId = ThemeHelper.Prompt("Enter Member ID: ");
			Member name = branch.FindMember(memberId);

			display.ShowAvailableBooks(branch);

			string bookId = ThemeHelper.Prompt("Enter the Copy ID to borrow");
			BookCopy book =  branch.FindCopy(bookId);

			book.Borrow(name);

			display.ShowBorrowSuccess(book, name);
			

		}
		public void HandleReturn()
		{
			string copyId = ThemeHelper.Prompt("Enter Copy ID: ");
			
			BookCopy book = branch.FindCopy(copyId);
			decimal fine = book.Return();

			display.ShowReturnSuccess(book,fine);
		}
		public void HandleBorrowingHistory()
		{
			string id = ThemeHelper.Prompt("Enter Your Membership ID: ");
			branch.FindMember(id);
			display.ShowBorrowHistory(branch.FindMember(id));
		}
		public void HandleRegisterNewMember()
		{
			string name = ThemeHelper.Prompt("Enter Your Name: ");
			string phone = ThemeHelper.Prompt("Enter Your Phone Number ");
			if (!phone.IsPhone())
			{
				throw new InvalidOperationException("Phone number must contain at least one digit.");
			}
			string email = ThemeHelper.Prompt("Enter Your Email Address: ");
			if (!email.IsEmail())
			{
				throw new InvalidOperationException("Invalid email format.Must contain '@' and '.'.");
			}

			Member newMember = branch.RegisterMember(name , phone , null , email ,DateOnly.FromDateTime(DateTime.Today));
			display.RegisterNewMemberSuccess(newMember);
		}
	}
}
