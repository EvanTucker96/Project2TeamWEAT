using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angela_sShuffler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Deck mydeck = new Deck();
            foreach (Card c in mydeck.Cards)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("How many times do you want to shuffle?");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
