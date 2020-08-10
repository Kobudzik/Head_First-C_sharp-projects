using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp18_Bees
{
    class Worker : Bee
    {
        public Worker(string[] jobsICanDo, double weightMg)//konstruktor
            :base(weightMg)//tell C# that it needs to call the base class’s constructor every time the subclass is instantiated.
        {
            this._jobsICanDo = jobsICanDo;
        }


        public int ShiftsLeft
        {
            get
            {
                return _shiftsToWork - _shiftsWorked;
            }
        }

        private string _currentJob = "";
        public string CurrentJob
        {
            get
            {
                return _currentJob;
            }
        }



        private string[] _jobsICanDo;
        private int _shiftsToWork;
        private int _shiftsWorked;



        public bool DoThisJob(string job, int numberOfShifts)//rozkaz pracy
        {
            if (!String.IsNullOrEmpty(_currentJob)) //jeśli pracuje         
                return false;

            for (int i = 0; i < _jobsICanDo.Length; i++)//jeśli nie pracuje
            {
                if (_jobsICanDo[i] == job)//i potrafi wykonac zadana prace
                {
                    _currentJob = job;
                    this._shiftsToWork = numberOfShifts;
                    _shiftsWorked = 0;
                    return true;
                }
            }
            return false;//jesli nie pracuje ale nie potrafi wykonac pracy
        }


        public bool DidYouFinish()
        {
            if (string.IsNullOrEmpty(_currentJob))//jeśli nie pracuje
                return false;

            _shiftsWorked++;

            if (_shiftsWorked > _shiftsToWork)//jesli wykonal prace
            {
                _shiftsToWork = 0;
                _shiftsWorked = 0;
                _currentJob = "";
                return true;
            }
            else
                return false;//dalej pracuje
        }

 
        public override double HoneyConsumptionRate()
        {
            double consumption = base.HoneyConsumptionRate();
            consumption += _shiftsWorked * honeyUnitsPerShiftWorked;
            return consumption;
        }
    }
}
