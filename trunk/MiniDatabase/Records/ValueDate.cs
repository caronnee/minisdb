using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Records
{
    class ValueDate : Value
    {
        private DateTime dTime;
        public ValueDate(DateTime d)
        {
            dTime = d;
        }
        public override int compare(DateTime d)
        {
            if (dTime.Date > d.Date)
                return 1;
            if (dTime.Date < d.Date)
                return -1;
            return 0;
        }
        public override int compare(Value v)
        {
            if (v == null) //FUJ! musim stale ifovat
                return -1;
            return v.compare(dTime);
        }
        public override string ToString()
        {
            return dTime.ToString(Misc.Common.dateFormat);
        }
    }
}
