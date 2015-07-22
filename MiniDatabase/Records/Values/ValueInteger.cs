using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;

namespace MiniDatabase.Records
{
  public class ValueInteger : Value
  {
    public int NNumber
    {
      get;
      set;
    }
    public override void Eval(ConditionRule con, ref bool result)
    {
      con.Accept(this, ref result);
    }
    public ValueInteger(int i)
    {
      NNumber = i;
    }
    public override string ToString()
    {
      return NNumber.ToString();
    }
  }
}
