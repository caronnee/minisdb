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
        List<Value> values;
        public Record()
        {
            values = new List<Value>();
        }
        public void clear()
        {
            values.Clear();
        }
        public void add(Value v) // can be null as not inicialized
        {
            values.Add(v);
        }
        public List<Value> getValues()
        {
            return values;
        }
    }
    public class Records //singleton, FUJ
    {
        private string dbName_;
        private List<Record> records;
        public List<AbstractAttribute> pattern;

        /* methods */
        public Records()
        {
             records = new List<Record>();
             pattern = new List<AbstractAttribute>();
        }
        public Records(string dbName) : this() //name of Db
        {
            dbName_ = dbName;
            load();
        }

        /* changes name of the database that enables saving to another name */
        public void changeName(string s) //jednoduche kopirovanie;)
        {
            dbName_ = s + Files.fileType;
        }
        public void add(AbstractAttribute t)
        {
            pattern.Add(t);
            t.close +=new AbstractAttribute.Handler(this.remove);
        }
        /* removes attribute from database */
        public void remove(AbstractAttribute a)
        {
            this.pattern.Remove(a);
        }

        public void settingGrid(DataGridView grid)
        {
            grid.ColumnCount = pattern.Count;
            for (int i = 0; i < pattern.Count; i++)
            {
                grid.Columns[i].Name = pattern[i].getAttributeName(); //pripisat aj typ? Ale nie, to sa preda spozna
            }
        }
        
        public void remove(Attribute t)
        {
            pattern.Remove(t);
        }
        public void addRow(InsertStrip sender)
        {
            List<AbstractControl> ctrls = new List<AbstractControl>();
            for (int i = 0; i < pattern.Count; i++)
            {
                ctrls.Add(pattern[i].getControl());
            }
            sender.add(ctrls);
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
        public void addNames(InsertStrip strip)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < pattern.Count; i++)
            {
                list.Add(pattern[i].getAttributeName());
            }
            strip.setNames(list);
        }
        /* save whole database */
        public void save()
        {
            TextWriter write = new StreamWriter(dbName_, false);
            //sprav getline az pokial nenajdes prazdnu lajnu
            foreach (AbstractAttribute a in pattern)
                write.WriteLine(a.ToString());
            write.WriteLine();//empty line to detect beginning of database

            //save database completely
            for (int i = 0; i < records.Count; i++)
            {
                List<Value> rcs = records[i].getValues();
                for (int j = 0; j < rcs.Count; j++)
                {
                    if (rcs[j] != null)
                        write.Write(rcs[j].ToString());
                    else
                        write.Write('\t');
                }
                write.WriteLine();
            }
            write.Close();
        }
        /* private methods */
        /* load attributes and records */
        private void load()
        {
            StreamReader stream = new StreamReader(dbName_);
            loadAttributes(stream);
            loadValues(stream);
            stream.Close();
        }
        private void loadValues(StreamReader reader)
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] strs = line.Split(new char[] { '\t' });
                Record r = new Record();
                for (int i = 0; i < pattern.Count; i++)
                    r.add(pattern[i].getControl().getValue(strs[i]));
                records.Add(r);
            }
        }
        private void loadAttributes(StreamReader read)
        {
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
                pattern.Add(att);
            }
        }
    }
}
