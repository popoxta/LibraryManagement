using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

public class LibraryController(HashSet<LibraryItem> libraryItems)
{
    public HashSet<LibraryItem> LibraryItems { get; } = libraryItems;

    public HashSet<string> GetAllTitles() => LibraryItems.Select(b => b.Title).ToHashSet();

    public HashSet<string> GetAllTitles<TLibraryItem>() where TLibraryItem : LibraryItem =>
        LibraryItems.OfType<TLibraryItem>().Select(b => b.Title).ToHashSet();

    public bool AddItem(LibraryItem item) => LibraryItems.Add(item);

    public bool RemoveItem<TLibraryItem>(string title) where TLibraryItem : LibraryItem =>
        LibraryItems.RemoveWhere(item => item is TLibraryItem && item.Title == title) > 0;
}