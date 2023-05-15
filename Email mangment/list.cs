﻿using System;
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
        public void deleteRecored(string name)
        {
            Hashing ha = new Hashing(name);
            int pos = ha.hash();
            Contact cs = new Contact();
            cs.lineChanger("\n",comboBox1.Text,pos);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            Hashing ha = new Hashing(name);
            int pos = ha.hash();
            string line = File.ReadLines(comboBox1.Text).ElementAt(pos - 1);
            dataGridView1.Rows.Clear();
            string[] data = tokenize(line);
            dataGridView1.Rows.Add(data[0], data[1], data[2]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            deleteRecored(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            modify modi = new modify();
            string curID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string curName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string curEmail = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            modi.selectedFile = comboBox1.Text;
            modi.init_values(curID, curName, curEmail);
            modi.ShowDialog();
        }
    }
}
