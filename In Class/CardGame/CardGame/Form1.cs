using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class frmCards : Form
    {
        Deck cardDeck = new Deck();
        public frmCards()
        {
            InitializeComponent();
            RefreshCards();
        }


        public void RefreshCards()
        {
            txtCardList.Text = cardDeck.ToString();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            cardDeck.Shuffle();
            RefreshCards();
        }
    }
}
