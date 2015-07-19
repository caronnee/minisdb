using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionHolder
  {
    public ConditionHolder()
    {
      Conditions = new List<ConditionRule>();
    }

    public List<ConditionRule> Conditions
    {
      get;
      set;
    }

    public bool Accept( Record record )
    {
      foreach (ConditionRule rule in Conditions)
      {
        if (!rule.Accept(record))
          return false;
      }
      return true;
    }
  }
}
