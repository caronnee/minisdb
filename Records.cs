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
	private int recordId;

        /* methods */
        public Records()
        {
		recordId = 0;
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
	public void delete(DataGridView grid);
	{
		//musime tam mat este nejake ID a to mat v gride
		foreach (DataGridViewRow row in grid.selectedRows)
		{//najdi poslednu value
			foreach(Record r in records)
			{
				List<Value> v = r.getValues();
				if (v[v.Count-1].compare(row.Cells[row.ColumnCount -1])!=0) //last Cell, snad to zavola to intove
					continue;
				records.Remove(r);
				grid.Rows.Remove(row); //snad to funguje
				break;
			}

		}
	}
        public void settingGrid(DataGridView grid)
        {
            grid.ColumnCount = pattern.Count +1;
            for (int i = 0; i < pattern.Count; i++)
              {
                  grid.Columns[i].Name = pattern[i].getAttributeName();
                  grid.Columns[i].ValueType = pattern[i].getControl().getType(); 
              }
	    grid.Columns[pattern.Count].Name = "ID"; //pripisat aj typ? Ano, bo to budeme zoradovat..a lexikograficke cisla nie su zoradene spravne..nehovoriac o datumoch
	    //typ tu nepotrebujeme
        }
        private AbstractAttribute find(string nm)
        {
            string cmp = nm.ToLower();
            foreach (AbstractAttribute a in pattern) //case sensitive?
            {
                if (a.getAttributeName().ToLower().Equals(cmp))
                    return a;
            }
            return null;
        }
        private Condition getCondition(string s)
        {
            Condition c = null;
            try
            {
                string[] strs = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (strs.Length != 3)
                    throw new Exception("Syntax error: '" + s + "', syntax is: \n " +
                     " attribute_name {containts, misses, >=, >, <=, <, =, !=} value \n");
                AbstractAttribute a;
                a = find(strs[0]);
                if (a == null)
                    throw new Exception("Name " + strs[0] + " is not recognized.");
                Value v = a.getControl().getValue(strs[2]);
                switch (strs[1])
                {
                    case "contains": //check name!
                        {
                            c = new ConditionContains(strs[0], v);
                            break;
                        }
                    case "misses":
                        {
                            c = new ConditionNot(new ConditionContains(strs[0],v));
                            break;
                        }
                    case "=":
                        {
                            c = new ConditionEqual(strs[0], v);
                            break;
                        }
                    case "<=":
                        {
                            c = new ConditionLessEqual(strs[0], v);
                            break;
                        }
                    case "<":
                        {
                            c = new ConditionLess(strs[0], v);
                            break;
                        }
                    case ">=":
                        {
                            c = new ConditionNot(new ConditionLess(strs[0], v));
                            break;
                        }
                    case ">":
                        {
                            c = new ConditionNot(new ConditionLessEqual(strs[0],v));
                            break;
                        }
                    default:
                        throw new Exception("Syntax error at condition '" + strs[1] + "'- no such condition implemented"); //+ nejaky help?
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error found!", MessageBoxButtons.OK);
            }
            return c;
        }
        private List<Condition> parseQuery(string s)
        {
            List<Condition> result = new List<Condition>();
            string[] lines = s.Split(new char[]{'\n','\r'},StringSplitOptions.RemoveEmptyEntries);
            foreach( string line in lines)
            {
                Condition c = getCondition(line);
                if (c ==null)
                    return null;
                 result.Add(c);
            }
            return result;
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
                ctrls.Add(pattern[i].getControl());//a poslednu Hidden?
            }
	    MNumeric m = new MNumeric(true);
	    m.setValue(recordId);
	    recordId++;
	    m.Hide();
	    ctrls.Add(m);
            sender.add(ctrls);
        }
        public void addRecord(object sender, RecordEventArgs e)
        {
		//skontrolovat, ci sa nam to tam uz nenachadza, ci to nie je edit
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
        public void filter(DataGridView data, string query)
        {
            List<Condition> conditions = this.parseQuery(query);
            //regexp = '*'
            if (conditions == null)
                return; //+ nejake warning? Myslim, ze netreba

            data.Rows.Clear();
            for (int i = 0; i < records.Count; i++)
            {
                int index;
                foreach (Condition c in conditions)
                {
                    index = pattern.IndexOf(this.find(c.getName()));
                    Value v1 = records[i].getValues()[index];
                    if (v1 == null)
                        goto Next;
                    if (!c.compareTo(v1))
                        goto Next; //goTO!!..ale brekeke!..FUUUUUUUJ
                }
                index = data.Rows.Add();
                //mozem sa spolahnut na poeradie?..vlastne musim;)..vlastne nie:D TODO dat do columns
                for (int j = 0; j < pattern.Count; j++)
                {
                    data.Rows[index].Cells[j].Value = records[i].getValues()[j];
                    data.Rows[index].HeaderCell.Value = (index + 1).ToString();
                }
            Next:
                ;
            }
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
                    write.Write('\t'); //v loadovani budeme mat vzdy o nedna viac, ale ignorujeme
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
	    this.recordId = records.Count;
            stream.Close();
        }
        private void loadValues(StreamReader reader)
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Equals(""))
                    continue;
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
