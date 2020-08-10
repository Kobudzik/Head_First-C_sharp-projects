using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballRoster.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BasketballRoster.ViewModel
{
    class RosterViewModel : INotifyPropertyChanged
    
    {
        public ObservableCollection<PlayerViewModel> Starters { get; private set; } //te dane musimy odświeżac
        public ObservableCollection<PlayerViewModel> Bench { get; private set; } //te dane musimy odświeżac

        private Roster _roster;

        private string _teamName;
        public string TeamName 
        {
            get { return _teamName; }
            set
            { _teamName = value;
                OnPropertyChanged("TeamName");  //dynamiczne odswiezanie
            } 
        }

        public RosterViewModel(Roster roster) // constructor
        {
            _roster = roster;
            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();
            TeamName = _roster.TeamName;
            UpdateRosters();
        }

        private void UpdateRosters() //wypełnianie danymi ROASTER VIEW MODEL
        {
            var startingPlayers =
                from player in _roster.Players
                where player.Starter 
                select player;

            Starters.Clear(); 
            
            foreach (Player player in startingPlayers)
                Starters.Add(new PlayerViewModel(player.Name, player.Number));



            var benchPlayers =
                from player in _roster.Players
                where player.Starter == false
                select player;
            
            Bench.Clear();

            foreach (Player player in benchPlayers) 
                Bench.Add(new PlayerViewModel(player.Name, player.Number));
        }

        public event PropertyChangedEventHandler PropertyChanged;   //event
        protected void OnPropertyChanged(string propertyName)   //raising
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged; 
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}
