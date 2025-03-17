using LibraryManagement.Main;
using LibraryManagement.Models;
using Spectre.Console;

namespace LibraryManagement.Controllers;

public class BooksController(Library library) : IBaseController
{
    public void ViewItems()
    {
        var table = new Table
        {
            Border = TableBorder.Rounded,
        };

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
        foreach (var book in library.LibraryItems.OfType<Book>())
            table.AddRow(
                book.Id.ToString(),
                $"[cyan]{book.Title}[/]",
                $"[cyan]{book.Author}[/]",
                $"[green]{book.Category}[/]",
                $"[blue]{book.Location}[/]",
                book.Pages.ToString()
            );

        AnsiConsole.Write(table);
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
        var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");


        var wasBookAdded = library.AddItem(new Book
        {
            Title = title,
            Pages = pages,
            Category = category,
            Author = author,
            Location = location
        });

        AnsiConsole.MarkupLine(wasBookAdded
            ? "[green]Book added successfully![/]"
            : "[red]Book already exists![/]");
    }

    public void DeleteItem()
    {
        var books = library.LibraryItems.OfType<Book>();
        if (books.ToArray().Length == 0)
        {
            AnsiConsole.MarkupLine("[red]There are no books in the library.[/]");
            return;
        }

        var bookToDelete =
            AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a [red]book[/] to delete:")
                .AddChoices(library.GetAllTitles<Book>())
            );
        var wasBookRemoved = library.RemoveItem<Book>(bookToDelete);
        AnsiConsole.MarkupLine(wasBookRemoved
            ? "[green]Book removed successfully![/]"
            : "[red]Book not found![/]");
    }
}