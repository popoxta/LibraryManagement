using LibraryManagement.Controllers;
using Spectre.Console;

namespace LibraryManagement.Main;

internal class UserInterface(LibraryController libraryController)
{
    private enum MenuOption
    {
        ViewAllItems,
        ViewItems,
        AddItem,
        DeleteItem,
    }

    private enum ItemType
    {
        Book,
        Magazine,
        Newspaper
    }

    private readonly Dictionary<ItemType, IBaseController> _controllers = new()
    {
        { ItemType.Book, new BooksController(libraryController) },
        { ItemType.Magazine, new MagazineController(libraryController) },
        { ItemType.Newspaper, new NewspaperController(libraryController) }
    };

    private static MenuOption GetMenuOption() =>
        AnsiConsole
            .Prompt(new SelectionPrompt<MenuOption>()
                .Title("Select the action you want to perform.")
                .AddChoices(Enum.GetValues<MenuOption>()));

    private static ItemType GetItemType() =>
        AnsiConsole
            .Prompt(new SelectionPrompt<ItemType>()
                .Title("Select the type of item you want to perform the action on")
                .AddChoices(Enum.GetValues<ItemType>()));

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
                case MenuOption.ViewAllItems:
                    foreach (var title in libraryController.GetAllTitles())
                        AnsiConsole.MarkupLine($"[red]{title}[/]");
                    break;
                case MenuOption.ViewItems:
                {
                    var itemType = GetItemType();
                    _controllers[itemType].ViewItems();
                    break;
                }
                case MenuOption.AddItem:
                {
                    var itemType = GetItemType();
                    _controllers[itemType].AddItem();
                    break;
                }
                case MenuOption.DeleteItem:
                {
                    var itemType = GetItemType();
                    _controllers[itemType].DeleteItem();
                    break;
                }

                default:
                    throw new ArgumentException("Invalid menu option!");
            }

            PressKeyToContinue();
        }
    }
}