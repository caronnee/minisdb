﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Misc;
using MiniDatabase.Records.Text;
using System.Windows.Controls;
using System.IO;

namespace MiniDatabase.Records
{
  public class RecordDescriptionText : RecordDescription
  {
    public RecordDescriptionText()
    {
      PresetValue = new ValueText();
      VControl = new InputControlText("");
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
    }

    public override Types GetRecordType()
    {
      return Types.TypeText;
    }
  }
}