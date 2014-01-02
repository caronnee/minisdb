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

namespace MiniDatabase.Misc
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MiniDatabase"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MiniDatabase;assembly=MiniDatabase"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:NumericUpDown/>
    ///
    /// </summary>
    public class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        public static readonly DependencyProperty NValue = DependencyProperty.Register("NumericValue", typeof(Int32), typeof(NumericUpDown), new PropertyMetadata(0));

        public Int32 NumericValue
        {
            get { return (Int32)this.GetValue(NValue); }
            set { this.SetValue(NValue, value); }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            // we have two buttons that needs to be have the event
            Button tempButton;
            tempButton = this.Template.FindName("BPlus", this) as Button;
            tempButton.Click += new RoutedEventHandler(IncrementValue);

            tempButton = this.Template.FindName("BMinus", this) as Button;
            tempButton.Click += new RoutedEventHandler(DecrementValue);
        }

        void DecrementValue(object sender, RoutedEventArgs e)
        {
            NumericValue--;
        }

        void IncrementValue(object sender, RoutedEventArgs e)
        {
            NumericValue++;
        }
    }
}
