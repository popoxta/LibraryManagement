namespace LibraryManagement.Main;

internal static class Program
{
    private static readonly Library Library = new(books:
    [
        ..MockDatabase.StarterBooks.Select(book => new Book
        {
            Title = book.Title,
            Pages = book.Pages
        })
    ]);

    private static readonly BooksController BooksController = new(library: Library);

    private static readonly UserInterface UserInterface = new(booksController: BooksController);


    private static void Main(string[] args) => UserInterface.MainMenu();
}