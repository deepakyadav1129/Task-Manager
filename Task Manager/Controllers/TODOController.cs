using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.ViewModels;
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

        public IActionResult Edit(int id)
        {
            var listItem = _context.TodoLists.Find(id);
            if (listItem == null) return NotFound();
            var model = new CreateToDoViewModel
            {
                Id = listItem.Id,
                Title = listItem.Title,
                Description = listItem.Description
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateToDoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var todo = _context.TodoLists.FirstOrDefault(x => x.Id == model.Id);
            if (todo == null)
                return NotFound();

            todo.Title = model.Title;
            todo.Description = model.Description;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var listItem = _context.TodoLists.Find(id);
            if (listItem == null) return NotFound();
            return View(listItem);
        }

        public IActionResult Open(int id)
        {
            var todo = _context.TodoLists.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                return NotFound();
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateToDoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _context.Users.First();
            var obj = new TodoList
            {
                Title = model.Title,
                Description = model.Description,
                UserId = user.Id 
            };
             _context.TodoLists.AddAsync(obj);
             _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
