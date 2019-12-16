using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        List<Card> cards = new List<Card>();


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
            for (int j = 0; j < Card.Suits.Length; j++) // loop through suits
            {
                for (int i = 0; i < Card.Ranks.Length; i++) // loop through ranks
                {
                    Card next = new Card(i, j);
                    cards.Add(next);
                }
            }
        }

        public override string ToString()
        {
            string stringified = "Deck of " + cards.Count + " Cards:" + Environment.NewLine 
                                            + "-----------------" + Environment.NewLine;
            foreach (Card c in cards)
            {
                stringified += c.ToShortString() +Environment.NewLine;
            }
            return stringified;
        }

    }
}
