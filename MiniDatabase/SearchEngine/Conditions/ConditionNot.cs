using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionNot : IConditionRule
  {
    public ConditionRule ToNegate
    {
      get;
      set;
    }

    public bool Accept(Record record)
    {
      return !record.GetValue(ToNegate.Index).Eval(ToNegate);
    }
  }
}
