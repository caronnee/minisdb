using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Minis
{
    static class Misc //TODO premenovat
    {
        public const string help = "Syntax is: \r\n " +
                     " 'attribute_name <operation> value'\r\n As operation can bbu currently used words:\r\n" +
                     " contains, misses, <, <=, >, >=, =, != \r\n" +
                     " For searching value that is not set use syntax attribute_name misses data";
        public const string savedSearch = "Saved search";
        public const string insertHelp = "You can insert multiple rows  ( add column to to add more records )";
        public const string noImagePath = "./images/noImage.jpg";
        public const int space = 10;
        public const string Id = "ID";
        public const string dateFormat = "dd.MMMM,yyyy";
        // enums are independant from rest of the databases, one database can use multiple enums
        public const string enumFile = "./data.data"; 
        public const string fileType = ".Minis";
        public static List<string> readEnum()
        {
            List<string> l = new List<string>();

            if (!File.Exists(Misc.enumFile))
                return l;

            TextReader read = new StreamReader(Misc.enumFile);
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
