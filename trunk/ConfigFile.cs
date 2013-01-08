using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Minis
{
    public class ConfigFile
    {
        private struct Pair
        {
            public String name;
            public List<String> value;
        }

        String myName;
        private List<Pair> configValues;

        public List<String> Find(String name)
        {
            foreach (Pair p in configValues)
            {
                if (p.name.Equals(name))
                    return p.value;
            }
            return null;
        }

        public void Add(String name, String value)
        {
            foreach ( Pair p in configValues)
            {
                if (p.name.Equals(name))
                {
                    p.value.Add(value);
                    return;
                }
            }
            Pair newPair = new Pair();
            newPair.name = name;
            newPair.value = new List<String>();
            newPair.value.Add(value);
            configValues.Add(newPair);
        }
        private void Load()
        {
            configValues = new List<Pair>();
            if (!File.Exists(myName))
                return;
            TextReader read = new StreamReader(myName);
            String line;
            while ((line = read.ReadLine()) != null)
            {
                String[] str = line.Split(new char[1]{'='},StringSplitOptions.RemoveEmptyEntries);
                String name = str[0];
                str = str[1].Split(new char[1] {';'}, StringSplitOptions.
RemoveEmptyEntries);
                foreach(String value in str)
                {
                    Add(name,value);
                }
            }
            read.Close();
        }

        public ConfigFile(String dbName)
        {
            if ( (myName != null) && (myName.Equals(dbName)) )
                return; // was already loaded
            myName = dbName;
            Load();
        }

        public List<String> ReadPrefix(String prefix)
        {
            List<String> str = new List<String>();
            foreach (Pair p in configValues)
            {
                if (p.name.StartsWith(prefix))
                    str.Add(p.name);
            }
            return null;
        }

    }
}
