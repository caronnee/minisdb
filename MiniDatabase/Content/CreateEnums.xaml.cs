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

namespace MiniDatabase.Content
{
    /// <summary>
    /// Interaction logic for CreateEnums.xaml
    /// </summary>
    public partial class CreateEnums : UserControl
    {
        private EnumBank enumBank;

        public CreateEnums()
        {
            InitializeComponent();
            enumBank = new EnumBank();
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
        }
        private void focusLostName(object sender, RoutedEventArgs e)
        {
            TextBox b = sender as TextBox;
            focusLostGeneric(b);
            b.Text = "&lt;Write here enum name and press enter&gt;";
        }
        private void focusLost(object sender, RoutedEventArgs e)
        {
            TextBox b = sender as TextBox;
            focusLostGeneric(b);
            b.Text = "&lt;Write here enum value and press enter&gt;";
        }

        private void checkEnterName(object sender, KeyEventArgs e)
        {
            TextBox b = sender as TextBox;
            if (!checkEnter(b, e))
                return;
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
            if (!checkEnter(b, e))
                return;
        }
    }
}
