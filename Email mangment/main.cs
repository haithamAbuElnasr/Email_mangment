using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Email_mangment
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text;
            fileName = fileName + ".txt";
            if (!File.Exists(fileName))
            {
                File.Create(Directory.GetCurrentDirectory() +"\\"+fileName).Close();
                MessageBox.Show("File is created Successfully in the path:\n" + fileName, "Note", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(fileName + " is ALREADY exist", "Note",
                    MessageBoxButtons.OK);
            }          

        }

        private void deleteFile_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text;
            fileName = fileName + ".txt";
            if (File.Exists(fileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\" + fileName);
                MessageBox.Show("File is deleted Successfully in the path:\n" + fileName, "Note", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(fileName + " Does NOT exist", "Note",
                    MessageBoxButtons.OK);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
