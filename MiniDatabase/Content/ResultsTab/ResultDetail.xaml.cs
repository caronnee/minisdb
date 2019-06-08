using System;
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
using MiniDatabase.Records.Description;


namespace MiniDatabase.Content.ResultsTab
{
  /// <summary>
  /// Interaction logic for ResultDetail.xaml
  /// </summary>
  /// 
  // server also as detail of the form
  public partial class ResultDetail : RecordableTab
  {
    public ResultDetail()
    {
      InitializeComponent();
    }

    public bool CanBeEdited
    {
      get;
      set;
    }

    public void CreateNewForm()
    {
      RecordsManager manager = DataContext as RecordsManager;
      Entries.Children.Clear();
      foreach (RecordDescription r in manager.Description)
      {
        // todo improve, give to the proper position
        Grid panel = new Grid();
        ColumnDefinition def = new ColumnDefinition();
        def.Width = new GridLength(1.0, GridUnitType.Star);
        panel.ColumnDefinitions.Add(def);
        panel.Name = r.Name;
        Label l = new Label();
        l.Content = r.Name;        
        panel.Children.Add(l);
        panel.Children.Add(r.VControl.Clone());
        Entries.Children.Add(panel);
      }
      Separator s = new Separator();
      Entries.Children.Add(s);
    }

    private void AddRecord(object sender, RoutedEventArgs e)
    {
      RecordsManager manager = DataContext as RecordsManager;
      StackPanel c = FindName("Entries") as StackPanel;
      int count = manager.Description.Count;
      Record rec = new Record(count);
      for (int index=0,i = 0; i < c.Children.Count; i++ )
      {
        ControlValue val = c.Children[i] as ControlValue;
        if (val == null)
          continue;
        rec.SetValue(val.ConvertToValue(), index);
        index++;
      }
      ParentContent.OnInfo("Added record");
      manager.AddRecord(rec);
      CreateNewForm();
    }
  }
}
