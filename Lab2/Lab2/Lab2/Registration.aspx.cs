using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data.SqlClient;


namespace Lab2
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MarinaEntities1 db = new MarinaEntities1(); // create the DataAccess entity
            Customer newCust = new Customer(); // empty Customer object
            bool exists; // used for determining if user exists or not
            lblRegStatus.Text = "";
            if (txtFName.Text != "" && txtLName.Text != "" && txtCity.Text != "" &&
                    txtPhone.Text != "" && txtEmail.Text != "" && txtPassword.Text != "")
            {
                try
                {// search the db for the email address
                    newCust = (from c in db.Customers
                               where c.EMail == txtEmail.Text
                               select c).Single();
                    exists = true; // yes we have an existing user
                }

                catch (System.InvalidOperationException)
                { // error when no data exists
                    exists = false; // no user found
                }

                if (!exists) // no user found, validate and create
                {
                    newCust.FirstName = txtFName.Text;
                    newCust.LastName = txtLName.Text;
                    newCust.City = txtCity.Text;
                    newCust.Phone = txtPhone.Text;
                    newCust.EMail = txtEmail.Text;
                    newCust.Salt = newCust.GetSalt();
                    newCust.Password = newCust.EncryptPassword(txtPassword.Text, newCust.Salt);
                    db.Customers.Add(newCust);
                    db.SaveChanges();
                    Session["Authenticated"] = true;
                    Session["Username"] = txtEmail.Text;
                    Response.Redirect("LeaseSlip.aspx");
                }

            }else
            {
                lblRegStatus.Text = "All fields required";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MarinaEntities1 db = new MarinaEntities1();
            lblStatus.Text = "";
            if (txtEmail2.Text != "" && txtPassword2.Text != "")
            {
                try
                {
                    var result = (from c in db.Customers
                                  where c.EMail == txtEmail2.Text
                                  select c).Single();

                    if (result.VerifyPassword(txtPassword2.Text))
                    {
                        Session["Authenticated"] = true;
                        Session["Username"] = txtEmail2.Text;
                        Response.Redirect("LeaseSlip.aspx");
                    }
                    else
                    {
                        // Invalid password
                        lblStatus.Text = "Invalid username or password.";

                    }
                }
                catch (Exception)
                {
                    lblLoginStatus.Text = "No user exists, please register.";
                }
            }
            else
            {
                lblLoginStatus.Text = "All fields required";
            }
            
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            lblStatus.Text = "";
            lblRegStatus.Text = "";
            lblLoginStatus.Text = "";
        }
    }
}