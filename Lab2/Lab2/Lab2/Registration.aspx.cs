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
            MarinaEntities1 db = new MarinaEntities1();
            Customer newCust = new Customer();
            bool exists;
            try
            {
                newCust = (from c in db.Customers
                           where c.EMail == txtEmail.Text
                           select c).Single();
                exists = true;
            }
            
            catch (System.InvalidOperationException)
            {
                exists = false;
            }

            if (!exists) 
            {
                if (txtFName.Text != "" && txtLName.Text != "" && txtCity.Text != "" &&
                    txtPhone.Text != "" && txtEmail.Text != "" && txtPassword.Text !="")
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
                }
            }
            
        }

        //protected void btnVerify_Click(object sender, EventArgs e)
        //{
        //    MarinaEntities1 db = new MarinaEntities1();
        //    //Customer newCust = new Customer();
        //    var result = (from c in db.Customers
        //                  where c.EMail == txtEmail.Text
        //                  select c).Single();
            
           
        //    lblVerify.Text= result.VerifyPassword(txtVerify.Text).ToString();
        //}
    }
}