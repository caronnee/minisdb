using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionEqual : ConditionRule
  {
    override public void Accept(Value v, ref bool result)
    {
      result = false;
    }
    override public void Accept(ValueText v, ref bool result)
    {
      ValueText t = Reference as ValueText;
      result = v.Text.Equals(t);
    }
    override public void Accept(ValueDate v, ref bool result)
    {
      ValueDate r = Reference as ValueDate;
      result = r.DTime == v.DTime;
    }
    override public void Accept(ValueInteger v, ref bool result)
    {
      ValueInteger r = Reference as ValueInteger;
      result = r.NNumber == v.NNumber;
    }
    
  }
}
