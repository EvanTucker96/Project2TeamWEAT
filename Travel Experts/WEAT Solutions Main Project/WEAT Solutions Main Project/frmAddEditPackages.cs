using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Add/Edit Packages
/// Author Wade Grimm (WG)
/// </summary>
namespace WEAT_Solutions_Main_Project
{
    public partial class frmAddEditPackages : Form
    {
        // create global lists, objects and boolean variable for use throughout the form
        public bool isAdd; // Are we adding a new Package?
        List<Product> rmvProd = new List<Product>(); // list of items removed from an existing package
        List<Product> addProd = new List<Product>(); // list of tiems added to a package (new and existing)
        //List<Product> products = new List<Product>(); // list of all available products
        List<Product> prodAssigned = new List<Product>(); // list of products current assigned to a Package (existing)
        List<Product> prodAvailable = new List<Product>(); // list of the products (less assigned) than can be assigned to a Package
        Package currPkg; // used for setting the currently selected package info

        public frmAddEditPackages()
        {
            InitializeComponent();
        }
        // Calls the method to load the dataGridView with existing packages
        private void frmAddEditPackages_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        /// <summary>
        /// Method GetProducts populates the products list with all
        /// available products
        /// </summary>
        public List<Product> GetProducts()
        {
            // setup DataAcess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            Product tmpProd; // temporary Product object
            //products.Clear(); // clear the products list
            List<Product> products = new List<Product>();
            // get all products and dump into a var list
            var listProducts = dbContext.Products.GroupBy(item => item.ProductId,
                               (key, group) => new {
                                   ProductId = key,
                                   prodName = group.First().ProdName}).ToList();
            // convert the var list items to Product objects and assign them to products list
            for (int i = 0; i < listProducts.Count; i++)
            {
                tmpProd = new Product();
                tmpProd.ProdName = listProducts[i].prodName;
                tmpProd.ProductId = listProducts[i].ProductId;
                products.Add(tmpProd);
            }
            return products;
        }
        /// <summary>
        /// Get the currently assigned products for a package based on the supplied 'id'
        /// add them to prodAssigned list
        /// </summary>
        /// <param name="id"></param>
        public void GetAssigned(int id)
        {
            // setup DatAccess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            List<Product> tmplist = new List<Product>(); // create a temporary list
            //prodAssigned.Clear(); // clear the list
            // get all products from DB based on Package id, dump results into a var list
            var names = (from pd in dbContext.Products
                     join ps in dbContext.Products_Suppliers on pd.ProductId equals ps.ProductId
                     join pps in dbContext.Packages_Products_Suppliers on ps.ProductSupplierId equals pps.ProductSupplierId
                     join pkg in dbContext.Packages on pps.PackageId equals pkg.PackageId
                     where pkg.PackageId == id
                     select pd).Distinct();
            // convert varlist into a Product list
            tmplist = names.ToList();
            // iterate through the tmplist, set attributes of tmpProd object and assign it to the prodAssigned list
            for (int i = 0; i < tmplist.Count; i++)
            {
                Product tmpProd = new Product();
                tmpProd.ProdName = tmplist[i].ProdName;
                tmpProd.ProductId = tmplist[i].ProductId;
               prodAssigned.Add(tmpProd);
            }
        }
        
        /// <summary>
        /// Iterate through all items in products list, compare to prodAssigned
        /// if it doesn't exist in prodAssigned then add it to prodAvailable
        /// </summary>
        public void GetAvailable()
        {
            List<Product> prods = new List<Product>(); // temp list
            prodAvailable.Clear(); // reset list
            prods = GetProducts();
            //for each item in prods, if it is NOT in prodAssigned add it to prodAvail
            foreach(Product item in prods)
            {
                if (!item.IfExists(prodAssigned))
                    prodAvailable.Add(item);
            }
        }

