using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Minis
{
    public abstract class Value 
    {
        public virtual int compare(DateTime d)
        {
            throw new Exception("No such type allowed to compare ");
        }
        public virtual int compare(int s)
        {
            throw new Exception("No such type allowed to compare ");
        }
        public virtual int compare(string s)
        {
            throw new Exception("No such type allowed to compare ");
        }
        public virtual int compare(Value v)
        {
            throw new Exception("Not implemented");
        }
        public virtual int contains(string s)
        {
            return this.ToString().IndexOf(s);
        }
        public virtual int contains(Value v)
        {
            if (v == null)
                return -1;
            return this.contains(v.ToString());
        }
    }
    class ValueText : Value
    {
        protected string text;
        public ValueText(string txt)
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
    }
    class ValuePicture : ValueText
    {
        public ValuePicture(string txt) : base(txt) { }
    }
    class ValueInteger : Value
    {
        private int value;
        public ValueInteger(int i)
        {
            value = i;
        }
        public override int compare(int i)
        {
            return value - i;
        }
        public override int compare(Value v)
        {
            if (v == null) //FUJ! musim stale ifovat
                return -1;
            return v.compare(value);
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
    class ValueDate : Value
    {
        private DateTime dTime;
        public ValueDate(DateTime d)
        {
            dTime = d;
        }
        public override int compare(DateTime d)
        {
            if (dTime.Date > d.Date)
                return 1;
            if (dTime.Date < d.Date)
                return -1;
            return 0;
        }
        public override int compare(Value v)
        {
            if (v == null) //FUJ! musim stale ifovat
                return -1;
            return v.compare(dTime);
        }
        public override string ToString()
        {
            return dTime.ToString(Files.dateFormat);
        }
    }
}
