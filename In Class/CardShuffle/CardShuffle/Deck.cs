using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffle
{
    public class Deck : Card
    {
        private const int NUMBER_OF_CARDS = 52;
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

        public void setupDeck()
        {
            int i = 0; // index for deck array
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    Card next = new Card { SUIT = s, RANK = r };
                    cards.Add(next);
                    i++;
                }
            }

        }
        public  int Count()
        {
            return cards.Count;
        }

        public Card GetCard(int i)
        {
            return cards.ElementAt(i);
        }

        public int GetValue(string s)
        {
            return GetRank(s);
        }

        public void RemoveAt(int i)
        {
            cards.RemoveAt(i);
        }
        public override string ToString()
        {
            string stringified = "Deck of " + cards.Count + " Cards:\r-----------------\r\n";
            foreach (Card c in cards)
            {
                stringified += c.ToString() + "\t";
            }
            return stringified;
        }
    }// end of class
} // end of namespace

