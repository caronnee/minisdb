using System;
using System.Collections.Generic;
using System.Text;
using MiniDatabase.Records;
using MiniDatabase.Records.Values;


namespace MiniDatabase.SearchEngine.Conditions
{
  public interface IConditionRule
  {
    bool Accept(Record record);
  }

  //for all select that can be writable
  public class ConditionRule : IConditionRule
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

    public bool Accept(Record record)
    {
      return record.GetValue(Index).Eval(this);
    }
  }
}
