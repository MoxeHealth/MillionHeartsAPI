using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MightyHeartsAPI;

namespace MightyHeartsTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "MightyHeartsTester";;
            var archpost = new ArchimedesPostHelper("40", "M", "70", "180", "F", "T", "T", "F", "120", "80", "100", "50", "50", "100", "8.0", "F", "F", "2", "F", "1", "1", "F");
            var makepost = new MightyHeartsAPI.MightyHeartsAPI();
            var post = makepost.sendArchimedesDataFull(archpost);
            ViewBag.post = post;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
