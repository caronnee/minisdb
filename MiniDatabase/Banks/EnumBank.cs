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

namespace MiniDatabase.Banks
{
    public class EnumBank : DependencyObject 
    {
        public class EnumCollection
        {
            public ICollection<String> Values
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
                Values = new List<String>();
            }
        }

        public static DependencyProperty CollectionProperty = DependencyProperty.Register("Collections", typeof(ObservableCollection<EnumCollection>), typeof(EnumBank), new PropertyMetadata(null));

        public EnumBank()
        {
            Collections = new ObservableCollection<EnumCollection>();
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

        static Predicate<EnumCollection> ByName(String s)
        {
            return delegate(EnumCollection c)
            {
                return c.Name == s;
            };
        }

        public EnumCollection GetEnum(String name)
        {
            //EnumCollection c = Collections.aa .Find(ByName(name));
            //if (c == null)
            //{
            //    c = CreateEnum(name);
            //}
            //return c;
            return null;
        }
    }
}
