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
            for (int i = 0; i < 7; i++) // "they" say seven times is the best (one time was kinda weak in any case)
            {
                while (cards.Count > 0)
                {
                    Random rand = new Random();
                    int selected = rand.Next(cards.Count); // get an index to move to the new deck
                    shuffledDeck.Add(cards.ElementAt(selected)); // move it
                    cards.RemoveAt(selected); // remove it from consideration
                }
                cards = shuffledDeck;  // replace deck
            }
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
            int cardCount = 0;
            foreach (Card c in cards)
            {
                stringified += c.ToString();
                //every third card do a newline instead of a tab
                stringified += ((cardCount % 3) == 2) ? "\r\n" : "\t";
                cardCount++;
            }

            return stringified;
        }
    }// end of class
} // end of namespace

