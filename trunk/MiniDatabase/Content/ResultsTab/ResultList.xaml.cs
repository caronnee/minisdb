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
using System.Collections.ObjectModel;

namespace MiniDatabase.Content.ResultsTab
{
    /// <summary>
    /// Interaction logic for ResultList.xaml
    /// </summary>
    public partial class ResultList : TabItem
    {
        public ObservableCollection<Record> Results
        {
            get;
            set;
        }

        public ResultList()
        {
            InitializeComponent();
            Results = new ObservableCollection<Record>();
        }

        private void ReloadEntries()
        {
            RecordsManager manager = DataContext as RecordsManager;
            Results.Clear();
            manager.Select(null, Results, 0, -1);
        }
        private void InitEntries(object sender, RoutedEventArgs e)
        {
            ReloadEntries();
        }
    }
}
