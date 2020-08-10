﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12__typing_game
{
    class Stats
    {
        public int Total = 0;
        public int Missed = 0;
        public int Correct = 0; 
        public int Accuracy = 0;

        public void Update(bool correctKey)
        {
            Total++;

            if (!correctKey)//jeśli źle
            {
                Missed++;
            }
            else
            {//jeśli dobrze
                Correct++;
            }

            Accuracy = 100 * Correct / Total;
        }
    }

}
