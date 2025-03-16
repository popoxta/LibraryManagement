namespace LibraryManagement.Main;

public class Library(HashSet<Book> books)
{
    public HashSet<Book> Books { get; } = books;

    public HashSet<string> GetAllBookTitles() => Books.Select(b => b.Title).ToHashSet();

    public bool AddBook(Book book) => Books.Add(book);

    public bool RemoveBook(string title) => Books.RemoveWhere(book => book.Title == title) > 0;
}