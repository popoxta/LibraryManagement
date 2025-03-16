namespace LibraryManagement.Models;

internal abstract class LibraryItem(int id, string name, string location)
{
    public required int Id { get; init; } = id;
    public required string Name { get; init; } = name;
    public required string Location { get; init; } = location;

    public abstract void DisplayDetails();
}