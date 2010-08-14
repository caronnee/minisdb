using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    public class Record
    {
        ulong id;
        List<Attribute> attributes; 
    }
    public class Records
    {
        private List<Record> records;

        public Records() //name of Db
        {
            records = new List<Record>();
        }
        public List<Record> find()
        {
            List<Record> result = new List<Record>();
            return result;
        }
    }
}
