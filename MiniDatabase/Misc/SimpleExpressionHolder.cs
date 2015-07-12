using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;
using MiniDatabase.Records;

namespace MiniDatabase.Misc
{
  public enum ConditionType
  {
    CContain,
    CEqual,
    CLess,
    CNull
  }
  public class SimpleExpressionHolder
  {
    public String OperationName;
    public String InvertedOperationName;
    public ConditionType CType;
    public Condition Create(bool negative,int index, Value val)
    {
      Condition c = null;
      switch (CType)
      {
        case ConditionType.CContain:
          {
            c = new ConditionContains();
            break;
          }
        case ConditionType.CEqual:
          {
            c = new ConditionContains();
            break;
          }
        case ConditionType.CLess:
          {
            c = new ConditionContains();
            break;
          }
        case ConditionType.CNull:
          {
            c = new ConditionContains();
            break;
          }
      }
      c.Index = index;
      c.Reference = val;
      if (negative)
        return new ConditionNot() { ToNegate = c };
      return c;
    }
  }
}
