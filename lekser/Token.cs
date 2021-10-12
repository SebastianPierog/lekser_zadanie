using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekser
{
    class Token
    {
        public Token(string name, string arguments, string index)
        {
            Name = name;
            Argument = arguments;
            Index = index;
        }
        public string Name { get; set; }
        public string Argument { get; set; }
        public string Index { get; set; }
    }
}
