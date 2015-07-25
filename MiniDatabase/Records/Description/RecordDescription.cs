using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Windows;

using System.Windows.Controls;
using MiniDatabase.Records.Values;
using MiniDatabase.Misc;
using MiniDatabase.Exceptions;

namespace MiniDatabase.Records.Description
{
  public interface ControlValue
  {
    Value ConvertToValue();
    void SetValue( Value value );
    String GetStringValue();
    Control Clone();
  }

  public class RecordDescription : DependencyObject
  {
    public Value PresetValue
    {
      get;
      set;
    }

    public ControlValue VControl
    {
      get;
      set;
    }
    public virtual Value CreateValueFromString(String str)
    {
      return null;
    }

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
      // name consists of string and deliminer
      writer.Write(Name);
    }

    /** basic load */
    public virtual void Load(BinaryReader reader)
    {
      Name = reader.ReadString();
    }

    public static void SaveRecordType(BinaryWriter writer, RecordDescription desc )
    {
      writer.Write((int)desc.GetRecordType());
    }

    public static RecordDescription LoadRecordFromType(BinaryReader reader)
    {
      int t = reader.ReadInt32();
      if (t < 0)
        return null;
      Types type = (Types) t ;
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

    public String Name
    {
      get;
      set;
    }
  }
}
