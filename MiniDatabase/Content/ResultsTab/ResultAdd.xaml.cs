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

        // add rows
        private void Plus(object sender, RoutedEventArgs e)
        {
            RecordsManager manager = DataContext as RecordsManager;
            StackPanel c = FindName("Controls") as StackPanel;
            foreach ( RecordDescription r in manager.Description)
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

        private void AddRecords(object sender, RoutedEventArgs e)
        {
            RecordsManager manager = DataContext as RecordsManager;
            StackPanel c = FindName("Controls") as StackPanel;
            int count = manager.Description.Count;
            Record rec = new Record(count);
            int index =0;
            for (int i = 0; i < c.Children.Count; i++ )
            {
                ControlValue val = c.Children[i] as ControlValue;
                if ( val == null )
                    continue;
                rec.SetValue(val.ConvertToValue(), index);
                index++;
                if (index == count)
                {
                    manager.AddRecord(rec);
                    index = 0;
                }
            }
            manager.Save();
            c.Children.Clear();
        }
    }
}
