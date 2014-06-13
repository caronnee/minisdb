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
        public ObservableCollection<String> Columns
        {
            get;
            set;
        }

        public ObservableCollection<Record> Results
        {
            get;
            set;
        }

        public object Condition
        {
            get;
            set;
        }

        public ResultList()
        {
            Results = new ObservableCollection<Record>();
            Columns = new ObservableCollection<String>();
            MinPerPage = 0;
            MaxPerPage = -1;
            InitializeComponent();
        }

        public int MaxPerPage
        {
            get;
            set;
        }

        public int MinPerPage
        {
            get;
            set;
        }
        
        public void ReloadEntries( )
        {
            RecordsManager manager = DataContext as RecordsManager;
            if (DataContext == null)
              return;
            Results.Clear();
            List<Record> l = manager.Select(Condition, MinPerPage, MaxPerPage);
            foreach ( Record r in l )
            {
                Results.Add(r);
            }
        }

        private void InitEntries(object sender, RoutedEventArgs e)
        {
            // set the names
            Columns.Clear();
            RecordsManager manager = DataContext as RecordsManager;
            if (manager == null)
              return;
            manager.updateAction += new RecordsManager.UpdateHandler( ReloadEntries );
            for (int i = 0; i < manager.Description.Count; i++)
            {
                String col = manager.Description[i].Name.ToString();
                Columns.Add(col);
            }
            //for (int i = 0; i < manager.Description.Count; i++)
            //{
            //    DataGridTextColumn col = new DataGridTextColumn();
            //    col.Header = manager.Description[i].Name;
            //    Results.Columns.Add(col);
            //}
            ReloadEntries();
        }
    }
}
