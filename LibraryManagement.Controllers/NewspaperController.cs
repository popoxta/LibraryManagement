﻿using LibraryManagement.Models;
using Spectre.Console;

namespace LibraryManagement.Controllers;

public class NewspaperController(LibraryController libraryController) : IBaseController
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
        table.AddColumn("[yellow]Location[/]");

        AnsiConsole.MarkupLine("[yellow]List of newspapers:[/]");
        foreach (var newspaper in LibraryController.LibraryItems.OfType<Newspaper>())
            table.AddRow(
                newspaper.Id.ToString(),
                $"[cyan]{newspaper.Title}[/]",
                $"[cyan]{newspaper.Publisher}[/]",
                $"[cyan]{newspaper.PublishDate:yyyy-MM-dd}[/]",
                $"[blue]{newspaper.Location}[/]"
            );

        AnsiConsole.Write(table);
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the newspaper to add:");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the newspaper:");
        var publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the newspaper (yyyy-MM-dd):");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the newspaper:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]page count[/] of the newspaper:");

        var wasNewspaperAdded = LibraryController.AddItem(new Newspaper
        {
            Title = title,
            Publisher = publisher,
            PublishDate = publishDate,
            Pages = pages,
            Location = location
        });

        AnsiConsole.MarkupLine(wasNewspaperAdded
            ? "[green]Newspaper added successfully![/]"
            : "[red]Newspaper already exists![/]");
    }

    public void DeleteItem()
    {
        var newspaper = LibraryController.LibraryItems.OfType<Newspaper>();
        if (newspaper.ToArray().Length == 0)
        {
            AnsiConsole.MarkupLine("[red]There are no newspaper in the library.[/]");
            return;
        }

        var newspaperToDelete =
            AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a [red]newspaper[/] to delete:")
                .AddChoices(LibraryController.GetAllTitles<Newspaper>())
            );
        var wasNewspaperRemoved = LibraryController.RemoveItem<Newspaper>(newspaperToDelete);
        AnsiConsole.MarkupLine(wasNewspaperRemoved
            ? "[green]Newspaper removed successfully![/]"
            : "[red]Newspaper not found![/]");
    }
}