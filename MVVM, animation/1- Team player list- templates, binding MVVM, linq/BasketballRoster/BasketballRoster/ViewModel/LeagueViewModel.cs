using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballRoster.Model;
using System.Collections.ObjectModel;

namespace BasketballRoster.ViewModel
{
    class LeagueViewModel
    {

        public RosterViewModel BriansTeam { get; private set; }
        public RosterViewModel JimmysTeam { get; private set; }

        public LeagueViewModel()// konstruktor- creates Model.Roster objects for each team that get passed to the RosterViewModel constructor
        {
            Roster briansRoster = new Roster("The Bombers", GetBomberPlayers());//create new Roster object with dummy data
            BriansTeam = new RosterViewModel(briansRoster);//passes Roster object to RosterViewModel

            Roster jimmysRoster = new Roster("The Amazins", GetAmazinPlayers());
            JimmysTeam = new RosterViewModel(jimmysRoster);
        }



        // two private methods to create dummy data for the page
        private IEnumerable<Player> GetBomberPlayers()
        {
            List<Player> bomberPlayers = new List<Player>()
            {
                new Player("Brian", 31, true),
                new Player("Lloyd", 23, true),
                new Player("Kathleen", 6, true),
                new Player("Mike", 0, true),
                new Player("Joe", 42, true),
                new Player("Herb", 32, false),
                new Player("Fingers", 8, false),
            };
            return bomberPlayers;
        }

        private IEnumerable<Player> GetAmazinPlayers()
        {
            List<Player> amazinPlayers = new List<Player>()
            {
                new Player("Jimmy", 42, true),
                new Player("Henry", 11, true),
                new Player("Bob", 4, true),
                new Player("Lucinda", 18, true),
                new Player("Kim", 16, true),
                new Player("Bertha", 23, false),
                new Player("Ed", 21, false),
            };
            return amazinPlayers;
        }


        
        
    }
}
