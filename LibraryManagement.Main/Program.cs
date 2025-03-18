using LibraryManagement.Controllers;

namespace LibraryManagement.Main;

internal static class Program
{
    private static readonly LibraryController LibraryController = new([..MockDatabase.LibraryItems]);

    private static readonly UserInterface UserInterface = new(LibraryController);

    private static void Main(string[] args) => UserInterface.MainMenu();
}