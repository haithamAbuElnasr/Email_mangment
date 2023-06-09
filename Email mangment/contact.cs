﻿using System;
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
        public Contact(int id,string name, string email)
        {
            this.id = id;
            this.email = email;
            this.Name = name;
        }
        public Contact()
        {

        }
        public Contact(string name, List<string> emails)
        {
            this.id = UUID_Gen();
            this.Name = name;
            this.emails = emails;
        }
        public void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public void save(string filePath, bool list)
        {
            Hashing hash = new Hashing(this.Name);
            int pos = hash.hash();
            if (list)
            {
                string emails = emailsToString(this.emails);
                lineChanger(this.id + "|" + this.Name + "|" + emails, filePath, pos);
            }
            else
            {
                lineChanger(this.id + "|" + this.Name + "|" + this.email, filePath, pos);
            }
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
