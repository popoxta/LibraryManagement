using Spectre.Console;

namespace LibraryManagement;

public static class Menu
{
    private static readonly string[] MenuOptions = ["View Books", "Add book", "Delete book"];

    public static string GetMenuOption()
    {
        return AnsiConsole
            .Prompt(new SelectionPrompt<string>()
                .Title("Select an option")
                .AddChoices(MenuOptions));
    }
}