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
using System.IO;
using MiniDatabase.Misc;
using System.Collections.ObjectModel;

namespace MiniDatabase.Content
{
    /// <summary>
    /// Interaction logic for OpenDatabase.xaml
    /// </summary>
    public partial class OpenDatabase : Window
    {
        public OpenDatabase()
        {
            DataContext = this;
            Filenames = new ObservableCollection<FileInfo>();
            //find all files in database
            InitializeComponent();

            DirectoryInfo d = new DirectoryInfo(@"."); // TODO specified directory
            ListBox box = FindName("Databases") as ListBox;
            foreach (FileInfo fi in d.GetFiles())
            {
                if (fi.Extension.Equals( Common.DbExt ))
                {
                    Filenames.Add(fi);               
                }
            }
            if (Filenames.Count == 0)
                throw new MiniDatabase.Exceptions.ExceptionNoData();
        }

        public ObservableCollection<FileInfo> Filenames
        {
            get;
            set;
        }

        public FileInfo Filename
        {
            get;
            set;
        }

        private void LoadDatabase(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
