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
        private enum Rank
        { Ace = 1, Two, Three, Four, Five,
            Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        }

        private enum Suit { Club, Diamond, Heart, Spade }

        // Properties
        //public int FaceValue { get { return Rank; } }

        //public static string GetSuit { get { return suit; } }

        // Constructor


        // Public operations
        public override string ToString()
        {
           

            return Rank + " of " + Suit;
        } 

    }
}
