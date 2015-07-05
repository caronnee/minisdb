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
  public partial class ChooseDatabase : ContentGeneric
  {
    public ChooseDatabase()
    {
      DataContext = this;
      Filenames = new ObservableCollection<FileInfo>();
      //find all files in database
      InitializeComponent();
    }

    public FileInfo Filename
    {
      get;
      set;
    }
    override public void Init()
    {
      DirectoryInfo d = new DirectoryInfo(@"."); // TODO specified directory
      ListBox box = FindName("Databases") as ListBox;
      foreach (FileInfo fi in d.GetFiles())
      {
        if (fi.Extension.Equals(Common.DbExt))
        {
          Filenames.Add(fi);
        }
      }
      OnInfo(string.Format("Found {0} records", Filenames.Count));
    }

    public ObservableCollection<FileInfo> Filenames
    {
      get;
      set;
    }

    private void DeleteDatabase(object sender, RoutedEventArgs e)
    {
      File.Delete(Filename.ToString());
      Filenames.Remove(Filename);
    }

    private void LoadDatabase(object sender, RoutedEventArgs e)
    {
      try
      {
        Records.RecordsManager manager = new Records.RecordsManager(Filename.ToString());
        Results r = new Results(manager);
        OnResult(r);
      }
      catch (MiniDatabase.Exceptions.ExceptionNoData)
      {
        MessageBox.Show("No valid database found. Please create one first");
        OnInfo("No valid database found");
      }
      catch (System.Exception)
      {
        MessageBox.Show("Corrupted database!", "Corruption detected");
        OnInfo(string.Format("Unable to load database {0}", Filename.ToString()));
      }
    }

    private void NewDatabase(object sender, RoutedEventArgs e)
    {
      OnResult(new CreateDatabase());
    }
  }
}
