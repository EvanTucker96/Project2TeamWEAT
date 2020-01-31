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
        List<Product> rmvProd = new List<Product>();
        List<Product> addProd = new List<Product>();
        List<Product> products = new List<Product>();
        List<Product> prodAssigned = new List<Product>();
        List<Product> prodAvailable = new List<Product>();
        Package currPkg;

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
            LoadEditRecordDetails();

        }

        public void LoadEditRecordDetails()
        {
            isAdd = false;
            rmvProd.Clear();
            addProd.Clear();
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
                currPkg = tmpPackage;
                GetProducts();
                GetAssigned(pkgNum);
                GetAvailable();



                foreach (Product item in prodAssigned)
                {
                    lbAssigned.Items.Add(item.ProdName);
                }
                foreach (Product item in prodAvailable)
                {
                    lbAvail.Items.Add(item.ProdName);
                }
                lbAvail.Sorted = true;
                lbAssigned.Sorted = true;

            }
            dtpPkgStart.Value = (DateTime)tmpPackage.PkgStartDate;
            dtpPkgEnd.Value = (DateTime)tmpPackage.PkgEndDate;
            txtPackageID.Text = tmpPackage.PackageId.ToString();
            txtPackageID.Enabled = false;
            txtPkgName.Text = tmpPackage.PkgName;
            txtPkgDesc.Text = tmpPackage.PkgDesc;
            txtPkgBase.Text = tmpPackage.PkgBasePrice.ToString("c");
            txtPakComm.Text = ((decimal)(tmpPackage.PkgAgencyCommission)).ToString("c");
            //EnableSave();
            gbDetails.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public Product GetProductByName(string s)
        {
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            Product p = new Product();
            List<Product> c = new List<Product>();

            var x = (from pd in dbContext.Products
                     where pd.ProdName == s
                     select pd).Distinct();
            c = x.ToList();
            foreach (Product item in c)
            {
                p.ProdName = item.ProdName;
                p.ProductId = item.ProductId;
            }
            return p;
        }
        
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            string name;
            //bool isAdded=false;
            if(lbAvail.SelectedIndex != -1)
            {
                lbAssigned.Items.Add(lbAvail.SelectedItem);
                name = lbAvail.SelectedItem.ToString();
                lbAvail.Items.Remove(lbAvail.SelectedItem);
                Product prod = new Product();
                prod = GetProductByName(name);
                if (!prod.IfExists(prodAssigned))
                    addProd.Add(GetProductByName(name));
               lbAvail.Sorted = true;
               lbAssigned.Sorted = true;
            }
            EnableSave();
            EnableRemove();
        }

        private void EnableRemove()
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

        private void btnRmvProd_Click(object sender, EventArgs e)
        {
            string name;

            if (lbAssigned.SelectedIndex != -1)
            {
                lbAvail.Items.Add(lbAssigned.SelectedItem);
                name = lbAssigned.SelectedItem.ToString();
                lbAssigned.Items.Remove(lbAssigned.SelectedItem);
                Product prod = new Product();
                prod = GetProductByName(name);
                if(!prod.IfExists(prodAvailable))
                    rmvProd.Add(prod);
                addProd.Remove(addProd.Find(p=>prod.ProdName==name));
                lbAvail.Sorted=true;
                lbAssigned.Sorted = true;
                
            }
            EnableSave();
            EnableRemove();
        }
        public List<Products_Supplier> GetProducts_Suppliers(List<Product> lstProd)
        {
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            Products_Supplier ps;
            List<Products_Supplier> lstPS = new List<Products_Supplier>();
            // get ProductSupplierID based on ProductID
            foreach (Product pd in lstProd)
            {
                ps = new Products_Supplier();
                ps.ProductSupplierId = Convert.ToInt32((from p in dbContext.Products_Suppliers
                                                        where p.ProductId == pd.ProductId
                                                        select p.ProductSupplierId).First());
                ps.ProductId = pd.ProductId;
                lstPS.Add(ps);
            }
            return lstPS;
        }
        public List<Packages_Products_Supplier> GetPackages_Products_Suppliers(List<Products_Supplier> lstPS)
        {
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            Packages_Products_Supplier ppsd;
            List<Packages_Products_Supplier> ppsdList = new List<Packages_Products_Supplier>();
            
            foreach (Products_Supplier prodsup in lstPS)
            {
                ppsd = new Packages_Products_Supplier();
                ppsd.ProductSupplierId = prodsup.ProductSupplierId;
                ppsd.PackageId = Convert.ToInt32(txtPackageID.Text);
                ppsdList.Add(ppsd);
            }
            return ppsdList;

        }

        public bool Save_Packages_Products_Suppliers(List<Packages_Products_Supplier> lstPPS, bool adding)
        {
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            bool status=false;
            if (adding)
            {
                foreach (Packages_Products_Supplier pw in lstPPS)
                {
                    try
                    {
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
            else
            {
                foreach (Packages_Products_Supplier pw in lstPPS) 
                {
                    //List<Packages_Products_Supplier> c = new List<Packages_Products_Supplier>();
                    Packages_Products_Supplier delItem = new Packages_Products_Supplier();
                    delItem = (from ppst in dbContext.Packages_Products_Suppliers
                               where ppst.PackageId == pw.PackageId && ppst.ProductSupplierId == pw.ProductSupplierId
                               select ppst).Single();
                    //c = deleteDetails.ToList();
                    //foreach (Packages_Products_Supplier item in c)
                    //{
                    //    delItem.PackageId = item.PackageId;
                    //    delItem.ProductSupplierId = item.ProductSupplierId;
                        dbContext.Packages_Products_Suppliers.DeleteOnSubmit(delItem);
                    //}
                    try
                    {
                        dbContext.SubmitChanges();
                        status = true;
                    }
                    catch
                    {
                        status = false;
                    }
                 }
            }
            return status;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool allGoodAdd = false;
            bool allGoodRmv = false;
            bool noItems = false;
            List<Products_Supplier> addProds = new List<Products_Supplier>();
            Packages_Products_Supplier ppsd =  new Packages_Products_Supplier();
            List<Packages_Products_Supplier> ppsdList = new List<Packages_Products_Supplier>();
            Products_Supplier ps = new Products_Supplier();

            // need to save existing data to packages and an any new or changed products to 
            // Packages_Products_Suppliers
            // need to add code to remove products from tables
            if (!isAdd)
            {
                TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
               
                try
                {
                    // Add new products
                    
                    if (addProd.Count > 0)
                    {
                        addProds = GetProducts_Suppliers(addProd);
                        ppsdList = GetPackages_Products_Suppliers(addProds);
                        allGoodAdd = Save_Packages_Products_Suppliers(ppsdList, true);
                    }else
                    {
                        noItems = true;
                    }
                    //Remove products
                    
                    if (rmvProd.Count > 0)
                    {
                        addProds = GetProducts_Suppliers(rmvProd);
                        ppsdList = GetPackages_Products_Suppliers(addProds);
                        allGoodRmv = Save_Packages_Products_Suppliers(ppsdList, false);
                    }
                    else
                    {
                        noItems = true;
                    }
                    // Save main record detail
                    if (noItems || allGoodAdd || allGoodRmv)
                    {
                        decimal basePrice, agcyComm;
                        Package pkg = dbContext.Packages.Single(p => p.PackageId == Convert.ToInt32(txtPackageID.Text));
                        pkg.PkgName = txtPkgName.Text;
                        pkg.PkgDesc = txtPkgDesc.Text;
                        pkg.PkgStartDate = dtpPkgStart.Value;
                        pkg.PkgEndDate = dtpPkgEnd.Value;
                        if (txtPkgBase.Text.StartsWith("$"))
                        {
                            basePrice = Convert.ToDecimal(txtPkgBase.Text.Remove(0, 1));
                        }
                        else
                        {
                            basePrice = Convert.ToDecimal(txtPkgBase.Text);
                        }
                        if (txtPakComm.Text.StartsWith("$"))
                        {
                            agcyComm = Convert.ToDecimal(txtPakComm.Text.Remove(0, 1));
                        }
                        else
                        {
                            agcyComm = Convert.ToDecimal(txtPakComm.Text);
                        }
                        pkg.PkgBasePrice = basePrice;
                        pkg.PkgAgencyCommission = agcyComm;
                        if (basePrice > agcyComm)
                        {
                            dbContext.SubmitChanges();
                        }
                        else
                        {
                            MessageBox.Show("Agency Commision is too high");
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occurred saving the data, tasks cancelled");
                    }
                    
                    
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
            LoadEditRecordDetails();
        }

      

        private void lbAvail_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbAssigned.SelectedIndex > 0)
                lbAssigned.SelectedIndex = -1;
        }

        private void lbAssigned_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbAvail.SelectedIndex > 0)
                lbAvail.SelectedIndex = -1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadEditRecordDetails();
            EnableSave();
        }

        public void EnableSave()
        {
            //decimal comm = currPkg.PkgAgencyCommission;
            if (!isAdd)
            {
                if (txtPkgName.Text != currPkg.PkgName || txtPkgDesc.Text != currPkg.PkgDesc ||
                    txtPkgBase.Text != currPkg.PkgBasePrice.ToString("c") ||
                    txtPakComm.Text != Convert.ToDecimal(currPkg.PkgAgencyCommission).ToString("c") ||
                    dtpPkgStart.Value != currPkg.PkgStartDate || dtpPkgEnd.Value != currPkg.PkgEndDate
                    || addProd.Count > 0 || rmvProd.Count > 0)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            else
            {
                if (txtPkgName.Text !="" && txtPkgDesc.Text != "" &&
                    txtPkgBase.Text != "" && txtPakComm.Text != "" &&
                   addProd.Count > 0)
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
            EnableSave();
        }

        private void txtPkgDesc_TextChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void dtpPkgStart_ValueChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void dtpPkgEnd_ValueChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void txtPkgBase_TextChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void txtPakComm_TextChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void dtpPkgStart_Validating(object sender, CancelEventArgs e)
        {
            //EnableSave();
        }

        private void dtpPkgEnd_Validating(object sender, CancelEventArgs e)
        {
            //EnableSave();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GetProducts();
            isAdd = true;
            txtPkgName.Text = "";
            txtPkgDesc.Text = "";
            txtPkgBase.Text = "";
            txtPakComm.Text = "";
            dtpPkgStart.Value = DateTime.Now;
            dtpPkgEnd.Value = DateTime.Now.AddDays(7);
            addProd.Clear();
            rmvProd.Clear();
            prodAssigned.Clear();
            prodAvailable = products;
            gbDetails.Enabled = true;
            foreach (Product item in prodAvailable)
            {
                lbAvail.Items.Add(item.ProdName);
            }
            lbAvail.Sorted = true;
            lbAssigned.Sorted = true;
        }
    }
}
