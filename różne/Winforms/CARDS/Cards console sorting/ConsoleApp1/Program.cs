using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberBetween0and3 = random.Next(4);
            int numberBetween1and13 = random.Next(1, 14);
            int anyRandomInteger = random.Next();

            List<Card> cards = new List<Card>();

            Console.WriteLine("Before sorting:");
            for (int i = 0; i < 5; i++)
            {
                cards.Add(new Card((Suits)random.Next(4), (Values)random.Next(1, 14)));
                Console.WriteLine(cards[i].Name);
            }

            

            Console.WriteLine("\n"+"Those same cards, sorted:");
            cards.Sort(new CardComparer_byValue());

            foreach (Card card in cards)
            {
                Console.WriteLine(card.Name);
            }

            Console.ReadKey();
        }
    }
}
