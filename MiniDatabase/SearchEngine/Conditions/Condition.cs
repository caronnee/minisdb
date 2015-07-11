using System;
using System.Collections.Generic;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  //for all select that can be writable
  abstract public class Condition
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

    virtual public bool Compare(Record record)
    {
      bool result = false;
      record.GetValue(Index).Eval(this, ref result);
      return result;
    }

    virtual public void Compare(Value v, ref bool result)
    {
      result = false;
    }
    virtual public void Compare(ValueText v, ref bool result)
    {
      result = false;
    }
    virtual public void Compare(ValueDate v, ref bool result)
    {
      result = false;
    }
    virtual public void Compare(ValueInteger v, ref bool result)
    {
      result = false;
    }
  }
}
