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

    private static void Main(string[] args)
    {
        var library = new Library
        {
            Books =
            [
                ..StarterBooks.Select(title => new Book
                {
                    Title = title,
                })
            ]
        };

        while (true)
        {
            Console.Clear();
            var option = Menu.GetMenuOption();

            switch (option)
            {
                case "View Books":
                    AnsiConsole.MarkupLine("[yellow]List of books:[/]");
                    foreach (var book in library.Books) AnsiConsole.MarkupLine($"- [cyan]{book.Title}[/]");

                    PressKeyToContinue();
                    break;
                case "Add book":
                    var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book:");
                    var wasBookAdded = library.AddBook(new Book { Title = title });
                    AnsiConsole.MarkupLine(wasBookAdded
                        ? "[green]Book added successfully![/]"
                        : "[red]Book already exists![/]");

                    PressKeyToContinue();
                    break;
                case "Delete book":
                    if (library.Books.Count == 0) AnsiConsole.MarkupLine("[red]There are no books in the library.[/]");
                    else
                    {
                        var bookToDelete =
                            AnsiConsole.Prompt(new SelectionPrompt<string>()
                                .Title("Select a [red]book[/] to delete:")
                                .AddChoices(library.GetAllBookTitles())
                            );
                        var wasBookRemoved = library.RemoveBook(bookToDelete);
                        AnsiConsole.MarkupLine(wasBookRemoved
                            ? "[green]Book removed successfully![/]"
                            : "[red]Book not found![/]");
                    }

                    PressKeyToContinue();
                    break;
            }
        }
    }

    private static void PressKeyToContinue()
    {
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }
}