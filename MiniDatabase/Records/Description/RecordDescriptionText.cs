using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.IO;
using MiniDatabase.Records.InputControl;
using MiniDatabase.Records.Values;
using MiniDatabase.Misc;

namespace MiniDatabase.Records.Description
{
  public class RecordDescriptionText : RecordDescription
  {
    public RecordDescriptionText()
    {
      VControl = new InputControlText("");
      PresetValue = new ValueText();
    }
    public override void Save(BinaryWriter writer)
    {
      base.Save(writer);
      PresetValue.Save(writer);
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
