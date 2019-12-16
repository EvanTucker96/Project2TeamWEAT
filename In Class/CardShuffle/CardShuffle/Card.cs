using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffle
{
   
    public class Card
    {
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }
        public enum Rank
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack = 10,
            Queen = 10,
            King =10
        }

        public char[] Symbol = { '\u2663', '\u2666', '\u2665', '\u2660' };

        // properties
        public Suit SUIT { get; set; }

        public Rank RANK { get; set; }

       
        public int GetRank(string temp)
        {
            return (int)Enum.Parse(typeof(Rank), temp); 
        }
        public override string ToString()
        {
            int i = Convert.ToInt32(SUIT);
            return Symbol[i].ToString() + " " + RANK + " of " + SUIT;
        }

    }// end of class
} // end of namespace
