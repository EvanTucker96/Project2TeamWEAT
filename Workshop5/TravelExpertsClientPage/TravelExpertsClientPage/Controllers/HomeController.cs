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
            List<Agency> agencies = new TravelExpertsEntities1().Agencies.ToList();
 
            //pass it to the contact page
            return View(agencies);
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Customer registration page.";

            return View();
        }


        /// <summary>
        /// For Registering a new user
        /// Author: WG
        /// </summary>
        /// <param name="cust">Passes in a Customer object from the form post</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            // setup a DataAccess object
            TravelExpertsEntities1 db = new TravelExpertsEntities1();
            if (cust != null) // make sure the passed info exists
            {
                // Checks DB for existing record that matches First and Last names and Email address
                int found = Convert.ToInt32((from c in db.Customers
                             where c.CustEmail == cust.CustEmail
                             && c.CustFirstName==cust.CustFirstName
                             && c.CustLastName==cust.CustLastName
                             select c.CustomerId).SingleOrDefault());
                if (found == 0) // if no records found
                {
                    //Encrypt the password using BCrypt
                    cust.Password = cust.EncryptPassword(cust.Password);
                    // set ComparePassword to encrypted password so validation passes
                    // we've already verified they were the same before submit
                    cust.ComparePassword = cust.Password;
                    db.Customers.Add(cust); // add the Customer record
                    db.SaveChanges(); // comit the changes
                    TempData["Status"] = "Registration Successful"; // set the Result status
                    return RedirectToAction("Index"); // go back to 'Home'
                }
                else 
                {
                    TempData["Status"] = "User Exists"; // set the Result status
                    return View();
                    //return RedirectToAction("Regi"); // go back to 'Home'
                }
            }
            else
            {
                return View();// no data present, return to Regisrtation form
            }
        }
        [HttpGet]
        public ActionResult Login(string id)
        {
           
            //TravelExpertsEntities1 db = new TravelExpertsEntities1();
            //cust.VerifyPassword(cust.Password);
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            TravelExpertsEntities1 db = new TravelExpertsEntities1();
            bool confirmPass;
            Customer temp;
            try
            {
                temp= (from c in db.Customers
                        where c.CustEmail == cust.CustEmail
                        select c).Single();

                confirmPass= temp.VerifyPassword(cust.Password);
            }
            catch
            {
                TempData["Status"] = "No user exists";
                return View();
            }
            if (confirmPass) {
                
                Session["Authenticated"] = true;
                Session["UserName"] = cust.CustEmail;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Status"] = "Username or password is incorrect";
                return View();
            }
        }
        public ActionResult Logout()
        {
            
           
            Session["Authenticated"] = false;
            Session["UserName"] = null;
            return RedirectToAction("Index");
            
        }
    }
}