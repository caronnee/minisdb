using MiniDatabase.SearchEngine.Conditions;
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
using MiniDatabase.Misc;
using MiniDatabase.Records;

namespace MiniDatabase.Content.ResultsTab
{
  /// <summary>
  /// Interaction logic for SelectTab.xaml
  /// </summary>
  public partial class ResultSelect : RecordableTab
  {
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

    ConditionHolder Conditions
    {
      get;
      set;
    }

    private void ToggleButton_Click(object sender, RoutedEventArgs e)
    {
      ToggleButton b = sender as ToggleButton;
      ListBox box = FindName("Operations") as ListBox;
      // change to the othername        
      box.DisplayMemberPath = (b.IsChecked == true) ? "InvertedOperationName" : "OperationName";
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

    private void Add_C_Click(object sender, RoutedEventArgs e)
    {
      ListBox listbox = FindName("Operations") as ListBox;
      SimpleExpressionHolder h = listbox.SelectedItem as SimpleExpressionHolder;
      ListBox names = FindName("AttributeName") as ListBox;
      int desindex = names.SelectedIndex;
      RecordDescription des = names.SelectedItem as RecordDescription;
      ToggleButton b = FindName("InvertCheck") as ToggleButton;

      ConditionRule rule = h.Create(b.IsChecked == true, desindex, des.VControl.ConvertToValue());
      Conditions.Conditions.Add(rule);
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
      Conditions.Conditions.Clear();
    }
  }
}