        /// <summary>
        /// this method initializes the dataGridView, sets and formats columns
        /// and other options
        /// </summary>
        public void LoadDGV()
        {
            // setup DataAccess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            // set the data source to the Packages table
            dataGridView1.DataSource = dbContext.Packages;
            // select full row instead of a single cell
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // don't allow more than one row to be selected
            dataGridView1.MultiSelect = false;
            //do not allow inline editing 
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            //remove blank row at the bottom
            dataGridView1.AllowUserToAddRows = false;
            // set column names and display format
            dataGridView1.Columns[0].HeaderText = "Package ID";
            dataGridView1.Columns[1].HeaderText = "Package Name";
            dataGridView1.Columns[2].HeaderText = "Start Date";
            dataGridView1.Columns[3].HeaderText = "End Date";
            dataGridView1.Columns[4].HeaderText = "Description";
            dataGridView1.Columns[5].HeaderText = "Base Price";
            dataGridView1.Columns[6].HeaderText = "Agency Commission";
            // set these two columns to display currency format
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
        }

        // when an item in the dataGridView is double clicked, load the record data
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadEditRecordDetails();

        }

        /// <summary>
        /// Called from dataGridView double click event
        /// Method determines the package id of the selected item
        /// </summary>
        public void LoadEditRecordDetails()
        {
            // we are not adding a new package
            isAdd = false;
            // clear the product lists
            rmvProd.Clear();
            addProd.Clear();
            lbAvail.Items.Clear();
            lbAssigned.Items.Clear();
            prodAssigned.Clear();
            prodAvailable.Clear();
            // determine the package id of the selected dataGridView item
            int rowNum = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            int pkgNum = Convert.ToInt32(dataGridView1[0, rowNum].Value);
            Package tmpPackage; // create a temporary package object
            
            // set up DatAccess and retrieve package details for the provided pkgNum
            using (TravelExpertsDataContext dbContext = new TravelExpertsDataContext())
            {
                tmpPackage = (from p in dbContext.Packages
                              where p.PackageId == pkgNum
                              select p).Single();
                currPkg = tmpPackage; // assign the package to the glocal currPkg
                GetAssigned(pkgNum); // get the assigned product of the package
                GetAvailable(); // get the available products that can be added to the package


                // iterate through prodAssigned and add it's name to the listbox lbAssigned
                foreach (Product item in prodAssigned)
                {
                    lbAssigned.Items.Add(item.ProdName);
                }
                // iterate through prodAvailable and add it's name to the listbox lbAvail
                foreach (Product item in prodAvailable)
                {
                    lbAvail.Items.Add(item.ProdName);
                }
                // set the listboxes to sort the entries
                lbAvail.Sorted = true;
                lbAssigned.Sorted = true;

            }
            // set the other form controls to the corresponding package detail
            dtpPkgStart.Value = (DateTime)tmpPackage.PkgStartDate;
            dtpPkgEnd.Value = (DateTime)tmpPackage.PkgEndDate;
            txtPackageID.Text = tmpPackage.PackageId.ToString();
            // packageId is not an editable field
            //txtPackageID.Enabled = false;
            txtPkgName.Text = tmpPackage.PkgName;
            txtPkgDesc.Text = tmpPackage.PkgDesc;
            txtPkgBase.Text = tmpPackage.PkgBasePrice.ToString("c");
            txtPakComm.Text = ((decimal)(tmpPackage.PkgAgencyCommission)).ToString("c");
            // enable the GroupBox so the entries can be edited
            gbDetails.Enabled = true;
        }

        // closes this form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Searchs the DB for a Product that match the provided string
        /// </summary>
        /// <param name="s"></param>
        /// <returns>returns a product object</returns>
        public Product GetProductByName(string s)
        {
            // setup DataAccess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            Product p = new Product(); // new Product object
            List<Product> c = new List<Product>(); // temp list to store the product
            // dump results to a var
            var x = (from pd in dbContext.Products
                     where pd.ProdName == s
                     select pd).Distinct();
            // transfer results to List<Product>
            // list is required because var only has a .ToList() method
            // and I was getting all kinds of type casting issues doing it in any other way
            c = x.ToList();
            //set product attributes from item in list
            foreach (Product item in c)
            {
                p.ProdName = item.ProdName;
                p.ProductId = item.ProductId;
            }
            return p; // return the Product
        }
        
