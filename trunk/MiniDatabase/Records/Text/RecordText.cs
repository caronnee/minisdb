using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Misc;
using MiniDatabase.Records.Text;
using System.Windows.Controls;
using System.IO;

namespace MiniDatabase.Records
{
    public class RecordDescriptionText : RecordDescription
    {
        public RecordDescriptionText()
        {
            Val = new ValueText();
        }
        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            Val.Save(writer);
        }
        public override Value CreateValueFromString(String str)
        {
            return new ValueText(str);
        }

        public override void Load(BinaryReader reader)
        {
            base.Load(reader);
            Val = new ValueText();
            Val.Load(reader);
        }
        public override Control CreateControl()
        {
            return new InputControlText(Val.ToString());
        }

        public ValueText Val
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
