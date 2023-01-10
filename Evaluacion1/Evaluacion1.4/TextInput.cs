using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1._4
{
    public class TextInput
    {
        public TextInput() { }
        protected string _value = "";
        public virtual void Add(char c) { _value += c; }

        public  string GetValue() => _value;

    }
}
