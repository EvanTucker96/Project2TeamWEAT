namespace WEAT_Solutions_Main_Project
{
    partial class frmAddEditSuppliers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblSuppName;
            System.Windows.Forms.Label lblSuppID;
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSuppID = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.lbAssigned = new System.Windows.Forms.ListBox();
            this.lbAvail = new System.Windows.Forms.ListBox();
            this.btnRmvProd = new System.Windows.Forms.Button();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.supplierIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travelExpertsDataContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            lblSuppName = new System.Windows.Forms.Label();
            lblSuppID = new System.Windows.Forms.Label();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelExpertsDataContextBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSuppName
            // 
            lblSuppName.AutoSize = true;
            lblSuppName.Location = new System.Drawing.Point(315, 34);
            lblSuppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSuppName.Name = "lblSuppName";
            lblSuppName.Size = new System.Drawing.Size(101, 17);
            lblSuppName.TabIndex = 14;
            lblSuppName.Text = "Supplier Name";
            // 
            // lblSuppID
            // 
            lblSuppID.AutoSize = true;
            lblSuppID.Location = new System.Drawing.Point(16, 34);
            lblSuppID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSuppID.Name = "lblSuppID";
            lblSuppID.Size = new System.Drawing.Size(79, 17);
            lblSuppID.TabIndex = 15;
            lblSuppID.Text = "Supplier Id:";
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.txtSuppID);
            this.gbDetails.Controls.Add(this.btnReset);
            this.gbDetails.Controls.Add(this.txtSuppName);
            this.gbDetails.Controls.Add(this.lbAssigned);
            this.gbDetails.Controls.Add(lblSuppName);
            this.gbDetails.Controls.Add(this.lbAvail);
            this.gbDetails.Controls.Add(this.btnRmvProd);
            this.gbDetails.Controls.Add(this.btnAddProd);
            this.gbDetails.Controls.Add(lblSuppID);
            this.gbDetails.Enabled = false;
            this.gbDetails.Location = new System.Drawing.Point(13, 311);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetails.Size = new System.Drawing.Size(727, 236);
            this.gbDetails.TabIndex = 31;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Supplier Details";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 22);
            this.label5.TabIndex = 31;
            this.label5.Text = "Products assigned to this Supplier";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(442, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 22);
            this.label4.TabIndex = 30;
            this.label4.Text = "Products available to this Supplier";
            // 
            // txtSuppID
            // 
            this.txtSuppID.Enabled = false;
            this.txtSuppID.Location = new System.Drawing.Point(103, 31);
            this.txtSuppID.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuppID.Name = "txtSuppID";
            this.txtSuppID.Size = new System.Drawing.Size(180, 22);
            this.txtSuppID.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(316, 142);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 32);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(424, 31);
            this.txtSuppName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(286, 22);
            this.txtSuppName.TabIndex = 3;
            // 
            // lbAssigned
            // 
            this.lbAssigned.ItemHeight = 16;
            this.lbAssigned.Location = new System.Drawing.Point(18, 99);
            this.lbAssigned.Margin = new System.Windows.Forms.Padding(4);
            this.lbAssigned.Name = "lbAssigned";
            this.lbAssigned.Size = new System.Drawing.Size(265, 116);
            this.lbAssigned.Sorted = true;
            this.lbAssigned.TabIndex = 22;
            // 
            // lbAvail
            // 
            this.lbAvail.ItemHeight = 16;
            this.lbAvail.Location = new System.Drawing.Point(445, 99);
            this.lbAvail.Margin = new System.Windows.Forms.Padding(4);
            this.lbAvail.Name = "lbAvail";
            this.lbAvail.Size = new System.Drawing.Size(265, 116);
            this.lbAvail.Sorted = true;
            this.lbAvail.TabIndex = 21;
            // 
            // btnRmvProd
            // 
            this.btnRmvProd.Location = new System.Drawing.Point(316, 191);
            this.btnRmvProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnRmvProd.Name = "btnRmvProd";
            this.btnRmvProd.Size = new System.Drawing.Size(100, 28);
            this.btnRmvProd.TabIndex = 20;
            this.btnRmvProd.Text = ">>";
            this.btnRmvProd.UseVisualStyleBackColor = true;
            this.btnRmvProd.Click += new System.EventHandler(this.btnRmvProd_Click);
            // 
            // btnAddProd
            // 
            this.btnAddProd.Location = new System.Drawing.Point(316, 99);
            this.btnAddProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(100, 28);
            this.btnAddProd.TabIndex = 19;
            this.btnAddProd.Text = "<<";
            this.btnAddProd.UseVisualStyleBackColor = true;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(755, 342);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 41);
            this.btnNew.TabIndex = 30;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(756, 404);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 41);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(756, 479);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 41);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.AutoGenerateColumns = false;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.supplierIdDataGridViewTextBoxColumn,
            this.supNameDataGridViewTextBoxColumn});
            this.dgvSuppliers.DataSource = this.supplierBindingSource;
            this.dgvSuppliers.Location = new System.Drawing.Point(13, 13);
            this.dgvSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.RowHeadersWidth = 51;
            this.dgvSuppliers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSuppliers.Size = new System.Drawing.Size(851, 278);
            this.dgvSuppliers.TabIndex = 27;
            this.dgvSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuppliers_CellClick);
            // 
            // supplierIdDataGridViewTextBoxColumn
            // 
            this.supplierIdDataGridViewTextBoxColumn.DataPropertyName = "SupplierId";
            this.supplierIdDataGridViewTextBoxColumn.HeaderText = "SupplierId";
            this.supplierIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.supplierIdDataGridViewTextBoxColumn.Name = "supplierIdDataGridViewTextBoxColumn";
            this.supplierIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // supNameDataGridViewTextBoxColumn
            // 
            this.supNameDataGridViewTextBoxColumn.DataPropertyName = "SupName";
            this.supNameDataGridViewTextBoxColumn.HeaderText = "SupName";
            this.supNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.supNameDataGridViewTextBoxColumn.Name = "supNameDataGridViewTextBoxColumn";
            this.supNameDataGridViewTextBoxColumn.Width = 454;
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(WEAT_Solutions_Main_Project.Supplier);
            // 
            // travelExpertsDataContextBindingSource
            // 
            this.travelExpertsDataContextBindingSource.DataSource = typeof(WEAT_Solutions_Main_Project.TravelExpertsDataContext);
            // 
            // frmAddEditSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 553);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvSuppliers);
            this.Name = "frmAddEditSuppliers";
            this.Text = "frmAddEditSuppliers";
            this.Load += new System.EventHandler(this.frmAddEditSuppliers_Load);
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelExpertsDataContextBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSuppID;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.ListBox lbAssigned;
        private System.Windows.Forms.ListBox lbAvail;
        private System.Windows.Forms.Button btnRmvProd;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.BindingSource travelExpertsDataContextBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supNameDataGridViewTextBoxColumn;
    }
}