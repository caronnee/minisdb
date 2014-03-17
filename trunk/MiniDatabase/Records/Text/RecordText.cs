using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Misc;

namespace MiniDatabase.Records
{
    public class RecordDescriptionText : RecordDescription
    {
        String Name
        {
            get;
            set;
        }
        Value Val
        {
            get;
            set;
        }
        public override Types GetRecordType()
        {
            return Types.TypeText;
        }
    }
}
