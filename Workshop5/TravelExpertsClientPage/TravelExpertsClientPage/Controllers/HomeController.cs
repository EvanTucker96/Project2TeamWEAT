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
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Registration page.";

            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            TravelExpertsEntities1 db = new TravelExpertsEntities1();
            if (cust != null)
            {
                List<Customer> customers = db.Customers.ToList();
                int found = Convert.ToInt32((from c in customers
                             where c.CustEmail == cust.CustEmail
                             select c.CustomerId).SingleOrDefault());
                if (found == 0)
                {
                    db.Customers.Add(cust);
                    db.SaveChanges();
                    ViewBag.Status = "Registration Successful";
                    return RedirectToAction("Index");
                }
                else 
                {
                    ViewBag.Status = "User Exists";
                    return RedirectToAction("Index");
                }


            }
            else
            {
                return View();
            }
        }
    }
}