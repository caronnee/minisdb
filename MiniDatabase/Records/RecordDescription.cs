using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiniDatabase.Misc;
using System.Windows;
using MiniDatabase.Exceptions;

namespace MiniDatabase.Records
{
    public class RecordDescription : DependencyObject
    {
        public virtual Value ReadValueFromDescription(BinaryReader reader)
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

        public virtual Types GetRecordType()
        {
            throw new MiniDatabase.Exceptions.ExceptionBadData("Bad record type");
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
                        return new RecordDescriptionText();
                    }
                default:
                    throw new ExceptionBadData("Something bad had happened, Harry");
            }
        }

        /** basic load */
        public virtual void Load( BinaryReader reader)
        {
            // nothing needs to be loaded
        }
    }
}
