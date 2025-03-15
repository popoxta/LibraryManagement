using System.Globalization;

namespace LibraryManagement;

public class Book
{
    private readonly TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;
    private readonly string _title = "";

    public required string Title
    {
        init => _title = TitleCaseBookTitle(value);
        get => _title;
    }

    public required int Pages { get; set; }

    private string TitleCaseBookTitle(string title) => _textInfo.ToTitleCase(title.Trim().ToLower());

    public override bool Equals(object? other) => other is Book book && _title == book._title;

    public override int GetHashCode() => _title.GetHashCode();
}