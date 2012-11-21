using System;
using System.Collections.Generic;
using System.Text;

namespace Minis
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
