using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEAT_Solutions_Main_Project
{
    public partial class frmAddEditPackages : Form
    {
        public bool isAdd;

        public frmAddEditPackages()
        {
            InitializeComponent();
        }

        private void frmAddEditPackages_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        public void LoadDGV()
        {

            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            dataGridView1.DataSource = dbContext.Packages;
            // select full row instead of a single cell
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // don't allow more than one row to be selected
            dataGridView1.MultiSelect = false;
            // set column names and display format
            dataGridView1.Columns[0].HeaderText = "Package ID";
            dataGridView1.Columns[1].HeaderText = "Package Name";
            dataGridView1.Columns[2].HeaderText = "Start Date";
            dataGridView1.Columns[3].HeaderText = "End Date";
            dataGridView1.Columns[4].HeaderText = "Description";
            dataGridView1.Columns[5].HeaderText = "Base Price";
            dataGridView1.Columns[6].HeaderText = "Agency Commission";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowNum = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            int pkgNum = Convert.ToInt32(dataGridView1[0, rowNum].Value);
            Package tmpPackage;
            Product tmpProd;
            List<string> products = new List<string>();
         
            
            List<string> names = new List<string>();
            //Packages_Products_Supplier pps =  new Packages_Products_Supplier;
            //Products_Supplier ps = new Products_Supplier;
            lbAvail.Items.Clear();
            lbAssigned.Items.Clear();
            using (TravelExpertsDataContext dbContext = new TravelExpertsDataContext())
            {
                tmpPackage = (from p in dbContext.Packages
                                           where p.PackageId == pkgNum
                                           select p).Single();

                names =  (from pd in dbContext.Products
                          join ps in dbContext.Products_Suppliers on pd.ProductId equals ps.ProductId
                          join pps in dbContext.Packages_Products_Suppliers on ps.ProductSupplierId equals pps.ProductSupplierId
                          join pkg in dbContext.Packages on pps.PackageId equals pkg.PackageId
                          where pkg.PackageId == pkgNum
                          select pd.ProdName).ToList();


                products = (from pd in dbContext.Products
                          select pd.ProdName).ToList();
                                     
                foreach(string item in names)
                {
                    if (products.Contains(item))
                    {
                        products.Remove(item);
                    }
                }
                
                foreach(string item in names)
                {
                    lbAssigned.Items.Add(item);
                }
                foreach(string item in products)
                {
                    lbAvail.Items.Add(item);
                }

                lbAvail.Sorted = true;
                lbAssigned.Sorted = true;

            }
            txtPackageID.Text = tmpPackage.PackageId.ToString();
            txtPackageID.Enabled = false;
            txtPkgName.Text = tmpPackage.PkgName;
            txtPkgDesc.Text= tmpPackage.PkgDesc;
            txtPkgBase.Text = tmpPackage.PkgBasePrice.ToString("c");
            txtPakComm.Text = ((decimal)(tmpPackage.PkgAgencyCommission)).ToString("c");
            dtpPkgStart.Value = (DateTime)tmpPackage.PkgStartDate;
            dtpPkgEnd.Value = (DateTime)tmpPackage.PkgEndDate;

          


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            bool isAdded=false;
            if(lbAvail.SelectedIndex != -1)
            {
                lbAssigned.Items.Add(lbAvail.SelectedItem);
                lbAvail.Items.Remove(lbAvail.SelectedItem);
                lbAvail.Sorted = true;
                lbAssigned.Sorted = true;
            }

        }

        private void btnRmvProd_Click(object sender, EventArgs e)
        {
            if(lbAssigned.SelectedIndex != -1)
            {
                lbAvail.Items.Add(lbAssigned.SelectedItem);
                lbAssigned.Items.Remove(lbAssigned.SelectedItem);
                lbAvail.Sorted=true;
                lbAssigned.Sorted = true;
            }
        }
    }
}
