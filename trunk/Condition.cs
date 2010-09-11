using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    //for all select that can be writable
    abstract public class Condition //co tak radsej interface?
    {
        private string name_;
        protected Value toCompare;
        public Condition(string name, Value tc)
        {
            this.toCompare = tc;
            this.name_ = name;
        }
        public string getName()
        {
            return name_;
        }
        abstract public bool compareTo(Value v);
    }
    public class ConditionContains : Condition
    {
        public ConditionContains(string name, Value v)
            : base(name, v)
        { 
            //nothing there so far, just initialization
        }
        public override bool compareTo(Value v)
        {
            return toCompare.contains(v) > 0;
        }
    }
    public class ConditionLess : Condition
    {
        public ConditionLess(string name, Value v)
            : base(name, v)
        { }
        public override bool compareTo(Value v)
        {
            return toCompare.compare(v) < 0;
        }
    }
    public class ConditionEqual : Condition
    {
        public ConditionEqual(string name, Value v) : base(name, v) { }
        public override bool compareTo(Value v)
        {
            return toCompare.compare(v) == 0;
        }
    }
    public class ConditionLessEqual : Condition
    {
        public ConditionLessEqual(string name, Value v) : base(name, v) { }
        public override bool compareTo(Value v)
        {
            return toCompare.compare(v) <= 0;
        }
    }
    public class ConditionNot : Condition //value bude Null/..co uz
    {
        private Condition toNegate;
        public ConditionNot(Condition c) : base(null, null) 
        {
            toNegate = c;
        }
        public override bool compareTo(Value v)
        {
            return !toNegate.compareTo(v);
        }
    }
}