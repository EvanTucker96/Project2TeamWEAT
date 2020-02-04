using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Add/Edit Suppliers Form
 * Author: Tom Hollis unless otherwise noted (but it's basically Wade's frmAddEditPackages "in my own words")
 * 
 */

namespace WEAT_Solutions_Main_Project
{
    public partial class frmAddEditSuppliers : Form
    {

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
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            // set the data grid view source to the supplier table
            dgvSuppliers.DataSource = dbContext.Suppliers;

            //restrict actions in the data grid: select whole rows, only one row, and don't edit within the grid
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;

            //make the column names pretty
            dgvSuppliers.Columns[0].HeaderText = "Supplier ID";
            dgvSuppliers.Columns[1].HeaderText = "Supplier Name";

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
                List<Product> products = (from p in db.Products
                                join ps in db.Products_Suppliers on p.ProductId equals ps.ProductId
                                where ps.SupplierId == SupplierId
                                select p).ToList();

                // populate available products list with all products first
                List<Product> availProducts = (from p in db.Products select p).ToList();

                
                
                foreach(Product p in products)
                {
                    availProducts.Remove(p); // get rid of the available products that the supplier already has
                    lbAssigned.Items.Add(p); // add the product they do have to their assigned list
                }

                foreach(Product p in availProducts)
                {
                    lbAvail.Items.Add(p);   // add the available products to the available list
                }

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

        /// <summary>
        /// deactivate all the details controls on reset 
        /// </summary>
        private void DeactivateDetails()
        {
            btnSave.Enabled = false;
            btnReset.Enabled = false;
            gbDetails.Enabled = false;
        }


        // on click New
        // clear out all the fields & set focus to supplier name
        // allow entry of supplier ID as long as it's not already used, otherwise do greatest one + 1

        // on click reset
        // if "new", clear everything and put products back on the right
        // if existing, reload the record and redisplay
        // save which item in DGV was selected, reload, focus back on selected

        // on click save
        // is there anything to actually save?
        // validate inputs
        // if "new", insert a record
        // if existing, update the record
        // exception handling
        // update the DGV

        // if time: pull over wade's fancy save checks



    } // class
} // namespace
