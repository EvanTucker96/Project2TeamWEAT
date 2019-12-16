namespace CardGame
{
    partial class frmCards
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
            this.txtCardList = new System.Windows.Forms.TextBox();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCardList
            // 
            this.txtCardList.AcceptsReturn = true;
            this.txtCardList.Location = new System.Drawing.Point(93, 12);
            this.txtCardList.Multiline = true;
            this.txtCardList.Name = "txtCardList";
            this.txtCardList.ReadOnly = true;
            this.txtCardList.Size = new System.Drawing.Size(209, 926);
            this.txtCardList.TabIndex = 0;
            // 
            // btnShuffle
            // 
            this.btnShuffle.Location = new System.Drawing.Point(12, 12);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(75, 23);
            this.btnShuffle.TabIndex = 1;
            this.btnShuffle.Text = "&Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // frmCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 961);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.txtCardList);
            this.Name = "frmCards";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCardList;
        private System.Windows.Forms.Button btnShuffle;
    }
}

