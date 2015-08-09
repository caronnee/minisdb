using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MiniDatabase.Records.Values;
using MiniDatabase.Misc;
using MiniDatabase.Records.InputControl;
using System.Windows;

namespace MiniDatabase.Records.Description
{
  public class RecordDescriptionInt : RecordDescription
  {
    public static DependencyProperty MaxValueProp = DependencyProperty.Register("MaxValue", typeof(int), typeof(RecordDescriptionInt), new PropertyMetadata(null));
    public static DependencyProperty MinValueProp = DependencyProperty.Register("MinValue", typeof(int), typeof(RecordDescriptionInt), new PropertyMetadata(null));

    public RecordDescriptionInt()
    {
      VControl = new InputControlInt();
      MinValue = -1;
      MaxValue = 10;
      PresetValue = new ValueInteger();
    }

    public int MinValue
    {
      get
      {
        return (int)GetValue(MinValueProp);
      }
      set
        {
          SetValue(MinValueProp, value);
        }
    }

    public int MaxValue
    {
      get
      {
        return (int)GetValue(MaxValueProp);
      }
      set
      {
        SetValue(MaxValueProp, value);
      }
    }

    public override void Save(BinaryWriter writer)
    {
      base.Save(writer);
      writer.Write(MinValue);
      writer.Write(MaxValue);         
      PresetValue.Save(writer);
    }

    public override void Load(BinaryReader reader)
    {
      PresetValue = new ValueInteger();

      base.Load(reader);
      MinValue = reader.ReadInt32();
      MaxValue = reader.ReadInt32();
      PresetValue.Load(reader);
      VControl.SetValue(PresetValue);
    }

    public override Types GetRecordType()
    {
      return Types.TypeInteger;
    }
  }
}
