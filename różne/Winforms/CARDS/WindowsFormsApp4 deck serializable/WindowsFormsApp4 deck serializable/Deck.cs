using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp4_deck_serializable
{
    [Serializable]
    class Deck
    {
        private List<Card> cards;
        private Random random = new Random();

        //domyslny konstruktor- dodaje kazda karte
        public Deck()
        { 
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++) 
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Suits)suit, (Values)value));
        }

        //konstruktor z parametrem dodaje wybrane karty
        public Deck(IEnumerable<Card> initialCards) 
        {
            cards = new List<Card>(initialCards);
        }



        public Deck(string filename)
        {
            cards = new List<Card>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    bool invalidCard = false;
                    string nextCard = reader.ReadLine();

                    string[] cardParts = nextCard.Split(new char[] { ' ' });
                    Values value = Values.Ace;
                    switch (cardParts[0])
                    { 
                        case "Ace": value = Values.Ace; break;
                        case "Two": value = Values.Two; break;
                        case "Three": value = Values.Three; break;
                        case "Four": value = Values.Four; break;
                        case "Five": value = Values.Five; break;
                        case "Six": value = Values.Six; break;
                        case "Seven": value = Values.Seven; break;
                        case "Eight": value = Values.Eight; break;
                        case "Nine": value = Values.Nine; break;
                        case "Ten": value = Values.Ten; break;
                        case "Jack": value = Values.Jack; break;
                        case "Queen": value = Values.Queen; break;
                        case "King": value = Values.King; break;
                        default: invalidCard = true;
                        break;
                    }

                    Suits suit = Suits.Clubs;
                    switch (cardParts[2])
                    { 
                        case "Spades": suit = Suits.Spades; break;
                        case "Clubs": suit = Suits.Clubs; break; 
                        case "Hearts": suit = Suits.Hearts; break;
                        case "Diamonds": suit = Suits.Diamonds;break; 
                        default: invalidCard = true; break;
                    }

                    if (!invalidCard)
                    {
                        cards.Add(new Card(suit, value));
                    }
                }
            }
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


        public void WriteCards(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            { 
                for (int i = 0; i < cards.Count; i++)
                { 
                    writer.WriteLine(cards[i].Name);
                }
            }
        }



    }
}
