using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExpertsClientPage.Models;

namespace TravelExpertsClientPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //get a list of agencies
            List<Agency> agencies = new TravelExpertsEntities().Agencies.ToList();
 
            //pass it to the contact page
            return View(agencies);
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Registration page.";

            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            ViewBag.Message = "Your Registration page.";

            return View(cust);
        }
    }
}