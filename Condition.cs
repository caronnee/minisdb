using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    abstract public class Condition //co tak radsej interface?
    {
        Value toCompare;
        public Condition(Value tc)
        {
            toCompare = tc;
        }
        abstract public int compare();
    }
    public class ConditionContains : Condition
    {
        public ConditionContains(Value v)
            : base(v)
        { }
        public override int compare()
        {
            return 0;
        }
    }
}
