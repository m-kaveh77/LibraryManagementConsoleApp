using LibraryManagementConsoleApp.Models;

List<Book> books = new();

while (true)
{
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine("Welcome to Library Management Console App");
    Console.WriteLine("-----------------------------------------------------------");

    Console.WriteLine();

    Console.WriteLine("------------------- Application options -------------------");
    Console.WriteLine();
    Console.WriteLine("1. Member List");
    Console.WriteLine("2. Book List");
    Console.WriteLine("3. Add new member");
    Console.WriteLine("4. Add new book");
    Console.WriteLine("5. Borrow book");
    Console.WriteLine("6. Return book");
    Console.WriteLine("7. Exit");
    Console.WriteLine();
    Console.WriteLine("-----------------------------------------------------------");

    Console.Write("Please select your option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            break;
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
            break;
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
                    Console.WriteLine("Press any key back to options...");
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
            break;
        case "6":
            break;
        case "7":
            break;
        default:
            Console.WriteLine("Your option is invalid...");
            Console.Write("Press any key back to options...");
            Console.ReadKey();
            break;
    }
}