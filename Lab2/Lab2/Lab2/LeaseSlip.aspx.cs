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
        Customer cust; // object to hold info for the current customer
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            MarinaEntities1 db = new MarinaEntities1(); // create DB object
            try
            {
                if (!(bool)Session["Authenticated"]) // if they somehow got here without authentication, kick them back
                {
                    Response.Redirect("Registration.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("Registration.aspx");
            }
            // get the username from the session data
            username = (string)Session["Username"];
            if(username != null && (bool)Session["Authenticated"] ==true)
                GetLeases(username);

        }

        public void GetLeases(string username)
        {
            MarinaEntities1 db = new MarinaEntities1(); // create DB object
            // use the username to get the customer from the database (mostly for their ID)
            cust = db.Customers.Where(c => c.EMail == username).Single();

            // get the slips that this customer has previously leased
            List<Slip> history = (from slip in db.Slips
                                  join l in db.Leases on slip.ID equals l.SlipID
                                  join c in db.Customers on l.CustomerID equals c.ID
                                  where l.CustomerID == cust.ID
                                  select slip).ToList();

            // put the list of this customer's leases in the DGV
            dgvLeases.DataSource = null;
            dgvLeases.DataSource = history;
            dgvLeases.DataBind();
        }



        protected void btnLease_Click(object sender, EventArgs e)
        {
            

        }
        public void DoLease(int slipNum)
        {
            //int chosenSlip = Convert.ToInt32(txtChosen.Text); // get the customer's choice of slip to lease


            using (MarinaEntities1 db = new MarinaEntities1())
            {
                // getting these again due to missing some crucial info in class while away -Tom
                List<int> leaseList = (from lease in db.Leases select lease.SlipID).ToList();
                List<int> availList = (from slip in db.Slips select slip.ID).ToList();


                // create a new lease with the customer and slip ID
                Lease leased = new Lease();
                leased.CustomerID = cust.ID;
                leased.SlipID = slipNum;

                // save to the database
                db.Leases.Add(leased);
                db.SaveChanges();
                GetLeases(username);
                lvAvailableSlips.SelectedIndex = -1;
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        { 
            Session["Username"]=null;
            Session["Authenticated"] = false;
            Response.Redirect("Default.aspx");
        }

        protected void lvAvailableSlips_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoLease(Convert.ToInt32(lvAvailableSlips.SelectedValue));
        }
    }    
}