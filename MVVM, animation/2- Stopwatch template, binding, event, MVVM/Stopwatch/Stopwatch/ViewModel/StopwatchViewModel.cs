using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stopwatch.Model;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace Stopwatch.ViewModel
{
    class StopwatchViewModel : INotifyPropertyChanged
    {
        private StopwatchModel _stopwatchModel = new StopwatchModel();
        private DispatcherTimer _timer = new DispatcherTimer();

        public bool Running { get { return _stopwatchModel.Running; } }

        public StopwatchViewModel() //konstruktor
        {
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += TimerTick; 
            _timer.Start();
            Start();
            _stopwatchModel.LapTimeUpdated += LapTimeUpdatedEventHandler; // podpiecie eventu
        }

        public void Start()
        {
            _stopwatchModel.Start();
        }
        public void Stop()
        { _stopwatchModel.Stop(); 
        }
        public void Lap() 
        {
            _stopwatchModel.Lap();
        }


        public void Reset() 
        {
            bool running = Running; //sprawdza czy zegarek chodzil (stare mialo value)
            _stopwatchModel.Reset();
            if (running)//jesli chodzil
                _stopwatchModel.Start();//startuje
        }


        int _lastHours;
        int _lastMinutes;
        decimal _lastSeconds;
        bool _lastRunning;

        void TimerTick(object sender, object e)//check to see if the hours, minutes, and seconds have changed
                                            //If they have, it fires off the right PropertyChanged event so the View can update itself
        {
            if (_lastRunning != Running)
            {
                _lastRunning = Running;
                OnPropertyChanged("Running");
            }
            if (_lastHours != Hours)
            {
                _lastHours = Hours;
                OnPropertyChanged("Hours");
            } 
            
            if (_lastMinutes != Minutes)
            {
                _lastMinutes = Minutes; 
                OnPropertyChanged("Minutes");
            }
            
            if (_lastSeconds != Seconds)
            { 
                _lastSeconds = Seconds;
                OnPropertyChanged("Seconds");
            }
        
        }
        public int Hours
        {
            get { return _stopwatchModel.Elapsed.HasValue ? _stopwatchModel.Elapsed.Value.Hours : 0; } //jest stopwatchmodel elapsed ma value to zwraca godziny, jeśli nie to zwraca 0
        }


        public int Minutes
        { 
            get { return _stopwatchModel.Elapsed.HasValue ? _stopwatchModel.Elapsed.Value.Minutes : 0; } 
        }


        public decimal Seconds
        {                     //jesli ma wartosc                                    //zwraca sekundy            +                   //milisekundy *0.01                     jeśli nie to 0            
            get { if (_stopwatchModel.Elapsed.HasValue) { return (decimal)_stopwatchModel.Elapsed.Value.Seconds + (_stopwatchModel.Elapsed.Value.Milliseconds * .001M); } else return 0.0M; }
        }
        
        
        public int LapHours
        { 
            get { return _stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Hours : 0; } }
       
        
        public int LapMinutes
        { 
            get { return _stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Minutes : 0; } }
      
        
        public decimal LapSeconds 
        {
            get { if (_stopwatchModel.LapTime.HasValue) { return (decimal)_stopwatchModel.LapTime.Value.Seconds + (_stopwatchModel.LapTime.Value.Milliseconds * .001M); } else return 0.0M; } }
       


        
        int _lastLapHours;
        int _lastLapMinutes;
        decimal _lastLapSeconds;
        
        private void LapTimeUpdatedEventHandler(object sender, LapEventArgs e)
        {
            if (_lastLapHours != LapHours)
            {
                _lastLapHours = LapHours; 
                OnPropertyChanged("LapHours");
            } 
            if (_lastLapMinutes != LapMinutes) 
            {
                _lastLapMinutes = LapMinutes;
                OnPropertyChanged("LapMinutes");
            }
            if (_lastLapSeconds != LapSeconds)
            { 
                _lastLapSeconds = LapSeconds;
                OnPropertyChanged("LapSeconds");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;   //EVENT
        protected void OnPropertyChanged(string propertyName)
        { 
            PropertyChangedEventHandler propertyChanged = PropertyChanged; 
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
