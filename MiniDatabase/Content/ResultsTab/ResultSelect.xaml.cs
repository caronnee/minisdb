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

    public static readonly DependencyProperty SelectedProp = DependencyProperty.Register("SelectedContent", typeof(Control), typeof(ResultSelect), new PropertyMetadata(null));

    public Control SelectedContent
    {
      get
      {
        return (Control)GetValue(SelectedProp);
      }
      set
      {
        SetValue(SelectedProp, value);
      }
    }

    public string FilterName
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

    private void AttributeName_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ListBox box = sender as ListBox;
      Records.RecordDescription des = box.SelectedItem as Records.RecordDescription;
      SelectedContent = des.VControl as Control;
    }
  }
}
