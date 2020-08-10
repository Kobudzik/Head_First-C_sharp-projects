using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1universal3_GO_FISH_redesign
{
    class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private Game game;
        // private TextBox textBoxOnForm;


        public Player(String name, Random random, Game game)
        {
            this.name = name;
            this.random = random;
            this.game = game;
            this.cards = new Deck(new Card[] { });
            game.AddProgress(this.name + " has just joined the game");

            // The constructor for the Player class initializes four private fields, and then
            // adds a line to the TextBox control on the form that says, "Joe has just  
            // joined the game"—but use the name in the private field, and don't forget to
            // add a line break at the end of every line you add to the TextBox.
        }


        public IEnumerable<Values> PullOutBooks()//funkcja pulloutbooks zwarajaca liste
        {
            List<Values> books = new List<Values>(); //tworzenie listy booksow

            for (int i = 1; i <= 13; i++)//dla kazdej wartosci kart
            {
                Values value = (Values)i;//dla sprawdzanego value
                int howMany = 0;//zaczyna podliczanie
                for (int card = 0; card < cards.Count; card++)//sprawdza wszystkie karty po kolei
                    if (cards.Peek(card).Value == value) howMany++;//jesli sie zgadza to dodaje do zmiennej howmany

                if (howMany == 4)
                {
                    books.Add(value);//dodaje graczowi booka
                    cards.PullOutValues(value);
                }

            }
            return books;
        }
      
            //it loops through each of the 13 card values.
            //For each of the values, it counts all of the cards in the player’s cards field that match
            //the value. If the player has all four cards with that value, that’s a complete book—it adds the value
            //to the books variable to be returned, and it removes the book from the player’s cards.

        
       

        public Values GetRandomValue()
        {
            Card randomCard = cards.Peek(random.Next(cards.Count)); 
            return randomCard.Value;
            // This method gets a random value—but it has to be a value that's in the deck! 
        }

        public Deck DoYouHaveAny(Values value)
        {
            Deck cardsIHave = cards.PullOutValues(value);
            game.AddProgress(Name + " has " + cardsIHave.Count + " " + Card.Plural(value));
            return cardsIHave;
            // This is where an opponent asks if I have any cards of a certain value 
            // Use Deck.PullOutValues() to pull out the values. Add a line to the TextBox
            // that says, "Joe has 3 sixes"—use the new Card.Plural() static method
        }


        public void AskForACard(List<Player> players, int myIndex, Deck stock)//gracz bierze 1 karte ze stolu
        { 
            if (stock.Count > 0)//jeśli jest przynajmniej 1 karta na stacku
            {
                if (cards.Count == 0)//jeśli gracz MA kartę
                    cards.Add(stock.Deal());//bierze karte ze stolu

                Values randomValue = GetRandomValue();
                AskForACard(players, myIndex, stock, randomValue);//ruch komputera- prosi o losową kartę
            }
        }


        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            game.AddProgress(Name + " asks if anyone has a " + value + Environment.NewLine);//komunikat

            int totalCardsGiven = 0; //licznik ile kart dał

            for (int i = 0; i < players.Count; i++) //petla dla kazdego racza
            {
                if (i != myIndex)// nie sprawdza samego siebie
                {
                    Player player = players[i];
                    Deck CardsGiven = player.DoYouHaveAny(value);
                    totalCardsGiven += CardsGiven.Count;
                    while (CardsGiven.Count > 0)
                        cards.Add(CardsGiven.Deal());
                }
            }
            if (totalCardsGiven == 0)
            {
                game.AddProgress(Name + " must draw from the stock.");
                cards.Add(stock.Deal());
            }
        }


        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
