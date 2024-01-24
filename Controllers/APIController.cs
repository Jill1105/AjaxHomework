using AjaxHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            var account = _dbContext.Members.Where(x => x.Name == name).Any();
            return Content($"{account}");
        }
    }
}
