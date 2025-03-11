using Spectre.Console;

namespace LibraryManagement;

internal static class Program
{
    private static readonly string[] StarterBooks =
    [
        "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye",
        "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm",
        "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist",
        "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
    ];

    private static void Main(string[] args)
    {
        var library = new Library
        {
            Books =
            [
                ..StarterBooks.Select(title => new Book
                {
                    Title = title,
                })
            ]
        };

        while (true)
        {
            Console.Clear();
            var option = Menu.GetMenuOption();

            switch (option)
            {
                case "View Books":
                    AnsiConsole.MarkupLine("[yellow]List of books:[/]");
                    foreach (var book in library.Books) AnsiConsole.MarkupLine($"- [cyan]{book.Title}[/]");

                    AnsiConsole.MarkupLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "Add book":
                case "Delete book":
                    break;
            }
        }
    }
}