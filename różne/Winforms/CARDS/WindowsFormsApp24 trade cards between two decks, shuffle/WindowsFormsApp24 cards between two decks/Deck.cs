using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp24_cards_between_two_decks
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();


        public Deck()
        { 
            //dodaje wszystkie
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++) 
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Suits)suit, (Values)value));
        }

        public Deck(IEnumerable<Card> initialCards) 
        {
            cards = new List<Card>(initialCards);
        }



        public int Count { get { return cards.Count; } }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal; 
        }

        public void Shuffle() // this method shuffles the cards by rearranging them in a random order
        {
            List<Card> randomList = new List<Card>();
            int randomIndex = 0;

            while (this.Count > 0)
            {
                randomIndex = random.Next(0, this.cards.Count); //Choose a random object from the inicial list
                randomList.Add(this.cards[randomIndex]); //add chosen object to new list
                this.cards.RemoveAt(randomIndex); //remove from inicial list to avoid duplicates
            }
            cards = randomList;
           

        }


        public IEnumerable<string> GetCardNames()
        {
            List<string> CardNames = new List<string>();

            for(int i=0; i< cards.Count; i++)
            {
                CardNames.Add(cards[i].Name);
            }
            // this method returns a string array that contains each card's name
            return CardNames;
        }



        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }


    }
}
