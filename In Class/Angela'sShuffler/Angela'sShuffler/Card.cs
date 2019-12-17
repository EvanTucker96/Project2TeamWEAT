using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela_sShuffler
{
    public class Card
    {
        private CardSuit Suit => Suit;
        private CardFace Face => Face;

        public Card(int mySuit, int myFace)
        {
            suit = (CardSuit)(mySuit);
            face = (CardFace)(myFace);
        }

        public CardSuit CardSuit
        {
            get { return Suit; }
        }

        public CardFace CardFace
        {
            get { return Face; }
        }
    }
}
