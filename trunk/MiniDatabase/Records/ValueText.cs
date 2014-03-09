using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDatabase.Records
{
    class ValueText : Value
    {
        // todo this textu should go into some tree maybe?
        protected string text;
        public ValueText(string txt = "")
        {
            text = txt;
        }
        public override int compare(string s)
        {
            return text.CompareTo(s);
        }
        public override int compare(Value v)
        {
            if (v == null) //FUJ! musim stale ifovat
                return -1;
            return v.compare(text);
        }
        public override string ToString()
        {
            return text;
        }
        public override void Save(System.IO.BinaryWriter writer)
        {
            writer.Write(text);
        }
    }
}
