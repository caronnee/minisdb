﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MiniDatabase.Records;

namespace MiniDatabase.Content.ResultsTab
{
  /// <summary>
  /// Interaction logic for ResultAdd.xaml
  /// </summary>
  public partial class ResultAdd : TabItem
  {
    public ResultAdd()
    {
      InitializeComponent();
    }

    public void CreateNewForm()
    {
      RecordsManager manager = DataContext as RecordsManager;
      StackPanel c = FindName("Controls") as StackPanel;
      c.Children.Clear();
      foreach (RecordDescription r in manager.Description)
      {
        // todo improve
        Label l = new Label();
        l.Content = r.Name;
        c.Children.Add(l);
        c.Children.Add(r.CreateControl());
      }
      Separator s = new Separator();
      c.Children.Add(s);
    }

    private void AddRecord(object sender, RoutedEventArgs e)
    {
      RecordsManager manager = DataContext as RecordsManager;
      StackPanel c = FindName("Controls") as StackPanel;
      int count = manager.Description.Count;
      Record rec = new Record(count);
      for (int index = 0; index < count; index++ )
      {
        ControlValue val = c.Children[index] as ControlValue;
        if (val == null)
          continue;
        rec.SetValue(val.ConvertToValue(), index);
      }
      manager.AddRecord(rec);
      CreateNewForm();
    }
  }
}
