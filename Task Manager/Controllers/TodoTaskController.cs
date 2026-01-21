using Microsoft.AspNetCore.Mvc;

namespace Task_Manager.Controllers
{
    public class TodoTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
