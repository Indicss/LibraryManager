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
            Console.WriteLine("No overdue books");
        }
    }
}
