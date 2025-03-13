namespace LibraryManagement;

public class Library
{
    public required HashSet<Book> Books { get; init; }

    public bool AddBook(Book book) => Books.Add(book);
}