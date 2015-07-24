using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;
using MiniDatabase.Records;
using System.Windows;

namespace MiniDatabase.Misc
{
  public enum ConditionType
  {
    CContain,
    CEqual,
    CLess,
    CNull
  }
  public class SimpleExpressionHolder : DependencyObject
  {
    public static DependencyProperty OperationProperty = DependencyProperty.Register("Operation", typeof(String), typeof(SimpleExpressionHolder), new PropertyMetadata(null));

    public void MakeSwitch()
    {
      OIndex = OIndex == 0?1:0;
      Operation = OperationNames[OIndex];
    }
    public String Operation
    {
      get
      {
        return (String)GetValue(OperationProperty);
      }
      set
      {
        SetValue(OperationProperty, value);
      }
    }

    int OIndex
    {
      get;
      set;
    }

    String[] operations;
    public String[] OperationNames
    {
      get
      {
        return operations;
      }
      set
      {
        operations = value;
        OIndex = 0;
        Operation = OperationNames[OIndex];
      }
    }

    public ConditionType CType
    {
      get;
      set;
    }

    public IConditionRule Create( int index, Value val)
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
      if (OIndex == 0) // TODO copy for safety
        return c;
      return new ConditionNot() { ToNegate = c };
    }
  }
}
