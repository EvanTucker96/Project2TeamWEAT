using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        //static class information
        public static string[] Ranks = {  "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        public static string[] Suits = {  "Clubs", "Diamonds", "Hearts", "Spades" };
        private char[] suitChar = { '\u2663', '\u2666', '\u2665', '\u2660' };

        //private data
        private readonly int rank;
        private readonly int suit;

        
        //getters (since readonly variables can only be set by the constructor)
        public char getSuitChar()
        {
            return suitChar[suit];
        }

        public string SuitName()
        {
            return Suits[suit];
        }
        public int Suit()
        {
            return suit;
        }

        public string RankName()
        {
            return Ranks[rank];
        }
        public int Rank()
        {
            return rank;
        }


        public Card(int r, int s)
        {
         
            rank = r;
            suit = s;
        }

        public override string ToString()
        {
            return RankName() + " of " + SuitName();
        }
    }
}
