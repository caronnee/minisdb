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
using MiniDatabase.Records.Description;


namespace MiniDatabase.Content.CreateFields
{
    /// <summary>
    /// Interaction logic for CreateFieldEnum.xaml
    /// </summary>
    public partial class FieldEnum : UserControl, FieldInterface
    {
        //public static readonly DependencyProperty EnumValue = DependencyProperty.Register("EnumSource", typeof(ICollection<Control>), typeof(CreateFieldEnum), new PropertyMetadata(null));
        
        public Banks.EnumBank EnumSource
        {
            get
            {
                return Banks.EnumBank.Bank;
            }
        }
        public FieldEnum()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.Write("Exception occured {0}",e.ToString());
            }
        }
        public bool Valid() { return true; }

        public RecordDescription GetRecordDescription()
        {
            throw new Exception("Not implemented yet");
        }
    }
}
