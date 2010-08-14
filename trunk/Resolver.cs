using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    class Resolver
    {
        private bool processing;
        public Resolver()
        {
            processing = false;
        }
        public virtual bool resolve(Value v1, Value v2)
        {
            if (processing)
                throw new Exception("Not supported");
            processing = true;
            //compare

            processing = false;
            return true;
        }
    }
    class ResolveText : Resolver
    {
        public ResolveText(ValueText text)
        {
            value = text;
        }
        private ValueText value;
        public virtual bool resolve(Value v)
        {
            throw new Exception ("No possible comparing");
        }
    }
}
