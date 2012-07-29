using System;
using System.Collections.Generic;
using System.Text;

namespace myDb
{
    public class RecordEventArgs : EventArgs
    {
        public readonly List<Record> records;
        public RecordEventArgs(List<Record> rc)
        {
            records = rc;
        }
    }
}
