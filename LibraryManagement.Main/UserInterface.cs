using Spectre.Console;

namespace LibraryManagement.Main;

internal class UserInterface(BooksController booksController)
{
    private enum MenuOption
    {
        ViewBooks,
        AddBook,
        DeleteBook,
    }

    private static MenuOption GetMenuOption() =>
        AnsiConsole
            .Prompt(new SelectionPrompt<MenuOption>()
                .Title("Select an option")
                .AddChoices(Enum.GetValues<MenuOption>()));

    private static void PressKeyToContinue()
    {
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }


    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            var option = GetMenuOption();

            switch (option)
            {
                case MenuOption.ViewBooks:
                    libraryController.ViewBooks();
                    break;
                case MenuOption.AddBook:
                    libraryController.AddBook();
                    break;
                case MenuOption.DeleteBook:
                    libraryController.DeleteBook();
                    break;
                default:
                    throw new ArgumentException("Invalid menu option!");
            }

            PressKeyToContinue();
        }
    }
}