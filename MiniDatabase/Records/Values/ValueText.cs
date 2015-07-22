using System;
using System.Collections.Generic;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;

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

    public override void Eval(ConditionRule con, ref bool result)
    {
      con.Accept(this, ref result);
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
    }

    public override void Load(System.IO.BinaryReader reader)
    {
      Text = reader.ReadString();
    }
  }
}
