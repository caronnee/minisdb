using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Misc;
using MiniDatabase.Records.Text;

namespace MiniDatabase.Records
{
    public class RecordDescriptionText : RecordDescription
    {
        public RecordDescriptionText()
        {
            InputControl = new InputControlText();
        }
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
