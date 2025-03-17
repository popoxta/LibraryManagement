using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

internal interface IBaseController
{
    protected Library Library { get; }
    void ViewItems();
    void AddItem();
    void DeleteItem();
}