        /// <summary>
        /// Fires when a product is seleted and button clicked to add it to the package
        /// </summary>
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            string name; // for searching by name, based on selected item text
            if(lbAvail.SelectedIndex != -1) // as long as something is slected in the list
            {
                // add it to the assigned list
                lbAssigned.Items.Add(lbAvail.SelectedItem);
                // set the name variable
                name = lbAvail.SelectedItem.ToString();
                // remove the item from available
                lbAvail.Items.Remove(lbAvail.SelectedItem);
                Product prod = new Product(); // temp Product object
                prod = GetProductByName(name); // get the Product details from the selected item
                // if the item isn't in the assisned list add it to the addProd list
                if (!prod.IfExists(prodAssigned))
                    addProd.Add(GetProductByName(name));
                // if item is in rmvProd list, remove it
                rmvProd.Remove(rmvProd.Find(p => prod.ProdName == name));
                lbAvail.Sorted = true;
                lbAssigned.Sorted = true;
            }
            EnableSave(); // check form controls to see if Save button should be enabled
            EnableReset(); // check form controls to see if Reset button should be enabled
        }

        /// <summary>
        /// If the addProd or rmvProd lists have any items, enable the reset button
        /// </summary>
        private void EnableReset()
        {
            if (addProd.Count > 0 || rmvProd.Count > 0)
            {
                btnReset.Enabled = true;
            }
            else
            {
                btnReset.Enabled = false;
            }
        }

        /// <summary>
        /// fires when an item is selected in lbAssigned and button is clicked
        /// </summary>
        private void btnRmvProd_Click(object sender, EventArgs e)
        {
            string name;// for searching by name, based on selected item text

            if (lbAssigned.SelectedIndex != -1)// as long as something is slected in the list
            {
                lbAvail.Items.Add(lbAssigned.SelectedItem); // add item to available items
                name = lbAssigned.SelectedItem.ToString(); // set the name variable
                lbAssigned.Items.Remove(lbAssigned.SelectedItem);// remove item from assigned
                Product prod = new Product(); // temp product object
                prod = GetProductByName(name); // get the Product details from the selected item
                // if the item isn't in the available list add it to the rmvProd list
                if (!prod.IfExists(prodAvailable))
                    rmvProd.Add(prod);
                // if item is in addProd list, remove it
                addProd.Remove(addProd.Find(p=>prod.ProdName==name));
                lbAvail.Sorted=true;
                lbAssigned.Sorted = true;
                
            }
            EnableSave(); // check form controls to see if Save button should be enabled
            EnableReset(); // check form controls to see if Reset button should be enabled
        }
        /// <summary>
        /// Get Products and Suppliers details from a list of Products
        /// </summary>
        /// <param name="lstProd"></param>
        /// <returns>List of Products_Suppilers</returns>
        public List<Products_Supplier> GetProducts_Suppliers(List<Product> lstProd)
        {
            // set up DataAccess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            Products_Supplier ps; // temp Product_Supplier object
            List<Products_Supplier> lstPS = new List<Products_Supplier>(); // temp list
            // get ProductSupplierID based on ProductID
            foreach (Product pd in lstProd)
            {
                ps = new Products_Supplier(); // create a new object each iteration
                // get the ProductSupplierId based on the ProductID of the current item
                ps.ProductSupplierId = Convert.ToInt32((from p in dbContext.Products_Suppliers
                                                        where p.ProductId == pd.ProductId
                                                        select p.ProductSupplierId).First());
                ps.ProductId = pd.ProductId; // set ProductID
                lstPS.Add(ps); // add it to the list
            }
            return lstPS; //return the list of Product_Supplier
        }

        /// <summary>
        /// Get the Packages_Products_Suppliers details for each item in a list of Product_Supplier
        /// </summary>
        /// <param name="lstPS"></param>
        /// <returns>List of Package_Product_Supplier</returns>
        public List<Packages_Products_Supplier> GetPackages_Products_Suppliers(List<Products_Supplier> lstPS)
        {
            //setup DataAccess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            Packages_Products_Supplier ppsd; // temp object
            List<Packages_Products_Supplier> ppsdList = new List<Packages_Products_Supplier>(); // temp list
            //iterate through the list and the the details for each item
            foreach (Products_Supplier prodsup in lstPS)
            {
                ppsd = new Packages_Products_Supplier();// new object for each iteration
                ppsd.ProductSupplierId = prodsup.ProductSupplierId; // set the ProductSupplierId
                if(txtPackageID.Text!="")
                    ppsd.PackageId = Convert.ToInt32(txtPackageID.Text); // set the PackageID
                ppsdList.Add(ppsd); // add item to the list
            }
            return ppsdList; // return the list

        }
        /// <summary>
        /// Method for saving the Package_Product_Supplier information
        /// </summary>
        /// <param name="lstPPS"></param> list of Package_Product_Supplier
        /// <param name="adding"></param> iadding items or removing items
        /// <returns>true if save was successful</returns>
        public bool Save_Packages_Products_Suppliers(List<Packages_Products_Supplier> lstPPS, bool adding)
        {
            //setup DataAccess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            bool status=false; // initalize the return value
            if (adding) // if this is a new item
            {
                foreach (Packages_Products_Supplier pw in lstPPS) // iterate through the list add a record for each
                {
                    try
                    {   // search for any existing items, if not then save
                        if ((from ppst in dbContext.Packages_Products_Suppliers
                             where ppst.PackageId == pw.PackageId && ppst.ProductSupplierId == pw.ProductSupplierId
                             select ppst.ProductSupplierId).Count() < 1)
                        {
                            Packages_Products_Supplier insItem = new Packages_Products_Supplier();
                            insItem.PackageId = Convert.ToInt32(txtPackageID.Text);
                            insItem.ProductSupplierId = pw.ProductSupplierId;
                            dbContext.Packages_Products_Suppliers.InsertOnSubmit(insItem);
                            dbContext.SubmitChanges();
                            status = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        //MessageBox.Show("Error encounctered saving data: \n" + ex.Message);
                        break;
                    }
                }
            }
            else // removing items form the table
            {
                foreach (Packages_Products_Supplier pw in lstPPS) 
                {
                    //List<Packages_Products_Supplier> c = new List<Packages_Products_Supplier>();
                    Packages_Products_Supplier delItem = new Packages_Products_Supplier();// temp object to hold search results
                    // get record details based on PackageID & ProductSupplierID
                    delItem = (from ppst in dbContext.Packages_Products_Suppliers
                               where ppst.PackageId == pw.PackageId && ppst.ProductSupplierId == pw.ProductSupplierId
                               select ppst).Single();
                    //c = deleteDetails.ToList();
                    //foreach (Packages_Products_Supplier item in c)
                    //{
                    //    delItem.PackageId = item.PackageId;
                    //    delItem.ProductSupplierId = item.ProductSupplierId;
                    // delete the record
                        dbContext.Packages_Products_Suppliers.DeleteOnSubmit(delItem);
                    //}
                    try
                    {
                        //Execute the delete
                        dbContext.SubmitChanges();
                        status = true; // set the return value
                    }
                    catch
                    {
                        status = false; // error in saving
                    }
                 }
            }
            return status;
        }
        /// <summary>
        /// Fires when Save is clicked
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // set booleans for various checks later on
            bool allGoodAdd = false; // True when adding Packages_Products_Suppliers records succesfully
            bool allGoodRmv = false; // True when deleting Packages_Products_Suppliers records succesfully
            bool noItems = false; // set to true if we have no items (no changes in Products of package)
            // temporary lists and objects
            List<Products_Supplier> prodsToAdd = new List<Products_Supplier>(); 
            Packages_Products_Supplier ppsd =  new Packages_Products_Supplier();
            List<Packages_Products_Supplier> ppsdList = new List<Packages_Products_Supplier>();
            Products_Supplier ps = new Products_Supplier();
            // setup DataAccess
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();

            // if we are not adding a new record
            if (!isAdd)
            {
                try
                {
                    // Add new products to existing record
                    
                    if (addProd.Count > 0)
                    {
                        // create lists for Products_Suppliers, Packages_Products_Suppliers
                        prodsToAdd = GetProducts_Suppliers(addProd);
                        ppsdList = GetPackages_Products_Suppliers(prodsToAdd);
                        // call the Save method, indicating true for save
                        allGoodAdd = Save_Packages_Products_Suppliers(ppsdList, true);
                    }else
                    {
                        noItems = true; // no items to save
                    }
                    //Remove products from existing package
                    
                    if (rmvProd.Count > 0)
                    {
                        // create lists for Products_Suppliers, Packages_Products_Suppliers
                        prodsToAdd = GetProducts_Suppliers(rmvProd);
                        ppsdList = GetPackages_Products_Suppliers(prodsToAdd);
                        // call the Save method, indicating false for delete
                        allGoodRmv = Save_Packages_Products_Suppliers(ppsdList, false);
                    }
                    else
                    {
                        noItems = true; // no items to remove
                    }
                    // Save main record detail
                    // if there are noItems or Add/Remove methods were successful
                    if (noItems || allGoodAdd || allGoodRmv)
                    {
                        // setup variables for later use
                        decimal basePrice, agcyComm;
                        // create a Package object with detail from DB based on PackageID
                        Package pkg = dbContext.Packages.Single(p => p.PackageId == Convert.ToInt32(txtPackageID.Text));
                        // set the various attributes of the object from form controls
                        pkg.PkgName = txtPkgName.Text;
                        pkg.PkgDesc = txtPkgDesc.Text;
                        pkg.PkgStartDate = dtpPkgStart.Value;
                        pkg.PkgEndDate = dtpPkgEnd.Value;
                        //if (pkg.PkgStartDate < pkg.PkgEndDate)
                        //{
                            if (txtPkgBase.Text.StartsWith("$")) // remove the leading $ if it exists
                            {
                                basePrice = Convert.ToDecimal(txtPkgBase.Text.Remove(0, 1));
                            }
                            else
                            {
                                basePrice = Convert.ToDecimal(txtPkgBase.Text);
                            }
                            if (txtPakComm.Text.StartsWith("$")) // remove the leading $ if it exists
                            {
                                agcyComm = Convert.ToDecimal(txtPakComm.Text.Remove(0, 1));
                            }
                            else
                            {
                                agcyComm = Convert.ToDecimal(txtPakComm.Text);
                            }
                            //set the object attributes
                            pkg.PkgBasePrice = basePrice;
                            pkg.PkgAgencyCommission = agcyComm;

                            if (basePrice > agcyComm) // check the Commision is not more than the base price
                            {
                                dbContext.SubmitChanges(); // save the changes
                            }
                            else
                            {
                                MessageBox.Show("Agency Commision is too high");
                            }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("An error occurred saving the data, tasks cancelled");
                    }
                    
                    
                }
                catch (ChangeConflictException)
                {
                    // if we have concurency exceptions, resolve them and contine the save
                    dbContext.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
                    dbContext.SubmitChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + " - " + ex.ToString());
                }

            }
            else // this is a new Package
            {
                // create lists, objects and variables needed later
                prodsToAdd = GetProducts_Suppliers(addProd);
                ppsdList = GetPackages_Products_Suppliers(prodsToAdd);
                allGoodAdd = Save_Packages_Products_Suppliers(ppsdList, true);
                decimal basePrice, agcyComm;
                Package pkg = new Package(); // create a new Package object
                // set object attributes based on form controls
                pkg.PkgName = txtPkgName.Text;
                pkg.PkgDesc = txtPkgDesc.Text;
                pkg.PkgStartDate = dtpPkgStart.Value;
                pkg.PkgEndDate = dtpPkgEnd.Value;
                //if (pkg.PkgStartDate < pkg.PkgEndDate)
                //{
                    if (txtPkgBase.Text.StartsWith("$")) // remove the leading $ if it exists
                    {
                        basePrice = Convert.ToDecimal(txtPkgBase.Text.Remove(0, 1));
                    }
                    else
                    {
                        basePrice = Convert.ToDecimal(txtPkgBase.Text);
                    }
                    if (txtPakComm.Text.StartsWith("$")) // remove the leading $ if it exists
                    {
                        agcyComm = Convert.ToDecimal(txtPakComm.Text.Remove(0, 1));
                    }
                    else
                    {
                        agcyComm = Convert.ToDecimal(txtPakComm.Text);
                    }
                    // set object attributes
                    pkg.PkgBasePrice = basePrice;
                    pkg.PkgAgencyCommission = agcyComm;
                    if (basePrice > agcyComm) // ensure commision is less than base price
                    {
                        dbContext.Packages.InsertOnSubmit(pkg);
                        dbContext.SubmitChanges(); // submit the changes to the DB
                    }
                    else
                    {
                        MessageBox.Show("Agency Commision is too high");
                    }
                //}
            }
            LoadDGV();
            //LoadEditRecordDetails();
        }

      
        // make sure only one item in either list box is selected at a time
        private void lbAvail_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbAssigned.SelectedIndex > 0)
                lbAssigned.SelectedIndex = -1;
        }

        // make sure only one item in either list box is selected at a time
        private void lbAssigned_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbAvail.SelectedIndex > 0)
                lbAvail.SelectedIndex = -1;
        }

        // reset the products from the values in DB
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadEditRecordDetails(); // retrieve the details
            EnableSave();// check if Save should be enabled
        }

        //checks if the Save button should be enabled
        public void EnableSave()
        {
            if (!isAdd) // if it's not a new package
            {   // check if any control has different data then the currPkg object or Add/Rmv lists have items
                if (txtPkgName.Text != currPkg.PkgName || txtPkgDesc.Text != currPkg.PkgDesc ||
                    txtPkgBase.Text != currPkg.PkgBasePrice.ToString("c") ||
                    txtPakComm.Text != Convert.ToDecimal(currPkg.PkgAgencyCommission).ToString("c") ||
                    dtpPkgStart.Value != currPkg.PkgStartDate && dtpPkgStart.Value < currPkg.PkgEndDate  
                    || dtpPkgEnd.Value != currPkg.PkgEndDate && dtpPkgEnd.Value > currPkg.PkgStartDate
                    || addProd.Count > 0 || rmvProd.Count > 0)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            else // new package
            {   // make sure all fields have data and atleast 1 product added
               
                if (txtPkgName.Text != "" && txtPkgDesc.Text != "" &&
                    txtPkgBase.Text != "" && txtPakComm.Text != "" &&
                    dtpPkgStart.Value !=null && dtpPkgEnd.Value >= dtpPkgStart.Value.AddDays(1) && addProd.Count > 0)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
        }

        private void txtPkgName_TextChanged(object sender, EventArgs e)
        {
            EnableSave(); // determine if Save button should be enabled
        }

        private void txtPkgDesc_TextChanged(object sender, EventArgs e)
        {
            EnableSave(); // determine if Save button should be enabled
        }

        private void dtpPkgStart_ValueChanged(object sender, EventArgs e)
        {
            EnableSave(); // determine if Save button should be enabled
        }

        private void dtpPkgEnd_ValueChanged(object sender, EventArgs e)
        {
            EnableSave(); // determine if Save button should be enabled
        }

        private void txtPkgBase_TextChanged(object sender, EventArgs e)
        {
            EnableSave(); // determine if Save button should be enabled
        }

        private void txtPakComm_TextChanged(object sender, EventArgs e)
        {
            EnableSave(); // determine if Save button should be enabled
        }

        // setup for a New Package
        private void btnNew_Click(object sender, EventArgs e)
        {
            
            isAdd = true; // let other methods know we are adding a record
            // clear form controls
            txtPackageID.Text = "";
            txtPkgName.Text = "";
            txtPkgDesc.Text = "";
            txtPkgBase.Text = "";
            txtPakComm.Text = "";
            // set the start date to today
            dtpPkgStart.Value = DateTime.Now;
            //set end date to 7 days from today
            dtpPkgEnd.Value = DateTime.Now.AddDays(7);
            // clear lists
            addProd.Clear();
            rmvProd.Clear();
            prodAssigned.Clear();
            // get the list of products
            prodAvailable = GetProducts();
            // enable the groupbox
            gbDetails.Enabled = true;
            // clear the two listboxes
            lbAssigned.Items.Clear();
            lbAvail.Items.Clear();
            // add items from prodAvailable to lbAvail
            foreach (Product item in prodAvailable)
            {
                lbAvail.Items.Add(item.ProdName);
            }
            // set sorting on listboxes
            lbAvail.Sorted = true;
            lbAssigned.Sorted = true;

            //reuse the button
            if (btnNew.Text == "&New")
            {
                btnNew.Text = "&Clear";
            }
            else
            {
                btnNew.Text = "&New";
            }
            
        }
        // only accepts numbers and backspace keystrokes
        private void txtPkgBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  e.KeyChar contains the character that was pressed
            // e.Handled is a boolean that indicates that handling is done
            //if a bad character is entered, set e.Handled to true and discard the keypress
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        // only accepts numbers and backspace keystrokes
        private void txtPakComm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  e.KeyChar contains the character that was pressed
            // e.Handled is a boolean that indicates that handling is done
            //if a bad character is entered, set e.Handled to true and discard the keypress
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
