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
        public int ProdID;
        public string ProdName;
        Product currentProduct;

        public frmAddEditProducts()
        {
            InitializeComponent();
        }

        // loading data grid view for products
        private void frmAddEditProducts_Load_1(object sender, EventArgs e)
        {
            LoadProducts();
            gbProductDetails.Enabled = false;
            btnSave.Enabled = false;
            btnReset.Enabled = false;
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
            EditRecords();
        }

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

        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdd = true;
            gbProductDetails.Enabled = true;
            txtProdName.Focus();
            txtProdID.Text = "";
            txtProdName.Text = "";
            btnSave.Enabled = true;
            btnReset.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRecords();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isAdd = false;
            txtProdID.Text = "";
            txtProdName.Text = "";
            gbProductDetails.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnReset.Enabled = false;
            btnSave.Enabled = false;
            //ResetOrSave();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProdName.Text != "")
            {
                using (TravelExpertsDataContext dbContext = new TravelExpertsDataContext())
                {
                    Product newItem = new Product();
                    newItem.ProdName = txtProdName.Text;
                    dbContext.Products.InsertOnSubmit(newItem);
                    try
                    {
                        dbContext.SubmitChanges();
                        MessageBox.Show("Product saved successfully");
                        txtProdName.Text = "";
                        btnReset.Enabled = false;
                        btnSave.Enabled = false;
                        gbProductDetails.Enabled = false;
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Save failed, please try again");
                    }
                }
            }
            else
            {
                MessageBox.Show("No information in Product Name field, save cancelled");
            }
        }

        private void EditRecords()
        {
            isAdd = false;
            int rowNum = Convert.ToInt32(dgvProducts.CurrentCell.RowIndex);
            int prodNum = Convert.ToInt32(dgvProducts[0, rowNum].Value);
            Product tempProd;

            using(TravelExpertsDataContext dbContext = new TravelExpertsDataContext())
            {
                tempProd = (from p in dbContext.Products
                            where p.ProductId == prodNum
                            select p).Single();
                currentProduct = tempProd;
            }

            txtProdID.Text = tempProd.ProductId.ToString();
            txtProdName.Text = tempProd.ProdName;
            gbProductDetails.Enabled = true;
            txtProdName.Enabled = true;
            txtProdName.Focus();
            btnSave.Enabled = true;
            btnReset.Enabled = true;

        }

        private void dgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRecords();
        }


    }
}
