using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myDb
{
    class Visitor
    {
        public Visitor() { }
        public void visited(AttributeImage im) { }
        public void visited(AttributeInteger number) { }
        public void visited(AttributeTime date) { }
        public void visited(AttributeEnum en) { }
        public void visited(Attribute a) { }
    }
}
