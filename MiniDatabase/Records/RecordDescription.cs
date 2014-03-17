using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiniDatabase.Misc;
using System.Windows;
using MiniDatabase.Exceptions;
using System.Windows.Controls;

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
            writer.Write(Name);
            writer.Write(Misc.Common.Deliminer);
        }

        public virtual Control CreateControl()
        {
            throw new Exception("Not implemented");
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
            char c = reader.ReadChar();
            StringBuilder builder = new StringBuilder();
            while (c != Misc.Common.Deliminer)
            {
                builder.Append(c);
                c = reader.ReadChar();
            }
            Name = builder.ToString();
        }

        public String Name
        {
            get;
            set;
        }
    }
}
