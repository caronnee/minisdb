using MiniDatabase.Banks;
using MiniDatabase.Misc;
using MiniDatabase.Records.InputControl;
using MiniDatabase.Records.Values;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace MiniDatabase.Records.Description
{
  public class RecordDescriptionEnum: RecordDescription
  {
    public RecordDescriptionEnum() {
      // -1 - not selected
      PresetValue = new ValueInteger();
      VControl = new InputControlEnum();
    }

    public override Types GetRecordType()
    {
      return Types.TypeEnum;
    }

    /** basic save */
    public override void Save(BinaryWriter writer)
    {
      base.Save(writer);
      InputControlEnum e = VControl as InputControlEnum;
      writer.Write(e.EnumContainer.Name);
      PresetValue.Save(writer);
    }

    /** basic load */
    public override void Load(BinaryReader reader)
    {
      base.Load(reader);
      InputControlEnum c = new InputControlEnum();
      String eName = reader.ReadString();
      c.EnumContainer = EnumBank.Bank.Find(eName);
      VControl = c;
      PresetValue = new ValueInteger();
      PresetValue.Load(reader);
      VControl.SetValue(PresetValue);
    }
  }
}
