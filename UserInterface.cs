using Spectre.Console;

namespace LibraryManagement;

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


    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            var option = GetMenuOption();

            switch (option)
            {
                case MenuOption.ViewBooks:
                    booksController.ViewBooks();
                    break;
                case MenuOption.AddBook:
                    booksController.AddBook();
                    break;
                case MenuOption.DeleteBook:
                    booksController.DeleteBook();
                    break;
                default:
                    throw new ArgumentException("Invalid menu option!");
            }

            BooksController.PressKeyToContinue();
        }
    }
}