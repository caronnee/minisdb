using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace myDb
{
    public class Record
    {
        ulong id;
        List<Value> values; 
    }
    public class Records //singleton, FUJ
    {
        private List<Record> records;

        public readonly List<Attribute> pattern;

        public Records(string dbName) //name of Db
        {
            records = new List<Record>();//+load existent
            TextReader read = new StreamReader(dbName);
            string line = "";
            while ((line = read.ReadLine()) != null)
            {
                if (line == "")
                    break; //to bude znamenat, ze sme na fazi nacotavania values
                Match m = new Regex("^[0-9]*").Match(line);
                int def = int.Parse(m.Value);
                AbstractAttribute att = null;
                switch (def)
                {
                    case AbstractAttribute.AttributeType.AText:
                        att = new Attribute();
                        break;
                    case AbstractAttribute.AttributeType.AEnum:
                        att = new AttributeEnum("Unknown", new ComboBox()); //najskor s prazdnym
                        break;
                    case AbstractAttribute.AttributeType.AInteger:
                        att = new AttributeInteger();
                        break;
                    case AbstractAttribute.AttributeType.APicture:
                        att = new AttributeImage();
                        break;
                    case AbstractAttribute.AttributeType.ATime:
                        att = new AttributeTime();
                        break;
                    default:
                        throw new Exception("No such type can be loaded");
                }
                att.reconstruct(line.Substring(m.Value.Length));
            }
            //nacitavane hodnoty - TODO
        }
        public void addRow()
        {
        }
        public void addRecord(object sender, RecordEventArgs e)
        {
            this.records.AddRange(e.records);
        }
        public List<Record> find()
        {
            List<Record> result = new List<Record>();
            return result;
        }
    }
}
