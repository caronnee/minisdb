using System;
using System.Collections.Generic;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  //for all select that can be writable
  abstract public class ConditionRule
  {
    public int Index
    {
      get;
      set;
    }

    public Value Reference
    {
      get;
      set;
    }

    virtual public bool Accept(Record record)
    {
      bool result = false;
      record.GetValue(Index).Eval(this, ref result);
      return result;
    }

    virtual public void Accept(Value v, ref bool result)
    {
      result = false;
    }
    virtual public void Accept(ValueText v, ref bool result)
    {
      result = false;
    }
    virtual public void Accept(ValueDate v, ref bool result)
    {
      result = false;
    }
    virtual public void Accept(ValueInteger v, ref bool result)
    {
      result = false;
    }
  }
}
