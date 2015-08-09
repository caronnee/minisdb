using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;


namespace MiniDatabase.Records.Values
{
  public class ValueInteger : Value
  {
    public int NNumber
    {
      get;
      set;
    }

    public Value Clone()
    {
      ValueInteger i = new ValueInteger();
      i.NNumber = NNumber;
      return i;
    }

    public bool Eval(ConditionRule con)
    {
      return con.Accept(this);
    }
    public ValueInteger()
    {
      NNumber = -1;
    }
    public override string ToString()
    {
      return NNumber.ToString();
    }
    public void Load(System.IO.BinaryReader reader)
    {
      NNumber = reader.ReadInt32();
    }
    public void Save(System.IO.BinaryWriter writer)
    {
      writer.Write(NNumber);
    }
  }
}
