using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffle
{
    public class Card
    {
        // Public data items as nothing changes
        public enum Rank
        {
            Ace = 1, Two, Three, Four, Five,
            Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        }

        public enum Suit { Club, Diamond, Heart, Spade }
        private char[] suitChar = { '\u2663', '\u2666', '\u2665', '\u2660' };

        private readonly int rank;
        private readonly int suit;
        private readonly int pic;
        // Properties

        //public Suit Suit { get; set; }
        //public Rank Rank { get; set; }
        // Constructor
        public Card (int r, int s, int p)
        {
            rank = r;
            suit = s;
            pic = p;
        }

        // Public operations
        public override string ToString()
        {
           

            return suitChar[pic] + " " + rank + " of " + suit;
        } 

       
    }// end of class
} // end of namespace
