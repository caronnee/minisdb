using System;
using System.IO;
using System.Text;
using MiniDatabase.Misc;

namespace MiniDatabase.Records
{
    interface RecordDescriptionInterface
    {
        Types GetRecordType();
        Value ReadValueFromDescription(BinaryReader reader);
    }
}
