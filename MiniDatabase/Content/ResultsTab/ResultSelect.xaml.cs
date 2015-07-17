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
    }

    public string FilterName
    {
      get;
      set;
    }

    List<ConditionRule> Conditions
    {
      get;
      set;
    }

    private void ToggleButton_Click(object sender, RoutedEventArgs e)
    {
      ToggleButton b = sender as ToggleButton;
      ListBox box = FindName("Operations") as ListBox;
      // change to the othername        
      box.DisplayMemberPath = (b.IsChecked == true)? "InvertedOperationName" : "OperationName";      
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
      if (FilterName == "")
        FilterName = "Default Customer";
      list.Question = FilterName;
      list.Header = TruncatedName(FilterName);
      c.Items.Insert(c.SelectedIndex +1,list);
      c.SelectedIndex = c.SelectedIndex+1;
    }
  }
}
