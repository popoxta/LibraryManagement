namespace LibraryManagement;

internal static class Program
{
    private static void Main(string[] args)
    {
        var option = Menu.GetMenuOption();
        Console.WriteLine(option);
    }
}