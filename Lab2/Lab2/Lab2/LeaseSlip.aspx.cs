using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Lab2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarinaEntities1 db = new MarinaEntities1();
            if (!(bool)Session["Authenticated"])
            {
                Response.Redirect("Registration.aspx");
            }
            // use Session["Username"] for logged in username

            //var results = (from slip in db.Slips
            //                        join dc in db.Docks on slip.DockID equals dc.ID
            //                        join l in db.Leases on slip.ID equals l.SlipID
            //                        join c in db.Customers on l.CustomerID equals c.ID
            //                        select slip);

            // need to format this list? debug shows values but datagrid not displaying
            //dgvLeases.DataSource = results.ToList();
        }
    }
}