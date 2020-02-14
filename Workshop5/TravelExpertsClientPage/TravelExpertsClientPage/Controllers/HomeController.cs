using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        /// <summary>
        /// Go to the contact page, passing in the agency and agent info from the DB
        /// Author: TH
        /// </summary>
        public ActionResult Contact()
        {
            //get a list of agencies
            List<Agency> agencies = new TravelExpertsEntities1().Agencies.ToList();

            //pass it to the contact page
            return View(agencies);
        }

        /// <summary>
        /// Go to the register page:
        /// If logged in, pass the current customer object
        /// If not, pass null
        /// (The view will then display as either a new registration or an account edit)
        /// Author: TH
        /// </summary>
        public ActionResult Register()
        {

            Customer cust = null;

            ViewBag.Message = "Customer registration page.";
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"]) // if a customer is logged in
            {
                // get the username which is logged in
                string username = (string)Session["Username"];
                // get the customer from the DB that has the same email as the logged in customer
                cust = new TravelExpertsEntities1().Customers.Where(c => c.CustEmail == username).Single();
            }

            return View(cust);
        }

        public ActionResult Packages()
        {
            ViewBag.Message = "View and order Packages";

            return RedirectToAction("Index", "PackagesController");
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
                                             select c.CustomerId).SingleOrDefault());

                if (found == 0 || cust.CustEmail == (string)Session["UserName"]) // if there is no conflict with existing email
                {
                    // if block Author: TH (for Task 2)
                    // if the account is already logged in, then this is an edit not a create
                    if (Session["Authenticated"] != null && (bool)Session["Authenticated"]) // if already logged in
                    {
                        // get the username
                        string username = (string)Session["UserName"];

                        // get the record with the old username
                        Customer custRecord = (from c in db.Customers
                                                               where c.CustEmail == username
                                                               select c).SingleOrDefault();

                        //update each field
                        custRecord.Password = cust.EncryptPassword(cust.Password);
                        custRecord.ComparePassword = custRecord.Password;
                        custRecord.CustAddress = cust.CustAddress;
                        custRecord.CustBusPhone = cust.CustBusPhone;
                        custRecord.CustCity = cust.CustCity;
                        custRecord.CustCountry = cust.CustCountry;
                        custRecord.CustEmail = cust.CustEmail;
                        custRecord.CustFirstName = cust.CustFirstName;
                        custRecord.CustHomePhone = cust.CustHomePhone;
                        custRecord.CustLastName = cust.CustLastName;
                        custRecord.CustPostal = cust.CustPostal;
                        custRecord.CustProv = cust.CustProv;

                        // commit
                        db.SaveChanges();

                        Session["UserName"] = cust.CustEmail; // in case they updated their email
                        TempData["Status"] = "User Account Successfully Edited"; // set the Result status
                        return View(); // we're done here
                    }
                    else // this is a new user
                    {

                        //Encrypt the password using BCrypt
                        cust.Password = cust.EncryptPassword(cust.Password);
                        // set ComparePassword to encrypted password so validation passes
                        // we've already verified they were the same before submit
                        cust.ComparePassword = cust.Password;
                        db.Customers.Add(cust); // add the Customer record
                        db.SaveChanges(); // comit the changes
                        TempData["Status"] = "Registration Successful"; // set the Result status
                        Session["Authenticated"] = true;
                        Session["UserName"] = cust.CustEmail;
                        return RedirectToAction("Index"); // go back to 'Home'
                    }
                }
                else // email already in use

                {
                    TempData["Status"] = "User Exists"; // set the Result status
                    return View();
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

                //                confirmPass= temp.VerifyPassword(cust.Password);
                return null;
            }
            catch
            {
                TempData["Status"] = "No user exists";
                return View();
            }
            /*
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
            */
        }
        public ActionResult Logout()
        {
            Session["Authenticated"] = false;
            Session["UserName"] = null;
            return RedirectToAction("Index");

        }
    }
}
