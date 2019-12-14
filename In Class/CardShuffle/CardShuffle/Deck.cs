using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffle
{
    public class Deck
    {
        private const int NUMBER_OF_CARDS = 52;

        List<Card> cards = new List<Card>(); // create an empty list

        //public void Shuffle()
        //{
        //    var random = new System.Random();
        //    var n = NUMBER_OF_CARDS;

        //    for (var i = 0; i < n; i++)
        //    {
        //        var r = i + random.Next(n - i);
        //        var card = cards[r];
        //        cards[r] = cards[i];
        //        cards[i] = card;
        //    }
        //}

        public void Shuffle()
        {
            List<Card> shuffledDeck = new List<Card>(); // make a place to hold the new deck order
            while (cards.Count > 0)
            {
                Random rand = new Random();
                int selected = rand.Next(cards.Count); // get an index to move to the new deck
                shuffledDeck.Add(cards.ElementAt(selected)); // move it
                cards.RemoveAt(selected); // remove it from consideration
            }
            cards = shuffledDeck;  // replace deck
        }
        public Deck()
        {
            for (int j = 0; j < 3; j++) // loop through suits
            {
                for (int i = 0; i < NUMBER_OF_CARDS; i++) // loop through ranks
                {
                    Card next = new Card(i, j, j);
                    cards.Add(next);
                }
            }
        }
        public override string ToString()
        {
            string stringified = "Deck of " + cards.Count + " Cards:\n-----------------\n";
            foreach (Card c in cards)
            {
                stringified += c.ToString() + "\n";
            }
            return stringified;
        }
    }// end of class
} // end of namespace

