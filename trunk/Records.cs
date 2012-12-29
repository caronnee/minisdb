using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace Minis
{
    public class Record
    {
        //TODO nacitat detaily zo subora, nie vlastnost patternu, ale pattern sa odkazuje
        
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
        public Value getIdValue()
        {
            return this.values[this.values.Count - 1];
        }
    }
    public class Records
    {
        private string dbName_;
        private List<Record> records;
        public List<AbstractAttribute> pattern;
        List<ControlInfo> controlInfo;
        private int recordId;

        public delegate void InfoHandler(string s);
        public event InfoHandler infoHandler;

        /* methods */
        public Records()
        {
            recordId = 0;
            records = new List<Record>();
            pattern = new List<AbstractAttribute>();
            controlInfo = new List<ControlInfo>();
        }
        public Records(string dbName)
            : this() //name of Db
        {
            dbName_ = dbName;
            load();
        }
        protected void onInfoHandler(string s)
        {
            if (infoHandler == null)
                return;
            infoHandler(s);
        }

        /* methods used for creating db */

        /* changes name of the database that enables saving to another name */
        public void changeName(string s) //jednoduche kopirovanie;)
        {
            dbName_ = s + Misc.fileType;
        }
        public void add(AbstractAttribute t)
        {
            pattern.Add(t);
            t.close += new AbstractAttribute.Handler(this.remove);
        }
        
        /* removes attribute from database */
        public void remove(AbstractAttribute a)
        {
            this.pattern.Remove(a);
        }

        public void initGrid(DataGridView grid)
        {
            grid.ColumnCount = pattern.Count + 1;
            for (int i = 0; i < pattern.Count; i++)
            {
                grid.Columns[i].Name = pattern[i].getAttributeName();
                grid.Columns[i].ValueType = pattern[i].getControl().getType();
            }
            grid.Columns[pattern.Count].Name = Misc.Id; //pripisat aj typ? Ano, bo to budeme zoradovat..a lexikograficke cisla nie su zoradene spravne..nehovoriac o datumoch
            //typ tu nepotrebujeme
        }
        public void addRow(InsertContent where, List<Value> values)
        {
            foreach (Value v in values)
            {
                Record r = findRecord(v);
                if (r == null)
                    throw new Exception("Unexpected value");
                List<AbstractControl> ctrls = new List<AbstractControl>();
                List<Value> row = r.getValues();
                for (int i = 0; i < row.Count - 1; i++)
                {
                    AbstractControl c = pattern[i].getControl();
                    c.setValue(row[i]);
                    ctrls.Add(c);
                }
                ctrls.Add(additionalHiddenControl(row[pattern.Count]));
                where.add(ctrls);
            }
        }
        public void addRecord(List<String> values)
        {
            //predpokladame ticho, ze pocet hodnot pre jedno a druhe je stejne
            Record record = new Record();
            //ja sa ich tu pokusim nacitat a ked nie, tak buchnem
            try
            {
                for (int i = 0; i < values.Count; i++)
                {
                    record.add(pattern[i].getControl().getValue(values[i]));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        } //NEPOUZITE
     
        /* methods in formular */
        public TabPage getDetail(Value idValue)
        {
            onInfoHandler("Displaying selected record, with id " + idValue.ToString() + "..");
            Record r = this.findRecord(idValue);
            TabPage p = new TabPage();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.AutoScroll = true;
            p.Text = idValue.ToString();
            List<Value> vals = r.getValues();
            for (int i = 0; i < pattern.Count; i++) //posledne neberieme
            {
                Control c = pattern[i].showControl(vals[i]);
                c.Location = new System.Drawing.Point(controlInfo[i].x, controlInfo[i].y);
                c.Size = new System.Drawing.Size(controlInfo[i].width, controlInfo[i].heigth);
                c.Name = this.pattern[i].getName();

                //malo by si to niest aj I..TODO
                c.SizeChanged += new EventHandler(c_SizeChanged);
                c.LocationChanged += new EventHandler(c_LocationChanged);
                p.Controls.Add(c);
            }
            onInfoHandler("Displayed. \r\n");
            p.Enter += new EventHandler(p_Enter);
            return p;
        }

        void p_Enter(object sender, EventArgs e)
        {
            TabPage page = sender as TabPage;
            for (int i = 0; i < page.Controls.Count; i++)
            {
                page.Controls[i].Location = new System.Drawing.Point(controlInfo[i].x,
                    controlInfo[i].y);
                page.Controls[i].Size = new System.Drawing.Size(controlInfo[i].width,
                    controlInfo[i].heigth);
            }
        }
        void c_LocationChanged(object sender, EventArgs e)
        {
            //TOTO nu chcelo az po kliknuti - TODO, inak nebudu fungovat infoboxy//mozno hover? TODO
            Control c = sender as Control;
            int index = getIndex(c.Name);
            controlInfo[index].x = c.Location.X;
            controlInfo[index].y = c.Location.Y;
        }
        void c_SizeChanged(object sender, EventArgs e)
        {
            Control c = sender as Control;
            onInfoHandler("Size changed to width = " + c.Size.Width.ToString() + "and heigth" + c.Size.Height.ToString() + "\r\n" );
            int index = getIndex(c.Name);
            controlInfo[index].width = c.Size.Width;
            controlInfo[index].heigth = c.Size.Height;
        }
        public void filter(DataGridView data, string query)
        {
            if (query == "")
                onInfoHandler("Refreshing database...");
            else 
                onInfoHandler("Selecting records by query " + query + "\r\n..");
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
                    if (!c.compareTo(v1))
                        goto Next; //goTO!!..ale brekeke!..FUUUUUUUJ
                }
                index = data.Rows.Add();
                //mozem sa spolahnut na poeradie?..vlastne musim;)..vlastne nie:D TODO dat do columns
                for (int j = 0; j < pattern.Count; j++)
                    data.Rows[index].Cells[j].Value = records[i].getValues()[j];
                data.Rows[index].Cells[pattern.Count].Value = records[i].getIdValue();
                data.Rows[index].HeaderCell.Value = (index + 1).ToString();
            Next:
                ;
            }
            onInfoHandler("Completed.\r\n");
        }
        public void addRow(List<AbstractControl> ctrls)
        {
            for (int i = 0; i < pattern.Count; i++)
            {
                ctrls.Add(pattern[i].getControl());//a poslednu Hidden?
            }
            ctrls.Add(additionalHiddenControl(null));
        }
        public void addRecord(object sender, RecordEventArgs e)
        {
            //skontrolovat, ci sa nam to tam uz nenachadza, ci to nie je edit, to jest vsetko,, co je mensie ako posledne nacitany zaznam.
            onInfoHandler("Updating database...\r\n");
            foreach (Record r in e.records)
            {
                if (r.getIdValue().compare(records.Count) >= 0)
                {                
                    this.records.Add(r);
                    onInfoHandler("Inserted record with Id " + r.getIdValue().ToString() +"\r\n");
                    continue;
                }
                int index = records.IndexOf(findRecord(r.getIdValue())); //if not null..co by nemal byt
                if (index < 0)
                    throw new Exception(" Not fulfilled prerequisity, consult creator");
                    //records.Add(r); //???
                 records[index] = r; //zamenime
                 onInfoHandler("Updated record with Id "+ r.getIdValue().ToString() +"\r\n");
            }
        } //tot posiela insert strip
        //myslim..
        public void delete(DataGridView grid)
        {
            //musime tam mat este nejake ID a to mat v gride
            foreach (DataGridViewRow row in grid.SelectedRows)
            {//najdi poslednu value

                foreach (Record r in records)
                {
                    onInfoHandler("Deleting record with id" + r.getIdValue().ToString() + "..\r\n");
                    Value rowValue = row.Cells[grid.ColumnCount - 1].Value as Value;
                    List<Value> v = r.getValues();
                    if (v[v.Count - 1].compare(rowValue) != 0) //last Cell, snad to zavola to intove
                        continue;
                    records.Remove(r);
                    grid.Rows.Remove(row); //snad to funguje
                    onInfoHandler("Deleted");
                    break;
                }

            }
        }
        //public void addNames(InsertContent strip)
        //{
        //    List<string> list = new List<string>();
        //    for (int i = 0; i < pattern.Count; i++)
        //    {
        //        list.Add(pattern[i].getAttributeName());
        //    }
        //    strip.setNames(list);
        //}

        /* private methods */
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
                    throw new Exception(" Syntax error on " + s + "\r\n"+ Misc.help);
                AbstractAttribute a;
                a = find(strs[0]);
                if (a == null)
                    throw new Exception("Name " + strs[0] + " is not recognized.");
                if ((strs[1].Equals("misses")) && (strs[2].Equals("data")))
                    return new ConditionIsNull(strs[0], null);
                Value v = a.getControl().getValue(strs[2]);
                switch (strs[1].ToLower())
                {// genericFactory
                    case "contains": //check name!
                        {
                            c = new ConditionContains(strs[0], v);
                            break;
                        }
                    case "misses":
                        {
                            c = new ConditionNot(new ConditionContains(strs[0], v));
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
                            c = new ConditionNot(new ConditionLessEqual(strs[0], v));
                            break;
                        }
                    default:
                        throw new Exception("Syntax error at condition '" + strs[1] + "'- no such condition implemented\r\n" + Misc.help); 
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
            string[] lines = s.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Condition c = getCondition(line);
                if (c == null)
                    return null;
                result.Add(c);
            }
            return result;
        }
        private int getIndex(string name)
        {
            for (int i = 0; i < pattern.Count; i++)
                if (pattern[i].getName().Equals(name))
                    return i;
            return -1;
        }
        private Record findRecord(Value v)
        {
            foreach (Record r in records)
            {
                if (r.getIdValue().compare(v) != 0) //chce sofistikovanejsie
                    continue;
                return r;
            }
            return null;
        }
        private AbstractControl additionalHiddenControl(Value t)
        {
            Value input = t;
            if (t == null)
                input = getIdValue();
            MNumeric m = new MNumeric(true);
            m.setValue(input);
            m.Hide();
            return m;
        }
        private Value getIdValue()
        {
            Value m = new ValueInteger(recordId);
            recordId++;
            return m;
        }

        /* commom methods */
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
            saveConfig();
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
            if (!File.Exists(this.dbName_ + ".config"))
                loadDefConfig();
            else 
                loadConfig();
        }
        private void saveConfig()
        {
            if (this.controlInfo.Count == 0)
                return;
            StreamWriter write = new StreamWriter(this.dbName_ + ".config");
            for (int i = 0; i < this.controlInfo.Count; i++)
            {
                write.WriteLine(controlInfo[i]);
            }
            write.Close();
        }
        private void loadConfig()
        {
            StreamReader stream = new StreamReader(this.dbName_ + ".config"); //tiez do Files
            string line;
            while ( (line = stream.ReadLine()) != null )
                this.controlInfo.Add( new ControlInfo(line) );
            stream.Close();
        }
        private void loadDefConfig()
        {
            int y = 0;
            int width = 100;
            int heigth = 50; //to by malo stacit ;)
            for (int i = 0; i < pattern.Count; i++)
            {
                controlInfo.Add(new ControlInfo(0,y,width,heigth));
                y += heigth + Misc.space;
            }
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
                r.add(getIdValue());
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
