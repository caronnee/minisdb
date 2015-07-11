using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Records
{
  public class ValueDate : Value
  {
    public DateTime DTime;
    public ValueDate(DateTime d)
    {
      DTime = d;
    }

    public override string ToString()
    {
      return DTime.ToString(Misc.Common.dateFormat);
    }
  }
}
