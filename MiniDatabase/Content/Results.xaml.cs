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
using MiniDatabase.Content.ResultsTab;

namespace MiniDatabase.Content
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : ContentGeneric
    {
        public RecordsManager Database
        {
            get;
            set;
        }

        public Results(RecordsManager database)
        {
            Database = database;
            DataContext = Database;
            InitializeComponent();
        }

        private void ResultControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          ResultAdd current = (sender as TabControl).SelectedItem as ResultAdd;
          if (current == null)
            return;
          current.CreateNewForm();
        }
    }
}
