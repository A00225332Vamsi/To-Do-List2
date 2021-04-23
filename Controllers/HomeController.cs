using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList1.Models;
using Xamarin.Essentials;

namespace TodoList1.Controllers
{
    public class HomeController : Controller
    {
        private IToDoRepository _ToDoRepository;

        public HomeController(IToDoRepository ToDoRepository)
        {
            _ToDoRepository = ToDoRepository;

        }
        [Authorize]
        public IActionResult Index()
        {
            ViewModels.HomeViewModel homeViewModel = new ViewModels.HomeViewModel();
            homeViewModel.LstRecentlyCompletedItems = _ToDoRepository.GetRecentlyCompletedItems();
            homeViewModel.LstDueItems = _ToDoRepository.GetDueItems();
            homeViewModel.LstAllDueItems = _ToDoRepository.GetAllDueItems();
            return View(homeViewModel);
        }

        public ViewResult home1()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(ToDoItem item)
        {
            if (ModelState.IsValid)
            {
                _ToDoRepository.CreateTask(item);
               return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        public IActionResult CompleteItem(int TaskId)
        {
            _ToDoRepository.CompleteItem(TaskId);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult DeleteItem(int id)
        {
            _ToDoRepository.DeleteItem(id);
            return RedirectToAction("Index");
        }

        //public async void Copy(string title)
        //{
        //    System.Web.cliConnectivityStatus.IsOffline
        //      await  Clipboard.SetTextAsync(title);
        //}
    }
}
