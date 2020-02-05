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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When the user clicks on a dock in the grid view, populate the slip grid view with that dock's slips
        /// </summary>
        protected void dgvDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected dock name and ID
            string selectedDock = dgvDocks.SelectedRow.Cells[2].Text;
            int dockID = Convert.ToInt32(dgvDocks.SelectedRow.Cells[1].Text);

            // update the label with the dock id #
            lblDockID.Text = "Slips for " + selectedDock + ":";

            // update the grid view with slips for that dock
            using (MarinaEntities db = new MarinaEntities())
            {
                dgvSlips.DataSourceID = null;
                dgvSlips.DataSource = null;
                dgvSlips.DataSource = db.Slips.Where(slip => slip.DockID == dockID).ToList();
            }

            // make the slip grid view visible
            dgvSlips.Visible = true;
        }

    }
}