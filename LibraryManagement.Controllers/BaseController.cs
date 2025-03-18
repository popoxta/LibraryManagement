using Spectre.Console;

namespace LibraryManagement.Controllers;

public abstract class BaseController
{
    protected static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.Yellow) =>
        AnsiConsole.MarkupLine($"{message}", color);

    protected static bool ConfirmDeletion(string itemName) =>
        AnsiConsole.Confirm($"Are you sure you want to delete {itemName}?");
}