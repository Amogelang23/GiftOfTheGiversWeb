using Microsoft.AspNetCore.Mvc;
using GiftOfTheGiversWeb.Models;
using System.Collections.Generic;

namespace GiftOfTheGiversWeb.Controllers
{
    public class DonationController : Controller
    {
        private static List<Donation> _donations = new List<Donation>();

        public IActionResult Index()
        {
            return View(_donations);
        }

        [HttpPost]
        public IActionResult Index(Donation donation)
        {
            if (ModelState.IsValid)
            {
                _donations.Add(donation);
                TempData["SuccessMessage"] = "Donation received. Thank you!";
                return RedirectToAction("Index");
            }
            return View(_donations);
        }
    }
}