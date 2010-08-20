using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace myDb
{
    public partial class Formular : MyForm
    {
        public Formular(string dbName)
        {
            InitializeComponent();

            records = new Records(dbName);
            //nacitaj atributy zo suboru dbname vsetky sttributy
        }
    }
}
