using Spectre.Console;

namespace LibraryManagement;

internal static class Program
{
    private static readonly string[] StarterBooks =
    [
        "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye",
        "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm",
        "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist",
        "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
    ];

    private static readonly Library Library = new()
    {
        Books =
        [
            ..StarterBooks.Select(title => new Book
            {
                Title = title,
            })
        ]
    };

    private static readonly BooksController BooksController = new()
    {
        Library = Library
    };


    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            var option = Menu.GetMenuOption();

            switch (option)
            {
                case Menu.MenuOption.ViewBooks:
                    BooksController.ViewBooks();
                    break;
                case Menu.MenuOption.AddBook:
                    BooksController.AddBook();
                    break;
                case Menu.MenuOption.DeleteBook:
                    BooksController.DeleteBook();
                    break;
                default:
                    throw new ArgumentException("Invalid menu option!");
            }

            BooksController.PressKeyToContinue();
        }
    }
}