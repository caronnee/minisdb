using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Exceptions
{
    class ExceptionBadData : Exception
    {
        public ExceptionBadData(String description) : base(description)
        {

        }
    }
}
