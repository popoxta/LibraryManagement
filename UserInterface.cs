using System.Diagnostics.CodeAnalysis;
using Spectre.Console;

namespace LibraryManagement;

[method: SetsRequiredMembers]
internal class UserInterface(BooksController booksController)
{
    private enum MenuOption
    {
        ViewBooks,
        AddBook,
        DeleteBook,
    }

    internal required BooksController BooksController { get; init; } = booksController;

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
                    BooksController.ViewBooks();
                    break;
                case MenuOption.AddBook:
                    BooksController.AddBook();
                    break;
                case MenuOption.DeleteBook:
                    BooksController.DeleteBook();
                    break;
                default:
                    throw new ArgumentException("Invalid menu option!");
            }

            BooksController.PressKeyToContinue();
        }
    }
}