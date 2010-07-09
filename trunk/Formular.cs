using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace myDb
{
    public partial class Formular : MyForm
    {
        public Formular(string dbName)
        {
            InitializeComponent();
            //nacitaj atributy zo suboru A vsetky e;ementy..pohadka na inu noc:)
        }
        private List<Attribute> attributes;
    }
}
