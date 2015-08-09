using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;


namespace MiniDatabase.Records.Values
{
  public class ValueDate : Value
  {
    public DateTime DTime
    {
      get;
      set;
    }

    public Value Clone()
    {
      ValueDate d = new ValueDate();
      d.DTime = DTime;
      return d;
    }

    public ValueDate()
    {
      DTime = DateTime.Today;
    }

    public bool Eval(ConditionRule con)
    {
      return con.Accept(this);
    }

    public override string ToString()
    {
      return DTime.ToString(Misc.Common.dateFormat);
    }

    public void Save(System.IO.BinaryWriter writer)
    {
      Int64 toWrite = DTime.Ticks; 
      writer.Write( toWrite );
    }

    public void Load(System.IO.BinaryReader reader)
    {
      long ticks = reader.ReadInt64();
      DTime = new DateTime( ticks );
    }
  }
}
