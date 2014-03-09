using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Records
{
    class ValueInteger : Value
    {
        private int value;
        public ValueInteger(int i)
        {
            value = i;
        }
        public override int compare(int i)
        {
            return value - i;
        }
        public override int compare(Value v)
        {
            if (v == null) //FUJ! musim stale ifovat
                return -1;
            return v.compare(value);
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
}
