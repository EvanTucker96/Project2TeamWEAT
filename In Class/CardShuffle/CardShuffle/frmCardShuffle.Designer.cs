namespace CardShuffle
{
    partial class frmCardShuffle
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
            this.txtCardDisplay = new System.Windows.Forms.TextBox();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCardDisplay
            // 
            this.txtCardDisplay.Enabled = false;
            this.txtCardDisplay.Location = new System.Drawing.Point(211, 34);
            this.txtCardDisplay.Multiline = true;
            this.txtCardDisplay.Name = "txtCardDisplay";
            this.txtCardDisplay.Size = new System.Drawing.Size(318, 377);
            this.txtCardDisplay.TabIndex = 0;
            // 
            // btnShuffle
            // 
            this.btnShuffle.Location = new System.Drawing.Point(50, 57);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(75, 23);
            this.btnShuffle.TabIndex = 1;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // frmCardShuffle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.txtCardDisplay);
            this.Name = "frmCardShuffle";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCardDisplay;
        private System.Windows.Forms.Button btnShuffle;
    }
}

