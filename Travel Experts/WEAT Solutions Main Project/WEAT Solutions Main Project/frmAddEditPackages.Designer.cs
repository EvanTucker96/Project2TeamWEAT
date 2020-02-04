namespace WEAT_Solutions_Main_Project
{
    partial class frmAddEditPackages
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
            System.Windows.Forms.Label packageIdLabel;
            System.Windows.Forms.Label pkgAgencyCommissionLabel;
            System.Windows.Forms.Label pkgBasePriceLabel;
            System.Windows.Forms.Label pkgDescLabel;
            System.Windows.Forms.Label pkgEndDateLabel;
            System.Windows.Forms.Label pkgNameLabel;
            System.Windows.Forms.Label pkgStartDateLabel;
            this.txtPackageID = new System.Windows.Forms.TextBox();
            this.packageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtPakComm = new System.Windows.Forms.TextBox();
            this.txtPkgBase = new System.Windows.Forms.TextBox();
            this.txtPkgDesc = new System.Windows.Forms.TextBox();
            this.dtpPkgEnd = new System.Windows.Forms.DateTimePicker();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.dtpPkgStart = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.packageIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkgNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkgStartDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkgEndDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkgDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkgBasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkgAgencyCommissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.btnRmvProd = new System.Windows.Forms.Button();
            this.lbAvail = new System.Windows.Forms.ListBox();
            this.lbAssigned = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            packageIdLabel = new System.Windows.Forms.Label();
            pkgAgencyCommissionLabel = new System.Windows.Forms.Label();
            pkgBasePriceLabel = new System.Windows.Forms.Label();
            pkgDescLabel = new System.Windows.Forms.Label();
            pkgEndDateLabel = new System.Windows.Forms.Label();
            pkgNameLabel = new System.Windows.Forms.Label();
            pkgStartDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // packageIdLabel
            // 
            packageIdLabel.AutoSize = true;
            packageIdLabel.Location = new System.Drawing.Point(33, 31);
            packageIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            packageIdLabel.Name = "packageIdLabel";
            packageIdLabel.Size = new System.Drawing.Size(82, 17);
            packageIdLabel.TabIndex = 15;
            packageIdLabel.Text = "Package Id:";
            // 
            // pkgAgencyCommissionLabel
            // 
            pkgAgencyCommissionLabel.AutoSize = true;
            pkgAgencyCommissionLabel.Location = new System.Drawing.Point(513, 130);
            pkgAgencyCommissionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgAgencyCommissionLabel.Name = "pkgAgencyCommissionLabel";
            pkgAgencyCommissionLabel.Size = new System.Drawing.Size(138, 17);
            pkgAgencyCommissionLabel.TabIndex = 9;
            pkgAgencyCommissionLabel.Text = "Agency Commission:";
            // 
            // pkgBasePriceLabel
            // 
            pkgBasePriceLabel.AutoSize = true;
            pkgBasePriceLabel.Location = new System.Drawing.Point(513, 98);
            pkgBasePriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgBasePriceLabel.Name = "pkgBasePriceLabel";
            pkgBasePriceLabel.Size = new System.Drawing.Size(80, 17);
            pkgBasePriceLabel.TabIndex = 10;
            pkgBasePriceLabel.Text = "Base Price:";
            // 
            // pkgDescLabel
            // 
            pkgDescLabel.AutoSize = true;
            pkgDescLabel.Location = new System.Drawing.Point(33, 98);
            pkgDescLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgDescLabel.Name = "pkgDescLabel";
            pkgDescLabel.Size = new System.Drawing.Size(83, 17);
            pkgDescLabel.TabIndex = 13;
            pkgDescLabel.Text = "Description:";
            // 
            // pkgEndDateLabel
            // 
            pkgEndDateLabel.AutoSize = true;
            pkgEndDateLabel.Location = new System.Drawing.Point(513, 64);
            pkgEndDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgEndDateLabel.Name = "pkgEndDateLabel";
            pkgEndDateLabel.Size = new System.Drawing.Size(71, 17);
            pkgEndDateLabel.TabIndex = 11;
            pkgEndDateLabel.Text = "End Date:";
            // 
            // pkgNameLabel
            // 
            pkgNameLabel.AutoSize = true;
            pkgNameLabel.Location = new System.Drawing.Point(33, 66);
            pkgNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgNameLabel.Name = "pkgNameLabel";
            pkgNameLabel.Size = new System.Drawing.Size(108, 17);
            pkgNameLabel.TabIndex = 14;
            pkgNameLabel.Text = "Package Name:";
            // 
            // pkgStartDateLabel
            // 
            pkgStartDateLabel.AutoSize = true;
            pkgStartDateLabel.Location = new System.Drawing.Point(513, 32);
            pkgStartDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            pkgStartDateLabel.Name = "pkgStartDateLabel";
            pkgStartDateLabel.Size = new System.Drawing.Size(76, 17);
            pkgStartDateLabel.TabIndex = 12;
            pkgStartDateLabel.Text = "Start Date:";
            // 
            // txtPackageID
            // 
            this.txtPackageID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PackageId", true));
            this.txtPackageID.Enabled = false;
            this.txtPackageID.Location = new System.Drawing.Point(209, 27);
            this.txtPackageID.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackageID.Name = "txtPackageID";
            this.txtPackageID.Size = new System.Drawing.Size(265, 22);
            this.txtPackageID.TabIndex = 2;
            // 
            // packageBindingSource
            // 
            this.packageBindingSource.DataSource = typeof(WEAT_Solutions_Main_Project.Package);
            // 
            // txtPakComm
            // 
            this.txtPakComm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgAgencyCommission", true));
            this.txtPakComm.Location = new System.Drawing.Point(689, 126);
            this.txtPakComm.Margin = new System.Windows.Forms.Padding(4);
            this.txtPakComm.Name = "txtPakComm";
            this.txtPakComm.Size = new System.Drawing.Size(265, 22);
            this.txtPakComm.TabIndex = 8;
            this.txtPakComm.TextChanged += new System.EventHandler(this.txtPakComm_TextChanged);
            this.txtPakComm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPakComm_KeyPress);
            // 
            // txtPkgBase
            // 
            this.txtPkgBase.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgBasePrice", true));
            this.txtPkgBase.Location = new System.Drawing.Point(689, 94);
            this.txtPkgBase.Margin = new System.Windows.Forms.Padding(4);
            this.txtPkgBase.Name = "txtPkgBase";
            this.txtPkgBase.Size = new System.Drawing.Size(265, 22);
            this.txtPkgBase.TabIndex = 7;
            this.txtPkgBase.TextChanged += new System.EventHandler(this.txtPkgBase_TextChanged);
            this.txtPkgBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPkgBase_KeyPress);
            // 
            // txtPkgDesc
            // 
            this.txtPkgDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgDesc", true));
            this.txtPkgDesc.Location = new System.Drawing.Point(209, 94);
            this.txtPkgDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtPkgDesc.Multiline = true;
            this.txtPkgDesc.Name = "txtPkgDesc";
            this.txtPkgDesc.Size = new System.Drawing.Size(265, 54);
            this.txtPkgDesc.TabIndex = 4;
            this.txtPkgDesc.TextChanged += new System.EventHandler(this.txtPkgDesc_TextChanged);
            // 
            // dtpPkgEnd
            // 
            this.dtpPkgEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packageBindingSource, "PkgEndDate", true));
            this.dtpPkgEnd.Location = new System.Drawing.Point(689, 59);
            this.dtpPkgEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPkgEnd.Name = "dtpPkgEnd";
            this.dtpPkgEnd.Size = new System.Drawing.Size(265, 22);
            this.dtpPkgEnd.TabIndex = 6;
            this.dtpPkgEnd.ValueChanged += new System.EventHandler(this.dtpPkgEnd_ValueChanged);
            // 
            // txtPkgName
            // 
            this.txtPkgName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgName", true));
            this.txtPkgName.Location = new System.Drawing.Point(209, 62);
            this.txtPkgName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(265, 22);
            this.txtPkgName.TabIndex = 3;
            this.txtPkgName.TextChanged += new System.EventHandler(this.txtPkgName_TextChanged);
            // 
            // dtpPkgStart
            // 
            this.dtpPkgStart.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packageBindingSource, "PkgStartDate", true));
            this.dtpPkgStart.Location = new System.Drawing.Point(689, 27);
            this.dtpPkgStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPkgStart.Name = "dtpPkgStart";
            this.dtpPkgStart.Size = new System.Drawing.Size(265, 22);
            this.dtpPkgStart.TabIndex = 5;
            this.dtpPkgStart.ValueChanged += new System.EventHandler(this.dtpPkgStart_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.packageIdDataGridViewTextBoxColumn,
            this.pkgNameDataGridViewTextBoxColumn,
            this.pkgStartDateDataGridViewTextBoxColumn,
            this.pkgEndDateDataGridViewTextBoxColumn,
            this.pkgDescDataGridViewTextBoxColumn,
            this.pkgBasePriceDataGridViewTextBoxColumn,
            this.pkgAgencyCommissionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.packageBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1379, 278);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // packageIdDataGridViewTextBoxColumn
            // 
            this.packageIdDataGridViewTextBoxColumn.DataPropertyName = "PackageId";
            this.packageIdDataGridViewTextBoxColumn.HeaderText = "PackageId";
            this.packageIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.packageIdDataGridViewTextBoxColumn.Name = "packageIdDataGridViewTextBoxColumn";
            this.packageIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // pkgNameDataGridViewTextBoxColumn
            // 
            this.pkgNameDataGridViewTextBoxColumn.DataPropertyName = "PkgName";
            this.pkgNameDataGridViewTextBoxColumn.HeaderText = "PkgName";
            this.pkgNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pkgNameDataGridViewTextBoxColumn.Name = "pkgNameDataGridViewTextBoxColumn";
            this.pkgNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // pkgStartDateDataGridViewTextBoxColumn
            // 
            this.pkgStartDateDataGridViewTextBoxColumn.DataPropertyName = "PkgStartDate";
            this.pkgStartDateDataGridViewTextBoxColumn.HeaderText = "PkgStartDate";
            this.pkgStartDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pkgStartDateDataGridViewTextBoxColumn.Name = "pkgStartDateDataGridViewTextBoxColumn";
            this.pkgStartDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // pkgEndDateDataGridViewTextBoxColumn
            // 
            this.pkgEndDateDataGridViewTextBoxColumn.DataPropertyName = "PkgEndDate";
            this.pkgEndDateDataGridViewTextBoxColumn.HeaderText = "PkgEndDate";
            this.pkgEndDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pkgEndDateDataGridViewTextBoxColumn.Name = "pkgEndDateDataGridViewTextBoxColumn";
            this.pkgEndDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // pkgDescDataGridViewTextBoxColumn
            // 
            this.pkgDescDataGridViewTextBoxColumn.DataPropertyName = "PkgDesc";
            this.pkgDescDataGridViewTextBoxColumn.HeaderText = "PkgDesc";
            this.pkgDescDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pkgDescDataGridViewTextBoxColumn.Name = "pkgDescDataGridViewTextBoxColumn";
            this.pkgDescDataGridViewTextBoxColumn.Width = 250;
            // 
            // pkgBasePriceDataGridViewTextBoxColumn
            // 
            this.pkgBasePriceDataGridViewTextBoxColumn.DataPropertyName = "PkgBasePrice";
            this.pkgBasePriceDataGridViewTextBoxColumn.HeaderText = "PkgBasePrice";
            this.pkgBasePriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pkgBasePriceDataGridViewTextBoxColumn.Name = "pkgBasePriceDataGridViewTextBoxColumn";
            this.pkgBasePriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // pkgAgencyCommissionDataGridViewTextBoxColumn
            // 
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.DataPropertyName = "PkgAgencyCommission";
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.HeaderText = "PkgAgencyCommission";
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.Name = "pkgAgencyCommissionDataGridViewTextBoxColumn";
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.Width = 125;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1284, 583);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 41);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddProd
            // 
            this.btnAddProd.Location = new System.Drawing.Point(536, 177);
            this.btnAddProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(100, 28);
            this.btnAddProd.TabIndex = 19;
            this.btnAddProd.Text = "<<";
            this.btnAddProd.UseVisualStyleBackColor = true;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // btnRmvProd
            // 
            this.btnRmvProd.Location = new System.Drawing.Point(536, 269);
            this.btnRmvProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnRmvProd.Name = "btnRmvProd";
            this.btnRmvProd.Size = new System.Drawing.Size(100, 28);
            this.btnRmvProd.TabIndex = 20;
            this.btnRmvProd.Text = ">>";
            this.btnRmvProd.UseVisualStyleBackColor = true;
            this.btnRmvProd.Click += new System.EventHandler(this.btnRmvProd_Click);
            // 
            // lbAvail
            // 
            this.lbAvail.FormattingEnabled = true;
            this.lbAvail.ItemHeight = 16;
            this.lbAvail.Location = new System.Drawing.Point(689, 177);
            this.lbAvail.Margin = new System.Windows.Forms.Padding(4);
            this.lbAvail.Name = "lbAvail";
            this.lbAvail.Size = new System.Drawing.Size(265, 116);
            this.lbAvail.TabIndex = 21;
            this.lbAvail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbAvail_MouseClick);
            // 
            // lbAssigned
            // 
            this.lbAssigned.FormattingEnabled = true;
            this.lbAssigned.ItemHeight = 16;
            this.lbAssigned.Location = new System.Drawing.Point(209, 177);
            this.lbAssigned.Margin = new System.Windows.Forms.Padding(4);
            this.lbAssigned.Name = "lbAssigned";
            this.lbAssigned.Size = new System.Drawing.Size(265, 116);
            this.lbAssigned.TabIndex = 22;
            this.lbAssigned.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbAssigned_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(1284, 508);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 41);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(536, 220);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 32);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(1283, 446);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 41);
            this.btnNew.TabIndex = 25;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.label3);
            this.gbDetails.Controls.Add(this.label2);
            this.gbDetails.Controls.Add(this.label1);
            this.gbDetails.Controls.Add(this.txtPackageID);
            this.gbDetails.Controls.Add(this.dtpPkgStart);
            this.gbDetails.Controls.Add(this.btnReset);
            this.gbDetails.Controls.Add(pkgStartDateLabel);
            this.gbDetails.Controls.Add(this.txtPkgName);
            this.gbDetails.Controls.Add(this.lbAssigned);
            this.gbDetails.Controls.Add(pkgNameLabel);
            this.gbDetails.Controls.Add(this.lbAvail);
            this.gbDetails.Controls.Add(this.dtpPkgEnd);
            this.gbDetails.Controls.Add(this.btnRmvProd);
            this.gbDetails.Controls.Add(pkgEndDateLabel);
            this.gbDetails.Controls.Add(this.btnAddProd);
            this.gbDetails.Controls.Add(this.txtPkgDesc);
            this.gbDetails.Controls.Add(pkgDescLabel);
            this.gbDetails.Controls.Add(this.txtPkgBase);
            this.gbDetails.Controls.Add(packageIdLabel);
            this.gbDetails.Controls.Add(pkgBasePriceLabel);
            this.gbDetails.Controls.Add(this.txtPakComm);
            this.gbDetails.Controls.Add(pkgAgencyCommissionLabel);
            this.gbDetails.Enabled = false;
            this.gbDetails.Location = new System.Drawing.Point(16, 313);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDetails.Size = new System.Drawing.Size(1227, 311);
            this.gbDetails.TabIndex = 26;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Package Details";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(206, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 22);
            this.label5.TabIndex = 31;
            this.label5.Text = "Products assigned to this Package";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(686, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 22);
            this.label4.TabIndex = 30;
            this.label4.Text = "Products available to this Package";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(961, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "Must be at numbers only";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(961, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Must be at numbers only";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(961, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Must be at least 1 day after start date";
            // 
            // frmAddEditPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 652);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddEditPackages";
            this.Text = "frmAddEditPackages";
            this.Load += new System.EventHandler(this.frmAddEditPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource packageBindingSource;
        private System.Windows.Forms.TextBox txtPackageID;
        private System.Windows.Forms.TextBox txtPakComm;
        private System.Windows.Forms.TextBox txtPkgBase;
        private System.Windows.Forms.TextBox txtPkgDesc;
        private System.Windows.Forms.DateTimePicker dtpPkgEnd;
        private System.Windows.Forms.TextBox txtPkgName;
        private System.Windows.Forms.DateTimePicker dtpPkgStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkgNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkgStartDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkgEndDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkgDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkgBasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkgAgencyCommissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.Button btnRmvProd;
        private System.Windows.Forms.ListBox lbAvail;
        private System.Windows.Forms.ListBox lbAssigned;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}