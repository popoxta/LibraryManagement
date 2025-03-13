using Spectre.Console;

namespace LibraryManagement;

public class BooksController
{
    public required Library Library { get; init; }

    public void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
        foreach (var book in Library.Books) AnsiConsole.MarkupLine($"- [cyan]{book.Title}[/]");
    }

    public void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book:");
        var wasBookAdded = Library.AddBook(new Book { Title = title });
        AnsiConsole.MarkupLine(wasBookAdded
            ? "[green]Book added successfully![/]"
            : "[red]Book already exists![/]");
    }

    public void DeleteBook()
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

    public static void PressKeyToContinue()
    {
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }
}