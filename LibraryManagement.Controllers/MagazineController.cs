using LibraryManagement.Main;
using LibraryManagement.Models;
using Spectre.Console;

namespace LibraryManagement.Controllers;

public class MagazineController(Library library) : IBaseController
{
    public void ViewItems()
    {
        var table = new Table
        {
            Border = TableBorder.Rounded,
        };

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Issue Number[/]");
        table.AddColumn("[yellow]Location[/]");

        AnsiConsole.MarkupLine("[yellow]List of magazines:[/]");
        foreach (var magazine in library.LibraryItems.OfType<Magazine>())
            table.AddRow(
                magazine.Id.ToString(),
                $"[cyan]{magazine.Title}[/]",
                $"[cyan]{magazine.Publisher}[/]",
                $"[cyan]{magazine.PublishDate:MMMM dd, yyyy}[/]",
                magazine.IssueNumber.ToString(),
                $"[blue]{magazine.Location}[/]"
            );

        AnsiConsole.Write(table);
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the magazine to add:");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the magazine:");
        var publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the magazine (yyyy-mm-dd):");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the magazine:");
        var issueNumber = AnsiConsole.Ask<int>("Enter the [green]issue number[/] of the magazine:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]page count[/] of the magazine:");

        var wasMagazineAdded = library.AddItem(new Magazine
        {
            Title = title,
            Publisher = publisher,
            PublishDate = publishDate,
            IssueNumber = issueNumber,
            Pages = pages,
            Location = location
        });

        AnsiConsole.MarkupLine(wasMagazineAdded
            ? "[green]Magazine added successfully![/]"
            : "[red]Magazine already exists![/]");
    }

    public void DeleteItem()
    {
        var magazines = library.LibraryItems.OfType<Magazine>();
        if (magazines.ToArray().Length == 0)
        {
            AnsiConsole.MarkupLine("[red]There are no magazines in the library.[/]");
            return;
        }

        var magazineToDelete =
            AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a [red]magazine[/] to delete:")
                .AddChoices(library.GetAllTitles<Magazine>())
            );
        var wasMagazineRemoved = library.RemoveItem<Magazine>(magazineToDelete);
        AnsiConsole.MarkupLine(wasMagazineRemoved
            ? "[green]Magazine removed successfully![/]"
            : "[red]Magazine not found![/]");
    }
}