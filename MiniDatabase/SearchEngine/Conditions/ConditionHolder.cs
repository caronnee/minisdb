using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using MiniDatabase.Records;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionHolder : DependencyObject
  {
    public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(String), typeof(ConditionHolder), new PropertyMetadata(null));

    public ConditionHolder()
    {
      Conditions = new List<IConditionRule>();
      Clear();
    }

    public void Clear()
    {
      Conditions.Clear();
      Name = "Empty";
      nodeDescriptions = new List<String>();
    }
    public List<String> nodeDescriptions;

    public void Add(IConditionRule rule, String des)
    {
      if (Conditions.Count > 0)
      {
        Conditions.RemoveAt(Conditions.Count - 1);
        nodeDescriptions.RemoveAt(nodeDescriptions.Count - 1);        
      }
      Conditions.Add(rule);
      nodeDescriptions.Add(des);
      if (Conditions.Count == 1)
        Name = des;
      else
      {
        foreach( String s in nodeDescriptions )
          Name = Name + " And " + s;
      }
    }
    List<IConditionRule> Conditions
    {
      get;
      set;
    }

    public string Name
    {
      get
      {
        return (string)GetValue(NameProperty);
      }
      set
      {
        SetValue(NameProperty, value);
      }
    }

    public bool Accept( Record record )
    {
      foreach (IConditionRule rule in Conditions)
      {
        if (!rule.Accept(record))
          return false;
      }
      return true;
    }

    public void MakeLastPermanent()
    {
      Conditions.Add(null);
    }
  }
}
