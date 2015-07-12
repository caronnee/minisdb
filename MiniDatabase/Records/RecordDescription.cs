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
  public interface ControlValue
  {
    Value ConvertToValue();
    void SetValue( Value value );
  }

  public class RecordDescription : DependencyObject
  {
    private ControlValue _vControl;
    public Value PresetValue
    {
      get;
      set;
    }

    public ControlValue VControl
    {
      get
      {
        _vControl.SetValue(PresetValue);
        return _vControl;
      }
      set
      {
        _vControl = value;
      }
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
      writer.Write(Misc.Common.Deliminer);
    }

    public static void SaveRecordType(BinaryWriter writer, RecordDescription desc )
    {
      writer.Write((int)desc.GetRecordType());
    }

    public static RecordDescription LoadRecordFromType(BinaryReader reader)
    {
      Types type = (Types)reader.ReadInt32();
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
    public virtual void Load(BinaryReader reader)
    {
      char c = reader.ReadChar();
      StringBuilder builder = new StringBuilder();
      while (c != Misc.Common.Deliminer)
      {
        builder.Append(c);
        c = reader.ReadChar();
      }
      Name = builder.ToString().Trim(Common.Whitespaces);
    }

    public String Name
    {
      get;
      set;
    }
  }
}
