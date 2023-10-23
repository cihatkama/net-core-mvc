
using EgitimSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EgitimSitesi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
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
            if(Repository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already an application for you.");
            }

            if (ModelState.IsValid)
            {
                Repository.Add(model);
                return View("Feedback", model);
            }
            return View();
            
        }

    }
}