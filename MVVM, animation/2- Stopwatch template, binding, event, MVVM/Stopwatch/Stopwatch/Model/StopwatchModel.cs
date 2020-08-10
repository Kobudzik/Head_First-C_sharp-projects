using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Model
{
    class StopwatchModel
    {
        private DateTime? _started;
        private TimeSpan? _previousElapsedTime;

        public bool Running { get { return _started.HasValue; } }


        public TimeSpan? Elapsed    // read-only property
        {
            get
            {
                if (_started.HasValue)  //jeśli started ma wartość
                {
                    if (_previousElapsedTime.HasValue)  //jeśli już wartosc previousElapsed
                        return CalculateTimeElapsedSinceStarted() + _previousElapsedTime;   //sumuje obydwa czasy- od startu do teraz + previousElapsed
                    else
                        return CalculateTimeElapsedSinceStarted();  //zwraca czas od poczatku
                }
                else
                    return _previousElapsedTime;    //jeśli zegar nie idzie- zwraca previousElapsed
            }
        }


        private TimeSpan CalculateTimeElapsedSinceStarted()
        {
            return DateTime.Now - _started.Value;
        }

        public void Start()
        {
            _started = DateTime.Now;    //zaczyna odliczanie
            
            if (!_previousElapsedTime.HasValue) //jeśli previousElapsed nie ma wartosci
                _previousElapsedTime = new TimeSpan(0); //ustawia previousElapsed na 0
        }

        public void Stop()
        {
            if (_started.HasValue)  //jesli started ma wartosc(zegar odlicza)
                _previousElapsedTime += DateTime.Now - _started.Value;// do previousElapsed dodajemy czas (od teraz do momentu zaczęcia odliczania)

            _started = null;
        }


        public void Reset()
        {
            _previousElapsedTime = null;
            _started = null;
            LapTime = null;
        }

        public StopwatchModel() //CONSTRUCTOR- This initializes each new instance of a StopwatchModel as reset and stopped
        { 
            Reset();
        }

        public TimeSpan? LapTime { get; private set; }

        public void Lap()   //updates the property and fires the event
        { 
            LapTime = Elapsed;
            OnLapTimeUpdated(LapTime);
        }

        public event EventHandler<LapEventArgs> LapTimeUpdated; //EVENT
        private void OnLapTimeUpdated(TimeSpan? lapTime)//to call
        { 
            EventHandler<LapEventArgs> lapTimeUpdated = LapTimeUpdated;
            if (lapTimeUpdated != null)
            {
                lapTimeUpdated(this, new LapEventArgs(lapTime));    // the usual code to fire an event
            }
        }



    }
}
