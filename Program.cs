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

    private static readonly Library Library = new(books:
    [
        ..StarterBooks.Select(title => new Book
        {
            Title = title,
        })
    ]);

    private static readonly BooksController BooksController = new(library: Library);

    private static readonly UserInterface UserInterface = new(booksController: BooksController);

    private static void Main(string[] args) => UserInterface.MainMenu();
}