using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDatabase.Misc;
using System.IO;

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
        
        public List<Record> Select(object o)
        {
            return _records;
        }

        public RecordsManager(String name)
        {
            Name = name;
            Clear();
            Load();
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
            File.Move(tempName,Name);
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
                    Value val = Description[i].ReadValueFromDescription(reader);
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
