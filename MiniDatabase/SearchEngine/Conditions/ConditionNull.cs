using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionIsNull : ConditionRule
  {
    public ConditionIsNull()
    {
      //nothing there so far, just initialization
    }

    override public void Accept(ValueText v, ref bool result)
    {
      result = v.Text == "";
    }

  }
}
