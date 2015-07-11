using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Records
{
  public class ValueInteger : Value
  {
    public int NNumber
    {
      get;
      set;
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
