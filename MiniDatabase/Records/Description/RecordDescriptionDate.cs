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
  public class RecordDescriptionDate: RecordDescription
  {
    public RecordDescriptionDate()
    {
      VControl = new InputControlDate();
      PresetValue = new ValueText();
    }
    public override void Save(BinaryWriter writer)
    {
      base.Save(writer);
      PresetValue.Save(writer);
    }
    public override Value CreateValueFromString(String str)
    {
      return new ValueText(str);
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
      return Types.TypeDate;
    }
  }
}
