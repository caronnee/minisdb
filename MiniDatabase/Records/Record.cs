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

        public Record()
        {
            _values = new List<Value>();
        }

        public void Save(BinaryWriter writer)
        {
            foreach (Value v in _values)
            {
                v.Save(writer);
            }
        }
        public void Load(BinaryReader reader)
        {

        }
    }
}
