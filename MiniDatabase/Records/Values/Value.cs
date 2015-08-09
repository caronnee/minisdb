using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using MiniDatabase.SearchEngine.Conditions;


namespace MiniDatabase.Records.Values
{
  public interface Value
  {
    bool Eval(ConditionRule con);
    void Save(System.IO.BinaryWriter writer);
    void Load(System.IO.BinaryReader reader);
    Value Clone();
  }
}
