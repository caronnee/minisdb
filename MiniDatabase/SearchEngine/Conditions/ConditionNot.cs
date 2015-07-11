using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionNot : Condition //value bude Null/..co uz
  {
    public Condition ToNegate
    {
      get;
      set;
    }
    override public bool Compare(Record r)
    {
      return !ToNegate.Compare(r);
    }

  }
}
