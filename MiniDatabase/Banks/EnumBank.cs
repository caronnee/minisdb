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

namespace MiniDatabase.Banks
{
    public class EnumBank : DependencyObject 
    {
        public class EnumCollection
        {
            public ObservableCollection<String> Values
            {
                get;
                set;
            }

            public String Name
            {
                get;
                set;
            }

            // creates one collection that is empty
            public EnumCollection(String name)
            {
                Name = name;
                Values = new ObservableCollection<String>();
            }
            public override string ToString()
            {
                return Name;
            }
        }

        public static DependencyProperty CollectionProperty = DependencyProperty.Register("Collections", typeof(ObservableCollection<EnumCollection>), typeof(EnumBank), new PropertyMetadata(null));

        public EnumBank()
        {
            Collections = new ObservableCollection<EnumCollection>();
            Load();
        }

        private static char[] separators = new char[] { '.', ' ' };
        private string EnumConfigFile = "enums.config";

        private void Load()
        {
          try
          {
            StreamReader reader = new StreamReader(EnumConfigFile);
            while (reader.EndOfStream == false)
            {
              String s = reader.ReadLine();
              String[] val = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
              int index = CreateEnum(val[0]);
              EnumCollection c = Collections.ElementAt(index);
              for (int i = 1; i < val.GetLength(0); i++)
              {
                c.Values.Add(val[i]);
              }
            }
          }
          catch (Exception e)
          {
            Console.Out.WriteLine(e.ToString());
          }
        }
        public void Save()
        {
          StreamWriter writer = new StreamWriter(EnumConfigFile);
          foreach (EnumCollection c in Collections)
          {
            if (c.Values.Count == 0)
              continue;
            writer.Write(c.Name);
            foreach (String s in c.Values)
            {
              writer.Write(separators[0]);
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
            return Collections.Count -1;
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
