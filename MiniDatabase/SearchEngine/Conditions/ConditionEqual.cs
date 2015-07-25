using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records.Values;


namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionEqual : ConditionRule
  {
    override public bool Accept(ValueText v)
    {
      ValueText t = Reference as ValueText;
      return v.Text.Equals(t);
    }
    override public bool Accept(ValueDate v)
    {
      ValueDate r = Reference as ValueDate;
      return r.DTime == v.DTime;
    }
    override public bool Accept(ValueInteger v)
    {
      ValueInteger r = Reference as ValueInteger;
      return r.NNumber == v.NNumber;
    }    
  }
}
