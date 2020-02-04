using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Add/Edit Suppliers Form
 * Author: Tom Hollis unless otherwise noted (but several chunks are basically Wade's frmAddEditPackages "in my own words")
 * 
 */

namespace WEAT_Solutions_Main_Project
{
    public partial class frmAddEditSuppliers : Form
    {
        bool isNew = false; // to keep track if this is a new record or we're editing one
        List<Product> originalProdList; // the list of products a selected supplier started with, to compare against when saving


        public frmAddEditSuppliers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On form load: make sure the form is initialized with supplier table data
        /// </summary>
        private void frmAddEditSuppliers_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        /// <summary>
        /// Fill the data grid view with a fresh view of the suppliers table
        /// Used by form load and save buttons
        /// </summary>
        private void LoadSuppliers()
        {
            // get the database object
            TravelExpertsDataContext db = new TravelExpertsDataContext();
            // set the data grid view source to the supplier table
            dgvSuppliers.DataSource = db.Suppliers;

            //restrict actions in the data grid: select whole rows, only one row, and don't edit within the grid
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.EditMode = DataGridViewEditMode.EditProgrammatically;  
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;

            //make the column names pretty
            dgvSuppliers.Columns[0].HeaderText = "Supplier ID";
            dgvSuppliers.Columns[1].HeaderText = "Supplier Name";

            // choose the first column and use it to sort by supplier ID ascending
            DataGridViewColumn sortCol = dgvSuppliers.Columns[0];
            dgvSuppliers.Sort(sortCol, ListSortDirection.Ascending);

        } // end LoadSuppliers()

        /// <summary>
        /// close this form
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// When a row is clicked in the data grid view, load the details for that supplier below
        /// </summary>
        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // get the supplier ID from the first column of the clicked row
            int suppID = (int)dgvSuppliers[0, e.RowIndex].Value;

            // make sure we're in edit mode
            isNew = false;

            // make the details area clickable/useable
            ActivateDetails();

            // pass the ID to the general purpose details loading method
            LoadSupplierDetails(suppID);
        }


        /// <summary>
        /// Get the details (the list of available products) of the supplier matching an ID
        /// </summary>
        /// <param name="SupplierId">The supplier ID of the details to retrieve in Products_Suppliers table</param>
        private void LoadSupplierDetails(int SupplierId)
        {
            
            using (TravelExpertsDataContext db = new TravelExpertsDataContext()) //get the DB object
            {
                // get the selected supplier
                Supplier currentSupplier = db.Suppliers.Where(supplier => supplier.SupplierId == SupplierId).Single();

                // fill in its fields
                txtSuppID.Text = currentSupplier.SupplierId.ToString();
                txtSuppName.Text = currentSupplier.SupName;

                // get all products with that supplier ID
                originalProdList = (from p in db.Products
                                join ps in db.Products_Suppliers on p.ProductId equals ps.ProductId
                                where ps.SupplierId == SupplierId
                                select p).ToList();

                // populate available products list with all products first
                List<Product> availProducts = (from p in db.Products select p).ToList();

                //start with a blank slate
                lbAssigned.Items.Clear();
                lbAvail.Items.Clear();
                
                foreach(Product p in originalProdList)
                {
                    availProducts.Remove(p); // get rid of the available products that the supplier already has
                    lbAssigned.Items.Add(p); // add the product they do have to their assigned list
                }

                foreach(Product p in availProducts)
                {
                    lbAvail.Items.Add(p);   // add the available products to the available list
                }

                //deactivate the ID so it can't be changed
                txtSuppID.Enabled = false;

            }
        }

        /// <summary>
        /// activate all the controls in the details list after something was selected
        /// </summary>
        private void ActivateDetails()
        {
            // enable the group box in general
            gbDetails.Enabled = true;

            // enable a reset and save buttons
            // TODO nice to have: keep these buttons disabled until it makes sense to be able to click them (see Packages)
            btnSave.Enabled = true;
            btnReset.Enabled = true;

        }

        /*
        /// <summary>
        /// deactivate all the details controls on reset  (unused)
        /// </summary>
        private void DeactivateDetails()
        {
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            gbDetails.Enabled = false;
        }*/

        /// <summary>
        /// Move a product from available to assigned list
        /// </summary>
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            int selection = lbAvail.SelectedIndex;      //save selection index to put the focus back later

            Product movedProduct = (Product)lbAvail.SelectedItem; // hold the item
            lbAssigned.Items.Add(movedProduct);                   // add it to the new list
            lbAvail.Items.Remove(movedProduct);                   // remove it from original list
            
            // if the selected index no longer exists, select the last item. otherwise select the index that used to be selected
            lbAvail.SelectedIndex = (selection >= lbAvail.Items.Count) ? (lbAvail.Items.Count - 1) : selection;
        }

        /// <summary>
        /// Remove a product from assigned, put back in available list
        /// </summary>
        private void btnRmvProd_Click(object sender, EventArgs e)
        {
            int selection = lbAssigned.SelectedIndex;      //save selection index to put the focus back later

            Product movedProduct = (Product)lbAssigned.SelectedItem; // hold the item
            lbAvail.Items.Add(movedProduct);                         // add it to the new list
            lbAssigned.Items.Remove(movedProduct);                   // remove it from original list
            
            // if the selected index no longer exists, select the last item. otherwise select the index that used to be selected
            lbAssigned.SelectedIndex = (selection >= lbAssigned.Items.Count) ? (lbAssigned.Items.Count - 1) : selection;
        }

        /// <summary>
        /// Reset the details to blank if this is a new record, or to the saved data if it's an existing record
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // if new, clear fields and move all products back to available
            if (isNew)
            {                
                PrepareNew();
            }
            // if not new, reload the details
            else
            {
                int suppID = Convert.ToInt32(txtSuppID.Text); // get the ID from the details (it can't be changed)
                LoadSupplierDetails(suppID);                  // pass to the reload method
            }
        }


        /// <summary>
        /// set the program state to add mode and run the PrepareNew() method
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            // switch to add mode
            isNew = true;

            // wake up the details section
            ActivateDetails();

            // set up the details section for adding a new record
            PrepareNew();
        }

        /// <summary>
        /// set up editing a new record -- shared between New and Reset buttons
        /// </summary>
        private void PrepareNew()
        {
            //start with a blank slate
            lbAssigned.Items.Clear();
            lbAvail.Items.Clear();
            txtSuppID.Text = "";
            txtSuppName.Text = "";

            using (TravelExpertsDataContext db = new TravelExpertsDataContext()) //get the DB object
            {
                // populate available products list with all products first
                List<Product> availProducts = (from p in db.Products select p).ToList();
                
                foreach (Product p in availProducts)
                {
                    lbAvail.Items.Add(p);   // add the available products to the available list
                }

                int? maxID = (from s in db.Suppliers select s.SupplierId).Max(); // find the highest supplier ID
                txtSuppID.Text = (maxID + 1).ToString();  // populate the supplier ID text box with that ID plus one
            }

            //activate the supplier ID field for entry
            txtSuppID.Enabled = true;
            txtSuppName.Focus(); // give the supplier name focus
        }

        /// <summary>
        /// When Save button clicked, proceed based on whether add or edit, validate inputs, then store in DB
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int suppID; // to hold the supplier ID later

            // global validations: are there assigned products? is there a name?
            if(lbAssigned.Items.Count == 0) // if no products are assigned
            {
                MessageBox.Show("The supplier must have at least one assigned product", "Missing data");
                return;
            }
            else if (txtSuppName.Text.Length == 0) // if no name
            {
                MessageBox.Show("The supplier must have a name", "Missing data");
                txtSuppName.Focus();
                return;
            }
            else if (!Int32.TryParse(txtSuppID.Text, out suppID)) // if the ID isn't a valid integer
            {
                MessageBox.Show("The supplier ID must be a number without decimals", "Incorrect data");
                txtSuppID.Text = "";
                txtSuppID.Focus();
                return;
            }
            try
            {
                using (TravelExpertsDataContext db = new TravelExpertsDataContext())
                {
                    if (isNew) // if we're adding a new record
                    {

                        // new record validations
                        if (txtSuppID.Text.Length == 0) // if no ID
                        {
                            MessageBox.Show("The supplier must have an ID", "Missing data");
                            txtSuppID.Focus();
                            return;
                        }

                        // check if the supplier ID is already used
                        // look in the DB for the number of records with that ID -- expecting 0 or 1
                        int checkID = (from s in db.Suppliers where s.SupplierId == suppID select s).Count();
                        if (checkID > null) // if it found something, do an error 
                        {
                            MessageBox.Show("The supplier ID is already in use. Please use another", "Incorrect data");
                            txtSuppID.Text = "";
                            txtSuppID.Focus();
                            return;
                        }

                        // make a new supplier object and give it the properties the user entered
                        Supplier newSupp = new Supplier();
                        newSupp.SupplierId = suppID;
                        newSupp.SupName = txtSuppName.Text;

                        // put it in the DB
                        db.Suppliers.InsertOnSubmit(newSupp);

                        // add the products to the Products_Suppliers table
                        foreach (Product p in lbAssigned.Items)
                        {
                            // create a new product-supplier record and give it the product and supplier IDs
                            Products_Supplier ps = new Products_Supplier();
                            ps.ProductId = p.ProductId;
                            ps.SupplierId = suppID;

                            // put it in the table
                            db.Products_Suppliers.InsertOnSubmit(ps);
                        }
                    }
                    else  // if we're editing an existing record
                    {
                        // delete removed entries                       
                        foreach(Product p in originalProdList)
                        {
                            if(!lbAssigned.Items.Contains(p))
                            {
                                // find the record to delete
                                Products_Supplier deletedRecord = (Products_Supplier)db.Products_Suppliers.Where(ps => (ps.SupplierId == suppID && ps.ProductId == p.ProductId)).Single();


                                // delete it from the DB
                                db.Products_Suppliers.DeleteOnSubmit(deletedRecord);
                            }
                        }
                                                
                        // add new entries
                        foreach(Product p in lbAssigned.Items)
                        {
                            if (!originalProdList.Contains(p))
                            {
                                // create the record to add, with product ID and supplier ID
                                Products_Supplier addedRecord = new Products_Supplier();
                                addedRecord.ProductId = p.ProductId;
                                addedRecord.SupplierId = suppID;

                                // add it to the DB
                                db.Products_Suppliers.InsertOnSubmit(addedRecord);
                            }
                        }

                        // update the name in suppliers table (ID can't be changed)
                        Supplier curSupp = db.Suppliers.Single(s => s.SupplierId == suppID);
                        curSupp.SupName = txtSuppName.Text;

                    }
                    db.SubmitChanges(); // make the changes happen if we've got to this point with no problems.
                }
            }
            catch (SqlException) // this will be thrown if there's a foreign key constraint problem
            {
                MessageBox.Show("Problem Saving Changes: One of the products you're trying to remove from this supplier is assigned to a package. " +
                    "Please remove this supplier's product from the package first, then try again", "Product In Use");
                return;
            }
            catch (Exception ex) // generic exception catching
            {
                MessageBox.Show("Problem saving to database: " + ex.Message, ex.GetType().ToString());

            }
            finally
            {
                // update the DGV
                LoadSuppliers();

                if (!isNew) // if completing an edit, reload the details
                {
                    LoadSupplierDetails(suppID);
                }
                else // if completing an add, clear to prepare for the next new supplier
                {
                    PrepareNew();
                }
            }          


        }
    } // class
} // namespace
