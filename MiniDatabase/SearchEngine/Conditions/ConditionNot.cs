using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionNot : ConditionRule //value bude Null/..co uz
  {
    public ConditionRule ToNegate
    {
      get;
      set;
    }
    override public bool Accept(Record r)
    {
      return !ToNegate.Accept(r);
    }

  }
}
