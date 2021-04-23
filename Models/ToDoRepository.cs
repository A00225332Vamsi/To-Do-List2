using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList1.Models
{
    public class ToDoRepository : IToDoRepository
    {
        public AppDbContext Context { get; }

        public ToDoRepository(AppDbContext context)
        {
            this.Context = context;
        }
        public List<ToDoItem> GetDueItems()
        {
            //fetching due Tasks(next 24 hours)
            DateTime now = DateTime.Now;
            //return Context.ToDoItems.Where(item => item.Done == false && item.DueDate > now.AddHours(24) && item.DueDate >= now).ToList<ToDoItem>();
            return Context.ToDoItems.Where(item => item.Done == false && item.DueDate <= now.AddHours(24)).ToList<ToDoItem>();
        }

        public List<ToDoItem> GetRecentlyCompletedItems()
        {
           //fetching recently completed Tasks(Last 24 hours)
            DateTime now = DateTime.Now;
            return Context.ToDoItems.Where(item => item.Done == true && item.DoneDate >now.AddHours(-24) && item.DoneDate<=now).ToList<ToDoItem>();
        }
        public void CompleteItem(int TaskId)
        {
            ToDoItem task = Context.ToDoItems.Find(TaskId);
            if(task!=null)
            {
                task.Done = true;
                task.DoneDate = DateTime.Now;
            }
            var item = Context.ToDoItems.Attach(task);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public void CreateTask(ToDoItem task)
        {
            task.Done = false;
            task.AddedDate = DateTime.Now;
            Context.ToDoItems.Add(task);
            Context.SaveChanges();
        }

        public void DeleteItem(int TaskId)
        {
            ToDoItem task = Context.ToDoItems.Find(TaskId);
            if (task != null)
            {
                Context.ToDoItems.Remove(task);
                Context.SaveChanges();
            }
        }
        public List<ToDoItem> GetAllDueItems()
        {
           return Context.ToDoItems.Where(item => item.Done == false).ToList<ToDoItem>();
        }
    }
}
