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

    private static readonly Library Library = new Library
    {
        Books =
        [
            ..StarterBooks.Select(title => new Book
            {
                Title = title,
            })
        ]
    };

    private static void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
        foreach (var book in Library.Books) AnsiConsole.MarkupLine($"- [cyan]{book.Title}[/]");
    }

    private static void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book:");
        var wasBookAdded = Library.AddBook(new Book { Title = title });
        AnsiConsole.MarkupLine(wasBookAdded
            ? "[green]Book added successfully![/]"
            : "[red]Book already exists![/]");
    }

    private static void DeleteBook()
    {
        if (Library.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]There are no books in the library.[/]");
            return;
        }

        var bookToDelete =
            AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a [red]book[/] to delete:")
                .AddChoices(Library.GetAllBookTitles())
            );
        var wasBookRemoved = Library.RemoveBook(bookToDelete);
        AnsiConsole.MarkupLine(wasBookRemoved
            ? "[green]Book removed successfully![/]"
            : "[red]Book not found![/]");
    }

    private static void PressKeyToContinue()
    {
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            var option = Menu.GetMenuOption();

            switch (option)
            {
                case Menu.MenuOption.ViewBooks:
                    ViewBooks();
                    break;
                case Menu.MenuOption.AddBook:
                    AddBook();
                    break;
                case Menu.MenuOption.DeleteBook:
                    DeleteBook();
                    break;
                default:
                    throw new ArgumentException("Invalid menu option!");
            }

            PressKeyToContinue();
        }
    }
}