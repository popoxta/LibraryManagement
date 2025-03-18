namespace LibraryManagement.Controllers;

public interface IBaseController
{
    protected LibraryController LibraryController { get; }
    void ViewItems();
    void AddItem();
    void DeleteItem();
}