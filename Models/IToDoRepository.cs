using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList1.Models
{
    public interface IToDoRepository
    {
        //get recent completed Items(Last 24 Hours) 
        List<ToDoItem> GetRecentlyCompletedItems();

        //get recent Due Items(next 24 Hours) 
        List<ToDoItem> GetDueItems();

        List<ToDoItem> GetAllDueItems();

        void CompleteItem(int TaskId);

        void DeleteItem(int TaskId);
        void CreateTask(ToDoItem item);

    }
}
