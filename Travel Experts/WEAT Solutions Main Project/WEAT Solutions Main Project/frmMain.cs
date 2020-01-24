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
            TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
            string uName, uPass;
            Agent dbAgent;
            uName = txtUsername.Text;
            uPass = txtPassword.Text;
            dbAgent = (Agent)(from agt in dbContext.Agents
                              where agt.AgtFirstName == uName && agt.Password == uPass
                              select agt).Single();
            if (dbAgent.Password == uPass)
            {
                btnProducts.Enabled = true;
                btnSuppliers.Enabled = true;
                btnTravelPkgs.Enabled = true;
                btnLogin.Enabled = false;
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
    }
}
