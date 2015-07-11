using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionEqual : Condition
  {
    override public void Compare(Value v, ref bool result)
    {
      result = false;
    }
    override public void Compare(ValueText v, ref bool result)
    {
      ValueText t = Reference as ValueText;
      result = v.Text.Equals(t);
    }
    override public void Compare(ValueDate v, ref bool result)
    {
      ValueDate r = Reference as ValueDate;
      result = r.DTime == v.DTime;
    }
    override public void Compare(ValueInteger v, ref bool result)
    {
      ValueInteger r = Reference as ValueInteger;
      result = r.NNumber == v.NNumber;
    }
  }
}
