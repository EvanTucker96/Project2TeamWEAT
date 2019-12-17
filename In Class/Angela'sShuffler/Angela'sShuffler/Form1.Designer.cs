namespace Angela_sShuffler
{
    partial class Form1
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
            this.lstDeck = new System.Windows.Forms.ListBox();
            this.btnNewDeck = new System.Windows.Forms.Button();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDeck
            // 
            this.lstDeck.FormattingEnabled = true;
            this.lstDeck.ItemHeight = 23;
            this.lstDeck.Location = new System.Drawing.Point(27, 30);
            this.lstDeck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lstDeck.Name = "lstDeck";
            this.lstDeck.Size = new System.Drawing.Size(404, 395);
            this.lstDeck.TabIndex = 0;
            // 
            // btnNewDeck
            // 
            this.btnNewDeck.Location = new System.Drawing.Point(530, 35);
            this.btnNewDeck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnNewDeck.Name = "btnNewDeck";
            this.btnNewDeck.Size = new System.Drawing.Size(263, 90);
            this.btnNewDeck.TabIndex = 1;
            this.btnNewDeck.Text = "New Deck";
            this.btnNewDeck.UseVisualStyleBackColor = true;
            // 
            // btnShuffle
            // 
            this.btnShuffle.Location = new System.Drawing.Point(530, 171);
            this.btnShuffle.Margin = new System.Windows.Forms.Padding(5);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(263, 90);
            this.btnShuffle.TabIndex = 2;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 454);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.btnNewDeck);
            this.Controls.Add(this.lstDeck);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDeck;
        private System.Windows.Forms.Button btnNewDeck;
        private System.Windows.Forms.Button btnShuffle;
    }
}

