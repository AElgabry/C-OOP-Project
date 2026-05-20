using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleTheme;

namespace OOPProject
{
	public class DisplayService
	{
		public void ShowBranshInfo(LibraryBransh branch)
		{
			ThemeHelper.PrintHeader("LIBRARY BRANCH INFO");
			Console.WriteLine(branch.Display());
		}
		public void ShowAllUsers(LibraryBransh branch)
		{
			ThemeHelper.PrintHeader("All Registered Users");
			IReadOnlyList<User> user = branch.Users; 
			for (int i = 0; i < user.Count; i++)
			{
				string header = user[i] is Librarian ? "LiBRARIAN PROFILE" : "MEMBER PROFILE";
				ThemeHelper.PrintSectionTitle(header);
				Console.WriteLine(user[i].Display());
			}
		}
		public void ShowAvailableBooks(LibraryBransh branch)
		{
			IReadOnlyList<BookCopy> available = branch.GetAvailableCopies();
			ThemeHelper.PrintHeader("Available Book Copies:");
			if (available.Count == 0)
			{
				ThemeHelper.PrintWarning("There are no available book copies");
				return;
			}
			for (int i = 0; i < available.Count; i++)
			{
				Console.WriteLine(available[i].Display());
			}
		}
		public void ShowAllCopies(LibraryBransh branch)
		{
			ThemeHelper.PrintHeader("ALL Book Copies");
			if (branch.Copies.Count == 0)
			{
				ThemeHelper.PrintWarning("No book copies found.");
				return;
			}
			for (int i = 0; i < branch.Copies.Count; i++)
			{
				Console.WriteLine(branch.Copies[i].Display());
			}
		}
		public void ShowBorrowHistory(Member member)
		{
			ThemeHelper.PrintHeader($"Transaction history for {member.Name}");
			if(member.Transactions.Count==0)
			{
				ThemeHelper.PrintWarning("No borrowing history found");
			}
			for (int i = 0; i < member.Transactions.Count; i++)
			{
				Console.WriteLine(member.Transactions[i].Display());
			}
		}
		public void ShowBorrowSuccess(BookCopy book , Member name)
		{
			ThemeHelper.PrintSuccess($"Copy [${book.CopyId}] : {book.Book.Title} is borrowed by {name.Name}");
			ThemeHelper.PrintSuccess($"Due date: {book.ActiveTransaction!.DueDate:dd/MM/yyyy}");
		}
		public void ShowReturnSuccess(BookCopy book,decimal fine)
		{
			ThemeHelper.PrintSuccess($"Copy [${book.CopyId}] : {book.Book.Title} is returned");
			if (fine == 0)
			{
				ThemeHelper.PrintSuccess("Returned on time. No fine.");
			}
			else
				ThemeHelper.PrintWarning($"Late return fine: {fine}");
		}
		public void RegisterNewMemberSuccess(Member member)
		{
			ThemeHelper.PrintSuccess($"Member: {member.Name} - {member.MemberShipId} registered");
		}
		public void ShowAddCopySuccess(BookCopy copy)
		{
			ThemeHelper.PrintSuccess($"Copy [{copy.CopyId}] - {copy.Book.Title}: added to branch.");
		}

	}
}
