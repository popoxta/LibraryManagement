using LibraryManagement.Models;
using Spectre.Console;

namespace LibraryManagement.Controllers;

public class MagazineController(LibraryController libraryController) : BaseController, IBaseController
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
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Issue Number[/]");
        table.AddColumn("[yellow]Location[/]");

        DisplayMessage("List of magazines:");
        foreach (var magazine in LibraryController.LibraryItems.OfType<Magazine>())
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
        var wasMagazineAdded = LibraryController.AddItem(new Magazine
        {
            Title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the magazine to add:"),
            Publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the magazine:"),
            PublishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the magazine (yyyy-mm-dd):"),
            IssueNumber = AnsiConsole.Ask<int>("Enter the [green]issue number[/] of the magazine:"),
            Pages = AnsiConsole.Ask<int>("Enter the [green]page count[/] of the magazine:"),
            Location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the magazine:")
        });

        if (wasMagazineAdded) DisplayMessage("Magazine added successfully!", ConsoleColor.Green);
        else DisplayMessage("Magazine already exists!", ConsoleColor.Red);
    }

    public void DeleteItem()
    {
        var magazines = LibraryController.LibraryItems.OfType<Magazine>();
        if (magazines.ToArray().Length == 0)
        {
            DisplayMessage("There are no magazines in the library!!", ConsoleColor.Red);
            return;
        }

        var magazineToDelete =
            AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a [red]magazine[/] to delete:")
                .AddChoices(LibraryController.GetAllTitles<Magazine>())
            );
        var wasMagazineRemoved = LibraryController.RemoveItem<Magazine>(magazineToDelete);

        if (wasMagazineRemoved) DisplayMessage("Magazine removed successfully!", ConsoleColor.Green);
        else DisplayMessage("Magazine could not be removed!", ConsoleColor.Red);
    }
}