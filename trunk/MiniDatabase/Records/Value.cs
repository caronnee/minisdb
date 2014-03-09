using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace MiniDatabase.Records
{
    public abstract class Value 
    {
        public virtual int compare(DateTime d)
        {
            throw new Exception("No such type allowed to compare ");
        }
        
        public virtual int compare(int s)
        {
            throw new Exception("No such type allowed to compare ");
        }
        
        public virtual int compare(string s)
        {
            throw new Exception("No such type allowed to compare ");
        }
        
        public virtual int compare(Value v)
        {
            throw new Exception("Not implemented");
        }
        
        public virtual int contains(string s)
        {
            return this.ToString().IndexOf(s);
        }

        public virtual int contains(Value v)
        {
            if (v == null)
                return -1;
            return this.contains(v.ToString());
        }

        public virtual void Save(System.IO.BinaryWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
