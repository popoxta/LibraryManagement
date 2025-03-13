using System.Diagnostics.CodeAnalysis;

namespace LibraryManagement;

// method: tells the compiler to apply the attribute to the constructor method
[method: SetsRequiredMembers]
public class Library(HashSet<Book> books)
{
    public required HashSet<Book> Books { get; init; } = books;

    public HashSet<string> GetAllBookTitles() => Books.Select(b => b.Title).ToHashSet();

    public bool AddBook(Book book) => Books.Add(book);

    public bool RemoveBook(string title) => Books.RemoveWhere(book => book.Title == title) > 0;
}