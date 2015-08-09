using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records.Description;

namespace MiniDatabase.Content.CreateFields
{
    interface FieldInterface
    {
        /* Return valid record corresponding to the control that implements this */
        RecordDescription GetRecordDescription();
    }
}
