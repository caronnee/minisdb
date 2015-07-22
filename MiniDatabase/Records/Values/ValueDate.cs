using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;

namespace MiniDatabase.Records
{
  public class ValueDate : Value
  {
    public DateTime DTime;
    public ValueDate(DateTime d)
    {
      DTime = d;
    }

    public override void Eval(ConditionRule con, ref bool result)
    {
      con.Accept(this, ref result);
    }

    public override string ToString()
    {
      return DTime.ToString(Misc.Common.dateFormat);
    }
  }
}
