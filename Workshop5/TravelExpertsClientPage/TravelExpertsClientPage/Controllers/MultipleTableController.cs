using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelExpertsClientPage.Models;
using System.Drawing.Imaging;

namespace TravelExpertsClientPage.Controllers
{
    public class MultipleTableController : Controller
    {
        TravelExpertsEntities1 db = new TravelExpertsEntities1();

        // GET: MultipleTable
        public ActionResult Index(int? custID = 105)
        {
            return View();
        }

        public ActionResult MultipleOrdersView(int? id = 1, string feeID = "BK")  // TODO: REMOVE THIS DEFAULT =1 When Your Passing Parameters OK
        {
            // check id parameter is non-null and if so error out of page rendering
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // fetch the package associated to the provided id, on failure return not found error
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }

            // fetch the fees table and return the booking fee amount
            Fee fee = db.Fees.Find(feeID);
            if (fee == null)
            {
                return HttpNotFound();
            }
            // build a new multiple table class instance to return as model to view
            MultipleTableClass model = new MultipleTableClass();
            model.packageDetails = package;

            // todo : fetchproducts, suppliers and fees now and construct mtc model fully

            return View(model);
        }

        [HttpPost]
        public ActionResult PostData(FormCollection fc)
        {
            var packageID = fc[0];
            var passengerNames = Array.FindAll<string>(fc.AllKeys, s => s.StartsWith("FullName_"));



            return View("InvoiceView");
        }

    }
}