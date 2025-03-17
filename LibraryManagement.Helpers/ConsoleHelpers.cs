using Spectre.Console;

namespace LibraryManagement.Helpers;

public class ConsoleHelpers
{
    public static void PressKeyToContinue()
    {
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }
}