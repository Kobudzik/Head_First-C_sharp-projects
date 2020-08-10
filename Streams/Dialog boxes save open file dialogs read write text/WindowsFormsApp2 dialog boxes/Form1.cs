using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2_dialog_boxes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          

        }
        string _path;               


        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//jesli uzytkownik kliknie ok
            {
                _path = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(_path);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//jesli uzytkownik kliknie ok
            { 
                _path = saveFileDialog1.FileName;
                File.WriteAllText(_path, textBox1.Text);
            }
        }
    }
}
