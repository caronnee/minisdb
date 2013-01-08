using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Minis
{
    public static class RecordsManager
    {
        public delegate void UpdateHandler(String name, String val);
        public static UpdateHandler updateHandler;

        public delegate void InfoHandler( string s );
        public static InfoHandler infoHandler;

        public static ConfigFile configFile;

        public static void Init()
        {
            configFile = new ConfigFile(Misc.ProfileFile);
        }

        public static List<String> FindEnum(String enumName)
        {
            String fnd = Misc.enumPrefix + enumName;
            return configFile.Find(fnd);
        }

        private static void OnUpdateHandler(String name, String val)
        {
            if (updateHandler == null)
                return;
            updateHandler(name, val);
        }
        /** All saved records in the chosen database */
        static Records database;

        public static void AddRecords(Object sender, RecordEventArgs args)
        {
            if (database != null)
                database.addRecord(sender, args);
        }
        public static void CreateEmpty(List<AbstractControl> ctrls)
        {
            if ( database == null )
                throw new Exception("In insert page this should be set!");
            database.addRow(ctrls);
        }
        public static void Load(string dbName)
        {
            database = new Records(dbName);
        }

        public static void AddToActive(AbstractAttribute att)
        {
            if (database == null)
                database = new Records("dummy");
            database.AddPattern(att);
        }

        public static void RenameActive(string name)
        {
            if ( (database == null) || (File.Exists(name)) )
            {
                // TODO warning
                return;
            }
            database.changeName(name);
        }

        public static void SaveActive()
        {
            if (database!= null)
                database.save();
        }

        public static void InitGrid(System.Windows.Forms.DataGridView results)
        {
            if (database != null)
                database.initGrid(results);
        }

        public static void Filter(System.Windows.Forms.DataGridView grid, String condition)
        {
            if (database != null)
                database.filter(grid, condition);
        }

        public static System.Windows.Forms.TabPage GetDetail(Value v)
        {
            return database.getDetail(v); //TODO change this to be inside this class, not Records
        }

        public static void SaveToProfileFile(String name, String value)
        {
            configFile.Add(name, value);
            //main window may want to detect changes in config file and react promptly
            OnUpdateHandler(name, value);
        }

        public static List<string> FindEnumNames()
        {
            return configFile.ReadPrefix(Misc.enumPrefix);
        }

    }
}
