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
        public int mod = 200;
        public Hashing(string value) {
            this.value = stringToNumber(value);
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
            int _hash = value;
            key = _hash % 10000;
            return key % mod;
        }
    }
}
