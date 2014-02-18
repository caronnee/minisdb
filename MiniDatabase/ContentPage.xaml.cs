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

namespace MiniDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ContentPage : Window
    {
        public static DependencyProperty AttributeProperty =
           DependencyProperty.Register("SelectedContent", typeof(UserControl),
           typeof(ContentPage), new UIPropertyMetadata(null));

        public UserControl SelectedContent
        {
            get
            {
                return (UserControl)GetValue(AttributeProperty);
            }
            set
            {
                SetValue(AttributeProperty, value);
            }
        }

        public ContentPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.Write("Something wrong happened {0}",e.ToString());
            }
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {
            AboutBox a = new AboutBox();
            a.ShowDialog();
        }

        private void RequestNewDatabase(object sender, RoutedEventArgs e)
        {

        }

        private void TreeAttribute_Selected(object sender, RoutedEventArgs e)
        {
            // show the content of the selected tree in the second window
            Misc.TreeAttribute att = sender as Misc.TreeAttribute;
            if (att.IsSelected)
                SelectedContent = att.AttributeContent;
        }

        private TreeViewItem GetTreeItemFromContext( object sender )
        {
            MenuItem contextItem = sender as MenuItem;
            ContextMenu ctx = contextItem.Parent as ContextMenu;
            return ctx.PlacementTarget as TreeViewItem;
        }

        private void attributeRemove(object sender, RoutedEventArgs e)
        {
            TreeViewItem nod = GetTreeItemFromContext(sender);
            if (nod == null)
                return;
            TreeViewItem parent = nod.Parent as TreeViewItem;
            parent.Items.Remove(nod);
            UpdateFirstChild();
        }

        private void UpdateFirstChild()
        {
            // check first childs
            Misc.TreeAttribute root = FindName("databaseName") as Misc.TreeAttribute;
            Misc.TreeAttribute child = root.Items[0] as Misc.TreeAttribute;
            child.CanBeRemoved = root.Items.Count > 1;
        }

        private Misc.TreeAttribute CreateTreeAttribute(string name)
        {
            Misc.TreeAttribute att = new Misc.TreeAttribute();
            att.Selected += new RoutedEventHandler(TreeAttribute_Selected);
            att.Header = name;
            object o = TryFindResource("TreeItemContextMenu");
            att.ContextMenu = o as ContextMenu;
            att.CanBeRemoved = true;
            return att;
        }
        
        private void attributeAdd(object sender, RoutedEventArgs e)
        {
            TreeViewItem nod = GetTreeItemFromContext(sender);
            int sons = nod.Items.Count;
            string newName = "Attribute " + sons.ToString();
            Misc.TreeAttribute t = CreateTreeAttribute(newName);
            nod.Items.Add(t);
            UpdateFirstChild();
        }
    }
}
