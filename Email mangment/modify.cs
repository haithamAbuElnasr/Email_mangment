using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_mangment
{
    public partial class modify : Form
    {
        public string selectedFile=null;
        public modify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search sr=new search();
            Contact cs = new Contact(int.Parse(textBox1.Text),textBox2.Text,textBox3.Text);
            sr.deleteRecored(textBox2.Text);
            cs.save(selectedFile,false);
            MessageBox.Show("The Record has been edited", "Done", MessageBoxButtons.OK);
        }
        public void init_values(string id,string name,string email)
        {
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = email;
        }
    }
}
