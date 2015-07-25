using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiniDatabase.Records.Values;
using MiniDatabase.Misc;
using MiniDatabase.Records.InputControl;

namespace MiniDatabase.Records.Description
{
  public class RecordDescriptionInt : RecordDescription
  {
    public RecordDescriptionInt()
    {
      VControl = new InputControlInt();
      PresetValue = new ValueInteger(0);
    }

    public int MinValue
    {
      get;
      set;
    }

    public int MaxValue
    {
      get;
      set;
    }

    public override void Save(BinaryWriter writer)
    {
      base.Save(writer);
      writer.Write(MinValue);
      writer.Write(MaxValue);         
      PresetValue.Save(writer);
    }
    public override Value CreateValueFromString(String str)
    {
      return new ValueInteger( Int32.Parse(str));
    }

    public override void Load(BinaryReader reader)
    {
      base.Load(reader);
      PresetValue = new ValueText();
      PresetValue.Load(reader);
      VControl.SetValue(PresetValue);
    }

    public override Types GetRecordType()
    {
      return Types.TypeText;
    }
  }
}
