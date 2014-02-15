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

        }

        private void attributeAtt(object sender, RoutedEventArgs e)
        {
            Point relativeToContext = Mouse.GetPosition(sender as IInputElement);
            Point p = Mouse.GetPosition(this);
            p.Offset( -relativeToContext.X, -relativeToContext.Y);
            HitTestResult result = VisualTreeHelper.HitTest(this, p );
            DependencyObject obj = result.VisualHit;
            while (!(obj is TreeViewItem))
            {
                if (obj == null)
                    return;
                obj = VisualTreeHelper.GetParent(obj);
            }
            TreeViewItem nod = obj as TreeViewItem;
            Misc.TreeAttribute n = new Misc.TreeAttribute();
            int sons = nod.Items.Count;
            string newName= "Attribute " + sons.ToString();
            n.Header = newName;
            nod.Items.Add(n);
        }
    }
}
