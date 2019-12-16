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

        public void btnShuffle_Click(object sender, EventArgs e)
        {
            
            //cardDeck.setupDeck();
            cardDeck.Shuffle();
            RefreshCards();
            btnDeal.Enabled = true;
            //btnClrHands.Enabled = true;
            //btnDealerHit.Enabled = true;
            //btnPlayerHit.Enabled = true;
        }

        private void RefreshCards()
        {
            //txtCardDisplay.Text = cardDeck.ToString();
            rtCards.Text = cardDeck.ToString();
           
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            int cardCheck = cardDeck.Count();
            if (cardCheck >= 4)
            {
                List<Card> playerHand = new List<Card>();
                List<Card> dealerHand = new List<Card>();
                string playerCards = "", dealerCards = "", temp;
                int player = 0, dealer = 0;


                while (playerHand.Count < 2)
                {
                    Random rand = new Random();
                    int cards = cardDeck.Count();
                    int selected = rand.Next(cards); // get an index to move to the new deck
                    playerHand.Add(cardDeck.GetCard(selected)); // move it
                    playerCards += cardDeck.GetCard(selected).ToString() + "\r\n";
                    temp = cardDeck.GetCard(selected).ToString();
                    string[] strlinst = temp.Split(' ');
                    player += cardDeck.GetValue(strlinst[1]);
                    cardDeck.RemoveAt(selected); // remove it from consideration
                    RefreshCards();
                }
                //for (int i = 0; i < playerHand.Count; i++)
                rtPLayer.Text = playerCards;
                lblPlayerHand.Text = player.ToString();

                while (dealerHand.Count < 2)
                {
                    Random rand = new Random();
                    int cards = cardDeck.Count();
                    int selected = rand.Next(cards); // get an index to move to the new deck
                    dealerHand.Add(cardDeck.GetCard(selected)); // move it
                    dealerCards += cardDeck.GetCard(selected).ToString() + "\r\n";
                    temp = cardDeck.GetCard(selected).ToString();
                    string[] strlinst = temp.Split(' ');
                    dealer += cardDeck.GetValue(strlinst[1]);
                    cardDeck.RemoveAt(selected); // remove it from consideration
                    RefreshCards();
                }
                //for (int i = 0; i < playerHand.Count; i++)
                rtDealer.Text = dealerCards;
                lblDealersHand.Text = dealer.ToString();
                btnClrHands.Enabled = true;
                btnDealerHit.Enabled = true;
                btnPlayerHit.Enabled = true;
                btnDeal.Enabled = false;
            }
            else
            {
                btnDealerHit.Enabled = false;
                btnPlayerHit.Enabled = false;
                btnDeal.Enabled = false;
                
            }
        }

        private void btnClrHands_Click(object sender, EventArgs e)
        {
            int checkCards;
            rtDealer.Text = "";
            rtPLayer.Text = "";
            lblDealersHand.Text = "";
            lblPlayerHand.Text = "";
            lblPlayerStat.Text = "";
            lblDealerStat.Text = "";
            btnClrHands.Enabled = false;
            btnDealerHit.Enabled = false;
            btnPlayerHit.Enabled = false;

            if ((checkCards = cardDeck.Count()) >= 4)
            {
                btnDeal.Enabled = true;
            }


        }

        private void btnPlayerHit_Click(object sender, EventArgs e)
        {
            int checkCards;
            if ((checkCards = cardDeck.Count()) >= 1)
            {
                string playerCards = "", temp;
            int player = 0, score;
            List<Card> playerHand = new List<Card>();
            Random rand = new Random();
            int cards = cardDeck.Count();
            int selected = rand.Next(cards); // get an index to move to the new deck
            playerHand.Add(cardDeck.GetCard(selected)); // move it
            playerCards += cardDeck.GetCard(selected).ToString() + "\r\n";
            temp = cardDeck.GetCard(selected).ToString();
            string[] strlinst = temp.Split(' ');
            player += cardDeck.GetValue(strlinst[1]);
            cardDeck.RemoveAt(selected); // remove it from consideration
            
            rtPLayer.Text += playerCards;
            if (lblPlayerHand.Text != "")
            {
                score = Convert.ToInt32(lblPlayerHand.Text) + player;
            }
            else
            {
                score = player;
            }
            
            if (score > 21)
            {
                lblPlayerStat.ForeColor = Color.Red;
                lblPlayerStat.Text = "BUST!";
                btnDealerHit.Enabled = false;
                btnPlayerHit.Enabled = false;
            }else if(score==21)
                {
                    lblPlayerStat.ForeColor = Color.Green;
                    lblPlayerStat.Text = "BLACKJACK!";
                    btnDealerHit.Enabled = false;
                    btnPlayerHit.Enabled = false;
                }
            lblPlayerHand.Text = score.ToString();
            RefreshCards();
            }
            else
            {
                btnDealerHit.Enabled = false;
                btnPlayerHit.Enabled = false;
                MessageBox.Show("Not enough Cards!");

            }
        }

        private void btnDealerHit_Click(object sender, EventArgs e)
        {
            int checkCards;
            if ((checkCards = cardDeck.Count()) >= 1)
            {
                string dealerCards = "", temp;
                int dealer = 0, score;
                List<Card> dealerHand = new List<Card>();
                Random rand = new Random();
                int cards = cardDeck.Count();
                int selected = rand.Next(cards); // get an index to move to the new deck
                dealerHand.Add(cardDeck.GetCard(selected)); // move it
                dealerCards += cardDeck.GetCard(selected).ToString() + "\r\n";
                temp = cardDeck.GetCard(selected).ToString();
                string[] strlinst = temp.Split(' ');
                dealer += cardDeck.GetValue(strlinst[1]);
                cardDeck.RemoveAt(selected); // remove it from consideration

                rtDealer.Text += dealerCards;
                if (lblDealersHand.Text != "")
                {
                    score = Convert.ToInt32(lblDealersHand.Text) + dealer;
                }
                else
                {
                    score = dealer;
                }
                if (score > 21)
                {
                    lblDealerStat.ForeColor = Color.Red;
                    lblDealerStat.Text = "BUST!";
                    btnDealerHit.Enabled = false;
                    btnPlayerHit.Enabled = false;
                }
                else if (score == 21)
                {
                    lblDealerStat.ForeColor = Color.Green;
                    lblDealerStat.Text = "BLACKJACK!";
                    btnDealerHit.Enabled = false;
                    btnPlayerHit.Enabled = false;
                }
                lblDealersHand.Text = score.ToString();
                RefreshCards();
            }
            else
            {
                btnDealerHit.Enabled = false;
                btnPlayerHit.Enabled = false;
                MessageBox.Show("Not enough Cards!");
            }
        }

        private void frmCardShuffle_Shown(object sender, EventArgs e)
        {
            cardDeck.setupDeck();
        }

        private void btnNewDeck_Click(object sender, EventArgs e)
        {
            cardDeck = new Deck();
            cardDeck.setupDeck();
            cardDeck.Shuffle();
            RefreshCards();
            btnDeal.Enabled = true;
        }
    }
}
