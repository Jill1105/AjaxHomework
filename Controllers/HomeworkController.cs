using AjaxHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult HW03()
        {
            return View();
        }
        public IActionResult HW04()
        {
            return View();
        }
    }
}
