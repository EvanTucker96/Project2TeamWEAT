using System;
using System.Collections.Generic;
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
        /// <param name="pkg">The package object from the page with edits to send to the DB</param>
        [HttpPost]
        public ActionResult PackageEdit(Package pkg)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    Package editedPkg = db.Packages.Where(p => p.PackageId == pkg.PackageId).Single();

                    editedPkg.PkgAgencyCommission = pkg.PkgAgencyCommission;
                    editedPkg.PkgBasePrice = pkg.PkgBasePrice;
                    editedPkg.PkgDesc = pkg.PkgDesc;
                    editedPkg.PkgEndDate = pkg.PkgEndDate;
                    editedPkg.PkgImageFile = pkg.PkgImageFile;
                    editedPkg.PkgName = pkg.PkgName;
                    editedPkg.PkgStartDate = pkg.PkgStartDate;

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
        [HttpPost]
        public ActionResult PackageCreate(Package pkg)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
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
            Supplier supplier = new TravelExpertsEntities1().Suppliers.Where(s => s.SupplierId == id).SingleOrDefault();
            return View(supplier);
        }

        /// <summary>
        /// submit an edited supplier for database update
        /// </summary>
        /// <param name="supp">The supplier object from the page with edits to send to the DB</param>
        [HttpPost]
        public ActionResult SupplierEdit(Supplier supp)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    Supplier editedSupp = db.Suppliers.Where(s => s.SupplierId == supp.SupplierId).Single();

                    editedSupp.SupName = supp.SupName;

                    db.SaveChanges();
                }
                return RedirectToAction("SupplierIndex");
            }
            catch
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
            TempData["Status"] = "";
            return View(); // just open the page
        }

        /// <summary>
        /// Receive the new supplier from the creation page and add to the database
        /// </summary>
        /// <param name="supp">The new supplier object to add to the database</param>
        [HttpPost]
        public ActionResult SupplierCreate(Supplier supp)
        {
            try
            {
                using (TravelExpertsEntities1 db = new TravelExpertsEntities1())
                {
                    db.Suppliers.Add(supp); // add the new supplier to the database
                    db.SaveChanges(); // commit
                }
                TempData["Status"] = "";
                return RedirectToAction("SupplierIndex"); // go back to the supplier listing
            }
            catch (Exception ex)
            {
                TempData["Status"] = ex.GetBaseException().Message;
                return View();
            }
        }
    }
}
