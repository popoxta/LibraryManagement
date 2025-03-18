using LibraryManagement.Models;
using Spectre.Console;

namespace LibraryManagement.Controllers;

public class BooksController(LibraryController libraryController) : BaseController, IBaseController
{
    public LibraryController LibraryController { get; } = libraryController;

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

        DisplayMessage("List of books");
        foreach (var book in LibraryController.LibraryItems.OfType<Book>())
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


        var wasBookAdded = LibraryController.AddItem(new Book
        {
            Title = title,
            Pages = pages,
            Category = category,
            Author = author,
            Location = location
        });

        if (wasBookAdded) DisplayMessage("Book added successfully!", ConsoleColor.Green);
        else DisplayMessage("Book already exists!", ConsoleColor.Red);
    }

    public void DeleteItem()
    {
        var books = LibraryController.LibraryItems.OfType<Book>();
        if (books.ToArray().Length == 0)
        {
            DisplayMessage("There are no books in the library.", ConsoleColor.Red);
            return;
        }

        var bookToDelete =
            AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a [red]book[/] to delete:")
                .AddChoices(LibraryController.GetAllTitles<Book>())
            );
        var wasBookRemoved = LibraryController.RemoveItem<Book>(bookToDelete);
        if (wasBookRemoved) DisplayMessage("Book removed successfully!", ConsoleColor.Green);
        else DisplayMessage("Book could not be removed!", ConsoleColor.Red);
    }
}