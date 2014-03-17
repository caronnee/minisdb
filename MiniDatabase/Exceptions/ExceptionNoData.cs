using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Exceptions
{
    class ExceptionNoData : Exception
    {
        public ExceptionNoData()
        {
            this.Data.Add("", "No data found");
        }
    }
}
