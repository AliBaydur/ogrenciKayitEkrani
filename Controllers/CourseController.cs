using System.Reflection.Metadata.Ecma335;
using Egitimlerim.Models;
using Microsoft.AspNetCore.Mvc;

namespace Egitimlerim.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }

        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate model)
        {
            if (Repository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already application for you.");
            }
            
            if (ModelState.IsValid)
            {
                Repository.Add(model);
                return View("FeedBack", model);
            }
            return View();


        }
    }
}