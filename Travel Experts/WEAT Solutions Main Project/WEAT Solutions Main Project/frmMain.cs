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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text !="" && txtPassword.Text!="" &&  btnLogin.Text == "&Login")
            {
                btnLogin.Text = "&Logout";
                TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
                string uName, uPass;
                Agent dbAgent;
                uName = txtUsername.Text;
                uPass = txtPassword.Text;
                try
                {
                    dbAgent = (Agent)(from agt in dbContext.Agents
                                      where agt.AgtFirstName == uName && agt.Password == uPass
                                      select agt).Single();

                    if (dbAgent.Password.ToLower() == uPass.ToLower())
                    {
                        btnProducts.Enabled = true;
                        btnSuppliers.Enabled = true;
                        btnTravelPkgs.Enabled = true;
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtUsername.Visible = false;
                        txtPassword.Visible = false;
                        lblWelcome.Visible = true;
                        lblWelcome.Text = "Welcome " + uName;
                    }
                    else
                    {
                        MessageBox.Show("Invaild Username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else
            {
                btnProducts.Enabled = false;
                btnSuppliers.Enabled = false;
                btnTravelPkgs.Enabled = false;
                btnLogin.Text = "&Login";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Visible = true;
                txtPassword.Visible = true;
                lblWelcome.Visible = false;
                lblWelcome.Text = "";
                btnLogin.Enabled = false;
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (btnLogin.Text != "&Login" || txtUsername.Text != "" && txtPassword.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (btnLogin.Text != "&Login" || txtUsername.Text != "" && txtPassword.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {

        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {

        }

        private void btnTravelPkgs_Click(object sender, EventArgs e)
        {

        }
    }
}
