using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniDatabase
{
    class EnumBank
    {
        List<EnumCollection> _collections;

        public class EnumCollection
        {   
            public ICollection<String> Values
            {
                get;
                set;
            }
            public String Name
            {
                get;
                set;
            }
            public EnumCollection(String name)
            {
                Name = name;
                Values = new List<String>();
            }
        }
        
        EnumBank()
        {
            _collections = new List<EnumCollection>();
        }

        EnumCollection CreateEnum(String name)
        {
            EnumCollection c = new EnumCollection(name);
            _collections.Add(c);
            return c;
        }

        static Predicate<EnumCollection> ByName(String s)
        {
            return delegate(EnumCollection c)
            {
                return c.Name == s;
            };
        }

        public EnumCollection GetEnums(String name)
        {
            EnumCollection c = _collections.Find(ByName(name));
            if (c == null)
            {
                c = CreateEnum(name);
            }
            return c;

        }
    }
}
