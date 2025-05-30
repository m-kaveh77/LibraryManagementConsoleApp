using LibraryManagementConsoleApp.Models;

List<Book> books = new();
List<Member> members = new();
List<BorrowBook> borrowBooks = new();

while (true)
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine("Welcome to Library Management Console App");
    Console.WriteLine("-----------------------------------------------------------");

    Console.WriteLine();

    Console.WriteLine("------------------- Application options -------------------");
    Console.WriteLine();
    Console.WriteLine("1. Add new member");
    Console.WriteLine("2. Add new book");
    Console.WriteLine("3. Borrow book");
    Console.WriteLine("4. Return book");
    Console.WriteLine("5. Member List");
    Console.WriteLine("6. Book List");
    Console.WriteLine("7. Exit");
    Console.WriteLine();
    Console.WriteLine("-----------------------------------------------------------");

    Console.Write("Please select your option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            {
                Console.Clear();
                Console.WriteLine("Member list: ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine();

                if (members.Count > 0)
                {
                    foreach (var member in members)
                    {
                        Console.WriteLine($"Name: {member.Name}\nFamily: {member.Family}\nNational Code: {member.NationalCode}");
                        Console.WriteLine("-----------------------------------------------------------");
                    }

                    Console.WriteLine();
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Member list is empty. Please add new member.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                }

                break;
            }
        case "2":
            {
                Console.Clear();
                Console.WriteLine("Book list: ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine();

                if (books.Count > 0)
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Title: {book.Title}\nAuthor Name: {book.AuthorName}\nISBN: {book.ISBN}");
                        Console.WriteLine("-----------------------------------------------------------");
                    }

                    Console.WriteLine();
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Book list is empty. Please add new book.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                }

                break;
            }
        case "3":
            {
                Console.Clear();
                Console.WriteLine("Please Enter the member information: ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name is required.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Family: ");
                string family = Console.ReadLine();

                if (string.IsNullOrEmpty(family))
                {
                    Console.WriteLine("Family is required.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("National Code: ");
                string code = Console.ReadLine();

                if (string.IsNullOrEmpty(code))
                {
                    Console.WriteLine("National Code is required.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                if (!string.IsNullOrEmpty(code) && code.Length != 10)
                {
                    Console.WriteLine("National Code is invalid.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family) && !string.IsNullOrEmpty(code))
                {
                    if (members.Any(m => m.Name == name && m.Family == family && m.NationalCode == code))
                    {
                        Console.WriteLine("The member is already exists.");
                        Console.Write("Press any key back to options...");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        members.Add(new Member
                        {
                            Id = members.Count + 1,
                            Name = name,
                            Family = family,
                            NationalCode = code
                        });

                        Console.WriteLine();
                        Console.WriteLine("member added.");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine();
                    }
                }

                Console.Write("Press any key back to options...");
                Console.ReadKey();
                break;
            }
        case "4":
            {
                Console.Clear();
                Console.WriteLine("Please Enter the book information: ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine();

                Console.Write("Title: ");
                string title = Console.ReadLine();

                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Title is required.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("AuthorName: ");
                string authorName = Console.ReadLine();

                if (string.IsNullOrEmpty(authorName))
                {
                    Console.WriteLine("Author name is required.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();

                if (string.IsNullOrEmpty(isbn))
                {
                    Console.WriteLine("ISBN is required.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(authorName) && !string.IsNullOrEmpty(isbn))
                {
                    if (books.Any(b => b.Title == title))
                    {
                        Console.WriteLine("The book is already exists.");
                        Console.Write("Press any key back to options...");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        books.Add(new Book
                        {
                            Id = books.Count + 1,
                            Title = title,
                            ISBN = int.Parse(isbn),
                            AuthorName = authorName
                        });

                        Console.WriteLine();
                        Console.WriteLine("Your book added.");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine();
                    }
                }

                Console.Write("Press any key back to options...");
                Console.ReadKey();
                break;
            }
        case "5":
            {
                Console.Clear();
                Console.WriteLine("Borrow Book: ");
                Console.WriteLine("-----------------------------------------------------------");

                if (books.Count == 0)
                {
                    Console.WriteLine("Book list is empty. Please add new book.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                if (members.Count == 0)
                {
                    Console.WriteLine("Member list is empty. Please add new member.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                foreach (var book in books)
                {
                    Console.Write($"Book list: {book.Title} | ");
                }

                Console.WriteLine();

                foreach (var member in members)
                {
                    Console.Write($"Member list: {member.Name} {member.Family} | ");
                }

                Console.WriteLine();

                Console.WriteLine("Please enter book title and member name to borrowing book.");
                Console.WriteLine();

                Console.Write("Book title: ");
                var bookTitle = Console.ReadLine();

                var isExistsBookTitle = books.Any(b => b.Title == bookTitle);

                if (!isExistsBookTitle)
                {
                    Console.WriteLine("The book name in not exists in book list.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                var isBorrowedBook = borrowBooks.Exists(b => b.BookTitle == bookTitle && b.ReturnDate == null);

                if (isBorrowedBook)
                {
                    Console.WriteLine("The book already borrowed.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Member name: ");
                var memberName = Console.ReadLine();

                var isExistsMemberName = members.Any(m => m.Name == memberName);

                if (!isExistsMemberName)
                {
                    Console.WriteLine("The member name in not exists in member list.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Member family: ");
                var memberFamily = Console.ReadLine();

                var isExistsMemberFamily = members.Any(m => m.Family == memberFamily);

                if (!isExistsMemberFamily)
                {
                    Console.WriteLine("The member family in not exists in member list.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                var isBookBorrowed = borrowBooks.Exists(b => b.BookTitle == bookTitle);

                if (isBookBorrowed)
                {
                    Console.WriteLine("The book is already borrowed.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    borrowBooks.Add(new BorrowBook
                    {
                        Id = borrowBooks.Count + 1,
                        BookTitle = bookTitle,
                        MemberName = memberName,
                        MemberFamily = memberFamily,
                        BorrowDate = DateTime.Now.Date
                    });

                    Console.WriteLine();
                    Console.WriteLine("Borrow book successfully");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine();
                }

                Console.Write("Press any key back to options...");
                Console.ReadKey();
                break;
            }
        case "6":
            {
                Console.Clear();
                Console.WriteLine("Return Book: ");
                Console.WriteLine("-----------------------------------------------------------");

                if(borrowBooks.Count == 0)
                {
                    Console.WriteLine("There is not any books to return");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Book title: ");
                var bookTitle = Console.ReadLine();

                Console.Write("Member name: ");
                var memberName = Console.ReadLine();

                Console.Write("Member family: ");
                var memberFamily = Console.ReadLine();

                var isExistsBook = borrowBooks.Any(b => b.BookTitle == bookTitle && b.MemberName == memberName && b.MemberFamily == memberFamily && b.ReturnDate == null);

                if (isExistsBook)
                {
                    var book = borrowBooks.Where(b => b.BookTitle == bookTitle && b.MemberName == memberName && b.MemberFamily == memberFamily && b.ReturnDate == null).Single();

                    book.ReturnDate = DateTime.Now.Date;

                    Console.WriteLine();
                    Console.WriteLine("Return book successfully");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The book name in not exists in borrow book list.");
                    Console.Write("Press any key back to options...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Press any key back to options...");
                Console.ReadKey();
                break;
            }
        case "7":
            {
                Console.Clear();
                Console.WriteLine("Good Luck! Bye");
                Console.WriteLine("-----------------------------------------------------------");

                return;
            }
        default:
            Console.WriteLine("Your option is invalid...");
            Console.Write("Press any key back to options...");
            Console.ReadKey();
            break;
    }
}