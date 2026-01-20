using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Manager.ViewModels;
using TaskManager.Data;
using TaskManager.Models;

namespace Task_Manager.Controllers
{
    public class TODOController : Controller
    {
        private readonly TaskManagerDBContext _context;
        public TODOController(TaskManagerDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var todoList = _context.TodoLists.ToList();
            Console.WriteLine("todoList : ", todoList);
            return View(todoList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateToDoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var obj = new TodoList
            {
                Title = model.Title,
                Description = model.Description,
                UserId = 1 // for time being until registraion flow in not created 
            };
             _context.TodoLists.AddAsync(obj);
             _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
