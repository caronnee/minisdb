﻿using System;
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

namespace MiniDatabase.CreateFields
{
    /// <summary>
    /// Interaction logic for CreateFieldText.xaml
    /// </summary>
    public partial class CreateFieldText : UserControl, CreateFieldInterface
    {
        public static DependencyProperty CRecord = DependencyProperty.Register("CreatedRecord", typeof(RecordDescriptionText), typeof(CreateFieldText), new PropertyMetadata(null));

        public CreateFieldText()
        {
            CreatedRecord = new RecordDescriptionText(); 
            InitializeComponent();
        }

        public RecordDescriptionText CreatedRecord
        {
            get { return GetValue(CRecord) as RecordDescriptionText; }
            set { SetValue(CRecord,value); }
        }
     
        public bool Valid() { return true; }

        public RecordDescription GetRecordDescription()
        {
            return CreatedRecord;
        }
    }
}