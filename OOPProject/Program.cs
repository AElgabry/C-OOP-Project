namespace OOPProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			LibraryBransh bransh = Database.Seed();
			var display = new DisplayService();
			var libraryService = new LibraryService(bransh, display);

			bool run = true;
			while(run)
			{
				MainMenu.ShowMenu();

				bool isParsed = int.TryParse(Console.ReadLine(), out int num);
				if(isParsed)
				{
					switch(num)
					{
						case 1: display.ShowBranshInfo(bransh); break;
						case 2: display.ShowAllUsers(bransh); break;
						case 3: display.ShowAvailableBooks(bransh); break;
						case 4: display.ShowAllCopies(bransh); break;
						case 5: libraryService.HandleBorrow(); break;
						case 6: libraryService.HandleReturn(); break;
						case 7: libraryService.HandleBorrowingHistory(); break;
						case 8: libraryService.HandleRegisterNewMember(); break;
						case 0: run = false; break;
						default: Console.WriteLine("Enter a number between 1 and 8");break;
					}
				}
				else
				{ 
				Console.WriteLine("Please Enter a Number"); 
				}
				Console.WriteLine("Press Enter to continue...");
				Console.ReadLine();

				Console.Clear();

			}
		}
	}
}
