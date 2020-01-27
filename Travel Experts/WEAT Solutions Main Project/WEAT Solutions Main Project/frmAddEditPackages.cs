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
/// Add/Edit Packages - Author Wade Grimm (WG)
/// </summary>
namespace WEAT_Solutions_Main_Project
{
    public partial class frmAddEditPackages : Form
    {
        public bool isAdd;
        List<string> rmvProd = new List<string>();
        List<Product> products = new List<Product>();
        List<Product> prodAssigned = new List<Product>();
        List<Product> prodAvailable = new List<Product>();

        public frmAddEditPackages()
        {
            InitializeComponent();
        }

        private void frmAddEditPackages_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        public void GetProducts()
        {
            List<Product> listProds = new List<Product>();
            Product tmpProd;
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            products.Clear();
            var listProducts = dbContext.Products.GroupBy(item => item.ProductId,
                               (key, group) => new {
                                   ProductId = key,
                                   prodName = group.First().ProdName}).ToList();

            for (int i = 0; i < listProducts.Count; i++)
            {
                tmpProd = new Product();
                tmpProd.ProdName = listProducts[i].prodName;
                tmpProd.ProductId = listProducts[i].ProductId;
                products.Add(tmpProd);
            }
        }
        public void GetAssigned(int id)
        {
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            List<Product> tmplist = new List<Product>();
            prodAssigned.Clear();

            var names = (from pd in dbContext.Products
                     join ps in dbContext.Products_Suppliers on pd.ProductId equals ps.ProductId
                     join pps in dbContext.Packages_Products_Suppliers on ps.ProductSupplierId equals pps.ProductSupplierId
                     join pkg in dbContext.Packages on pps.PackageId equals pkg.PackageId
                     where pkg.PackageId == id
                     select pd).Distinct();
            
            tmplist = names.ToList();
            
            for (int i = 0; i < tmplist.Count; i++)
            {
                Product tmpProd = new Product();
                tmpProd.ProdName = tmplist[i].ProdName;
                tmpProd.ProductId = tmplist[i].ProductId;
               prodAssigned.Add(tmpProd);
            }
        }
        public void GetAvailable()
        {
            prodAvailable.Clear();
            foreach(Product item in products)
            {
                if (!item.IfExists(prodAssigned))
                    prodAvailable.Add(item);

            }
        }

        public void LoadDGV()
        {

            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            dataGridView1.DataSource = dbContext.Packages;
            // select full row instead of a single cell
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // don't allow more than one row to be selected
            dataGridView1.MultiSelect = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
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
            isAdd = false;
            rmvProd.Clear();
            int rowNum = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            int pkgNum = Convert.ToInt32(dataGridView1[0, rowNum].Value);
            Package tmpPackage;
            lbAvail.Items.Clear();
            lbAssigned.Items.Clear();
            using (TravelExpertsDataContext dbContext = new TravelExpertsDataContext())
            {
                tmpPackage = (from p in dbContext.Packages
                              where p.PackageId == pkgNum
                              select p).Single();

                GetProducts();
                GetAssigned(pkgNum);
                GetAvailable();



                foreach (Product item in prodAssigned)
                {
                    lbAssigned.Items.Add(item.ProdName );
                }
                foreach(Product item in prodAvailable)
                {
                    lbAvail.Items.Add(item.ProdName);
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
            //bool isAdded=false;
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
                rmvProd.Add(lbAssigned.SelectedItem.ToString());
                lbAvail.Items.Add(lbAssigned.SelectedItem);
                lbAssigned.Items.Remove(lbAssigned.SelectedItem);
                lbAvail.Sorted=true;
                lbAssigned.Sorted = true;
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> products = new List<string>();
            List<Product> prods = new List<Product>();
            List<Products_Supplier> addProds = new List<Products_Supplier>();
            Packages_Products_Supplier ppsd =  new Packages_Products_Supplier();
            List<Packages_Products_Supplier> ppsdList = new List<Packages_Products_Supplier>();
            Product ppd = new Product();
            Products_Supplier ps = new Products_Supplier();
            int tmpID;
            // need to save existign data to packages and an any new or changed products to 
            // Packages_Products_Suppliers
            // need to add code to remove products from tables
            if (!isAdd)
            {
                TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
               
                try
                {
                    // get productID for each entry in List
                    foreach (string item in lbAssigned.Items) 
                    {
                        ppd = new Product();
                        tmpID = Convert.ToInt32((from p in dbContext.Products
                                        where p.ProdName == item
                                        select p.ProductId).Single());
                        ppd.ProductId = tmpID;
                        ppd.ProdName = item;
                        prods.Add(ppd);

                    }
                    // get ProductSupplierID based on ProductID
                    foreach(Product pd  in prods)
                    {
                        ps = new Products_Supplier();
                        ps.ProductSupplierId = Convert.ToInt32((from p in dbContext.Products_Suppliers
                                               where p.ProductId == pd.ProductId
                                               select p.ProductSupplierId).First());
                        ps.ProductId = pd.ProductId;
                        addProds.Add(ps);
                    }
                    // create Product_Pacakes_Suppliers entities from each list item
                    foreach(Products_Supplier prodsup in addProds)
                    {
                        ppsd = new Packages_Products_Supplier();
                        ppsd.ProductSupplierId = prodsup.ProductSupplierId;
                        ppsd.PackageId = Convert.ToInt32(txtPackageID.Text);
                        ppsdList.Add(ppsd);
                    }


                    // for each entry save the product info to Packages_Products_Suppliers
                    foreach (Packages_Products_Supplier pw in ppsdList) 
                    {
                        
                       if((from ppst in dbContext.Packages_Products_Suppliers
                                where ppst.PackageId == pw.PackageId && ppst.ProductSupplierId == pw.ProductSupplierId
                                select ppst.ProductSupplierId).Count() < 1)
                        {
                            Packages_Products_Supplier insItem = new Packages_Products_Supplier();
                            insItem.PackageId = Convert.ToInt32(txtPackageID.Text);
                            insItem.ProductSupplierId = pw.ProductSupplierId;
                            dbContext.Packages_Products_Suppliers.InsertOnSubmit(insItem);
                            dbContext.SubmitChanges();
                        }
                        
                        

                    }
                    
                    Package pkg = dbContext.Packages.Single(p => p.PackageId == Convert.ToInt32(txtPackageID.Text));
                    pkg.PkgName = txtPkgName.Text;
                    pkg.PkgDesc = txtPkgDesc.Text;
                    pkg.PkgStartDate = dtpPkgStart.Value;
                    pkg.PkgEndDate = dtpPkgEnd.Value;
                    pkg.PkgBasePrice = Convert.ToDecimal(txtPkgBase.Text.Remove(0,1));
                    pkg.PkgAgencyCommission = Convert.ToDecimal(txtPakComm.Text.Remove(0,1));
                    dbContext.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    dbContext.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
                    dbContext.SubmitChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + " - " + ex.ToString());
                }

            }
            else
            {
                // Add new Package code here
            }
        }
    }
}
