using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Misc;
using System.IO;
using System.Collections.ObjectModel;
using MiniDatabase.SearchEngine.Conditions;


namespace MiniDatabase.Records
{
    public class RecordsManager
    {
        /** Records */
        List<Record> _records;
        
        /** Highest record id */
        int maxRecordId;

        /** name of the database */
        public String Name
        {
            get;
            set;
        }

        public List<RecordDescription> Description
        {
            get;
            set;
        }

        void Clear()
        {
            maxRecordId = 0;
            Description = new List<RecordDescription>();
            _records = new List<Record>();
        }
        
        /** Constructor */
        public RecordsManager()
        {
            Clear();
        }

        public List<Record> Select(object condition, int offset, int count)
        {
            List<Record> rec = new List<Record>();
            if (count < 0)
                count = _records.Count;
            if ( condition == null)
            {
                for (int i = 0; i < count; i++)
                {
                    if ( i + offset < _records.Count)
                        rec.Add(_records[i + offset]);
                }
            }
            else
                throw new NotImplementedException("Selection of the records");
            return rec;
        }

        public RecordsManager(String name)
        {
            Name = name;
            Clear();
            Load();
        }

        private int FindDescriptionIndex(String name)
        {
            for (int i = 0; i < Description.Count; i++)
            {
                if (Description[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        public List<Record> Filter(String query)
        {
            if (query == "")
                onInfoHandler("Refreshing database...");
            else
                onInfoHandler("Selecting records by query " + query + "\r\n..");
            List<Condition> conditions = this.ParseQuery(query);
            
            if (conditions == null)
            {
                onInfoHandler("no conditions set");
                return null;
            }

            List<Record> results = new List<Record>();

            for (int i = 0; i < _records.Count; i++)
            {
                bool isMatch = true;
                foreach (Condition c in conditions)
                {
                    int index = FindDescriptionIndex(c.getName());
                    if (index < 0)
                    {
                        onInfoHandler("Unable to recognize attribute name");
                        return null;
                    }
                    Value v1 = _records[i].GetValue(index);
                    if (!c.compareTo(v1))
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    results.Add(_records[i]);
                }
            }
            onInfoHandler("Completed.\r\n");
            return results;
        }

        private Condition ConvertToCondition(string s)
        {
            Condition c = null;
            try
            {
                string[] strs = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (strs.Length != 3)
                    throw new Exception(" Syntax error on " + s + "\r\n" + Misc.Common.help);
                RecordDescription description;
                Predicate<RecordDescription> finder = (RecordDescription p) => { return p.Name == strs[0]; };
                description = Description.Find(finder);
                if (description == null)
                    throw new Exception("Name " + strs[0] + " is not recognized.");
                if ((strs[1].Equals("misses")) && (strs[2].Equals("data")))
                    return new ConditionIsNull(strs[0], null);
                Value v = description.CreateValueFromString(strs[2]);
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
                        throw new Exception("Syntax error at condition '" + strs[1] + "'- no such condition implemented\r\n" + Misc.Common.help);
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Error found!");
            }
            return c;
        }

        private List<Condition> ParseQuery(string s)
        {
            List<Condition> result = new List<Condition>();
            string[] lines = s.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Condition c = ConvertToCondition(line);
                if (c == null)
                    return null;
                result.Add(c);
            }
            return result;
        }

        public void AddDescription(RecordDescription rec)
        {
            Description.Add(rec);
        }

        /** Changing name of the database */
        public void ChangeName(string s) 
        {
            onInfoHandler("Renaming " + Name + " to " + s );
            Name = s + Common.DbExt;
            // TODO delete the old file, or rename, mark the change
            onInfoHandler("Database renamed");
        }

        /* common methods */
        /* save whole database */
        public void Save()
        {
            String tempName = Name + Misc.Common.saveInProgressAppendix;
            BinaryWriter writer = new BinaryWriter(File.Open(tempName, FileMode.Create));
            // patterns are delimited by blank line
            foreach (RecordDescription a in Description)
            {
                a.Save(writer);
            }
            writer.Write(-1); //deliminer
            int count = Description.Count;
            foreach (Record a in _records)
            {
                for (int i = 0; i < count; i++)
                    a.GetValue(i).Save(writer);
            }
            writer.Close();
            File.Delete(Name);
            File.Move(tempName,Name);
            onUpdate();
        }

        public void Load()
        {
            BinaryReader reader = new BinaryReader(File.Open(Name, FileMode.Open));

            while (reader.BaseStream.Length != reader.BaseStream.Position)
            {
                int type = reader.ReadInt32();
                if (type < 0)
                    break; // database starts
                Types t = (Types)type;
                RecordDescription description = RecordDescription.GetRecordFromType(t);
                description.Load(reader);
                AddDescription(description);
            }
            // read the records
            int count = Description.Count;
            if (count <= 0)
            {
                reader.Close();
                throw new Exception("Database corrupted");
            }
            while (reader.BaseStream.Length != reader.BaseStream.Position)
            {
                Record record = new Record(count);
                for (int i = 0; i < Description.Count; i++)
                {
                    Value val = new ValueText();    // Description[i].ReadValueFromDescription(reader);
                    val.Load(reader);
                    record.SetValue(val, i);
                }
                AddRecord(record);
            }
            reader.Close();
        }

        public void AddRecord(Record record)
        {
            record.ID = maxRecordId;
            maxRecordId++;
            _records.Add(record);
        }
        /** calls information about operation on database */
        public delegate void UpdateHandler();
        public event UpdateHandler updateAction;

        protected void onUpdate()
        {
            if (updateAction == null)
                return;
            updateAction();
        }

        /** calls information about operation on database */
        public delegate void InfoHandler(string s);
        public event InfoHandler infoHandler;

        protected void onInfoHandler(string s)
        {
            if (infoHandler == null)
                return;
            infoHandler(s);
        }
    }
}
