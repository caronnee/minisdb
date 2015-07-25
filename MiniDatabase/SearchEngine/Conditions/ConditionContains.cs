using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records.Values;


namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionContains : ConditionRule
  {
    public ConditionContains()
    {
      //nothing there so far, just initialization
    }
    override public bool Accept(ValueText v)
    {
      ValueText r = Reference as ValueText;
      return r.Text.Contains(v.Text);
    }

    override public bool Accept(ValueDate v)
    {
      ValueDate r = Reference as ValueDate;
      return r.ToString().Contains(v.ToString());
    }

    override public bool Accept(ValueInteger v)
    {
      return Reference.ToString().Contains(v.ToString());
    }
  }
}
