using AjaxHomework.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxHomework.Controllers
{

    public class APIController : Controller
    {
        private readonly MyDBContext _dbContext;

        public APIController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckAccount(string name)
        {
            Member member = _dbContext.Members.FirstOrDefault(a => a.Name == name);
            if (member == null) return Json(false);
            return Json(true);
        }
    }
}
