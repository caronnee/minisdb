using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace myDb
{
    static class Files //TODO premenovat
    {
        public const string noImagePath = "./images/noImage.jpg";
        public const int space = 10;
        public const string Id = "ID";
        public const string dateFormat = "dd.MMMM,yyyy";
        public const string enumFile = "./enums.data";
        public const string fileType = ".myDb";
        public static List<string> readEnum()
        {
            List<string> l = new List<string>();

            if (!File.Exists(Files.enumFile))
                return l;

            TextReader read = new StreamReader(Files.enumFile);
            //sprav geline az pokial nenajdes s
            String line;
            while ((line = read.ReadLine()) != null)
            {
                l.Add(line);
            }
            read.Close();
            return l;
        }
    }
}
