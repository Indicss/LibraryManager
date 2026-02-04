bool running = true;
Library library = new Library();

while (running)
{
    Console.WriteLine("\nLibrary Manager:");
    Console.WriteLine("1. Add a new book");
    Console.WriteLine("2. View all books");
    Console.WriteLine("3. Borrow a book");
    Console.WriteLine("4. Return a book");
    Console.WriteLine("5. View overdue books");
    Console.WriteLine("6. Exit");

    Console.Write("Choose option: ");
    int option = int.Parse(Console.ReadLine()!);

    if (option == 1)
    {
        library.AddBook();
    }
    else if (option == 2)
    {
        library.ListBooks();
    }
    else if (option == 3)
    {
        library.BorrowBook();
    }
    else if (option == 4)
    {
        library.ReturnBook();
    }
    else if (option == 5)
    {
        library.ListOverdueBooks();
    }
    else if (option == 6)
    {
        Console.WriteLine("You exit the menu.");
        running = false;
    }
}

public class Book
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsBorrowed { get; set; }
    public DateTime? BorrowedAt { get; set; }

    public void Borrow()
    {
        IsBorrowed = true;
        BorrowedAt = DateTime.Now;
    }
    
    public void Return()
    {
        IsBorrowed = false;
        BorrowedAt = null;
    }
    
    public bool IsOverdue()
    {
        return IsBorrowed && BorrowedAt.HasValue &&
               (DateTime.Now - BorrowedAt.Value).Days > 14;
    }
}

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine()!;

        Console.Write("Author: ");
        string author = Console.ReadLine()!;

        books.Add(new Book { Title = title, Author = author });
        Console.WriteLine("Book added successfully.");
    }
    
    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.WriteLine("\nBooks in library:");
        for (int i = 0; i < books.Count; i++)
        {
            var b = books[i];
            Console.WriteLine($"{i}. {b.Title} - {b.Author}  Borrowed: {b.IsBorrowed}");
        }
    }

    public void BorrowBook()
    {
        ListBooks();
        
        if (books.Count == 0) return;
        
        Console.Write("Choose book index: ");
        if (int.TryParse(Console.ReadLine(), out int chosenIndex))
        {
            if (chosenIndex >= 0 && chosenIndex < books.Count)
            {
                if (!books[chosenIndex].IsBorrowed)
                {
                    books[chosenIndex].Borrow();
                    Console.WriteLine("Book borrowed.");
                }
                else
                {
                    Console.WriteLine("Book already borrowed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    public void ReturnBook()
    {
        var borrowedBooks = new List<(int Index, Book Book)>();
        
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].IsBorrowed)
            {
                borrowedBooks.Add((i, books[i]));
            }
        }
        
        if (borrowedBooks.Count == 0)
        {
            Console.WriteLine("No borrowed books to return.");
            return;
        }
        
        Console.WriteLine("\nBorrowed books:");
        foreach (var (index, book) in borrowedBooks)
        {
            Console.WriteLine($"{index}. {book.Title} - {book.Author}");
        }
        
        Console.Write("Choose book index to return: ");
        if (int.TryParse(Console.ReadLine(), out int chosenIndex))
        {
            if (chosenIndex >= 0 && chosenIndex < books.Count && books[chosenIndex].IsBorrowed)
            {
                books[chosenIndex].Return();
                Console.WriteLine("Book returned.");
            }
            else
            {
                Console.WriteLine("Invalid index or book not borrowed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    public void ListOverdueBooks()
    {
        bool foundOverdue = false;
        
        foreach (var book in books)
        {
            if (book.IsOverdue())
            {
                Console.WriteLine($"{book.Title} is overdue!");
                foundOverdue = true;
            }
        }
        
        if (!foundOverdue)
        {
            Console.WriteLine("No overdue books.");
        }
    }
}