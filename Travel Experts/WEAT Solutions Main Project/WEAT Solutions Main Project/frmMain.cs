using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

/// <summary>
/// inital form design Angela Dunwoodie-Lambert, login, clear and validation code by Wade Grimm
/// </summary>
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
            Login(); // call the Login method
        }
        /// <summary>
        /// Author Wade Grimm (WG)
        /// Method to compare the supplied user name and password against DB values
        /// </summary>
        public void Login()
        {// make sure data is present and button action is login not Logout
            if (txtUsername.Text != "" && txtPassword.Text != "" && btnLogin.Text == "&Login")
            {
                // set up data access entity
                TravelExpertsDataContext dbContext = new TravelExpertsDataContext();
                string uName, uPass; // variables for username and password
                Agent dbAgent; // instatiate a Agent object
                uName = txtUsername.Text; // set the variables from textbox control values
                uPass = txtPassword.Text;
                try
                {// query the DB for a match
                    dbAgent = (Agent)(from agt in dbContext.Agents
                                      where agt.AgtFirstName == uName 
                                      select agt).SingleOrDefault();
                   
                    if (dbAgent.VerifyPassword(uPass)) // will be Null if no matches found
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
                        btnLogin.Text = "&Logout";// set the Button text so we can logout with same control
                        btnLogin.Enabled = true;
                        btnClear.Enabled = false;
                    }
                    else // no match
                    {
                        MessageBox.Show("Invaild Username or password.","Login falied",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        ClearForm();// reset form to try again
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show(ioe.Message + ": " + ioe.ToString());
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("User does not exist.", "User lookup failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearForm();// reset form to try again
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ": " + ex.ToString());
                }
            }
            else
            {
                ClearForm(); // reset form
            }
        }
        /// <summary>
        /// Author Wade Grimm (WG)
        /// Checks if all controls have data and that we are not already logged in
        /// if so then enable login button
        /// </summary>     
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
        /// <summary>
        /// Author Wade Grimm (WG)
        /// Checks if all controls have data and that we are not already logged in
        /// if so then enable login button
        /// </summary>
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
        /// <summary>
        /// Load the Products Add/Edit form
        /// Author: Angela Dunwoodie-Lambert
        /// </summary>
        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmAddEditProducts frmAddEditProducts = new frmAddEditProducts();  //initialize the dialog object
            DialogResult = frmAddEditProducts.ShowDialog();  //show dialog and store it's status
        }

        /// <summary>
        /// Load the Suppliers Add/Edit form
        /// Author: Tom Hollis
        /// </summary>
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmAddEditSuppliers frmAddEditSuppliers = new frmAddEditSuppliers(); // initialize the dialog object
            DialogResult = frmAddEditSuppliers.ShowDialog();                     // show the dialog and store its status
        }

        /// <summary>
        /// Author Wade Grimm (WG)
        /// Load the Packages Add/Edit form
        /// </summary>
        private void btnTravelPkgs_Click(object sender, EventArgs e)
        {
            //initalize a new form object, load it as a dialog
            frmAddEditPackages frmAddEditPackages = new frmAddEditPackages();
            DialogResult = frmAddEditPackages.ShowDialog();
        }
        /// <summary>
        /// Author Wade Grimm (WG)
        /// Checks the Keypress in the control field, if it's the Enter key
        /// and all fields have data and we are not already logged in
        /// then call the login method and/or just enables the Clear button
        /// </summary>
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnLogin.Text != "&Login" || txtUsername.Text != "" && txtPassword.Text != "")
            {
                if(e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
            if (txtPassword.Text != "")
            {
                btnClear.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }
        }
        /// <summary>
        /// Author Wade Grimm (WG)
        /// Checks the Keypress in the control field, if it's the Enter key
        /// and all fields have data and we are not already logged in
        /// then call the login method and/or just enables the Clear button
        /// </summary>
        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnLogin.Text != "&Login" || txtUsername.Text != "" && txtPassword.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
            if (txtUsername.Text != "")
            {
                btnClear.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }
        }
        // Calls the ClearForm method
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        /// <summary>
        /// Author Wade Grimm (WG)
        /// Reset the controls on the form
        /// </summary>
        public void ClearForm()
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
            btnClear.Enabled = false;
            txtUsername.Focus();
        }
    }
}
