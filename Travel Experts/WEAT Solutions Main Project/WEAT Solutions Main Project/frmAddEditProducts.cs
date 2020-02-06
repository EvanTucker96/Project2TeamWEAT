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
 * Add/Edit Products form
 * Author: Angela Dunwoodie-Lambert
 */

namespace WEAT_Solutions_Main_Project
{
    public partial class frmAddEditProducts : Form
    {
        public bool isAdd; //decider for if we are adding a new product




        public frmAddEditProducts()
        {
            InitializeComponent();
        }

        // loading data grid view for products
        private void frmAddEditProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        /// <summary>
        /// Fill the data grid view with a fresh view of the products table
        /// used by form load and save buttons
        /// </summary>
        private void LoadProducts()
        {
            //set db access
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            //populate datagridview
            dgvProducts.DataSource = dbContext.Products;
            //select full row
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //do not allow multiselect
            dgvProducts.MultiSelect = false;
            //do not allow inline editing
            dgvProducts.EditMode = DataGridViewEditMode.EditProgrammatically;
            //do not allow user to add in data grid view
            dgvProducts.AllowUserToAddRows = false;
            //do not allow user to remove rows in data grid view
            dgvProducts.AllowUserToDeleteRows = false;
            //add column names
            dgvProducts.Columns[0].HeaderText = "Product ID";
            dgvProducts.Columns[1].HeaderText = "Product Type";
        } //edn LoadProducts

        private void DataGridView_CellDoubleClick(object sender, EventArgs e)
        {
            LoadEditRecordDetails();
        }

        private void LoadEditRecordDetails()
        {
            
        }

        /// <summary>
        /// Make item editable in the Details when row clicked
        /// </summary>

        //private void dgvProducts_CellClick(object sender, EventArgs e)
        //{
        //    //get product ID from the first column of the table
        //     int prodID = (int)dgvProducts[0, e.RowIndex].Value;

        //    //make edit fields usable
        //    ActivateDetails();

        //    //Pass the id to details fields
        //    LoadProductsDetails(prodID);
        //}

        private void LoadProductsDetails(int prodID)
        {
            using(TravelExpertsDataContext db = new TravelExpertsDataContext())
            {
                // get the selected product
                Product currentProduct = db.Products.Where(product => product.ProductId == prodID).Single();

                //fill in the fields
                txtProdID.Text = currentProduct.ProductId.ToString();
                txtProdName.Text = currentProduct.ProdName;
            }
        }

        private void ActivateDetails()
        {
            //enable the group box in general
            gbProductDetails.Enabled = true;

            //enable reset and save buttons
            btnSave.Enabled = true;
            btnReset.Enabled = true;
        }



        // close this form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
