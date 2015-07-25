using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiniDatabase.Records.Values;

namespace MiniDatabase.Records
{
    public class Record
    {
        public int ID { get; set; }
        public List<Value> Values { get; set; }

        public Record( int recordSize )
        {
            Values = new List<Value>(recordSize);
            for (int i = 0; i < recordSize; i++)
                Values.Add(null);// TODO special value
        }

        public void SetValue(Value v, int index)
        {
            Values[index] = v;
        }

        internal Value GetValue(int i)
        {
            if (Values.Count <= i)
                return null;
            return Values[i];
        }
    }
}
