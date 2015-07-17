﻿using System;
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
    public String OperationName
    {
      get;
      set;
    }
    public String InvertedOperationName
    {
      get;
      set;
    }
    public ConditionType CType
    {
      get;
      set;
    }
    public ConditionRule Create(bool negative, int index, Value val)
    {
      ConditionRule c = null;
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
