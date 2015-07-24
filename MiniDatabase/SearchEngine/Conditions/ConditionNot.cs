using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionNot : ConditionRule
  {
    public ConditionRule ToNegate
    {
      get;
      set;
    }
    override public bool Accept(ValueText v)
    {
      return !ToNegate.Accept(v);
    }
    override public bool Accept(ValueDate v)
    {
      return !ToNegate.Accept(v);
    }
    override public bool Accept(ValueInteger v)
    {
      return !ToNegate.Accept(v);
    }
  }
}
