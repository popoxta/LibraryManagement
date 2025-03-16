using Spectre.Console;

namespace LibraryManagement.Main;

public class BooksController(Library library)
{
    public void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
        foreach (var book in library.Books) AnsiConsole.MarkupLine($"- [cyan]{book.Title} - {book.Pages} pages[/]");
    }

    public void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]pages[/] of the book:");
        var wasBookAdded = library.AddBook(new Book { Title = title, Pages = pages });
        AnsiConsole.MarkupLine(wasBookAdded
            ? "[green]Book added successfully![/]"
            : "[red]Book already exists![/]");
    }

    public void DeleteBook()
    {
        if (library.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]There are no books in the library.[/]");
            return;
        }

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

    public static void PressKeyToContinue()
    {
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }
}