using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace test_binding
{
    //interfejs do- OnPropertyChanged
    class PersonMaker : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Persons { get; private set; }

        //konstruktor
        public PersonMaker()
        {
            Persons = new ObservableCollection<Person>();

        }

        public DateTime GeneratedDate
        {
            get; private set;
        }

       public int NumberOfPeople { get { return Persons.Count(); } set { } }

       

        public void Refresh()
        {
            GeneratedDate = DateTime.Now;
            OnPropertyChanged("GeneratedDate");
            OnPropertyChanged("NumberOfPeople");
        }


        
        public event PropertyChangedEventHandler PropertyChanged; //event

        private void OnPropertyChanged(string propertyName) //dzialania do wywolania eventem
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null) 
            { 
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
