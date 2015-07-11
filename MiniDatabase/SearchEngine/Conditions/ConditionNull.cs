using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionIsNull : Condition
  {
    public ConditionIsNull()
    {
      //nothing there so far, just initialization
    }

    override public void Compare(ValueText v, ref bool result)
    {
      result = v.Text == "";
    }

  }
}
