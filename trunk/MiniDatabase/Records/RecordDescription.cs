using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiniDatabase.Misc;

namespace MiniDatabase.Records
{
    public class RecordDescription : RecordDescriptionInterface
    {
        public Value ReadValueFromDescription(BinaryReader reader)
        {
            Value ret;
            switch (GetRecordType())
            {
                case Types.TypeText:
                    ret = new ValueText();
                    break;
                default:
                    return null; // unrecognized
            }
            return ret;
        }

        public Types GetRecordType()
        {
            return Types.TypeUnknown;
        }

        /** basic save */
        public virtual void Save(BinaryWriter writer)
        {
            writer.Write((int)GetRecordType());
        }

        public static RecordDescription GetRecordFromType(Types type)
        {
            switch (type)
            {
                case Types.TypeText:
                    {
                        return new RecordText();
                    }
                default:
                    throw new Exception("Something bad happened, Harry");
            }
        }

        /** basic load */
        public virtual void Load( BinaryReader reader)
        {
            // nothing needs to be loaded
        }
    }
}
