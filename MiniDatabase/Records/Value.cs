using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using MiniDatabase.SearchEngine.Conditions;

namespace MiniDatabase.Records
{
  public abstract class Value
  {
    public void Eval(ConditionRule con, ref bool result)
    {
      con.Accept(this, ref result);
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
