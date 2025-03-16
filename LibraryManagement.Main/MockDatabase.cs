using LibraryManagement.Models;

namespace LibraryManagement.Main;

internal static class MockDatabase
{
    internal static readonly List<LibraryItem> StarterBooks =
    [
        new Book
        {
            Title = "The Great Gatsby",
            Pages = 218,
            Author = "F. Scott Fitzgerald",
            Category = "Fiction",
            Location = "A1",
        },
        new Book
        {
            Title = "Brave New World",
            Pages = 311,
            Author = "Aldous Huxley",
            Category = "Science Fiction",
            Location = "E5",
        },
        new Book
        {
            Title = "The Catcher in the Rye",
            Pages = 277,
            Author = "J.D. Salinger",
            Category = "Classic",
            Location = "F2",
        },
        new Book
        {
            Title = "Sapiens: A Brief History of Humankind",
            Pages = 443,
            Author = "Yuval Noah Harari",
            Category = "Non-Fiction",
            Location = "G1",
        },
        new Book
        {
            Title = "The Night Circus",
            Pages = 387,
            Author = "Erin Morgenstern",
            Category = "Fantasy",
            Location = "H3",
        },
        new Magazine
        {
            Title = "National Geographic",
            Pages = 120,
            Publisher = "National Geographic Society",
            PublishDate = new DateTime(2024, 3, 1),
            IssueNumber = 315,
            Location = "M1",
        },
        new Magazine
        {
            Title = "TIME",
            Pages = 98,
            Publisher = "Time USA, LLC",
            PublishDate = new DateTime(2024, 2, 15),
            IssueNumber = 2024,
            Location = "M2",
        },
        new Magazine
        {
            Title = "Forbes",
            Pages = 110,
            Publisher = "Forbes Media",
            PublishDate = new DateTime(2024, 1, 20),
            IssueNumber = 45,
            Location = "M3",
        },
        new Magazine
        {
            Title = "Scientific American",
            Pages = 95,
            Publisher = "Springer Nature",
            PublishDate = new DateTime(2024, 3, 10),
            IssueNumber = 328,
            Location = "M4",
        },
        new Magazine
        {
            Title = "The New Yorker",
            Pages = 80,
            Publisher = "Condé Nast",
            PublishDate = new DateTime(2024, 2, 5),
            IssueNumber = 9,
            Location = "M5",
        },
        new Newspaper
        {
            Title = "The New York Times",
            Pages = 48,
            Publisher = "The New York Times Company",
            PublishDate = new DateTime(2024, 3, 16),
            Location = "N1",
        },
        new Newspaper
        {
            Title = "The Guardian",
            Pages = 40,
            Publisher = "Guardian Media Group",
            PublishDate = new DateTime(2024, 3, 15),
            Location = "N2",
        },
        new Newspaper
        {
            Title = "The Wall Street Journal",
            Pages = 52,
            Publisher = "Dow Jones & Company",
            PublishDate = new DateTime(2024, 3, 14),
            Location = "N3",
        },
        new Newspaper
        {
            Title = "The Washington Post",
            Pages = 46,
            Publisher = "Nash Holdings",
            PublishDate = new DateTime(2024, 3, 13),
            Location = "N4",
        },
        new Newspaper
        {
            Title = "The Times",
            Pages = 44,
            Publisher = "News UK",
            PublishDate = new DateTime(2024, 3, 12),
            Location = "N5",
        }
    ];
}