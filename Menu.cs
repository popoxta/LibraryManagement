using Spectre.Console;

namespace LibraryManagement;

public static class Menu
{
    public enum MenuOption
    {
        ViewBooks,
        AddBook,
        DeleteBook,
    }

    public static MenuOption GetMenuOption() =>
        AnsiConsole
            .Prompt(new SelectionPrompt<MenuOption>()
                .Title("Select an option")
                .AddChoices(Enum.GetValues<MenuOption>()));
}