using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    class DinnerParty : Party
    { 

        public bool HealthyOption { get; set; }

        //konstruktor
        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            FancyDecorations = fancyDecorations;
            HealthyOption = healthyOption;
        }

     
        private decimal CalculateCostOfBeveragesPerPerson()
        {

            if (HealthyOption)
            {
                return 5.00M;

            }
            else
            {
                return 20.00M;
            }
        }

        override public decimal SummaredCost
        {
            get
            {
                decimal totalCost = base.SummaredCost;
                totalCost += CalculateCostOfBeveragesPerPerson() * NumberOfPeople;

                if (HealthyOption)
                {
                    totalCost *= .95M;
                }

                return totalCost;
            }
        }
    }
}
