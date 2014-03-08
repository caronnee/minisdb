using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MiniDatabase.Misc
{
    static class Common
    {
        public const string help = "Syntax is: \r\n " +
                     " 'attribute_name <operation> value'\r\n As operation can bbu currently used words:\r\n" +
                     " contains, misses, <, <=, >, >=, =, != \r\n" +
                     " For searching value that is not set use syntax attribute_name misses data";
        public const char Deliminer = ';';
        public const String enumPrefix = "enum";
        public const String savedSearch = "Saved search";
        public const String insertHelp = "You can insert multiple rows  ( add column to to add more records )";
        public const String noImagePath = "./images/noImage.jpg";
        public const int space = 10;
        public const String Id = "ID";
        public const String dateFormat = "dd.MMMM,yyyy";
        // enums are independant from rest of the databases, one database can use multiple enums
        public const String ProfileFile = "./data.data"; 
        public const String DbExt = ".Minis";
    }
}
