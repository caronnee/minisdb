using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    public abstract class Value //ma dedit po icomparable?
    {
        public override string ToString()
        {
            return base.ToString();
        }
        public void contains(string s)
        { 
        }
        public bool comparing(Value V)
        {
            throw new Exception("not implemented");
        }
        public virtual bool compare(Value v) //condition C
        {
            return v.comparing(this);
        }
        public string toString();
    }
    class ValueText : Value
    {
        private string text;
        public ValueText(string txt)
        {
            text = txt;
        }
        public override bool compare(Value v) //condition C
        {
            return v.comparing(this);
        }
        public bool comparing(Resolver r)
        {
            return false;
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
        public override string ToString()
        {
            return dTime.ToString();
        }
    }
}