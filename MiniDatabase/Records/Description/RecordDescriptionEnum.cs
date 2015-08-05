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
  class RecordDescriptionEnum: RecordDescription
  {
    public RecordDescriptionEnum() {
      PresetValue = new ValueInteger(-1);
      VControl = new InputControlEnum();
    }

    public override Value CreateValueFromString(String str)
    {
      return null;
      //int index = EnumContainer.Values.IndexOf(str);
      //return new ValueInteger(index);
    }

    public override Types GetRecordType()
    {
      return Types.TypeEnum;
    }

    /** basic save */
    public override void Save(BinaryWriter writer)
    {
      base.Save(writer);
      InputControlEnum en = VControl as InputControlEnum;
      writer.Write(en.EnumContainer.Name);
      PresetValue.Save(writer);
    }

    /** basic load */
    public override void Load(BinaryReader reader)
    {
      base.Load(reader);
      InputControlEnum c = new InputControlEnum();
      c.EnumContainer = EnumBank.Bank.Find(Name);
      VControl = c;
      PresetValue = new ValueInteger(-1);
      PresetValue.Load(reader);
    }
  }
}
