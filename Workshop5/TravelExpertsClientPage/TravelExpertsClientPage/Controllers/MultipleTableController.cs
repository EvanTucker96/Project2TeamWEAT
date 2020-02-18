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
            List<Customer> customers = db.Customers.ToList();
            List<Booking> bookings = db.Bookings.ToList();
            List<Package> packages = db.Packages.ToList();
            List<Products_Suppliers> products_Suppliers = db.Products_Suppliers.ToList();
            List<Product> products = db.Products.ToList();
            List<BookingDetail> bookingDetails = db.BookingDetails.ToList();
            List<Fee> fees = db.Fees.ToList();

            var clientDetails = from b in bookings
                                join c in customers on b.CustomerId equals c.CustomerId into table1
                                from c in table1.DefaultIfEmpty()
                                join bd in bookingDetails on b.BookingId equals bd.BookingId into table2
                                from bd in table2.DefaultIfEmpty()
                                join p in packages on b.PackageId equals p.PackageId into table3
                                from p in table3.DefaultIfEmpty()
                                join f in fees on bd.FeeId equals f.FeeId into table4
                                from f in table4.DefaultIfEmpty()
                                select new MultipleTableClass
                                {
                                    bookingD = b,
                                    customerDetails = c,
                                    bookingDetails = bd,
                                    packageDetails = p,
                                    feeDetails = f
                                };

            //var index=    from p in packages
            //                  join prod in products_Suppliers on p.PackageId equals prod.ProductId into table1
            //                  from prod in table1.DefaultIfEmpty()
            //                  join bd in bookingDetails on prod.ProductSupplierId equals bd.ProductSupplierId into table2
            //                  from bd in table2.DefaultIfEmpty()
            //                  join f in fees on bd?.FeeId equals f.FeeId into table3
            //                  from f in table3.DefaultIfEmpty()
            //                  select new MultipleTableClass { packageDetails = p, bookingDetails=bd, prod_supDetails = prod, feeDetails = f};

            return View(clientDetails);
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