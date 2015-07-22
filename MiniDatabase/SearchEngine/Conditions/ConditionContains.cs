using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionContains : ConditionRule
  {
    public ConditionContains()
    {
      //nothing there so far, just initialization
    }

    override public void Accept(ValueText v, ref bool result)
    {
      ValueText r = Reference as ValueText;
      result = r.Text.Contains(v.Text);
    }
  }
}
