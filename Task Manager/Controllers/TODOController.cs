using Microsoft.AspNetCore.Mvc;
using Task_Manager.ViewModels;

namespace Task_Manager.Controllers
{
    public class TODOController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
            Console.WriteLine(model.Title);
            Console.WriteLine(model.Description);
            return RedirectToAction("Index");
        }
    }
}
