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
        List<RecordDescription> _description;
        List<Record> _records;
        
        /** Highest record id */
        int maxRecordId;

        /** name of the database */
        public String Name
        {
            get;
            set;
        }

        void Clear()
        {
            maxRecordId = 0;
            _description = new List<RecordDescription>();
            _records = new List<Record>();
        }
        /** Constructor */
        public RecordsManager()
        {
            Clear();
        }
        public RecordsManager(String name)
        {
            Name = name;
            Clear();
            Load();
        }

        public void AddDescription(RecordDescription rec)
        {
            _description.Add(rec);
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
            BinaryWriter write = new BinaryWriter( File.Open(Name,FileMode.CreateNew) );
            // patterns are delimited by blank line
            foreach (RecordDescription a in _description)
            {
                a.Save(write);
            }
            write.Write(-1); //deliminer
            foreach (Record a in _records)
            {
                a.Save(write);
            }
            write.Close();
        }

        public void Load()
        {
            BinaryReader reader = new BinaryReader(File.Open(Name, FileMode.Open));

            while (reader.BaseStream.Length != reader.BaseStream.Position)
            {
                Types t = (Types)reader.ReadInt32();
                RecordDescription record = RecordDescription.GetRecordFromType(t);
                record.Load(reader);
            }
            reader.Close();
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
