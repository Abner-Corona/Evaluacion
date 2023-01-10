using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1._4
{
    public class NumericInput : TextInput
    {
        public NumericInput() { }

        public override void Add(char c)
        {
            if (!char.IsNumber(c)) return;
            this._value += c;
        }
    }
}
