using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp25_go_fish_game
{
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();


        public Deck()//domyslny konstuktor dodaje wszystkie 52 karty
        { 
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++) 
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Suits)suit, (Values)value));
        }

        public Deck(IEnumerable<Card> initialCards) //konstuktor dodajacy okreslona liste kart
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }//zwraca ilosc kart

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal(int index)//wyciąga karte 
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal; 
        }
        public Card Deal()// If you don’t pass it any parameters, it deals a card off the top of the deck.

        {
            return Deal(0);
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

            for(int i=0;i<cards.Count;i++)
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

        public Card Peek(int cardNumber)//The Peek() method lets you take a peek at one of the cards in the deck without dealing it. 
        {
            return cards[cardNumber];
        }

        public bool ContainsValue(Values value)//searches through the entire deck for cards with a certain value, and returns true if it finds any
        { 
            foreach (Card card in cards)
                if (card.Value == value) return true;
            return false;
        }

        public Deck PullOutValues(Values value)//zwraca deck tylko z kartami z argumentu
        {
            Deck deckToReturn = new Deck(new Card[] { }); //zwraca nowy deck

            for (int i = cards.Count - 1; i >= 0; i--)//petla po wszystkich kartach gracza
                if (cards[i].Value == value)//jesli wartosc karty zgadza sie z argumentem
                    deckToReturn.Add(Deal(i));//do nowego decka dodaje ten element
            return deckToReturn;
        }


        public bool HasBook(Values value)//method checks a deck to see if it contains a book of four cards of whatever     
               //value was passed as the parameter. It returns true if there’s a book in the deck, false otherwise. 

                
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
                if (card.Value == value) NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else
                return false; 
        }

        public void SortByValue()
        { 
            cards.Sort(new CardComparer_bySuit());
        }

    }
}
