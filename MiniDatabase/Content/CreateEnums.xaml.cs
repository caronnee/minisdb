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
using MiniDatabase.Banks;


namespace MiniDatabase.Content
{
    /// <summary>
    /// Interaction logic for CreateEnums.xaml
    /// </summary>
    public partial class CreateEnums : ContentGeneric
    {
        public static DependencyProperty EnumsProperty = DependencyProperty.Register("Enums", typeof(Banks.EnumBank), typeof(CreateEnums), new PropertyMetadata(null));
        private String renaming;

        public CreateEnums()
        {
            InitializeComponent();
            Enums = Banks.EnumBank.Bank;
            renaming = null;
        }

        public Banks.EnumBank Enums
        {
            get {
                return (Banks.EnumBank)GetValue(EnumsProperty);
            }
            set { 
                SetValue(EnumsProperty,value); 
            }
        }

        private void focusGained(object sender, RoutedEventArgs e)
        {
            TextBox b = sender as TextBox;
            b.Text = "";
            b.Foreground = Brushes.Black;
        }

        private void focusLostGeneric(TextBox b)
        {
            b.Foreground = Brushes.Gray;
            renaming = null;
        }

        private void focusLostName(object sender, RoutedEventArgs e)
        {
            TextBox b = sender as TextBox;
            focusLostGeneric(b);
            b.Text = "<Write here enum name and press enter>";
        }
        private void focusLost(object sender, RoutedEventArgs e)
        {
            TextBox b = sender as TextBox;
            focusLostGeneric(b);
            b.Text = "<Write here enum value and press enter>";
        }

        private void checkEnterName(object sender, KeyEventArgs e)
        {
            TextBox b = sender as TextBox;
            String name = b.Text;
            if (!checkEnter(b, e))
                return;
            int index;
            if (renaming != null)
                index = Enums.Rename(renaming,name);
            else
                index = Enums.CreateEnum(name);
            // select the one added/renamed
            object o = FindName("enumNamesHolder");
            ListBox l = o as ListBox;
            l.SelectedIndex = index;
            // ad between names and focus
        }
        

        private bool checkEnter(TextBox b, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return false;
            b.Text = "";
            b.Focus();
            return true;
        }

        private void checkEnter(object sender, KeyEventArgs e)
        {
            TextBox b = sender as TextBox;
            String c = b.Text;
            if (!checkEnter(b, e))
                return;
            // add value to the currently selected item
            object o = FindName("enumNamesHolder");
            ListBox l = o as ListBox;
            EnumCollection collection = l.SelectedItem as EnumCollection;
            if (renaming != null)
            {
                for (int i = 0; i < collection.Values.Count; i++)
                {
                    if (collection.Values[i] == renaming)
                    {
                        collection.Values[i] = c;
                        break;
                    }
                }
            }
            else
                collection.Values.Add(c);
        }

        private void renameName(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;
            ContextMenu t = m.Parent as ContextMenu;
            ListBox l = t.PlacementTarget as ListBox;
            EnumCollection ec = l.SelectedItem as EnumCollection;
            renaming = ec.Name;
            TextBox b = FindName("enumNames") as TextBox;
            b.Focus();
            b.Text = renaming;
        }

        private void renameValue(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;
            ContextMenu t = m.Parent as ContextMenu;
            ListBox l = t.PlacementTarget as ListBox;
            String ec = l.SelectedItem as String;
            renaming = ec;
            TextBox b = FindName("enumValues") as TextBox;
            b.Focus();
            b.Text = renaming;
        }

        private void removeFromListValue(object sender, RoutedEventArgs e)
        {
            object o = FindName("enumNamesHolder");
            ListBox l = o as ListBox;
            MenuItem m = sender as MenuItem;
            ContextMenu t = m.Parent as ContextMenu;
            ListBox l2 = t.PlacementTarget as ListBox;
            EnumCollection s = Enums.Collections.ElementAt(l.SelectedIndex);
            Array values = Array.CreateInstance(typeof(String), l2.SelectedItems.Count);
            l2.SelectedItems.CopyTo(values, 0);
            foreach (String st in values)
            {
                s.Values.Remove(st);
            }
        }

        private void removeFromListName(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;
            ContextMenu t = m.Parent as ContextMenu;
            ListBox b = t.PlacementTarget as ListBox;
            // remove all selected
            Enums.Collections.Remove(b.SelectedItem as EnumCollection);
        }

        private void enumsChanged(object sender, RoutedEventArgs e)
        {
            Enums.Save();
            OnInfo("Enums saved");
            OnResult(new ChooseDatabase());
        }
    }
}
