using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardShuffle
{
    public partial class frmCardShuffle : Form
    {
        Deck cardDeck = new Deck();
        public frmCardShuffle()
        {
            InitializeComponent();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            cardDeck.setupDeck();
            cardDeck.Shuffle();
            RefreshCards();
        }

        private void RefreshCards()
        {
            txtCardDisplay.Text = cardDeck.ToString();
        }
    }
}
