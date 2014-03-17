using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDatabase.Records
{
    public class ValueText : Value
    {
        // todo this Textu should go into some tree maybe?
        public String Text
        {
            get;
            set;
        }
        public ValueText(string txt = "")
        {
            Text = txt;
        }
        public override int compare(string s)
        {
            return Text.CompareTo(s);
        }
        public override int compare(Value v)
        {
            return v.compare(Text);
        }
        public override string ToString()
        {
            return Text;
        }
        public override void Save(System.IO.BinaryWriter writer)
        {
            writer.Write(Text);
        }
    }
}
