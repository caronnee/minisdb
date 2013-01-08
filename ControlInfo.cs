using System;
using System.Collections.Generic;
using System.Text;

namespace Minis
{
    class ControlInfo
    {
        public int x, y, width, heigth;
        public ControlInfo(int x_, int y_, int width_, int heigth_)
        {
            x = x_;
            y = y_;
            width = width_;
            heigth = heigth_;
        }
        public ControlInfo(string toConvert)
        {
            string[] s = toConvert.Split(new char[] { Misc.Deliminer }, StringSplitOptions.RemoveEmptyEntries);

            x = System.Convert.ToInt32(s[0]);
            y = System.Convert.ToInt32(s[1]);
            width = System.Convert.ToInt32(s[2]);
            heigth = System.Convert.ToInt32(s[3]);
        }
        public override string ToString()
        {
            return (x.ToString() +
                Misc.Deliminer.ToString() + y.ToString() +
                Misc.Deliminer.ToString() + width.ToString() +
                Misc.Deliminer.ToString() + heigth.ToString());
        }
    }
}
