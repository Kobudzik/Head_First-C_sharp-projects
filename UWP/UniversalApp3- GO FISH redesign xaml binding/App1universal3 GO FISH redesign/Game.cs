using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace App1universal3_GO_FISH_redesign
{
   class Game: INotifyPropertyChanged
    {
        public bool GameInProgress { get; private set; }
        public bool GameNotStarted { get { return !GameInProgress; } }
        public string PlayerName { get; set; }
        public ObservableCollection<string> Hand { get; private set; }
        public string Books { get { return DescribeBooks(); } }
        public string GameProgress { get; private set; }


        private List<Player> players;   //lista graczy
        private Dictionary<Values, Player> books; //slownik kolekcji 4x
        private Deck stock;//karty na stole
       // private TextBox textBoxOnForm;//element form

        public Game()
        { 
            PlayerName = "Ed";
            Hand = new ObservableCollection<string>();
            ResetGame(); 
        }



        //public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        //{
        //    Random random = new Random();
        //    this.textBoxOnForm = textBoxOnForm;
        //    players = new List<Player>();
        //    players.Add(new Player(playerName, random, textBoxOnForm));//dodanie gracza JA

        //    foreach (string player in opponentNames)//dodanie przeciwnikow
        //        players.Add(new Player(player, random, textBoxOnForm));

        //    books = new Dictionary<Values, Player>();//stworzenie slownika kolekcji 4x
        //    stock = new Deck();//domyslnie tworzy 52 karty a-z
        //    Deal();//losowanie wszystkich kart,rozdanie kart- po 5 kazdy
        //    players[0].SortHand();
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void StartGame()
        {
            ClearProgress();
            GameInProgress = true;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");
            Random random = new Random();
            players = new List<Player>();
            players.Add(new Player(PlayerName, random, this));
            players.Add(new Player("Bob", random, this));
            players.Add(new Player("Joe", random, this));
            Deal();//rozdaje karty i wyciaga booki
            players[0].SortHand(); 
            Hand.Clear();

            foreach (String cardName in GetPlayerCardNames())
                Hand.Add(cardName); 

            if (!GameInProgress) 
                AddProgress(DescribePlayerHands());

            OnPropertyChanged("Books");
        }

        public void ClearProgress()
        {
            GameProgress = String.Empty;
            OnPropertyChanged("GameProgress");
        }

        public void AddProgress(string progress) 
        { 
            GameProgress = progress + Environment.NewLine + GameProgress; 
            OnPropertyChanged("GameProgress"); 
        }

        public void ResetGame()
        {
            GameInProgress = false;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted"); 
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Hand.Clear(); }

        private void Deal()
        {
            stock.Shuffle();

            for (int i = 0; i < 5; i++)// 5 razy- 5 kart
                foreach (Player player in players)//dla kazdego gracza
                    player.TakeCard(stock.Deal());//daj jedną kartę

            foreach (Player player in players)//dla kazdego gracza
                PullOutBooks(player);
            // This is where the game starts—this method's only called at the beginning
            // of the game. Shuffle the stock, deal five cards to each player, then use a
            // foreach loop to call each player's PullOutBooks() method.  
        }


        public void PlayOneRound(int selectedPlayerCard)
        {
            Values cardToAskFor = players[0].Peek(selectedPlayerCard).Value; //karta do sprawdzenia to zaznaczona karta

            for (int i = 0; i < players.Count; i++)//dla kazdego gracza
            {
                if (i == 0)//jeśli gracz JA
                {
                    players[0].AskForACard(players, 0, stock, cardToAskFor);//sprawdza  gracza JA czy mają tą wybraną kartę
                }
                else
                { 
                    players[i].AskForACard(players, i, stock);//jeśli gracz PC- sprawdza wszystkich pozostalych graczy czy mają jego losową
                }


                if (PullOutBooks(players[i]))//jesli gracz juz nie ma kart- podlicza jego booki
                {
                    AddProgress(players[i].Name + " drew a new hand" + Environment.NewLine);//informuje

                    int card = 1;

                    while (card <= 5 && stock.Count > 0)//(jeśli gracz już nie ma kart), musi zabrać 5- jeśli są na stosie
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                OnPropertyChanged("Books");
                players[0].SortHand();//sortuje karty gracza JA

                if (stock.Count == 0)//jeśli stock pusty
                {
                    AddProgress("The stock is out of cards. Game over!" + Environment.NewLine);
                    AddProgress("The winner is... " + GetWinnerName());
                    ResetGame();
                    return;

                }                
            }
           // return false;//jesli stock nie jest pusty- gra trwa dalej
        }
    
         

        public bool PullOutBooks(Player player)
        {
            IEnumerable<Values> booksPulled = player.PullOutBooks();

            foreach (Values value in booksPulled)//dodaje do listy books jego booki
                books.Add(value, player);

            if (player.CardCount == 0)//jeśli już nie ma kart
                return true;
            return false;
        }

        // Pull out a player's books. Return true if the player ran out of cards, otherwise
        // return false. Each book is added to the Books dictionary. A player runs out of  
        // cards when he’'s used all of his cards to make books—and he wins the game.    
    

    public string DescribeBooks()
     {
        string whoHasWhichBooks = "";

        foreach (Values value in books.Keys)
            whoHasWhichBooks += books[value].Name + " has a book of " + Card.Plural(value) + Environment.NewLine;

        return whoHasWhichBooks;

        // Return a long string that describes everyone's books by looking at the Books dictionary
        //"Joe has a book of sixes. (line break) Ed has a book of Aces." 
    }


        public IEnumerable<string> GetPlayerCardNames()//funkcja zwraca liste kart gracza
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()//zwraca stringa opisujacego stan gry- kart graczy i stos
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)//dla kazdego gracza
            {
                description += players[i].Name + " has " + players[i].CardCount;//opisuje jakie ma karty
                if (players[i].CardCount == 1)//jeśli ma tylko jedną
                    description += " card." + Environment.NewLine;//bez s
                else description += " cards." + Environment.NewLine;//z s
            }
            description += "The stock has " + stock.Count + " cards left.";//ile kart zostało na stosie
            return description;
        }

        public string GetWinnerName()
        {
        Dictionary<string, int> winners = new Dictionary<string, int>(); //utworzenie nowego dictionary

        foreach (Values value in books.Keys)//dla kazdego booka gracza
        {
            string name = books[value].Name;//zwraca nazwę booka

            if (winners.ContainsKey(name)) 
                winners[name]++;
            else winners.Add(name, 1);
        }


        int mostBooks = 0;
        
        foreach (string name in winners.Keys)
            if (winners[name] > mostBooks)
                mostBooks = winners[name];
        bool tie = false;
        string winnerList = "";
        
        foreach (string name in winners.Keys)
            if (winners[name] == mostBooks)
            { 
                if (!String.IsNullOrEmpty(winnerList)) 
                { 
                    winnerList += " and ";
                    tie = true;
                }
                winnerList += name;
            }
        winnerList += " with " + mostBooks + " books";
        if (tie) 
            return "A tie between " + winnerList;
        else 
            return winnerList;
        // This method is called at the end of the game. It uses its own dictionary
        // (Dictionary<string, int> winners) to keep track of how many books each player
        // ended up with in the books dictionary. First it uses a foreach loop
        // on books.Keys—foreach (Values value in books.Keys)—to populate 
        // its winners dictionary with the number of books each player ended up with. 
        // Then it loops through that dictionary to find the largest number of books
        // any winner has. And finally it makes one last pass through winners to come 
        // up with a list of winners in a string ("Joe and Ed"). If there's one winner,
        // it returns a string like this: "Ed with 3 books". Otherwise, it returns a 
        // string like this: "A tie between Joe and Bob with 2 books."
    }

        }
    }
