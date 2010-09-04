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
        public virtual bool void compare(DateTime d) 
	{ 
		throw new Exception("No such type allowed to compare ");
	}
        public virtual bool void compare(int s) 
	{ 
		throw new Exception("No such type allowed to compare ");
	}
        public virtual bool void compare(string s) 
	{ 
		throw new Exception("No such type allowed to compare ");
	}
        public virtual bool void contains(string s) 
	{ 
		throw new Exception("No such type allowed to compare ");
	}
	public bool visit(Condition c)
	{
		return c.visited(this); //TEST
	}
        public abstract bool compare(Value v);
        public string toString();
    }
    class ValueText : Value
    {
        private string text;
        public ValueText(string txt)
        {
            text = txt;
        }
        public override bool compare(string s);
        {
            return text.compare(s);
        }
	public override bool contains(string s)
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
	public override bool compare(int i)
	{
		return value - i;
	}
	public override bool contains(string s)
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
	public override bool contains(string s)
	{
		return dTime.toString().IntexOf(s);
	}
	public override bool compare(DateTime d)
	{
		return dTime - d;
	}
        public override string ToString()
        {
            return dTime.ToString();
        }
    }
}
