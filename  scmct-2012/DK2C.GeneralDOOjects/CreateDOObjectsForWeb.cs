namespace DK2C.GeneralDOOjects
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using DK2C.DataAccess.Win;

    public class CreateDOObjectsForWeb : SQLConnectWin
    {
        public static void CreateFileClass(string sPrefixNameSpace, string sTableName, string sPath)
        {
            int num = 0;
            DataTable table = SQLConnectWin.GetTable("sp_columns " + sTableName);
            if ((table != null) && (table.Rows.Count != 0))
            {
                string str4;
                string str5;
                bool flag;
                string str6;
                string str9;
                string str11;
                string path = sTableName + ".cs";
                string str2 = sPrefixNameSpace + ".Objects";
                if (sPath == null)
                {
                    sPath = "";
                }
                path = sPath + "\\" + path;
                File.WriteAllText(path, "");
                StreamWriter writer = new StreamWriter(path);
                string str3 = "using System;\r\n using System.Collections.Generic;\r\n using System.Text;\r\n using System.Data;\r\n using System.Data.SqlClient;\r\n using DK2C.DataAccess.Web;\r\n";
                str3 = (((str3 + "//───────────────────────────────────────────────────────────────────────────────────────\r\n") + " namespace " + str2 + "\r\n  { \r\n") + " public class " + sTableName + ":  SQLConnectWeb { \r\n") + " public static string sTableName= \"" + sTableName + "\"; \r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str3 = str3 + "   public string " + table.Rows[num]["COLUMN_NAME"].ToString() + ";\r\n";
                }
                str3 = str3 + "   #region DataColumn Name ;\r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str3 += " public static  string cl_" + table.Rows[num]["COLUMN_NAME"].ToString() + "=\"" + table.Rows[num]["COLUMN_NAME"].ToString() + "\" ;\r\n";
                }
                str3 = (((str3 + " #endregion;\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n") + "       public " + sTableName + "() {}\r\n") + "//───────────────────────────────────────────────────────────────────────────────────────\r\n") + "       public " + sTableName + "(\r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str3 = str3 + "         string s" + table.Rows[num]["COLUMN_NAME"].ToString() + ",\r\n";
                }
                str3 = (str3 + ")").Replace(",\r\n)", ")") + "{\r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str11 = str3;
                    str3 = str11 + "         this." + table.Rows[num]["COLUMN_NAME"].ToString() + "= s" + table.Rows[num]["COLUMN_NAME"].ToString() + ";\r\n";
                }
                str11 = str3 + "}\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n";
                str11 = str11 + "       public static " + sTableName + " Create_" + sTableName + " ( string s" + table.Rows[0]["COLUMN_NAME"].ToString() + "  ){\r\n";
                str3 = ((((((((str11 + "    DataTable dt=SearchBy" + table.Rows[0]["COLUMN_NAME"].ToString() + "(s" + table.Rows[0]["COLUMN_NAME"].ToString() + ") ;\r\n") + "    if(dt!=null && dt.Rows.Count>0) \r\n") + "      return new " + sTableName + "(dt,0);\r\n") + "      return null;\r\n") + "}\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n") + "   private static string s_Select()\r\n" + "    {\r\n") + "   return \" SELECT T.* FROM " + sTableName + " AS T\";\r\n") + "    }\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n")
                    + " public " + sTableName + "( DataTable table,int pos)\r\n{\r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str11 = str3;
                    str3 = str11 + "         this." + table.Rows[num]["COLUMN_NAME"].ToString() + "= table.Rows[pos][\"" +table.Rows[num]["COLUMN_NAME"]+ "\"].ToString();\r\n";
                }
                str3 = str3 + "}\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str4 = table.Rows[num]["COLUMN_NAME"].ToString();
                    str5 = "";
                    flag = false;
                    str6 = table.Rows[num]["TYPE_NAME"].ToString().ToLower();
                    if (((((str6.IndexOf("int") != -1) || (str6.IndexOf("num") != -1)) || ((str6.IndexOf("double") != -1) || (str6.IndexOf("float") != -1))) || ((str6.IndexOf("deci") != -1) || (str6.IndexOf("datetime") != -1))) || (str6.IndexOf("bit") != -1))
                    {
                        flag = true;
                    }
                    if (str6.IndexOf("char") != -1)
                    {
                        str5 = "N";
                    }
                    str11 = str3;
                    str3 = (str11 + " public static DataTable SearchBy" + table.Rows[num]["COLUMN_NAME"].ToString() + "(string s" + table.Rows[num]["COLUMN_NAME"].ToString() + ")\r\n{\r\n") + "          string sqlSelect= s_Select()+ \" WHERE " + str4;
                    if (!flag)
                    {
                        str11 = str3;
                        str3 = str11 + "  Like " + str5 + "'%\"+ s" + str4 + " + \"%'\"; \r\n";
                    }
                    else
                    {
                        str3 = str3 + "  =\"+ s" + str4 + " + \"\"; \r\n";
                    }
                    str3 = (str3 + "          DataTable dt=GetTable(sqlSelect) ;\r\n") + "          return dt; \r\n }" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n";
                    if (flag)
                    {
                        str11 = str3 + "//───────────────────────────────────────────────────────────────────────────────────────\r\n";
                        str3 = ((((str11 + " public static DataTable SearchBy" + table.Rows[num]["COLUMN_NAME"].ToString() + "(string s" + table.Rows[num]["COLUMN_NAME"].ToString() + ",string sMatch)\r\n{\r\n") + "          string sqlSelect= s_Select()+ \" WHERE " + str4) + "\"+ sMatch +s" + str4 + " + \"\"; \r\n") + "          DataTable dt=GetTable(sqlSelect) ;\r\n") + "          return dt; \r\n }" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n";
                    }
                }
                str3 = str3 + " public static DataTable Search(";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str3 = str3 + " string s" + table.Rows[num]["COLUMN_NAME"].ToString() + "\r\n            ,";
                }
                str3 = str3.Remove(str3.Length - 1, 1) + ")\r\n {\r\n" + "       string sqlselect=s_Select() + \" WHERE\" ;\r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str11 = str3;
                    str3 = str11 + "      if (s" + table.Rows[num]["COLUMN_NAME"].ToString() + "!=null && s" + table.Rows[num]["COLUMN_NAME"].ToString() + "!=\"\") \r\n";
                    str4 = table.Rows[num]["COLUMN_NAME"].ToString();
                    str5 = "";
                    flag = false;
                    str6 = table.Rows[num]["TYPE_NAME"].ToString().ToLower();
                    if (((((str6.IndexOf("int") != -1) || (str6.IndexOf("num") != -1)) || ((str6.IndexOf("double") != -1) || (str6.IndexOf("float") != -1))) || (str6.IndexOf("deci") != -1)) || (str6.IndexOf("bit") != -1))
                    {
                        flag = true;
                    }
                    if (table.Rows[num]["TYPE_NAME"].ToString().ToLower().IndexOf("char") != -1)
                    {
                        str5 = "N";
                    }
                    str3 = str3 + "            sqlselect +=\" AND " + table.Rows[num]["COLUMN_NAME"].ToString();
                    if (!flag)
                    {
                        str11 = str3;
                        str3 = str11 + " LIKE " + str5 + "'%\" + s" + table.Rows[num]["COLUMN_NAME"].ToString() + " +\"%'\" ;\r\n";
                    }
                    else
                    {
                        str3 = str3 + " =\" + s" + table.Rows[num]["COLUMN_NAME"].ToString() + " ;\r\n";
                    }
                }
                str3 = (((str3 + "   sqlselect=sqlselect.Replace(\"WHERE AND\",\"WHERE\");\r\n" + "   int n=sqlselect.IndexOf(\"WHERE\");\r\n") + "   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;\r\n" + "   return GetTable(sqlselect);\r\n") + "}\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n") + " public static " + sTableName + " Insert_Object(\r\n";
                List<string> list = new List<string>();
                for (num = 0; num < table.Rows.Count; num++)
                {
                    if (table.Rows[num]["TYPE_NAME"].ToString().IndexOf("identity") == -1)
                    {
                        str3 = str3 + "string  s" + table.Rows[num]["COLUMN_NAME"].ToString() + "\r\n            ,";
                        list.Add("s" + table.Rows[num]["COLUMN_NAME"].ToString());
                    }
                }
                if (list.Count > 0)
                {
                    str3 = str3.Remove(str3.Length - 1, 1);
                }
                str11 = (str3 + ") \r\n { \r\n" + GetInsertText(sTableName)) + "           if (OK) \r\n" + "           { \r\n";
                str3 = str11 + "          " + sTableName + " new" + sTableName + "= new " + sTableName + "();\r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    if (table.Rows[num]["TYPE_NAME"].ToString().IndexOf("identity") == -1)
                    {
                        str11 = str3;
                        str3 = str11 + "              new" + sTableName + "." + table.Rows[num]["COLUMN_NAME"].ToString() + "=s" + table.Rows[num]["COLUMN_NAME"].ToString() + ";\r\n";
                    }
                    else
                    {
                        str11 = str3;
                        str3 = str11 + "                 new" + sTableName + "." + table.Rows[num]["COLUMN_NAME"].ToString() + "=GetTable( \" SELECT TOP 1 " + table.Rows[num]["COLUMN_NAME"].ToString() + " FROM " + sTableName + " ORDER BY " + table.Rows[num]["COLUMN_NAME"].ToString() + " DESC \").Rows[0][0].ToString();\r\n";
                    }
                }
                str3 = (((str3 + "            return new" + sTableName + "; \r\n") + "           } \r\n") + "           else return null ;\r\n" + "}\r\n") + "//───────────────────────────────────────────────────────────────────────────────────────\r\n" + "public bool  Save_Object(";
                for (num = 0; num < list.Count; num++)
                {
                    str3 = str3 + "string " + list[num] + "\r\n                ,";
                }
                if (list.Count > 0)
                {
                    str3 = str3.Remove(str3.Length - 1, 1);
                }
                str3 = (str3 + ") \r\n { \r\n" + GetUpdateText(sTableName)) + "           if (OK) \r\n" + "           { \r\n";
                for (num = 1; num < table.Rows.Count; num++)
                {
                    str11 = str3;
                    str3 = str11 + "                this." + table.Rows[num]["COLUMN_NAME"].ToString() + "=s" + table.Rows[num]["COLUMN_NAME"].ToString() + ";\r\n";
                }
                str3 = (str3 + "           } \r\n" + " return OK;  }\r\n") + "//───────────────────────────────────────────────────────────────────────────────────────\r\n" + " #region Update DataColumn  \r\n";
                string str8 = "";
                if (table.Rows[0]["TYPE_NAME"].ToString().ToLower().IndexOf("char") != -1)
                {
                    str8 = "N";
                }
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str9 = table.Rows[num]["COLUMN_NAME"].ToString();
                    str5 = "";
                    if (table.Rows[num]["TYPE_NAME"].ToString().ToLower().IndexOf("char") != -1)
                    {
                        str5 = "N";
                    }
                    str11 = str3;
                    str11 = (str11 + " public bool Update_" + str9 + "(string s" + str9 + ")\r\n") + "{\r\n";
                    str3 = (str11 + "    string sqlSave= \" UPDATE " + sTableName + " SET " + str9 + "='" + str5 + "\"+ s" + str9 + "+ \"' WHERE " + table.Rows[0]["COLUMN_NAME"].ToString() + "='" + str8 + "\"+ this." + table.Rows[0]["COLUMN_NAME"].ToString() + "+\"' \";\r\n bool OK=Exec(sqlSave)>=1?true:false;\r\n if(OK)\r\n {\r\n    this." + str9 + "=s" + str9 + ";\r\n }\r\n return OK;\r\n") + "}\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n";
                }
                str3 = str3 + " #endregion\r\n" + " #region Update DataColumn  Static \r\n";
                for (num = 0; num < table.Rows.Count; num++)
                {
                    str9 = table.Rows[num]["COLUMN_NAME"].ToString();
                    string str10 = table.Rows[num]["TYPE_NAME"].ToString();
                    str5 = "";
                    if (table.Rows[num]["TYPE_NAME"].ToString().ToLower().IndexOf("char") != -1)
                    {
                        str5 = "N";
                    }
                    if (str10.IndexOf("identity") == -1)
                    {
                        str11 = str3;
                        str11 = (str11 + " public static bool Update_" + str9 + "(string s" + str9 + ",string s_" + table.Rows[0]["COLUMN_NAME"].ToString() + ")\r\n") + "{\r\n";
                        str3 = (str11 + "  string sqlSave= \" UPDATE " + sTableName + " SET " + str9 + "='" + str5 + "\"+s" + str9 + "+\"' WHERE " + table.Rows[0]["COLUMN_NAME"].ToString() + "='" + str8 + "\"+ s_" + table.Rows[0]["COLUMN_NAME"].ToString() + "+\"' \";\r\n bool OK=Exec(sqlSave)>=1?true:false;\r\n return OK;\r\n") + "}\r\n" + "//───────────────────────────────────────────────────────────────────────────────────────\r\n";
                    }
                }
                str11 = str3 + "#endregion\r\n"
                    + "//───────────────────────────────────────────────────────────────────────────────────────\r\n"
                    + " public static DataTable GetTableAll() \r\n"
                    + " {\r\n"
                    + "       return  GetTableAll(null, null);\r\n"
                    + " }\r\n"
                    + "public static DataTable GetTableAll(string sWhere, params string[] orderFields)\r\n"
                    + "{\r\n"
                    + "   string sqlSelect = \" SELECT * FROM " + sTableName + "\";\r\n"
                    + "   if (!string.IsNullOrEmpty(sWhere))\r\n"
                    + "      sqlSelect += \" where \" + sWhere; \r\n"
                    + "   string order = \"\";\r\n"
                    + "   if (orderFields != null && orderFields.Length > 0)\r\n"
                    + "     order = string.Join(\",\", orderFields);\r\n"
                    + "   if (order != \"\")\r\n"
                    + "      sqlSelect += \" ORDER BY \" + order;\r\n"
                    + "   return GetTable(sqlSelect);\r\n"
                    + "}\r\n"
                    + "//───────────────────────────────────────────────────────────────────────────────────────\r\n"
                    + "//───────────────────────────────────────────────────────────────────────────────────────\r\n" 
                    + "public static DataTable GetTableFields(string sWhere, string[] orderFields, params string[] fields)\r\n"
                    + "{\r\n"
                    + " string field = \"\";\r\n"
                    + " if (fields != null && fields.Length > 0)\r\n"
                    + "    field = string.Join(\",\", fields);\r\n"
                    + " else field = \"*\";\r\n"
                    + " string sqlSelect = string.Format(\" SELECT {0} FROM {1} \", field, \""+sTableName+"\");\r\n"
                    + " if (!string.IsNullOrEmpty(sWhere))\r\n"
                    + "    sqlSelect += \" where \" + sWhere;\r\n"
                    + " string order = \"\";\r\n"
                    + " if (orderFields != null && orderFields.Length > 0)\r\n"
                    + "    order = string.Join(\",\", orderFields);\r\n"
                    + " if (order != \"\")\r\n"
                    + "    sqlSelect += \" ORDER BY \" + order;\r\n"
                    + " return GetTable(sqlSelect);\r\n"
                    + " }\r\n"
                    + " public static DataTable GetTableFields(params string[] fields)\r\n"
                    + " {\r\n"
                    + "    return GetTableFields(null, null, fields);\r\n"
                    + " }\r\n"
                    + " public static DataTable GetTableFields(string[] orderFields, params string[] fields)\r\n"
                    + " {\r\n"
                    + "    return GetTableFields(null, orderFields, fields);\r\n"
                    + " }\r\n"

                    + "//───────────────────────────────────────────────────────────────────────────────────────\r\n"
                    + "   private static DataTable dt_" + sTableName + ";\r\n"
                    + "   public static bool Change_dt_" + sTableName + " = true;\r\n"
                    + "   public static bool AllowAutoChange = true;\r\n"
                    + "   public static DataTable get_" + sTableName + "()\r\n"
                    + "   {\r\n";
                str3 = str11 + "   if (dt_" + sTableName + " == null || Change_dt_" + sTableName + " == true)\r\n"
                    + "     {\r\n" + "   dt_" + sTableName + " = GetTableAll();\r\n"
                    + "         Change_dt_" + sTableName + " = true && AllowAutoChange ;\r\n"
                    + "     }\r\n"
                    + "     return dt_" + sTableName + ";\r\n"
                    + "   }\r\n"
                    + "   //───────────────────────────────────────────────────────────────────────────────────────\r\n"
                    + "}  \r\n } ";
                writer.WriteLine(str3);
                writer.Close();
            }
        }

        public static string GetInsertText(string sTableName)
        {
            string str = "\" INSERT INTO " + sTableName + "(\"+\r\n";
            string str2 = "";
            string str3 = "";
            DataTable table = SQLConnectWin.GetTable("sp_columns " + sTableName);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return null;
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str4 = table.Rows[i]["TYPE_NAME"].ToString();
                if (str4.IndexOf("identity") == -1)
                {
                    string str5 = table.Rows[i]["COLUMN_NAME"].ToString();
                    str = str + "                   \"" + str5 + ",\" \r\n        +";
                    string str6 = "tem_s" + str5;
                    string str9 = str3;
                    str3 = str9 + "              string " + str6 + "=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(s" + str5 + ",\"" + str4 + "\");\r\n";
                    str2 = str2 + str6 + "+\",\"\r\n +";
                }
            }
            int length = str.LastIndexOf(",\" \r\n        +");
            str = str.Substring(0, length);
            int num4 = str2.LastIndexOf("+\",\"\r\n +");
            str2 = str2.Substring(0, num4);
            str = str + ") VALUES(\"\r\n +";
            str2 = str2 + " +\")\"";
            return ((str3 + "\r\n             string sqlSave=" + str + str2 + ";\r\n") + "             bool OK = Exec(sqlSave)>=1?true:false;\r\n");
        }

        public static string GetUpdateText(string sTableName)
        {
            string str8;
            string str = "";
            DataTable table = SQLConnectWin.GetTable("sp_columns " + sTableName);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return null;
            }
            string str2 = "\" UPDATE " + sTableName + " SET \"+";
            for (int i = 1; i < table.Rows.Count; i++)
            {
                string str3 = table.Rows[i]["TYPE_NAME"].ToString();
                if (str3.IndexOf("identity") == -1)
                {
                    string str4 = table.Rows[i]["COLUMN_NAME"].ToString();
                    string str5 = "tem_s" + str4;
                    str8 = str2;
                    str2 = str8 + "\"" + str4 + " =\"+" + str5 + "+\",\"\r\n +";
                    str8 = str;
                    str = str8 + "              string " + str5 + "=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(s" + str4 + ",\"" + str3 + "\");\r\n";
                }
            }
            int length = str2.LastIndexOf("+\",\"\r\n +");
            if (length != -1)
            {
                str2 = str2.Substring(0, length);
            }
            str8 = str2;
            str2 = str8 + "+\" WHERE " + table.Rows[0]["COLUMN_NAME"].ToString() + "=\"+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this." + table.Rows[0]["COLUMN_NAME"].ToString() + ",\"" + table.Rows[0]["TYPE_NAME"].ToString() + "\");";
            return ((str + "\r\n string sqlSave=" + str2 + ";\r\n") + "              bool OK = Exec(sqlSave)>=1?true:false;\r\n");
        }

        public static void CreateDOObject(string sPrefixNameSpace, DataTable dt, string sPath)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CreateFileClass(sPrefixNameSpace, dt.Rows[i][0].ToString(), sPath);
            }
        }

        public static void CreateStaticClass(string sPrefixNameSpace, DataTable dt, string sPath)
        {
            string contents = "namespace " + sPrefixNameSpace + ".Objects {\r\n public class TBLS{\r\n";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable table = SQLConnectWin.GetTable("sp_columns [" + dt.Rows[i][0].ToString() + "]");
                if (dt == null)
                {
                    return;
                }
                contents = contents + " public enum tbl_" + dt.Rows[i][0].ToString() + "{\r\n";
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    contents = contents + "            " + table.Rows[k]["COLUMN_NAME"].ToString() + ",\r\n";
                }
                int startIndex = contents.LastIndexOf(",\r\n");
                contents = contents.Remove(startIndex, 1) + "}\r\n" + "//──────────────────────────────────────────────────\r\n";
            }
            DataTable table2 = SQLConnectWin.GetTable("SELECT NAME FROM SYSOBJECTS WHERE TYPE='U' AND NAME NOT LIKE '%PROPER%'");
            contents = contents + " public enum TBL_NAME\r\n {\r\n";
            for (int j = 0; j < table2.Rows.Count; j++)
            {
                contents = contents + "    " + table2.Rows[j][0].ToString() + "\r\n,";
            }
            contents = (contents.Remove(contents.Length - 1, 1) + " } \r\n") + "}// end class \r\n" + "}// end name space \r\n";
            if (!Directory.Exists(sPath + "\\" + sPrefixNameSpace + ".Objects"))
            {
                Directory.CreateDirectory(sPath + "\\" + sPrefixNameSpace + ".Objects");
            }
            File.WriteAllText(sPath + "\\" + sPrefixNameSpace + ".Objects\\z_TBLS.CS", contents);
        }
    }
}

