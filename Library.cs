namespace LibraryManagement;

public class Library
{
    public required HashSet<Book> Books { get; init; }

    public HashSet<string> GetAllBookTitles() => Books.Select(b => b.Title).ToHashSet();

    public bool AddBook(Book book) => Books.Add(book);

    public bool RemoveBook(string title) => Books.RemoveWhere(book => book.Title == title) > 0;
}