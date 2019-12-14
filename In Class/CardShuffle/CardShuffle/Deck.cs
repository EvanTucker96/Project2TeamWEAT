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

        private Card[] deck; // array for Cards
        public Deck()
        {
            deck = new Card[NUMBER_OF_CARDS];// dimension array to 52
        }

        public Card[] getDeck { get { return deck; } }


        // create the deck
        public void setupDeck()
        {
            int i = 0; // index for deck array
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank r in Enum.GetValues(typeof(Rank)))
                {
                    deck[i] = new Card {SUIT = s,RANK = r };
                    i++;
                }
            }
            
        }

        public void Shuffle()
        {
            Random rand = new Random();
            Card temp;

            for (int shuffletimes = 0; shuffletimes <1000; shuffletimes++)
            {
                for(int i=0;i<NUMBER_OF_CARDS; i++)
                {
                    int secondcardindex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondcardindex];
                    deck[secondcardindex] = temp;
                }
            }

        }

        
        public override string ToString()
        {
            string stringified = "Deck of " + NUMBER_OF_CARDS + " Cards:\n-----------------\n";
            foreach (Card c in deck)
            {
                stringified += c.ToString() + "\n";
            }
            return stringified;
        }
    }// end of class
} // end of namespace

