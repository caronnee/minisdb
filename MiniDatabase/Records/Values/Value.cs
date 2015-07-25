using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using MiniDatabase.SearchEngine.Conditions;


namespace MiniDatabase.Records.Values
{
  public abstract class Value
  {
    public virtual bool Eval(ConditionRule con)
    {
      return false;
    }

    public virtual void Save(System.IO.BinaryWriter writer)
    {
      throw new NotImplementedException();
    }

    public virtual void Load(System.IO.BinaryReader writer)
    {
      throw new NotImplementedException();
    }
  }
}
