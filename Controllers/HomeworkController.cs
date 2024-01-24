using Microsoft.AspNetCore.Mvc;

namespace AjaxHomework.Controllers
{
    public class HomeworkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HW01()
        {
            return View();
        }

        public IActionResult HW02()
        {
            return View();
        }
    }
}
