using AjaxHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AjaxHomework.Controllers
{

    public class APIController : Controller
    {
        private readonly MyDBContext _dbContext;
        private readonly IWebHostEnvironment _host;

        public APIController(MyDBContext dbContext, IWebHostEnvironment host)
        {
            _dbContext = dbContext;
            _host = host;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(Member member, IFormFile Avatar)
        {

            string fileName = "empty.jpg";
            if (Avatar != null)
            {
                fileName = Avatar.FileName;
            }

            string uploadPath = Path.Combine(_host.WebRootPath, "uploads", fileName);

            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
            {
                Avatar.CopyTo(fileStream);
            }

            //轉成二進位, 將檔案存入資料庫
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                Avatar?.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }

            member.FileData = imgByte;
            member.FileName = fileName;

            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();

            return Content("OK");
        }
        public IActionResult CheckAccount(string name)
        {
            var account = _dbContext.Members.Where(x => x.Name == name).Any();
            return Content($"{account}");
        }
    }
}
