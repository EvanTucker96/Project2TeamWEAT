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

            cardDeck.Shuffle();
            RefreshCards();
            btnDeal.Enabled = true;
        }

        private void RefreshCards()
        {
            rtCards.Text = cardDeck.ToString();

        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            int cardCheck = cardDeck.Count(); // Get the current number of cards
            if (cardCheck >= 4) // only do this if we have atleast 4 cards remaining
            {
                DealOrHit(true, cardCheck, rtPLayer, lblPlayerHand, lblPlayerStat);
                DealOrHit(true, cardCheck, rtDealer, lblDealersHand, lblDealerStat);

                // enable the Clear Hands & Hit buttons, disable Deal
                btnClrHands.Enabled = true;
                btnDealerHit.Enabled = true;
                btnPlayerHit.Enabled = true;
                btnDeal.Enabled = false;
            }
            else // if we don't have enough cards, disable Actions
            {
                btnDealerHit.Enabled = false;
                btnPlayerHit.Enabled = false;
                btnDeal.Enabled = false;

            }
        }

        public void DealOrHit(bool Deal, int cardCount, RichTextBox rtb, Label lb, Label stat)
        {
            List<Card> Hand = new List<Card>(); // create a temporary List for Cards (empty)
            Random rand = new Random();
            string tmpCards = "", temp; // setup string variables
            int score = 0; // setup int variables for the hand score

            if (Deal) // only do this if we are dealing
            {
                while (Hand.Count < 2) // each deal gets 2 cards
                {
                    //Random rand = new Random(); // create a rand variable
                    //int cards = cardDeck.Count(); // get the current # cards in the deck
                    int selected = rand.Next(cardCount); // get an index to move to the new deck
                    Hand.Add(cardDeck.GetCard(selected)); // move it
                    tmpCards += cardDeck.GetCard(selected).ToString() + "\r\n"; //generate the string for RichTextBox
                    temp = cardDeck.GetCard(selected).ToString(); // temp container to hold the string that we will split
                    string[] strlinst = temp.Split(' '); // split string on space
                    score = cardDeck.GetValue(strlinst[1]); // get the Rank value of the card, position 1 is Rank
                                                             // add values together to get running total
                    cardDeck.RemoveAt(selected); // remove card from deck
                    RefreshCards(); // refresh the deck display
                }
                rtb.Text = tmpCards; // add the cards to the RT
                UpdateScore(lb,stat, score); // display the current hand value
            }
            else
            {
                int selected = rand.Next(cardCount); // get an index to move to the new deck
                Hand.Add(cardDeck.GetCard(selected)); // move it
                tmpCards += cardDeck.GetCard(selected).ToString() + "\r\n";
                temp = cardDeck.GetCard(selected).ToString();
                string[] strlinst = temp.Split(' ');
                //score = Convert.ToInt32(lb.Text);
                score = cardDeck.GetValue(strlinst[1]);
                cardDeck.RemoveAt(selected); // remove it from consideration
                UpdateScore(lb,stat, score);
                rtb.Text += tmpCards;
            }


        }

        private void btnClrHands_Click(object sender, EventArgs e)
        {
            int checkCards;
            rtDealer.Text = "";
            rtPLayer.Text = "";
            lblDealersHand.Text = "";
            lblDealersHand.ForeColor = Color.Black;
            lblPlayerHand.Text = "";
            lblPlayerHand.ForeColor = Color.Black;
            lblPlayerStat.Text = "";
            lblDealerStat.Text = "";
            btnClrHands.Enabled = false;
            btnDealerHit.Enabled = false;
            btnPlayerHit.Enabled = false;

            // only enable if we have 4 or more cards
            if ((checkCards = cardDeck.Count()) >= 4)
            {
                btnDeal.Enabled = true;
            }


        }

        private void btnPlayerHit_Click(object sender, EventArgs e)
        {
            int checkCards, score=0;
            if (lblPlayerHand.Text != "")
            {
                score = Convert.ToInt32(lblPlayerHand.Text);
            }
            if ((checkCards = cardDeck.Count()) >= 1 && score < 21)
            {
                DealOrHit(false, checkCards, rtPLayer, lblPlayerHand, lblPlayerStat);
                
            }
            else
            {
               
                MessageBox.Show("Not enough Cards!");

            }
        }

        private void UpdateScore(Label lb, Label stat, int score)
        {
            //int tmpScore = 0;
            if (lb.Text != "")
            {
                score += Convert.ToInt32(lb.Text); // + tmpScore;
            }
            

            if (score > 21)
            {
                stat.ForeColor = Color.Red;
                stat.Text = "BUST!";
                btnDealerHit.Enabled = false;
                btnPlayerHit.Enabled = false;
            }
            else if (score == 21)
            {
                stat.ForeColor = Color.Green;
                stat.Text = "BLACKJACK!";
                btnDealerHit.Enabled = false;
                btnPlayerHit.Enabled = false;
            }
            
            lb.Text = score.ToString();
            RefreshCards();
        
        }
    
            


        private void btnDealerHit_Click(object sender, EventArgs e)
        {
            int checkCards, score = 0;
            if (lblDealersHand.Text != "")
            {
                score = Convert.ToInt32(lblDealersHand.Text);
            }
            if ((checkCards = cardDeck.Count()) >= 1 && score < 21)
            {
            DealOrHit(false, checkCards, rtDealer, lblDealersHand, lblDealerStat);
                btnDealerHit.Enabled = true;
                btnPlayerHit.Enabled = true;

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
