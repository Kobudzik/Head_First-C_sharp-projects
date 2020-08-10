using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalApp12_dispose
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clone1Button_Click(object sender, EventArgs e)
        {
            using (Clone clone1 = new Clone(1))//dispose willl run, then finalizer
            {        // Do nothing!   
            }
        }

        private void clone2Button_Click(object sender, EventArgs e)
        {
            Clone clone2 = new Clone(2);//only finalizer runs
           // clone2 = null;
        }

        private void gcButton_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
