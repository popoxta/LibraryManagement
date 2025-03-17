using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

internal interface IBaseController
{
    protected LibraryController LibraryController { get; }
    void ViewItems();
    void AddItem();
    void DeleteItem();
}