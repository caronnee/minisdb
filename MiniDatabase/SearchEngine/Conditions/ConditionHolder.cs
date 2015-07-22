using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Records;
using System.Windows;

namespace MiniDatabase.SearchEngine.Conditions
{
  public class ConditionHolder : DependencyObject
  {
    public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(String), typeof(ConditionHolder), new PropertyMetadata(null));

    public ConditionHolder()
    {
      Conditions = new List<ConditionRule>();
      Clear();
    }

    public void Clear()
    {
      Conditions.Clear();
      Name = "Empty";
    }
    public void Add(ConditionRule rule, String des)
    {
      Conditions.Add(rule);
      if (Conditions.Count == 1)
        Name = des;
      else
      {
        Name = Name + " And " + des;
      }
    }
    List<ConditionRule> Conditions
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
      foreach (ConditionRule rule in Conditions)
      {
        if (!rule.Accept(record))
          return false;
      }
      return true;
    }
  }
}
