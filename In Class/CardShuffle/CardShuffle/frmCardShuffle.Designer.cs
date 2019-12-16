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
            this.btnShuffle = new System.Windows.Forms.Button();
            this.rtCards = new System.Windows.Forms.RichTextBox();
            this.rtPLayer = new System.Windows.Forms.RichTextBox();
            this.rtDealer = new System.Windows.Forms.RichTextBox();
            this.btnDeal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayerHand = new System.Windows.Forms.Label();
            this.lblDealersHand = new System.Windows.Forms.Label();
            this.btnClrHands = new System.Windows.Forms.Button();
            this.btnPlayerHit = new System.Windows.Forms.Button();
            this.btnDealerHit = new System.Windows.Forms.Button();
            this.lblPlayerStat = new System.Windows.Forms.Label();
            this.lblDealerStat = new System.Windows.Forms.Label();
            this.btnNewDeck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShuffle
            // 
            this.btnShuffle.Location = new System.Drawing.Point(434, 45);
            this.btnShuffle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(112, 35);
            this.btnShuffle.TabIndex = 1;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = true;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // rtCards
            // 
            this.rtCards.Location = new System.Drawing.Point(555, 45);
            this.rtCards.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtCards.Name = "rtCards";
            this.rtCards.Size = new System.Drawing.Size(595, 424);
            this.rtCards.TabIndex = 2;
            this.rtCards.Text = "";
            // 
            // rtPLayer
            // 
            this.rtPLayer.Location = new System.Drawing.Point(15, 182);
            this.rtPLayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtPLayer.Name = "rtPLayer";
            this.rtPLayer.Size = new System.Drawing.Size(204, 150);
            this.rtPLayer.TabIndex = 3;
            this.rtPLayer.Text = "";
            // 
            // rtDealer
            // 
            this.rtDealer.Location = new System.Drawing.Point(249, 182);
            this.rtDealer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtDealer.Name = "rtDealer";
            this.rtDealer.Size = new System.Drawing.Size(200, 150);
            this.rtDealer.TabIndex = 4;
            this.rtDealer.Text = "";
            // 
            // btnDeal
            // 
            this.btnDeal.Enabled = false;
            this.btnDeal.Location = new System.Drawing.Point(15, 89);
            this.btnDeal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(112, 35);
            this.btnDeal.TabIndex = 5;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Players Hand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 157);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dealers Hand";
            // 
            // lblPlayerHand
            // 
            this.lblPlayerHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlayerHand.Location = new System.Drawing.Point(15, 341);
            this.lblPlayerHand.Name = "lblPlayerHand";
            this.lblPlayerHand.Size = new System.Drawing.Size(106, 32);
            this.lblPlayerHand.TabIndex = 8;
            this.lblPlayerHand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDealersHand
            // 
            this.lblDealersHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDealersHand.Location = new System.Drawing.Point(255, 341);
            this.lblDealersHand.Name = "lblDealersHand";
            this.lblDealersHand.Size = new System.Drawing.Size(92, 32);
            this.lblDealersHand.TabIndex = 9;
            this.lblDealersHand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClrHands
            // 
            this.btnClrHands.Enabled = false;
            this.btnClrHands.Location = new System.Drawing.Point(249, 89);
            this.btnClrHands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClrHands.Name = "btnClrHands";
            this.btnClrHands.Size = new System.Drawing.Size(112, 35);
            this.btnClrHands.TabIndex = 10;
            this.btnClrHands.Text = "Clear Hands";
            this.btnClrHands.UseVisualStyleBackColor = true;
            this.btnClrHands.Click += new System.EventHandler(this.btnClrHands_Click);
            // 
            // btnPlayerHit
            // 
            this.btnPlayerHit.Enabled = false;
            this.btnPlayerHit.Location = new System.Drawing.Point(144, 341);
            this.btnPlayerHit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlayerHit.Name = "btnPlayerHit";
            this.btnPlayerHit.Size = new System.Drawing.Size(75, 35);
            this.btnPlayerHit.TabIndex = 11;
            this.btnPlayerHit.Text = "Hit!";
            this.btnPlayerHit.UseVisualStyleBackColor = true;
            this.btnPlayerHit.Click += new System.EventHandler(this.btnPlayerHit_Click);
            // 
            // btnDealerHit
            // 
            this.btnDealerHit.Enabled = false;
            this.btnDealerHit.Location = new System.Drawing.Point(374, 342);
            this.btnDealerHit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDealerHit.Name = "btnDealerHit";
            this.btnDealerHit.Size = new System.Drawing.Size(75, 35);
            this.btnDealerHit.TabIndex = 12;
            this.btnDealerHit.Text = "Hit!";
            this.btnDealerHit.UseVisualStyleBackColor = true;
            this.btnDealerHit.Click += new System.EventHandler(this.btnDealerHit_Click);
            // 
            // lblPlayerStat
            // 
            this.lblPlayerStat.Location = new System.Drawing.Point(18, 383);
            this.lblPlayerStat.Name = "lblPlayerStat";
            this.lblPlayerStat.Size = new System.Drawing.Size(201, 20);
            this.lblPlayerStat.TabIndex = 13;
            // 
            // lblDealerStat
            // 
            this.lblDealerStat.Location = new System.Drawing.Point(245, 383);
            this.lblDealerStat.Name = "lblDealerStat";
            this.lblDealerStat.Size = new System.Drawing.Size(204, 20);
            this.lblDealerStat.TabIndex = 14;
            // 
            // btnNewDeck
            // 
            this.btnNewDeck.Location = new System.Drawing.Point(435, 89);
            this.btnNewDeck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewDeck.Name = "btnNewDeck";
            this.btnNewDeck.Size = new System.Drawing.Size(112, 35);
            this.btnNewDeck.TabIndex = 15;
            this.btnNewDeck.Text = "New Deck";
            this.btnNewDeck.UseVisualStyleBackColor = true;
            this.btnNewDeck.Click += new System.EventHandler(this.btnNewDeck_Click);
            // 
            // frmCardShuffle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 540);
            this.Controls.Add(this.btnNewDeck);
            this.Controls.Add(this.lblDealerStat);
            this.Controls.Add(this.lblPlayerStat);
            this.Controls.Add(this.btnDealerHit);
            this.Controls.Add(this.btnPlayerHit);
            this.Controls.Add(this.btnClrHands);
            this.Controls.Add(this.lblDealersHand);
            this.Controls.Add(this.lblPlayerHand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.rtDealer);
            this.Controls.Add(this.rtPLayer);
            this.Controls.Add(this.rtCards);
            this.Controls.Add(this.btnShuffle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCardShuffle";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.frmCardShuffle_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.RichTextBox rtCards;
        private System.Windows.Forms.RichTextBox rtPLayer;
        private System.Windows.Forms.RichTextBox rtDealer;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlayerHand;
        private System.Windows.Forms.Label lblDealersHand;
        private System.Windows.Forms.Button btnClrHands;
        private System.Windows.Forms.Button btnPlayerHit;
        private System.Windows.Forms.Button btnDealerHit;
        private System.Windows.Forms.Label lblPlayerStat;
        private System.Windows.Forms.Label lblDealerStat;
        private System.Windows.Forms.Button btnNewDeck;
    }
}

