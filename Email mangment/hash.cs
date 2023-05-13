using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Email_mangment
{
    internal class Hashing
    {
        public int key = 0;
        public int value;
        public int mod = 2000;
        public int id;
        public Hashing(int id, string value) {
            int _value = stringToNumber(value);
            this.id = id;
        }
        private int stringToNumber(string value)
        {
            int output=0;
            foreach(char s in value)
            {
                output += s;
            }
            return output;
        }
        public int hash()
        {
            int _hash = id + value;
            key = _hash % 1158;
            return key % mod;
        }
    }
}
