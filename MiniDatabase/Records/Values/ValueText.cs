using System;
using System.Collections.Generic;
using System.Text;
using MiniDatabase.SearchEngine.Conditions;


namespace MiniDatabase.Records.Values
{
  public class ValueText : Value
  {
    // todo this Textu should go into some tree maybe?
    public String Text
    {
      get;
      set;
    }

    public override bool Eval(ConditionRule con)
    {
      return con.Accept(this);
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
      writer.Write(Text);
    }

    public override void Load(System.IO.BinaryReader reader)
    {
      Text = reader.ReadString();
    }
  }
}
