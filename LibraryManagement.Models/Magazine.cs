using Spectre.Console;

namespace LibraryManagement.Models;

public class Magazine : LibraryItem
{
    public required string Publisher { get; init; }
    public required DateTime PublishDate { get; init; }
    public required int IssueNumber { get; init; }

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[bold]Magazine:[/] [cyan]{Title}[/] published by [cyan]{Publisher}[/]") +
                              $"\n[bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}" +
                              $"\n[bold]Issue Number:[/] {IssueNumber}" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}