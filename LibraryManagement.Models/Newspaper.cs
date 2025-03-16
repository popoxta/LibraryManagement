using Spectre.Console;

namespace LibraryManagement.Models;

public class NewsPaper : LibraryItem
{
    public required string Publisher { get; init; }
    public required DateTime PublishDate { get; init; }

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[bold]Newspaper:[/] [cyan]{Title}[/] published by [cyan]{Publisher}[/]") +
                              $"\n[bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}