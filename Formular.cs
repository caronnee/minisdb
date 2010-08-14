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

            attributes = new List<Attribute>();
            //nacitaj atributy zo suboru dbname vsetky sttributy
             TextReader read = new StreamReader(dbName);
            string line = "";
            while ((line = read.ReadLine()) != null)
            {
                if (line == "")
                    continue;
                Match m =new Regex("^[0-9]*").Match(line);
                int def = int.Parse(m.Value);
                AbstractAttribute att = null;
                switch (def)
                {
                    case AttributeType.AText :
                        att = new Attribute();
                        break;
                    case AttributeType.AEnum :
                        att = new AttributeEnum("unknown",new ComboBox()); //najskor s prazdnym
                        break;
                    case AttributeType.AInteger :
                        att = new AttributeInteger();
                        break;
                    case AttributeType.APicture :
                        att = new AttributeImage();
                        break;
                    case AttributeType.ATime :
                        att = new AttributeTime();
                        break;
                    default :
                        throw new Exception("No such type can be loaded");
                }
                att.setValue(line.Substring(m.Value.Length));
            }
        }
        private List<Attribute> attributes;
    }
}
