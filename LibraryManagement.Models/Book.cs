using Spectre.Console;

namespace LibraryManagement.Models;

public class Book : LibraryItem
{
    public required string Category { get; init; }
    public required string Author { get; init; }

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[bold]Book:[/] [cyan]{Title}[/] by [cyan]{Author}[/]") +
                              $"\n[bold]Pages:[/] {Pages}" +
                              $"\n[bold]Category:[/] [green]{Category}[/]" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}