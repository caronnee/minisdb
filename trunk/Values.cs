using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
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
            throw new Exception("No such type allowed to compare ");
        }
        public virtual int contains(Value v)
        {
            throw new Exception("Not implemented yet");
        }
    }
    class ValueText : Value
    {
        private string text;
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
            return compare(text);
        }
        public override int contains(string s)
        {
            return text.IndexOf(s);
        }
        public override string ToString()
        {
            return text;
        }
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
            return v.compare(value);
        }
        public override int contains(string s)
        {
            return value.ToString().IndexOf(s);
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
        public override int contains(string s)
        {
            return dTime.ToString().IndexOf(s);
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
            return v.compare(dTime);
        }
        public override string ToString()
        {
            return dTime.ToString(Files.dateFormat);
        }
    }
}
