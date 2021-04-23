using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList1.Models;

namespace TodoList1.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ToDoItem> LstRecentlyCompletedItems { get; set; }
        public IEnumerable<ToDoItem> LstDueItems { get; set; }

        public IEnumerable<ToDoItem> LstAllDueItems { get; set; }
    }
}
