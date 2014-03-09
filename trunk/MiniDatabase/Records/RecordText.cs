using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Records
{
    public class RecordText : RecordDescription
    {
        String Name
        {
            get;
            set;
        }
        String Value
        {
            get;
            set;
        }
    }
}
