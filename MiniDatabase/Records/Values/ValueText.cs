using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDatabase.Records
{
  public class ValueText : Value
  {
    // todo this Textu should go into some tree maybe?
    public String Text
    {
      get;
      set;
    }

    public ValueText(string txt = "")
    {
      Text = txt;
    }
  
    public override string ToString()
    {
      return Text;
    }

    public override void Save(System.IO.BinaryWriter writer)
    {
      if (Text.Length > 0)
        writer.Write(Text);
      writer.Write(Misc.Common.Deliminer);
    }

    public override void Load(System.IO.BinaryReader reader)
    {
      char s = reader.ReadChar();
      StringBuilder builder = new StringBuilder();
      while (s != Misc.Common.Deliminer)
      {
        builder.Append(s);
        s = reader.ReadChar();
      }
      Text = builder.ToString();
    }
  }
}
