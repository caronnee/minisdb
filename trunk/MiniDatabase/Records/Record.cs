using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MiniDatabase.Records
{
    public class Record
    {
        List<Value> _values;

        public int ID { get; set; }

        public Record( int recordSize )
        {
            _values = new List<Value>( recordSize );
        }

        public void SetValue(Value v, int index)
        {
            _values[index] = v;
        }

        internal Value GetValue(int i)
        {
            return _values[i];
        }
    }
}
