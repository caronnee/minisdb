using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionLess : ConditionRule
  {
    override public bool Accept(ValueText v)
    {
      ValueText t = Reference as ValueText;
      for (int i = 0; i < t.Text.Length; i++ )
      {
        if (v.Text[i] != t.Text[i])
          return v.Text[i] < t.Text[i];
      }
      return false;
    }
    override public bool Accept(ValueDate v)
    {
      ValueDate r = Reference as ValueDate;
      return r.DTime < v.DTime;
    }
    override public bool Accept(ValueInteger v)
    {
      ValueInteger r = Reference as ValueInteger;
      return r.NNumber < v.NNumber;
    }  
  }
}
