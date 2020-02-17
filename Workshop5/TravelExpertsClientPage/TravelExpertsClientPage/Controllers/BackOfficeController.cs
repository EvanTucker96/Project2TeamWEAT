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
            return View();
        }

        /// <summary>
        /// Get the list of packages from the database and send it to the package list view
        /// </summary>
        [HttpGet]
        public ActionResult PackageIndex()
        {
            List<Package> packages = new TravelExpertsEntities1().Packages.ToList();
            return View(packages);
        }

        /// <summary>
        /// Get a specific package from the database and send it to the package details view
        /// </summary>
        [HttpGet]
        public ActionResult PackageDetails(int id)
        {
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
            Package package = new TravelExpertsEntities1().Packages.Where(p => p.PackageId == id).SingleOrDefault();
            return View(package);
        }

        /// <summary>
        /// submit an edited package for database update
        /// </summary>
        /// <param name="id">The package ID to save to the DB</param>
        /// <param name="collection">All the field values from the form</param>
        [HttpPost]
        public ActionResult PackageEdit(int id, FormCollection collection)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    Package editedPkg = db.Packages.Where(p => p.PackageId == id).Single();

                    editedPkg.PkgAgencyCommission = Convert.ToDecimal(collection["PkgAgencyCommission"]);
                    editedPkg.PkgBasePrice = Convert.ToDecimal(collection["PkgBasePrice"]);
                    editedPkg.PkgDesc = collection["PkgDesc"];
                    editedPkg.PkgEndDate = Convert.ToDateTime(collection["PkgEndDate"]);
                    editedPkg.PkgImageFile = collection["PkgImageFile"];
                    editedPkg.PkgName = collection["PkgName"];
                    editedPkg.PkgStartDate = Convert.ToDateTime(collection["PkgStartDate"]);

                    db.SaveChanges();
                }
                return RedirectToAction("PackageIndex");
            }
            catch
            {
                return View();
            }
        }
        
        /// <summary>
        /// Go to the blank page to create a package
        /// </summary>
        [HttpGet]
        public ActionResult PackageCreate()
        {
            return View(); // just open the page
        }

        /// <summary>
        /// Receive the new package from the creation page and add to the database
        /// </summary>
        /// <param name="pkg">The new package object to add to the database</param>
        /// <param name="collection">All the field values from the form (for the product/supplier info)</param>
        [HttpPost]
        public ActionResult PackageCreate(Package pkg, FormCollection collection)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    db.Packages.Add(pkg); // add the new package to the database
                    //product supplier info goes in here
                    db.SaveChanges(); // commit
                }
                return RedirectToAction("PackageIndex"); // go back to the package listing
            }
            catch
            {
                return View();
            }
        }

        // package delete
       


        //
        // PRODUCTS METHODS
        //
                    
        /// <summary>
        /// Get the list of products from the database and send it to the product list view
        /// </summary>
        [HttpGet]
        public ActionResult ProductIndex()
        {
            List<Product> products = new TravelExpertsEntities1().Products.ToList();
            return View(products);
        }

        /// <summary>
        /// Get a specific product from the database and send it to the product details view
        /// </summary>
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
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
                    Product editedProd = db.Products.Where(p => p.ProductId == prod.ProductId).Single();

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
            List<Supplier> suppliers = new TravelExpertsEntities1().Suppliers.ToList();
            return View(suppliers);
        }

        /// <summary>
        /// Get a specific supplier from the database and send it to the supplier details view
        /// </summary>
        [HttpGet]
        public ActionResult SupplierDetails(int id)
        {
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
                    Supplier editedSupp = db.Suppliers.Where(s => s.SupplierId == id).Single(); // get a reference to the record in the DB for editing

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
            using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
            {
                TempData["Status"] = "";
                ViewBag.Products = db.Products.ToList();  // pass a list of all products to the view
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
