using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_mangment
{
    public partial class adding : Form
    {
        List<string> emails = new List<string>();
        string selectedFile;
        bool treatAsArray=false;
        public adding()
        {
            InitializeComponent();
            init_Box();
        }
        private void init_Box()
        {
            DirectoryInfo dinfo = new DirectoryInfo(".");
            FileInfo[] files = dinfo.GetFiles("*.txt");
            comboBox1.DataSource = files;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFile = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emails.Add(textBox3.Text);
            textBox3.Clear();
            treatAsArray = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                if (treatAsArray)
                {
                    Contact contact = new Contact(textBox2.Text, emails);                    
                    contact.save(selectedFile, treatAsArray);
                }
                else
                {
                    Contact contact = new Contact(textBox2.Text, textBox3.Text);
                    contact.save(selectedFile, treatAsArray);
                }
                clearAddForm();
                MessageBox.Show("The Contact Saved", "Note", MessageBoxButtons.OK);
            }
            
        }
        
        private bool validation()
        {
            if (textBox2.Text == string.Empty && textBox3.Text == string.Empty)
            {
                MessageBox.Show("You Must fill the inputs", "Error", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void clearAddForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            emails.Clear();
        }
    }
}
