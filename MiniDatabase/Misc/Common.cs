using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MiniDatabase.SearchEngine.Conditions;

namespace MiniDatabase.Misc
{
    public enum Types
    {
        TypeUnknown,
        TypeText,
        TypeInteger,
        TypeEnum,
    }

    static class Common
    {
      public static List<SimpleExpressionHolder> SimpleExpressions = new List<SimpleExpressionHolder>() { 
        new SimpleExpressionHolder(){ InvertedOperationName="More than", OperationName="Less than", CType=ConditionType.CLess }, 
        new SimpleExpressionHolder(){ InvertedOperationName="Misses", OperationName="Contains", CType=ConditionType.CContain } ,
        new SimpleExpressionHolder(){ InvertedOperationName="Differs from", OperationName="Equals to", CType=ConditionType.CEqual } 
      };

      public static char[] Whitespaces = { ' ',  '\a', '\b', '\n', '\r', '\f', '\t', '\v' };
      public const String saveInProgressAppendix = ".part";
      public const string help = "Syntax is: \r\n " +
                   " 'attribute_name <operation> value'\r\n As operation can e currently used words:\r\n" +
                   " contains, misses, <, <=, >, >=, =, != \r\n" +
                   " For searching value that is not set use syntax attribute_name misses data";
      public const char Deliminer = ';';
      public const String enumPrefix = "enum";
      public const String savedSearch = "Saved search";
      public const String insertHelp = "You can insert multiple rows  ( add column to to add more records )";
      // image that will be show when no default image is provided
      public const String noImagePath = "./images/noImage.jpg";
      public const int space = 10;
      public const String Id = "ID";
      public const String dateFormat = "dd.MMMM,yyyy";
      // enums are independant from rest of the databases, one database can use multiple enums
      public const String ProfileFile = "./data.data";
      public const String DbExt = ".Minis";
    }
}
