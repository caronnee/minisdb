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

    public bool Accept(Record record)
    {
      return record.GetValue(Index).Eval(this);
    }

    virtual public bool Accept(Value v)
    {
      return false;
    }
    virtual public bool Accept(ValueText v)
    {
      return false;
    }
    virtual public bool Accept(ValueDate v)
    {
      return false;
    }
    virtual public bool Accept(ValueInteger v)
    {
      return false;
    }
  }
}
