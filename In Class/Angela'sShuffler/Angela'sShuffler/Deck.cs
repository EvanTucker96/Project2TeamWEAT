using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela_sShuffler
{
    public class Deck
    {
        public List<Card> MyCards { get; set; }

    //construct the deck
    public Deck()
    {
        MyCards = new List<Card>();

        for (int i = 1; i<4; i++)
        {
            for (int ii = 1; ii<14; ii++)
            {
                MyCards.Add(new Card(i, ii));
            }
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < MyCards.Count; i++)
        {
                var temp = MyCards[i];
                var index = Randomizer(0, MyCards.Count);
                MyCards[i] = MyCards[Convert.ToInt32(index)];
                MyCards[Convert.ToInt32(index)] = temp;
        }
    }

        private object Randomizer(int v, int count)
        {
            lock ()
            {
                return Random.Equals(v, count);
            }
        }
    }
}
