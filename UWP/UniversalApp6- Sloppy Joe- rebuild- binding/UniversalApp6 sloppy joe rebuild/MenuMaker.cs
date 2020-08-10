using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace UniversalApp6_sloppy_joe_rebuild
{
    class MenuMaker: INotifyPropertyChanged
    {
        private Random random = new Random();
        private List<String> meats = new List<String>() { "Roast beef", "Salami", "Turkey", "Ham", "Pastrami" };
        private List<String> condiments = new List<String>() { "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing" };
        private List<String> breads = new List<String>() { "rye", "white", "wheat", "pumpernickel", "italian bread", "a roll" };

        public ObservableCollection<MenuItem> Menu { get; private set; }
        public DateTime GeneratedDate { get; private set; }
        public int NumberOfItems { get; set; }

        public MenuMaker()
        {
            Menu = new ObservableCollection<MenuItem>();
            NumberOfItems = 10; 
            UpdateMenu();
        }

   




        private MenuItem CreateMenuItem() 
        {
            string randomMeat = meats[random.Next(meats.Count)];
            string randomCondiment = condiments[random.Next(condiments.Count)];
            string randomBread = breads[random.Next(breads.Count)];
            
            return new MenuItem(randomMeat, randomCondiment, randomBread);
        }


        public void UpdateMenu()
        { 
            Menu.Clear();
            for (int i = 0; i < NumberOfItems; i++)
            {
                Menu.Add(CreateMenuItem());
            }
            
            GeneratedDate = DateTime.Now;
            OnPropertyChanged("GeneratedDate");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
