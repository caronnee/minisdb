
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MiniDatabase.SearchEngine.Conditions;
using MiniDatabase.Misc;
using MiniDatabase.Records.Description;



namespace MiniDatabase.Content.ResultsTab
{
  /// <summary>
  /// Interaction logic for SelectTab.xaml
  /// </summary>
  public partial class ResultSelect : RecordableTab
  {
    public static readonly DependencyProperty ConditionProperty = DependencyProperty.Register("Conditions", typeof(ConditionHolder), typeof(RecordableTab), new PropertyMetadata(null));
    public ResultSelect()
    {
      InitializeComponent();
      Conditions = new ConditionHolder();
    }

    public string FilterName
    {
      get;
      set;
    }

    public ConditionHolder Conditions
    {
      get
      {
        return (ConditionHolder)GetValue(ConditionProperty);
      }
      set
      {
        SetValue(ConditionProperty, value);
      }
    }

    private void ToggleButton_Click(object sender, RoutedEventArgs e)
    {
      foreach (SimpleExpressionHolder s in Misc.Common.SimpleExpressions)
      {
        s.MakeSwitch();
      }
      UpdateLastCondition();
    }

    String TruncatedName(String name)
    {
      // maximum 5 letters +3x .
      if (name.Length > 5)
      {
        String n = name.Substring(0, 5) + "...";
        return n;
      }
      return name;
    }

    private void Select_Click(object sender, RoutedEventArgs e)
    {
      // create conditions
      TabControl c = Parent as TabControl;
      ResultList list = new ResultList();
      list.Conditions = Conditions;
      if (FilterName == null || FilterName == "")
        FilterName = "Default Customer";
      list.Question = FilterName;
      list.Header = TruncatedName(FilterName);
      c.Items.Insert(c.SelectedIndex + 1, list);
      c.SelectedIndex = c.SelectedIndex + 1;
    }

    private void UpdateLastCondition()
    {
      // add permanently and create new
      ListBox listbox = FindName("Operations") as ListBox;
      SimpleExpressionHolder h = listbox.SelectedItem as SimpleExpressionHolder;
      ListBox names = FindName("AttributeName") as ListBox;
      int desindex = names.SelectedIndex;
      RecordDescription des = names.SelectedItem as RecordDescription;
      if (des == null)
        return;
      string sDes = string.Format("{0} {1} {2}", des.Name, h.Operation, des.VControl.GetStringValue());
      IConditionRule rule = h.Create(desindex, des.VControl.ConvertToValue());
      Conditions.Add(rule, sDes);
    }

    private void Add_C_Click(object sender, RoutedEventArgs e)
    {
      Conditions.MakeLastPermanent();
      ListBox names = FindName("AttributeName") as ListBox;
      RecordDescription des = names.SelectedItem as RecordDescription;
      des.VControl.SetValue(des.PresetValue); 
      UpdateLastCondition();
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
      Conditions.Clear();
      ListBox names = FindName("AttributeName") as ListBox;
      RecordDescription des = names.SelectedItem as RecordDescription;
      des.VControl.SetValue(des.PresetValue); 
      UpdateLastCondition();
    }

    private void AttributeName_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      UpdateLastCondition();
    }

    private void User_Entry_KeyUp(object sender, KeyEventArgs e)
    {
      UpdateLastCondition();
    }

    private void User_Entry_MouseUp(object sender, MouseButtonEventArgs e)
    {
      UpdateLastCondition();
    }
  }
}
