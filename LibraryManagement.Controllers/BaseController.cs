using Spectre.Console;

namespace LibraryManagement.Controllers;

public abstract class BaseController
{
    protected static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.Yellow) =>
        AnsiConsole.MarkupLine($"{message}", color);
}