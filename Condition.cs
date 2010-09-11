using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    //for all select that can be writable
    abstract public class Condition //co tak radsej interface?
    {
        protected Value toCompare;
        public Condition(Value tc)
        {
            toCompare = tc;
        }
        abstract public bool compareTo(Value v);
    }
    public class ConditionContains : Condition
    {
        public ConditionContains(Value v)
            : base(v)
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
        public ConditionLess(Value v)
            : base(v)
        { }
        public override bool compareTo(Value v)
        {
            return toCompare.compare(v) < 0;
        }
    }
    public class ConditionEqual : Condition
    {
        public ConditionEqual(Value v) : base(v) { }
        public override bool compareTo(Value v)
        {
            return toCompare.compare(v) == 0;
        }
    }
    public class ConditionMore : Condition
    {
        public ConditionMore(Value v) : base(v) { }
        public override bool compareTo(Value v)
        {
            return toCompare.compare(v) > 0;
        }
    }
    public class ConditionNot : Condition //value bude Null/..co uz
    {
        private Condition toNegate;
        public ConditionNot(Condition c) : base(null) 
        {
            toNegate = c;
        }
        public override bool compareTo(Value v)
        {
            return !toNegate.compareTo(v);
        }
    }
}