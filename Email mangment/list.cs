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
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
            init_Box();
        }

        private void list_Load(object sender, EventArgs e)
        {

        }
        private void init_Box()
        {
            DirectoryInfo dinfo = new DirectoryInfo(".");
            FileInfo[] files = dinfo.GetFiles("*.txt");
            comboBox1.DataSource = files;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            datafromFile(comboBox1.Text);
        }
        private void datafromFile(string filename)
        {
            string fileData = File.ReadAllText(filename);
            string[] lines = fileData.Split('\n');
            string[] result = new string[lines.Length];
            for (int i = 0;i < result.Length; i++)
            {
                if (lines[i] != null && lines[i] != "" && lines[i] != "\r" && lines[i] != "\n")
                {
                    string[] obj = tokenize(lines[i]);
                    dataGridView1.Rows.Add(obj[0], obj[1], obj[2]);
                }
            }
        }
        private string[] tokenize(string str)
        {
            string[] all = str.Split('|');
            return all;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
