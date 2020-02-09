using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class LeaseSlip : System.Web.UI.Page
    {
        // uncomment this if Page_Load is implemented
        //int widthMax, widthMin, lengthMax, lengthMin; // store the highest and lowest amounts from the database

        int custID; // so we know who's on


        protected void Page_Load(object sender, EventArgs e)
        {
            // ideally: get max/min values for width and height and populate the text boxes
        }

        /// <summary>
        /// When the user clicks on a dock in the grid view, populate the slip grid view with that dock's slips
        /// </summary>
        protected void dgvDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected dock name and ID
            string selectedDock = dgvDocks.SelectedRow.Cells[2].Text;
            int dockID = Convert.ToInt32(dgvDocks.SelectedRow.Cells[1].Text);

            //get the user's constraints on dock width and length
            int widthLow = Convert.ToInt32(txtWidthMin.Text),
                widthHigh = Convert.ToInt32(txtWidthMax.Text),
                lengthLow = Convert.ToInt32(txtLengthMin.Text),
                lengthHigh = Convert.ToInt32(txtLengthMax.Text);

            // update the label with the dock id #
            lblDockID.Text = "Slips for " + selectedDock + ":";

            // update the grid view with slips for that dock
            using (MarinaEntities db = new MarinaEntities())
            {
                dgvSlips.DataSourceID = null;
                dgvSlips.DataSource = null;
                dgvSlips.DataSource = db.Slips.Where(slip => (slip.DockID == dockID && slip.Length >= lengthLow && slip.Length <= lengthHigh
                    && slip.Width >= widthLow && slip.Width <= widthHigh)).ToList(); // get all slips on that dock, with dimensions in range

                //dgvLeases.DataSource = db.Leases.Where(lease => lease.CustomerID == custID);
            }

            // make the slip grid view visible
            dgvSlips.Visible = true;

            //if this customer has a lease history
            //lblLeases.Visible = true;
            //dgvLeases.Visible = true;
        }



    }
}