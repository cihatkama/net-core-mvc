
using EgitimSitesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimSitesi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Default olarak [HttpGet] çalışır.
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]  // İşlemin yapıldığı tarayıcı dışından isteklere karşı güvenlik alır.
        // [ValidateAntiForgeryToken] .NET7.0 da Http 400 hatasına sebep oldu.
        public IActionResult Apply([FromForm] Candidate model)
        {
            Repository.Add(model);
            return View("Feedback", model); ;
        }

    }
}