using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_mangment
{
    class Contact
    {
        public int id;
        public string Name;
        public List<string> emails;
        public string email;
        public Contact(string name,string email) {
            this.id = UUID_Gen();
            this.email = email;
            this.Name = name;
        }
        public Contact(string name, List<string> emails)
        {
            this.id = UUID_Gen();
            this.Name = name;
            this.emails = emails;
        }
        public void save(string filePath, bool list)
        {
            StreamWriter sw = File.AppendText(filePath);
            if(list)
            {
                string emails = emailsToString(this.emails);
                sw.WriteLine(this.id + "|" + this.Name + "|" + emails);
            }
            else
            {
                sw.WriteLine(this.id+"|"+this.Name+"|"+this.email);
            }
            sw.Close();
        }
        private string emailsToString(List<string> emails)
        {
            string emailsString = "";
            foreach(string email in emails)
            {
                emailsString += email;
                emailsString += ",";
            }
            return emailsString.Substring(0,emailsString.Length-1);
        }
        public int UUID_Gen()
        {
            Random r = new Random();
            int genID = r.Next(1000,10000);
            return genID;
        }
    }
}
