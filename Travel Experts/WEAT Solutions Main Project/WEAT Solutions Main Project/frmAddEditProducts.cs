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

        //opens the group box to enter a new product to the DB
        private void btnNew_Click(object sender, EventArgs e)
        {
            isAdd = true;
            gbProductDetails.Enabled = true;
            txtProdName.Focus();
            txtProdID.Text = "";
            txtProdName.Text = "";
            EnableEditDelete();
        }

        //activates the edit records
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRecords();
        }

        //deletes a product from the database and reloads the grid view to show as removed
        private void btnDelete_Click(object sender, EventArgs e)
        {
            isAdd = false;
            int rowNum = Convert.ToInt32(dgvProducts.CurrentCell.RowIndex);
            int prodNum = Convert.ToInt32(dgvProducts[0, rowNum].Value);
            //Product tempProd;

            using (TravelExpertsDataContext dbContext = new TravelExpertsDataContext())
            {
                try
                {
                    DeleteProduct(prodNum, dbContext);
                    dbContext.SubmitChanges();
                    MessageBox.Show("Product Deleted");
                    LoadProducts();
                }
                catch (Exception)
                {
                    MessageBox.Show("Delete product fail, item not in Database");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isAdd = false;
            txtProdID.Text = "";
            txtProdName.Text = "";
            gbProductDetails.Enabled = false;
            btnNew.Enabled = true;
            EnableEditDelete();
        }


    //checked to see if the product is new or edited, saves the data to the DB and reloads the grid view
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProdName.Text != "")
            {
                using (TravelExpertsDataContext dbContext = new TravelExpertsDataContext())
                {
                    if (isAdd == true)
                    {
                        NewProduct(txtProdName.Text, dbContext);
                    }
                    else
                    {
                        EditProduct(Convert.ToInt32(txtProdID.Text), txtProdName.Text, dbContext);
                    }

                    try
                    {
                        dbContext.SubmitChanges();
                        LoadProducts();
                        MessageBox.Show("Product saved successfully");
                        txtProdName.Text = "";
                        gbProductDetails.Enabled = false;
                        btnNew.Enabled = true;
                        //btnEdit.Enabled = true;
                    }
                    catch (Exception)
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

        //function to load the information and edit the record
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
            btnEdit.Enabled = false;
        }

        //edit records from cell double click
        private void dgvProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditRecords();

        }

        // close this form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //add new product information to the DB
        private static void NewProduct(string prodName, TravelExpertsDataContext dbContext)
        {
            Product newItem = new Product();
            newItem.ProdName = prodName;
            dbContext.Products.InsertOnSubmit(newItem);
        }

        //edit product information in the DB
        private static void EditProduct(int prodID, string prodName, TravelExpertsDataContext dbContext)
        {
            var prod = dbContext.Products.Where(x => x.ProductId == prodID).SingleOrDefault();
            prod.ProdName = prodName;
        }

        //delete product from the DB
        private void DeleteProduct(int prodID, TravelExpertsDataContext dbContext)
        {
            var prod = dbContext.Products.Where(x => x.ProductId == prodID).SingleOrDefault();
            dbContext.Products.DeleteOnSubmit(prod);
        }
        public void EnableEditDelete()
        {
            if (dgvProducts.SelectedRows.Count > 0 && isAdd == false)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isAdd = false;
            gbProductDetails.Enabled = false;
            EnableEditDelete();
        }

        private void txtProdID_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnableEditDelete();
        }

        private void txtProdName_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnableEditDelete();
        }
    }
}
