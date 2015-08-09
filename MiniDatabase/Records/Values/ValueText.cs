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
    public Value Clone()
    {
      ValueText text = new ValueText();
      text.Text = Text;
      return text;
    }

    public bool Eval(ConditionRule con)
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

    public void Save(System.IO.BinaryWriter writer)
    {
      writer.Write(Text);
    }

    public void Load(System.IO.BinaryReader reader)
    {
      Text = reader.ReadString();
    }
  }
}
