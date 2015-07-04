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
using MiniDatabase.Misc;
using MiniDatabase.CreateFields;

namespace MiniDatabase.Content
{
    /// <summary>
    /// Interaction logic for ContentCreateDatabase.xaml
    /// </summary>
    public partial class CreateDatabase : ContentGeneric
    {
        public  CreateDatabase()
        {
            InitializeComponent();
        }

        private TreeViewItem GetTreeItemFromContext(object sender)
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

        private void OnEnterUpdate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox b = sender as TextBox;
                BindingExpression be = b.GetBindingExpression(TextBox.TextProperty);
                be.UpdateSource();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            OnResult(new ChooseDatabase());
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            RecordsManager manager = new RecordsManager();
            TreeViewItem attributes = FindName("databaseName") as TreeViewItem;
            foreach (TreeAttribute att in attributes.Items)
            {
                CreateFieldInterface attInterface = att.AttributeContent as CreateFieldInterface;
                if (!attInterface.Valid())
                {
                    //TODO say all invalid nodes that his has
                    MessageBox.Show("Some input is invalid. Node ( " + att.Header+" )", "Invalid Entry",MessageBoxButton.OK);
                    return; // do nothing
                }
                RecordDescription desc = attInterface.GetRecordDescription();// TODO remove this and add binding
                desc.Name = att.Header.ToString();
                manager.AddDescription( desc );
            }
            manager.ChangeName(attributes.Header as String);
            manager.Save();
            Results w = new Results(manager);
            OnResult(w);
        }
    }
}
