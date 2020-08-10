using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3_excuse_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _currentExcuse.LastUsed = lastUsed.Value;
        }

        private void UpdateForm(bool changed)
        {
            if (!changed)
            {
                this.description.Text = _currentExcuse.Description;
                this.results.Text = _currentExcuse.Results;
                this.lastUsed.Value = _currentExcuse.LastUsed;

                if (!String.IsNullOrEmpty(_currentExcuse.ExcusePath))
                    FileDate.Text = File.GetLastWriteTime(_currentExcuse.ExcusePath).ToString();

                this.Text = "Excuse Manager";
            }
            else
                this.Text = "Excuse Manager*";

            this._formChanged = changed;
        }

        private Excuse _currentExcuse = new Excuse();
        private string _selectedFolder = "";
        private bool _formChanged = false;
        Random random = new Random();


        private void folder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = _selectedFolder;

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _selectedFolder = folderBrowserDialog1.SelectedPath;
                save.Enabled = true;
                open.Enabled = true;
                randomExcuse.Enabled = true;
            }
        }


        private void save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(description.Text) || String.IsNullOrEmpty(results.Text))
            {
                MessageBox.Show
                    (
                    "Please specify an excuse and a result",
                    "Unable to save",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );

                return;
            }

            saveFileDialog1.InitialDirectory = _selectedFolder;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = description.Text + ".txt";

            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _currentExcuse.Save(saveFileDialog1.FileName);
                UpdateForm(false);
                MessageBox.Show("Excuse written");
            }
        }



        private void open_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                openFileDialog1.InitialDirectory = _selectedFolder;
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FileName = description.Text + ".txt";

                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _currentExcuse = new Excuse(openFileDialog1.FileName);
                    UpdateForm(false);
                }
            }
        }


        private void randomExcuse_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                _currentExcuse = new Excuse(random, _selectedFolder);
                UpdateForm(false);
            }
        }


        private bool CheckChanged()
        {
            if (_formChanged)
            {
                DialogResult result = MessageBox.Show
                    (
                      "The current excuse has not been saved. Continue?",
                       "Warning",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning
                    );

                if (result == DialogResult.No)
                    return false;
            }
            return true;
        }


        private void description_TextChanged(object sender, EventArgs e)
        {
            _currentExcuse.Description = description.Text;
            UpdateForm(true);
        }


        private void results_TextChanged(object sender, EventArgs e)
        {
            _currentExcuse.Results = results.Text;
            UpdateForm(true);
        }


        private void lastUsed_ValueChanged(object sender, EventArgs e)
        {
            _currentExcuse.LastUsed = lastUsed.Value;
            UpdateForm(true);
        }
    }
}