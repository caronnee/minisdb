using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;


namespace MiniDatabase.Records.Values
{
  public class ValueDate : Value
  {
    public DateTime DTime;
    public ValueDate(DateTime d)
    {
      DTime = d;
    }

    public override bool Eval(ConditionRule con)
    {
      return con.Accept(this);
    }

    public override string ToString()
    {
      return DTime.ToString(Misc.Common.dateFormat);
    }

    public override void Save(System.IO.BinaryWriter writer)
    {
      writer.Write( (Int32)DTime.Ticks );
    }

    public override void Load(System.IO.BinaryReader reader)
    {
      DTime = new DateTime( reader.ReadInt32() );
    }
  }
}
