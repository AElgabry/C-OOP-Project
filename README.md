# 📚 Library Management System — C# OOP Project

A console-based Library Management System built in C# as an Object-Oriented Programming project. The system simulates real library operations including borrowing, returning, member registration, and transaction tracking — all structured around core OOP principles.

---

## ✨ Features

- **Branch Management** — View library branch info, manager details, opening hours, and stats
- **Book & Copy Tracking** — Manage individual book copies with condition and availability status
- **Borrow & Return** — Borrow available copies and return them with automatic fine calculation
- **Member Registration** — Register new members with validation on phone number and email format
- **Transaction History** — View full borrowing history per member including fines
- **User Display** — List all users (librarian + members) with their profile details

---

## 🏗️ Project Structure

```
OOPProject/
│
├── Models
│   ├── User.cs               # Abstract base class for all users
│   ├── Member.cs             # Inherits User — library members with transaction history
│   ├── Librarian.cs          # Inherits User — branch manager with salary & hire date
│   ├── Book.cs               # Book metadata (ISBN, title, author, category, year)
│   ├── BookCopy.cs           # Physical copy of a book with status and borrow/return logic
│   ├── BorrowTransaction.cs  # Tracks a single borrow event with fine calculation
│   └── LibraryBransh.cs      # Branch entity holding members, copies, and the manager
│
├── Services
│   ├── LibraryService.cs     # Handles user-facing operations (borrow, return, register)
│   └── DisplayService.cs     # Responsible solely for console output and formatting
│
├── Infrastructure
│   ├── IDisplay.cs           # Interface enforcing a Display() contract across entities
│   ├── Status.cs             # Enum: Available, Borrowed, Damaged, Reserved
│   ├── Extention.cs          # Extension methods for string validation (phone, email, ID)
│   ├── Database.cs           # Seed data — preloads branch, books, copies, and members
│   └── MainMenu.cs           # Static menu renderer
│
└── Program.cs                # Entry point — main loop with switch-case menu routing
```

---

## 🧩 OOP Concepts Applied

### Inheritance
`User` is an abstract base class inherited by both `Member` and `Librarian`, sharing `Name` and `Phone` while each subclass adds its own specific fields.

```csharp
public abstract class User : IDisplay { ... }
public class Member : User { ... }
public class Librarian : User { ... }
```

### Polymorphism
`Display()` is declared abstract in `User` and overridden differently in `Member` and `Librarian`, allowing a `List<User>` to call `.Display()` on each without knowing the concrete type.

```csharp
public override string Display()  // Member shows membership ID, email, join date
public override string Display()  // Librarian shows salary, hire date, librarian ID
```

### Interfaces
`IDisplay` is implemented across `Book`, `BookCopy`, `BorrowTransaction`, `Member`, `Librarian`, and `LibraryBransh` — enforcing a consistent display contract system-wide.

```csharp
public interface IDisplay
{
    string Display();
}
```

### Encapsulation
Properties use `private set` throughout to protect internal state. Collections are exposed only as `IReadOnlyList<T>` to prevent external mutation.

```csharp
public IReadOnlyList<BookCopy> Copies { get { return _copies; } }
public IReadOnlyList<BorrowTransaction> Transactions { get { return _transaction; } }
```

### Enums
`Status` enum cleanly represents the state of a book copy instead of magic strings.

```csharp
public enum Status { Available, Borrowed, Damaged, Reserved }
```

### Extension Methods
`Extention.cs` adds reusable string utility methods without modifying the `string` class.

```csharp
phone.IsPhone()   // checks for at least one digit
email.IsEmail()   // checks for '@' and '.'
id.Compare()      // trims and uppercases for consistent ID matching
```

### Separation of Concerns
- `LibraryService` handles business logic and user input
- `DisplayService` handles all output formatting
- `LibraryBransh` manages data and domain operations
- `Database` handles seeding — completely isolated from the rest

### Static Counter Pattern
`Member` and `BorrowTransaction` each use a `private static int _counter` to auto-generate unique IDs (`MEM-1`, `MEM-2`, Transaction IDs starting from 1001).

---

## 💰 Fine Calculation

Fines are calculated automatically on return based on days overdue:

```
Fine = (ReturnDate - DueDate) × 10 EGP/day
```

If the book is returned on or before the due date, no fine is charged.

---

## 🚀 How to Run

**Requirements:** .NET 6 or later

```bash
git clone https://github.com/your-username/OOPProject.git
cd OOPProject
dotnet run
```

The app launches with a preloaded branch, 3 members, 3 books, and 4 copies ready to interact with.

---

## 📋 Menu Options

```
1. Branch Information
2. Show All Users
3. Show Available Books
4. Show All Book Copies
5. Borrow a Book
6. Return a Book
7. Member Borrowing History
8. Register New Member
0. Exit
```

---

## 🛠️ Tech Stack

- **Language:** C# (.NET)
- **Paradigm:** Object-Oriented Programming
- **UI:** Console application
- **External package:** ConsoleTheme (for styled output headers, prompts, warnings)
