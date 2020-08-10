using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp25_dict
{
    class JerseyPlayer
    {
        public string FullName { get; private set; }
        public int YearRetired { get; private set; }

        public JerseyPlayer(string player, int numberRetired)
        {
            FullName = player;
            YearRetired = numberRetired;
        }
    }
}
