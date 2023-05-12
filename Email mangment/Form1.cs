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
    public partial class Form1 : Form
    {
        public Form1()
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

        }
    }
}
