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

    private string TitleCaseBookTitle(string title)
    {
        return _textInfo.ToTitleCase(title.Trim().ToLower());
    }
}