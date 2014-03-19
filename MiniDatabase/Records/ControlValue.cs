using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.Records
{
    interface ControlValue
    {
        Value ConvertToValue();
    }
}
