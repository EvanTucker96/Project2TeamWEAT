using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop4_team3
{
    public partial class Form1 : Form
    {
        TravelExpertsDataContext teContext = new TravelExpertsDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TravelExpertsDataContext teContext = new TravelExpertsDataContext();
            LoadDGV();
        }

        public void LoadDGV()
        {
            packageDataGridView.DataSource = teContext.Packages;
            //packageDataGridView.AutoResizeColumns();

            // dataGrid formatting items - they don't all matter as we aren't allowing
            // data editing in this application
            // Allows the columns to Autoresize based on contents
           // packageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // select full row instead of a single cell
            packageDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // don't allow more than one row to be selected
            packageDataGridView.MultiSelect = false;
            packageDataGridView.Columns[0].HeaderText = "Package ID";
            packageDataGridView.Columns[1].HeaderText = "Package Name";
            //packageDataGridView.Columns[2].Width = 330;
            packageDataGridView.Columns[2].HeaderText = "Start Date";
            packageDataGridView.Columns[3].HeaderText = "End Date";
            packageDataGridView.Columns[4].HeaderText = "Description";
            packageDataGridView.Columns[5].HeaderText = "Base Price";
            packageDataGridView.Columns[6].HeaderText = "Agency Commission";
            packageDataGridView.Columns[5].DefaultCellStyle.Format = "c";
            packageDataGridView.Columns[6].DefaultCellStyle.Format = "c";
            //packageDataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
