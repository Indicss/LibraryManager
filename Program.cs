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
        Console.WriteLine("You exit the menu");
        running = false;
    }
}
