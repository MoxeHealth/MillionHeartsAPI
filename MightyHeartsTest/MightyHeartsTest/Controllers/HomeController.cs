using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MillionHeartsAPI;

namespace MightyHeartsTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "MightyHeartsTester";;
            var archpost = new ArchimedesPostHelper("40", "M", "70", "180", "F", "T", "T", "F", "120", "80", "100", "50", "50", "100", "8.0", "F", "F", "2", "F", "1", "1", "F");
            var makepost = new MillionHeartsAPI.MillionHeartsAPI();
            var post = makepost.sendArchimedesDataFull(archpost);
            var pharm = makepost.closestSurescriptsPharmacy("3a0a572b-4f5d-47a2-9a75-819888576454", (float)44.979965, (float)-93.263836, 2);
            ViewBag.pharm = pharm;
            ViewBag.post = post;
        
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
