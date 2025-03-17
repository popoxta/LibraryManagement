using System.Globalization;

namespace LibraryManagement.Models;

public abstract class LibraryItem
{
    private readonly TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

    public Guid Id { get; } = Guid.NewGuid();
    public required string Location { get; init; }
    public required int Pages { get; init; }

    private readonly string _title = "";

    public required string Title
    {
        init => _title = TitleCaseTitle(value);
        get => _title;
    }

    public abstract void DisplayDetails();

    private string TitleCaseTitle(string title) => _textInfo.ToTitleCase(title.Trim().ToLower());

    public override bool Equals(object? other) =>
        other is LibraryItem item && other.GetType() == GetType() && Title == item.Title;

    public override int GetHashCode() => GetType().GetHashCode() ^ Title.GetHashCode();
}