using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Customer newCust = new Customer();
            if (txtFName.Text != "" && txtLName.Text != "" && txtCity.Text != "" &&
                txtPhone.Text != "" && txtEmail.Text != "")
            {
                newCust.FirstName = txtFName.Text;
                newCust.LastName = txtLName.Text;
                newCust.City = txtCity.Text;
                newCust.Phone = txtPhone.Text;
                
            }
        }
    }
}