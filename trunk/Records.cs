﻿using System;
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
        private string name;
        private List<Record> records;

        public readonly List<AbstractAttribute> pattern;

        public Records(string dbName) //name of Db
        {
            name = dbName;
            records = new List<Record>();
            pattern = new List<AbstractAttribute>();
            load();
        }
        public void addRow(InsertStrip sender)
        {
            List<AbstractControl> ctrls = new List<AbstractControl>();
            for ( int i =0; i< pattern.Count; i++)
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
        public void save()
        {

            TextWriter write = new StreamWriter(dbName, false);
            //sprav getline az pokial nenajdes prazdnu lajnu
            foreach (AbstractAttribute a in pattern)
                a.save(write); //TODO zmenit na toString
            write.WriteLine();

            //save database
            for (int i = 0; i < records.Count; i++)
            {
                List<Value> rcs = records[i].getValues();
                for (int j = 0; j < rcs.Count; j++)
                {
                    if (rcs[i] == null)
                        write.Write('\t');
                    else
                        write.Write(rcs[j].toString());
                }
                write.WriteLine();
            }
        }
        /* load attributes and records */
        private void load()
        {
            TextReader stream = new StreamReader(dbName);
            loadAttributes(stream);
            loadValues(read);
            stream.Close();
        }
        private void loadValues(StreamReader reader)
        {
             string line = "";
             while ((line = read.ReadLine()) != null)
             {
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
