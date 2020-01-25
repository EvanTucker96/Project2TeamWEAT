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
            packageIdLabel = new System.Windows.Forms.Label();
            pkgAgencyCommissionLabel = new System.Windows.Forms.Label();
            pkgBasePriceLabel = new System.Windows.Forms.Label();
            pkgDescLabel = new System.Windows.Forms.Label();
            pkgEndDateLabel = new System.Windows.Forms.Label();
            pkgNameLabel = new System.Windows.Forms.Label();
            pkgStartDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // packageIdLabel
            // 
            packageIdLabel.AutoSize = true;
            packageIdLabel.Location = new System.Drawing.Point(12, 175);
            packageIdLabel.Name = "packageIdLabel";
            packageIdLabel.Size = new System.Drawing.Size(65, 13);
            packageIdLabel.TabIndex = 15;
            packageIdLabel.Text = "Package Id:";
            // 
            // pkgAgencyCommissionLabel
            // 
            pkgAgencyCommissionLabel.AutoSize = true;
            pkgAgencyCommissionLabel.Location = new System.Drawing.Point(372, 255);
            pkgAgencyCommissionLabel.Name = "pkgAgencyCommissionLabel";
            pkgAgencyCommissionLabel.Size = new System.Drawing.Size(126, 13);
            pkgAgencyCommissionLabel.TabIndex = 9;
            pkgAgencyCommissionLabel.Text = "Pkg Agency Commission:";
            // 
            // pkgBasePriceLabel
            // 
            pkgBasePriceLabel.AutoSize = true;
            pkgBasePriceLabel.Location = new System.Drawing.Point(372, 229);
            pkgBasePriceLabel.Name = "pkgBasePriceLabel";
            pkgBasePriceLabel.Size = new System.Drawing.Size(83, 13);
            pkgBasePriceLabel.TabIndex = 10;
            pkgBasePriceLabel.Text = "Pkg Base Price:";
            // 
            // pkgDescLabel
            // 
            pkgDescLabel.AutoSize = true;
            pkgDescLabel.Location = new System.Drawing.Point(12, 229);
            pkgDescLabel.Name = "pkgDescLabel";
            pkgDescLabel.Size = new System.Drawing.Size(57, 13);
            pkgDescLabel.TabIndex = 13;
            pkgDescLabel.Text = "Pkg Desc:";
            // 
            // pkgEndDateLabel
            // 
            pkgEndDateLabel.AutoSize = true;
            pkgEndDateLabel.Location = new System.Drawing.Point(372, 202);
            pkgEndDateLabel.Name = "pkgEndDateLabel";
            pkgEndDateLabel.Size = new System.Drawing.Size(77, 13);
            pkgEndDateLabel.TabIndex = 11;
            pkgEndDateLabel.Text = "Pkg End Date:";
            // 
            // pkgNameLabel
            // 
            pkgNameLabel.AutoSize = true;
            pkgNameLabel.Location = new System.Drawing.Point(12, 203);
            pkgNameLabel.Name = "pkgNameLabel";
            pkgNameLabel.Size = new System.Drawing.Size(60, 13);
            pkgNameLabel.TabIndex = 14;
            pkgNameLabel.Text = "Pkg Name:";
            // 
            // pkgStartDateLabel
            // 
            pkgStartDateLabel.AutoSize = true;
            pkgStartDateLabel.Location = new System.Drawing.Point(372, 176);
            pkgStartDateLabel.Name = "pkgStartDateLabel";
            pkgStartDateLabel.Size = new System.Drawing.Size(80, 13);
            pkgStartDateLabel.TabIndex = 12;
            pkgStartDateLabel.Text = "Pkg Start Date:";
            // 
            // txtPackageID
            // 
            this.txtPackageID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PackageId", true));
            this.txtPackageID.Location = new System.Drawing.Point(144, 172);
            this.txtPackageID.Name = "txtPackageID";
            this.txtPackageID.Size = new System.Drawing.Size(200, 20);
            this.txtPackageID.TabIndex = 2;
            // 
            // packageBindingSource
            // 
            this.packageBindingSource.DataSource = typeof(WEAT_Solutions_Main_Project.Package);
            // 
            // txtPakComm
            // 
            this.txtPakComm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgAgencyCommission", true));
            this.txtPakComm.Location = new System.Drawing.Point(504, 252);
            this.txtPakComm.Name = "txtPakComm";
            this.txtPakComm.Size = new System.Drawing.Size(200, 20);
            this.txtPakComm.TabIndex = 8;
            // 
            // txtPkgBase
            // 
            this.txtPkgBase.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgBasePrice", true));
            this.txtPkgBase.Location = new System.Drawing.Point(504, 226);
            this.txtPkgBase.Name = "txtPkgBase";
            this.txtPkgBase.Size = new System.Drawing.Size(200, 20);
            this.txtPkgBase.TabIndex = 7;
            // 
            // txtPkgDesc
            // 
            this.txtPkgDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgDesc", true));
            this.txtPkgDesc.Location = new System.Drawing.Point(144, 226);
            this.txtPkgDesc.Multiline = true;
            this.txtPkgDesc.Name = "txtPkgDesc";
            this.txtPkgDesc.Size = new System.Drawing.Size(200, 57);
            this.txtPkgDesc.TabIndex = 4;
            // 
            // dtpPkgEnd
            // 
            this.dtpPkgEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packageBindingSource, "PkgEndDate", true));
            this.dtpPkgEnd.Location = new System.Drawing.Point(504, 198);
            this.dtpPkgEnd.Name = "dtpPkgEnd";
            this.dtpPkgEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpPkgEnd.TabIndex = 6;
            // 
            // txtPkgName
            // 
            this.txtPkgName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.packageBindingSource, "PkgName", true));
            this.txtPkgName.Location = new System.Drawing.Point(144, 200);
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(200, 20);
            this.txtPkgName.TabIndex = 3;
            // 
            // dtpPkgStart
            // 
            this.dtpPkgStart.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.packageBindingSource, "PkgStartDate", true));
            this.dtpPkgStart.Location = new System.Drawing.Point(504, 172);
            this.dtpPkgStart.Name = "dtpPkgStart";
            this.dtpPkgStart.Size = new System.Drawing.Size(200, 20);
            this.dtpPkgStart.TabIndex = 5;
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1025, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // packageIdDataGridViewTextBoxColumn
            // 
            this.packageIdDataGridViewTextBoxColumn.DataPropertyName = "PackageId";
            this.packageIdDataGridViewTextBoxColumn.HeaderText = "PackageId";
            this.packageIdDataGridViewTextBoxColumn.Name = "packageIdDataGridViewTextBoxColumn";
            this.packageIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // pkgNameDataGridViewTextBoxColumn
            // 
            this.pkgNameDataGridViewTextBoxColumn.DataPropertyName = "PkgName";
            this.pkgNameDataGridViewTextBoxColumn.HeaderText = "PkgName";
            this.pkgNameDataGridViewTextBoxColumn.Name = "pkgNameDataGridViewTextBoxColumn";
            this.pkgNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // pkgStartDateDataGridViewTextBoxColumn
            // 
            this.pkgStartDateDataGridViewTextBoxColumn.DataPropertyName = "PkgStartDate";
            this.pkgStartDateDataGridViewTextBoxColumn.HeaderText = "PkgStartDate";
            this.pkgStartDateDataGridViewTextBoxColumn.Name = "pkgStartDateDataGridViewTextBoxColumn";
            this.pkgStartDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // pkgEndDateDataGridViewTextBoxColumn
            // 
            this.pkgEndDateDataGridViewTextBoxColumn.DataPropertyName = "PkgEndDate";
            this.pkgEndDateDataGridViewTextBoxColumn.HeaderText = "PkgEndDate";
            this.pkgEndDateDataGridViewTextBoxColumn.Name = "pkgEndDateDataGridViewTextBoxColumn";
            this.pkgEndDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // pkgDescDataGridViewTextBoxColumn
            // 
            this.pkgDescDataGridViewTextBoxColumn.DataPropertyName = "PkgDesc";
            this.pkgDescDataGridViewTextBoxColumn.HeaderText = "PkgDesc";
            this.pkgDescDataGridViewTextBoxColumn.Name = "pkgDescDataGridViewTextBoxColumn";
            this.pkgDescDataGridViewTextBoxColumn.Width = 250;
            // 
            // pkgBasePriceDataGridViewTextBoxColumn
            // 
            this.pkgBasePriceDataGridViewTextBoxColumn.DataPropertyName = "PkgBasePrice";
            this.pkgBasePriceDataGridViewTextBoxColumn.HeaderText = "PkgBasePrice";
            this.pkgBasePriceDataGridViewTextBoxColumn.Name = "pkgBasePriceDataGridViewTextBoxColumn";
            this.pkgBasePriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // pkgAgencyCommissionDataGridViewTextBoxColumn
            // 
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.DataPropertyName = "PkgAgencyCommission";
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.HeaderText = "PkgAgencyCommission";
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.Name = "pkgAgencyCommissionDataGridViewTextBoxColumn";
            this.pkgAgencyCommissionDataGridViewTextBoxColumn.Width = 125;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(963, 405);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 33);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddProd
            // 
            this.btnAddProd.Location = new System.Drawing.Point(389, 289);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(75, 23);
            this.btnAddProd.TabIndex = 19;
            this.btnAddProd.Text = "<<";
            this.btnAddProd.UseVisualStyleBackColor = true;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // btnRmvProd
            // 
            this.btnRmvProd.Location = new System.Drawing.Point(389, 363);
            this.btnRmvProd.Name = "btnRmvProd";
            this.btnRmvProd.Size = new System.Drawing.Size(75, 23);
            this.btnRmvProd.TabIndex = 20;
            this.btnRmvProd.Text = ">>";
            this.btnRmvProd.UseVisualStyleBackColor = true;
            this.btnRmvProd.Click += new System.EventHandler(this.btnRmvProd_Click);
            // 
            // lbAvail
            // 
            this.lbAvail.FormattingEnabled = true;
            this.lbAvail.Location = new System.Drawing.Point(504, 289);
            this.lbAvail.Name = "lbAvail";
            this.lbAvail.Size = new System.Drawing.Size(200, 95);
            this.lbAvail.TabIndex = 21;
            // 
            // lbAssigned
            // 
            this.lbAssigned.FormattingEnabled = true;
            this.lbAssigned.Location = new System.Drawing.Point(144, 289);
            this.lbAssigned.Name = "lbAssigned";
            this.lbAssigned.Size = new System.Drawing.Size(200, 95);
            this.lbAssigned.TabIndex = 22;
            // 
            // frmAddEditPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 450);
            this.Controls.Add(this.lbAssigned);
            this.Controls.Add(this.lbAvail);
            this.Controls.Add(this.btnRmvProd);
            this.Controls.Add(this.btnAddProd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(packageIdLabel);
            this.Controls.Add(this.txtPackageID);
            this.Controls.Add(pkgAgencyCommissionLabel);
            this.Controls.Add(this.txtPakComm);
            this.Controls.Add(pkgBasePriceLabel);
            this.Controls.Add(this.txtPkgBase);
            this.Controls.Add(pkgDescLabel);
            this.Controls.Add(this.txtPkgDesc);
            this.Controls.Add(pkgEndDateLabel);
            this.Controls.Add(this.dtpPkgEnd);
            this.Controls.Add(pkgNameLabel);
            this.Controls.Add(this.txtPkgName);
            this.Controls.Add(pkgStartDateLabel);
            this.Controls.Add(this.dtpPkgStart);
            this.Name = "frmAddEditPackages";
            this.Text = "frmAddEditPackages";
            this.Load += new System.EventHandler(this.frmAddEditPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}