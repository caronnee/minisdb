using System;
using System.Collections.Generic;
using System.Text;

namespace Minis
{
    public static class RecordsManager
    {
        public delegate void InfoHandler(string s);
        public static InfoHandler infoHandler;
        static Records database;
        public static void AddRecords(Object sender, RecordEventArgs args)
        {
            database.addRecord(sender, args);
        }
        public static void CreateEmpty(List<AbstractControl> ctrls)
        {
            database.addRow(ctrls);
        }
        public static void Load(string dbName)
        {
            database = new Records(dbName);
        }

        public static void AddToActive(AbstractAttribute att)
        {
            database.add(att);
        }

        public static void RenameActive(string name)
        {
            database.changeName(name);
        }

        public static void SaveActive()
        {
            database.save();
        }

        public static void LoadColumns(System.Windows.Forms.DataGridView results)
        {
            if (database != null)
                database.initGrid(results);
        }

        public static void Filter(System.Windows.Forms.DataGridView grid, String condition)
        {
            database.filter(grid, condition);
        }

        public static System.Windows.Forms.TabPage GetDetail(Value v)
        {
            return database.getDetail(v); //TODO change this to be inside this class, not Records
        }

    }
}
