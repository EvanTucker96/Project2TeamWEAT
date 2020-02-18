using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExpertsClientPage.Models;

/// <summary>
/// Back office functionality: edit packages/products/suppliers online
/// Author (where not auto-generated): TH
/// </summary>

namespace TravelExpertsClientPage.Controllers
{
    public class BackOfficeController : Controller
    {
        //
        // PACKAGE METHODS
        //        

        /// <summary>
        /// Display the main menu for the back office functions (choose which type of data to edit)
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            return View();
        }

        /// <summary>
        /// Get the list of packages from the database and send it to the package list view
        /// </summary>
        [HttpGet]
        public ActionResult PackageIndex()
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            List<Package> packages = new TravelExpertsEntities1().Packages.ToList();
            return View(packages);
        }

        /// <summary>
        /// Get a specific package from the database and send it to the package details view
        /// </summary>
        [HttpGet]
        public ActionResult PackageDetails(int id)
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            Package package = new TravelExpertsEntities1().Packages.Where(p => p.PackageId == id).SingleOrDefault();
            return View(package);
        }

        /// <summary>
        /// grab the package to edit from the database and pass it to the view
        /// </summary>
        /// <param name="id">The package ID to get from the DB</param>
        [HttpGet]
        public ActionResult PackageEdit(int id)
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
            {
                Package package = db.Packages.Where(p => p.PackageId == id).SingleOrDefault();
                ViewBag.Products = db.Products.OrderBy(p => p.ProdName).ToList();  // pass a list of all products to the view

                Dictionary<string, List<Supplier>> prodSupp = new Dictionary<string, List<Supplier>>(); // somewhere to put all the suppliers for each product
                Dictionary<string, Supplier> currentProdSupp = new Dictionary<string, Supplier>(); // somewhere to put all the selected suppliers for the products it already has

                foreach (Product p in (List<Product>)ViewBag.Products) // for each product, get the list of suppliers
                {
                    List<Supplier> s = db.Suppliers.Where(supp =>
                        // suppliers where supplier ID is in the list of product_suppliers with p's product ID
                        (from ps in db.Products_Suppliers where ps.ProductId == p.ProductId select ps.SupplierId).ToList().Contains(supp.SupplierId)).ToList();
                    prodSupp.Add(p.ProdName, s); // add it to the dictionary
                }

                foreach(Products_Suppliers ps in (package.Products_Suppliers.ToList()))
                {
                    Supplier s = db.Suppliers.Where(supp => supp.SupplierId == ps.SupplierId).SingleOrDefault();
                    currentProdSupp.Add(ps.Product.ProdName, s);
                }
                ViewBag.ProdSupp = prodSupp;
                ViewBag.CurProdSupp = currentProdSupp;
                return View(package);
            }
        }

        /// <summary>
        /// submit an edited package for database update
        /// </summary>
        /// <param name="id">The package ID to save to the DB</param>
        /// <param name="collection">All the field values from the form</param>
        [HttpPost]
        public ActionResult PackageEdit(int id, FormCollection collection)
        {
            TempData["Status"] = ""; // reset any error message

            // first: make sure dates are valid
            DateTime? start = Convert.ToDateTime(collection["PkgStartDate"]); // get the dates
            DateTime? end = Convert.ToDateTime(collection["PkgEndDate"]);

            // if the start is after the end
            if (start > end)
            {
                TempData["Status"] = "Start date must come before end date";
                return RedirectToAction("PackageEdit"); // go back to the page for correction
            }

            // then update the DB
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    Package editedPkg = db.Packages.Where(p => p.PackageId == id).SingleOrDefault(); // get this record from the DB

                    // update all the fields
                    editedPkg.PkgAgencyCommission = Convert.ToDecimal(collection["PkgAgencyCommission"]);
                    editedPkg.PkgBasePrice = Convert.ToDecimal(collection["PkgBasePrice"]);
                    editedPkg.PkgDesc = collection["PkgDesc"];
                    editedPkg.PkgEndDate = Convert.ToDateTime(collection["PkgEndDate"]);
                    editedPkg.PkgImageFile = collection["PkgImageFile"];
                    editedPkg.PkgName = collection["PkgName"];
                    editedPkg.PkgStartDate = Convert.ToDateTime(collection["PkgStartDate"]);

                    List<Products_Suppliers> changes = new List<Products_Suppliers>();// somewhere to put the changes we're making below

                    // any product_supplier that's in the original package but not in the form selections, remove
                    foreach(Products_Suppliers ps in editedPkg.Products_Suppliers)
                    {
                        int suppID = Convert.ToInt32(collection[ps.Product.ProdName]); // get the drop down matching that product name in the form
                        if (!(suppID > 0)) // if a supplier wasn't selected
                        {
                            changes.Add(ps); // put on the list of things to remove
                        }
                    }

                    foreach(Products_Suppliers ps in changes)// remove them from the db reference
                    {
                        editedPkg.Products_Suppliers.Remove(ps);
                    }

                    changes.Clear(); // clear the list for the next part

                    // anything that's in the form selections but not in the original package, add 
                    foreach(Product p in db.Products.ToList())
                    {
                        int suppID = Convert.ToInt32(collection[p.ProdName]); // get the drop down matching that product name in the form
                        
                        if (suppID > 0) // if a supplier was selected
                        {
                            // get that product_supplier from the DB
                            Products_Suppliers testCase = db.Products_Suppliers.Where(ps => ps.SupplierId == suppID && ps.ProductId == p.ProductId).Single(); 
                            if (!editedPkg.Products_Suppliers.Contains(testCase)) // if it's not in the original list
                            {
                                changes.Add(testCase); // add it to the list of changes
                            }
                        }
                    }

                    foreach(Products_Suppliers ps in changes)
                    {
                        editedPkg.Products_Suppliers.Add(ps); // add it to the db reference
                    }

                    db.SaveChanges(); // commit
                }
                return RedirectToAction("PackageIndex");
            }
            catch (Exception ex) // if something went wrong, return them to this page to try again
            {
                TempData["Status"] = ex.GetType().ToString() + ": " + ex.Message;
                return View();
            }
        }
        
        /// <summary>
        /// Go to the blank page to create a package
        /// </summary>
        [HttpGet]
        public ActionResult PackageCreate()
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
            {
                ViewBag.Products = db.Products.OrderBy(p=>p.ProdName).ToList();  // pass a list of all products to the view

                Dictionary<string,List<Supplier>> prodSupp = new Dictionary<string,List<Supplier>>(); // somewhere to put all the suppliers for each product

                foreach(Product p in (List<Product>)ViewBag.Products) // for each product, get the list of suppliers
                {
                    List<Supplier> s = db.Suppliers.Where(supp =>
                        // suppliers where supplier ID is in the list of product_suppliers with p's product ID
                        (from ps in db.Products_Suppliers where ps.ProductId == p.ProductId select ps.SupplierId).ToList().Contains(supp.SupplierId)).ToList();
                    prodSupp.Add(p.ProdName,s); // add it to the dictionary
                }
                ViewBag.ProdSupp = prodSupp;
                return View(); // open the page
            }
        }

        /// <summary>
        /// Receive the new package from the creation page and add to the database
        /// </summary>
        /// <param name="pkg">The new package object to add to the database</param>
        /// <param name="collection">All the field values from the form (for the product/supplier info)</param>
        [HttpPost]
        public ActionResult PackageCreate(Package pkg, FormCollection collection)
        {
            TempData["Status"] = ""; // reset any error message
            
            // first: make sure dates are valid
            DateTime? start = Convert.ToDateTime(collection["PkgStartDate"]); // get the dates
            DateTime? end = Convert.ToDateTime(collection["PkgEndDate"]);

            // new packages must have dates after today
            if (start < DateTime.Now || end < DateTime.Now)
            {
                TempData["Status"] = "Start and end dates must be in the future";
                return RedirectToAction("PackageCreate"); // go back to the page for correction
            }

            // if the start is after the end
            if (start > end)
            {
                TempData["Status"] = "Start date must come before end date";
                return RedirectToAction("PackageCreate"); // go back to the page for correction
            }

            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    foreach(Product p in db.Products.ToList()) // for each product, see whether it was selected on the form
                    {
                        int? prodSupp = Convert.ToInt32(collection[p.ProdName]); // get the supplier selection from the dropdown
                        if (prodSupp > 0) // if it was actually selected
                        {
                            // get the database record in products_suppliers that matches this productID and supplierID and add it to the package 
                            pkg.Products_Suppliers.Add(db.Products_Suppliers.Where(ps=>ps.ProductId==p.ProductId&&ps.SupplierId==prodSupp).SingleOrDefault());
                        }
                    }                       

                    db.Packages.Add(pkg); // add the new package to the database
                    db.SaveChanges(); // commit
                }
                return RedirectToAction("PackageIndex"); // go back to the package listing
            }
            catch
            {
                return View();
            }
        }

        //
        // PRODUCTS METHODS
        //
                    
        /// <summary>
        /// Get the list of products from the database and send it to the product list view
        /// </summary>
        [HttpGet]
        public ActionResult ProductIndex()
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            List<Product> products = new TravelExpertsEntities1().Products.ToList();
            return View(products);
        }

        /// <summary>
        /// Get a specific product from the database and send it to the product details view
        /// </summary>
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            Product product = new TravelExpertsEntities1().Products.Where(p => p.ProductId == id).SingleOrDefault();
            return View(product);
        }

        /// <summary>
        /// grab the product to edit from the database and pass it to the view
        /// </summary>
        /// <param name="id">The product ID to get from the DB</param>
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            Product product = new TravelExpertsEntities1().Products.Where(p => p.ProductId == id).SingleOrDefault();
            return View(product);
        }

        /// <summary>
        /// submit an edited product for database update
        /// </summary>
        /// <param name="prod">The product object from the page with edits to send to the DB</param>
        [HttpPost]
        public ActionResult ProductEdit(Product prod)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    Product editedProd = db.Products.Where(p => p.ProductId == prod.ProductId).SingleOrDefault();

                    editedProd.ProdName = prod.ProdName;

                    db.SaveChanges();
                }
                return RedirectToAction("ProductIndex");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Go to the blank page to create a product
        /// </summary>
        [HttpGet]
        public ActionResult ProductCreate()
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            return View(); // just open the page
        }

        /// <summary>
        /// Receive the new product from the creation page and add to the database
        /// </summary>
        /// <param name="prod">The new product object to add to the database</param>
        [HttpPost]
        public ActionResult ProductCreate(Product prod)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    db.Products.Add(prod); // add the new product to the database
                    db.SaveChanges(); // commit
                }
                return RedirectToAction("ProductIndex"); // go back to the product listing
            }
            catch
            {
                return View();
            }
        }


        //
        // SUPPLIER METHODS
        //
        
        /// <summary>
        /// Get the list of suppliers from the database and send it to the supplier list view
        /// </summary>
        [HttpGet]
        public ActionResult SupplierIndex()
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            List<Supplier> suppliers = new TravelExpertsEntities1().Suppliers.ToList();
            return View(suppliers);
        }

        /// <summary>
        /// Get a specific supplier from the database and send it to the supplier details view
        /// </summary>
        [HttpGet]
        public ActionResult SupplierDetails(int id)
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            Supplier supplier = new TravelExpertsEntities1().Suppliers.Where(s => s.SupplierId == id).SingleOrDefault();
            return View(supplier);
        }

        /// <summary>
        /// grab the supplier to edit from the database and pass it to the view
        /// </summary>
        /// <param name="id">The supplier ID to get from the DB</param>
        [HttpGet]
        public ActionResult SupplierEdit(int id)
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
            {
                Supplier supplier = db.Suppliers.Where(s => s.SupplierId == id).SingleOrDefault(); // get this supplier
                int?[] offerings = (from ps in db.Products_Suppliers where ps.SupplierId == id select ps.ProductId).ToArray();
                ViewBag.Products = db.Products.ToList();  // pass a list of all products to the view
                ViewBag.Offerings = (from prods in db.Products where offerings.Contains(prods.ProductId) select prods).ToList(); // pass a list of products they already have

                return View(supplier); // display the page
            }
                
        }

        /// <summary>
        /// submit an edited supplier for database update
        /// </summary>
        /// <param name="id">The supplier ID to save to the DB</param>
        /// <param name="collection">All the field values from the form</param>
        [HttpPost]
        public ActionResult SupplierEdit(int id, FormCollection collection)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    Supplier editedSupp = db.Suppliers.Where(s => s.SupplierId == id).SingleOrDefault(); // get a reference to the record in the DB for editing

                    editedSupp.SupName = collection["SupName"]; // update the supplier name

                    // get a list of their current products
                    List<Products_Suppliers> current = db.Products_Suppliers.Where(ps => ps.SupplierId == id).ToList();

                    // get the list of the products that were selected
                    List<Products_Suppliers> selected = new List<Products_Suppliers>(); // create a placeholder list
                    foreach(Product p in db.Products.ToList()) // go through each possible product
                    {
                        if (Convert.ToInt32(collection[p.ProdName]) == p.ProductId) // look for whether it was selected in the form
                        {
                            Products_Suppliers ps = new Products_Suppliers(); // if so, make a new products_supplier
                            ps.ProductId = p.ProductId;  // populate it with product ID
                            ps.SupplierId = id;          // and supplier ID
                            selected.Add(ps);           // add it to the list
                        }
                    }

                    // for each current product
                    foreach(Products_Suppliers ps in current)
                    {
                        // if it's not in the new list
                        if (!selected.Contains(ps))
                        {
                            // delete it from the DB
                            db.Products_Suppliers.Remove(ps);
                        }
                    }

                    // for each selected product
                    foreach (Products_Suppliers ps in selected)
                    {
                        // if it's not in the old list
                        if (!current.Contains(ps))
                        {
                            // add it
                            db.Products_Suppliers.Add(ps);
                        }

                    }
                    db.SaveChanges(); // commit
                }
                return RedirectToAction("SupplierIndex"); // go back to index
            }
            catch // if there's any problem, go back to the form so they can try again
            {
                return View();
            }
        }
        
        /// <summary>
        /// Go to the blank page to create a supplier
        /// </summary>
        [HttpGet]
        public ActionResult SupplierCreate()
        {
            ViewBag.BackOffice = true; // tell the view to use the backoffice navbar
            using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
            {
                TempData["Status"] = "";
                ViewBag.Products = db.Products.ToList();  // pass a list of all products to the view
                ViewBag.NextId = (from suppliers in db.Suppliers select suppliers.SupplierId).Max()+1;
                return View(); // open the page
            }
        }

        /// <summary>
        /// Receive the new supplier from the creation page and add to the database
        /// </summary>
        /// <param name="supp">The new supplier object to add to the database</param>
        /// <param name="collection">All the field values from the form (for the product/supplier info)</param>
        [HttpPost]
        public ActionResult SupplierCreate(Supplier supp, FormCollection collection)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    db.Suppliers.Add(supp); // add the new supplier to the database
                    List<Products_Suppliers> prodlist = new List<Products_Suppliers>(); // a list to hold their product offerings

                    foreach(Product prod in db.Products.ToList()) // for each potential product that could exist
                    {
                        if (Convert.ToInt32(collection[prod.ProdName]) == prod.ProductId) // see if its box was checked in the form
                        {
                            Products_Suppliers offering = new Products_Suppliers(); // make a new object to hold the offering details
                            offering.SupplierId = supp.SupplierId;
                            offering.ProductId = prod.ProductId;
                            db.Products_Suppliers.Add(offering); // add it to the database
                        }
                    }                    

                    db.SaveChanges(); // commit
                }
                TempData["Status"] = "";
                return RedirectToAction("SupplierIndex"); // go back to the supplier listing
            }
            catch (Exception ex)
            {   // this isn't being caught as an "SqlException" for some reason, so have to resort to this
                if (ex.GetBaseException().GetType().ToString() == "System.Data.SqlClient.SqlException") // if they tried to use a duplicate primary key
                {
                    TempData["Status"] = "That supplier ID is already in use. Please choose another number.";
                }
                else // otherwise...
                {
                    TempData["Status"] = ex.GetBaseException().GetType().ToString() + ": " + ex.GetBaseException().Message;
                }
                return View(); // go back to the creation page for them to try again
            }
        }
    }
}
