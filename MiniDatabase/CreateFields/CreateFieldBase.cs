using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;

namespace MiniDatabase.CreateFields
{
    interface CreateFieldBase
    {
        /** Checks if this record is fully set up */
        bool Valid();

        /* Return valid record corresponding to the control that implements this */
        RecordDescription GetRecord();
    }
}
