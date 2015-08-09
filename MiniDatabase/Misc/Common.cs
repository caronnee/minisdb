using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace MiniDatabase.Misc
{
  public enum Types
  {
    TypeUnknown,
    TypeText,
    TypeInteger,
    TypeDate,
    TypeEnum,
  }

  static class Common
  {
    public static String EnumConfigFile = "enums.config";
    public static List<SimpleExpressionHolder> SimpleExpressions = new List<SimpleExpressionHolder>() { 
        new SimpleExpressionHolder(){ OperationNames=new String[]{ "Less than" ,"More or equal than"}, CType=ConditionType.CLess }, 
        new SimpleExpressionHolder(){ OperationNames=new String[]{ "Contains","Misses"}, CType=ConditionType.CContain } ,
        new SimpleExpressionHolder(){ OperationNames=new String[]{"Equals to","Differs from"}, CType=ConditionType.CEqual } 
      };

    public static char[] Whitespaces = { ' ', '\a', '\b', '\n', '\r', '\f', '\t', '\v' };
    public const String saveInProgressAppendix = ".part";
    public const String SaveFolder = "..\\Docs\\";
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
