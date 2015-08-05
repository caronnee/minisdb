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
using System.Collections.ObjectModel;
using System.IO;
using System.ComponentModel;

namespace MiniDatabase.Banks
{
  public class EnumCollection : INotifyPropertyChanged
  {
    public ObservableCollection<String> Values
    {
      get;
      set;
    }

    private string str;

    public String Name
    {
      get { return str; }
      set { str = value; NotifyPropertyChanged("Name"); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // This method is called by the Set accessor of each property. 
    // The CallerMemberName attribute that is applied to the optional propertyName 
    // parameter causes the property name of the caller to be substituted as an argument. 
    private void NotifyPropertyChanged(String propertyName = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    // creates one collection that is empty
    public EnumCollection(String name)
    {
      Name = name;
      Values = new ObservableCollection<String>();
    }
  }
  public class EnumBank : DependencyObject
  {
    private static EnumBank _bank;

    static public EnumBank Bank
    {
      get
      {
        if (_bank == null)
        {
          _bank = new EnumBank();
          _bank.Load();
        }
        return _bank;
      }
    }

    public static DependencyProperty CollectionProperty = DependencyProperty.Register("Collections", typeof(ObservableCollection<EnumCollection>), typeof(EnumBank), new PropertyMetadata(null));

    public EnumBank()
    {
      Collections = new ObservableCollection<EnumCollection>();
    }

    public EnumCollection Find(string name)
    {
      foreach (EnumCollection col in Collections)
      {
        if (col.Name == name)
          return col;
      }
      return null;
    }

    private void Load()
    {
      try
      {
        StreamReader reader = new StreamReader(Misc.Common.SaveFolder + Misc.Common.EnumConfigFile);
        while (reader.EndOfStream == false)
        {
          String s = reader.ReadLine();
          String[] val = s.Split(Misc.Common.Whitespaces, StringSplitOptions.RemoveEmptyEntries);
          int index = CreateEnum(val[0]);
          EnumCollection c = Collections.ElementAt(index);
          for (int i = 1; i < val.GetLength(0); i++)
          {
            c.Values.Add(val[i]);
          }
        }
      }
      catch (FileNotFoundException)
      {
        Console.Out.WriteLine("File was not found. Creating default one");
      }
    }
    public void Save()
    {
      StreamWriter writer = new StreamWriter(Misc.Common.SaveFolder + Misc.Common.EnumConfigFile);
      foreach (EnumCollection c in Collections)
      {
        if (c.Values.Count == 0)
          continue;
        writer.Write(c.Name);
        foreach (String s in c.Values)
        {
          writer.Write(Misc.Common.Whitespaces[0]);
          writer.Write(s);
        }
        writer.WriteLine();
      }
      writer.Close();
    }

    public ObservableCollection<EnumCollection> Collections
    {
      get { return (ObservableCollection<EnumCollection>)GetValue(CollectionProperty); }
      set { SetValue(CollectionProperty, value); }
    }

    public int CreateEnum(String name)
    {
      EnumCollection c;
      for (int i = 0; i < Collections.Count; i++)
      {
        c = Collections.ElementAt(i);
        if (c.Name == name)
          return i;
      }
      c = new EnumCollection(name);
      Collections.Add(c);
      return Collections.Count - 1;
    }

    public int Rename(String oldName, String newName)
    {
      int index = CreateEnum(oldName);
      Collections[index].Name = newName;
      return index;
    }

    static Predicate<EnumCollection> ByName(String s)
    {
      return delegate(EnumCollection c)
      {
        return c.Name == s;
      };
    }
  }
}
