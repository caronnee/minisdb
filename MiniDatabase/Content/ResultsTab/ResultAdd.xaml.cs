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
                c.Children.Add(r.CreateControl());
            }
        }
    }
}
