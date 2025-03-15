namespace LibraryManagement;

internal static class MockDatabase
{
    internal static readonly BookInfo[] StarterBooks =
    [
        new("The Great Gatsby", 1234), new("To Kill a Mockingbird", 495), new("1984", 999),
        new("Pride and Prejudice", 697), new("The Catcher in the Rye", 599), new("The Hobbit", 765),
        new("Moby-Dick", 766), new("War and Peace", 394), new("The Odyssey", 300), new("The Lord of the Rings", 239),
        new("Jane Eyre", 233), new("Animal Farm", 1238), new("Brave New World", 991),
        new("The Chronicles of Narnia", 88), new("The Diary of a Young Girl", 828), new("The Alchemist", 987),
        new("Wuthering Heights", 231), new("Fahrenheit 451", 672), new("Catch-22", 231),
        new("The Hitchhiker's Guide to the Galaxy", 390)
    ];
}

internal record BookInfo(string Title, int Pages);