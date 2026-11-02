using Microsoft.AspNetCore.Mvc;
using GiftOfTheGiversWeb.Models;
using System.Collections.Generic;

namespace GiftOfTheGiversWeb.Controllers
{
    public class VolunteerController : Controller
    {
        private static List<Volunteer> _volunteers = new List<Volunteer>();

        public IActionResult Index()
        {
            return View(_volunteers);
        }

        [HttpPost]
        public IActionResult Index(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _volunteers.Add(volunteer);
                TempData["SuccessMessage"] = "Thank you for registering to volunteer!";
                return RedirectToAction("Index");
            }
            return View(_volunteers);
        }
    }
}