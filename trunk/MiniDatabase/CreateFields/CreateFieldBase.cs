using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase.CreateFields
{
    interface CreateFieldBase
    {
        bool Valid();
        Records.Record GetRecord();
    }
}
