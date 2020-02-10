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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            MarinaEntities1 db = new MarinaEntities1(); // create DB object
            if (!(bool)Session["Authenticated"]) // if they somehow got here without authentication, kick them back
            {
                Response.Redirect("Registration.aspx");
            }

            // get the username from the session data
            string username = (string)Session["Username"];

            // use the username to get the customer from the database (mostly for their ID)
            cust = db.Customers.Where(c => c.EMail == username).Single();
            
            // get the slips that this customer has previously leased
            List<Slip> history = (from slip in db.Slips
                                    join l in db.Leases on slip.ID equals l.SlipID
                                    join c in db.Customers on l.CustomerID equals c.ID
                                    where l.CustomerID == cust.ID
                                    select slip).ToList();

            // put the list of this customer's leases in the DGV
            // this isn't working for some reason
            dgvLeases.DataSource = null;
            dgvLeases.DataSource = history;
            
            // bad, gross workaround to display the customer's lease history
            foreach (Slip s in history)
            {
                lblTrash.Text = s.ID.ToString() + "</br>";
            }

        }

        protected void btnLease_Click(object sender, EventArgs e)
        {
            lblUnavailable.Visible = false; // reset the "unavailable" error message
            int chosenSlip = Convert.ToInt32(txtChosen.Text); // get the customer's choice of slip to lease


            using (MarinaEntities1 db = new MarinaEntities1())
            {
                // getting these again due to missing some crucial info in class while away -Tom
                List<int> leaseList = (from lease in db.Leases select lease.SlipID).ToList();
                List<int> availList = (from slip in db.Slips select slip.ID).ToList();


                // check whether the lease number is unavailable (if it's already leased or not a valid number)
                if (!availList.Contains(chosenSlip) || leaseList.Contains(chosenSlip))
                {
                    lblUnavailable.Visible = true; // make the unavailable error visible
                    return; // don't do anything more
                }
                // otherwise continue

                // create a new lease with the customer and slip ID
                Lease leased = new Lease();
                leased.CustomerID = cust.ID;
                leased.SlipID = chosenSlip;

                // save to the database
                db.Leases.Add(leased);
                db.SaveChanges();
            }
            
        }
    }
}