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
        public static readonly DependencyProperty AContent = DependencyProperty.Register("CurrentContent", typeof(Content.ContentGeneric), typeof(ContentPage), new PropertyMetadata(null));

        public UserControl CurrentContent
        {
            set { SetValue(AContent,value); }
            get { return (UserControl)GetValue(AContent); }
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
            CurrentContent = new Content.CreateDatabase();
        }

        private void RequestManageEnums(object sender, RoutedEventArgs e)
        {
            CurrentContent = new Content.CreateEnums();
        }
    }
}
