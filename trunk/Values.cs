using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    public abstract class Value //ma dedit po icomparable?
    {
        public void contains()
        { }
        public bool comparing(Value V)
        {
            throw new Exception("not implemented");
        }
        public virtual bool compare(Value v) //condition C
        {
            return v.comparing(this);
        }
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
    }
    class ValueInteger : Value
    {
        private int value;
        public ValueInteger(int i)
        {
            value = i;
        }
    }
    class ValueDate : Value
    {
        DateTime dTime;
        public ValueDate(DateTime d)
        {
            dTime = d;
        }
    }
}