namespace DK2C.DataAccess.Web
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SQLToolWeb : SQLConnectWeb
    {
        private static string ConvertSaveData(string value)
        {
            if (((value == null) || (value.Trim() == "")) || (value == "NULL"))
            {
                return "NULL";
            }
            return value;
        }

        private static string ConvertSaveStringData(string value, bool isVN)
        {
            if (((value == null) || (value.Trim() == "")) || (value.ToUpper() == "NULL"))
            {
                return "NULL";
            }
            if (isVN)
            {
                return ("N'" + value + "'");
            }
            return ("'" + value + "'");
        }

        private static List<string> getLstColumname(string sTableName)
        {
            DataTable table = SQLConnectWeb.GetTable("sp_columns " + sTableName);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return null;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(table.Rows[i]["COLUMN_NAME"].ToString());
            }
            return list;
        }

        private static List<string> getLstValue(string sTableName, DataView dv, int pos)
        {
            DataTable table = SQLConnectWeb.GetTable("sp_columns " + sTableName);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return null;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(dv[pos][i].ToString());
            }
            return list;
        }

        public static bool InsertIntoTable(string sTableName, List<string> lstValue)
        {
            try
            {
                DataTable table = SQLConnectWeb.GetTable("sp_columns " + sTableName);
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return false;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i]["TYPE_NAME"].ToString().IndexOf("identity") == -1)
                    {
                        list.Add(table.Rows[i]["COLUMN_NAME"].ToString());
                    }
                }
                string str2 = " INSERT INTO " + sTableName + "(";
                for (int j = 0; j < list.Count; j++)
                {
                    str2 = str2 + list[j] + ",";
                }
                str2 = str2.Remove(str2.Length - 1, 1) + ") VALUES(";
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    int index = list.IndexOf(table.Rows[k]["COLUMN_NAME"].ToString());
                    if (index != -1)
                    {
                        string str3 = "";
                        if (table.Rows[k]["TYPE_NAME"].ToString().ToLower().IndexOf("char") != -1)
                        {
                            str3 = "N";
                        }
                        if (str3 == "")
                        {
                            str2 = str2 + ConvertSaveStringData(lstValue[index], false) + ",";
                        }
                        else
                        {
                            str2 = str2 + ConvertSaveStringData(lstValue[index], true) + ",";
                        }
                    }
                }
                return (SQLConnectWeb.Exec(str2.Remove(str2.Length - 1, 1) + ")\r\n") == 1);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetSaveValue(string sValue, string sValueType)
        {
            if (((sValue == null) || (sValue.Trim() == "")) || (sValue.ToUpper() == "NULL"))
            {
                return "NULL";
            }
            if (((((sValueType.IndexOf("int") != -1) || (sValueType.IndexOf("num") != -1)) || ((sValueType.IndexOf("double") != -1) || (sValueType.IndexOf("float") != -1))) || (sValueType.IndexOf("deci") != -1)) || (sValueType.IndexOf("bit") != -1))
            {
                if (sValueType.IndexOf("bit") == -1)
                {
                    return sValue;
                }
                if (((sValue.ToLower() == "y") || (sValue == "true")) || (sValue == "1"))
                {
                    return "1";
                }
                return "0";
            }
            if (sValueType.IndexOf("Date") != -1)
            {
                return ("'" + sValue + "'");
            }
            return ("N'" + sValue + "'");
        }

        public static bool Update(string sTableName, List<string> lstValue)
        {
            try
            {
                DataTable table = SQLConnectWeb.GetTable("sp_columns " + sTableName);
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return false;
                }
                string str = "UPDATE " + sTableName + " SET ";
                for (int i = 1; i < lstValue.Count; i++)
                {
                    string str2 = "";
                    if (table.Rows[i]["TYPE_NAME"].ToString().ToLower().IndexOf("char") != -1)
                    {
                        str2 = "N";
                    }
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, table.Rows[i]["COLUMN_NAME"], "=", (str2 == "") ? ConvertSaveStringData(lstValue[i], false) : ConvertSaveStringData(lstValue[i], true), "," });
                }
                string str3 = str.Remove(str.Length - 1, 1);
                return (SQLConnectWeb.Exec(str3 + " WHERE " + table.Rows[0]["COLUMN_NAME"].ToString() + "='" + lstValue[0] + "'") == 1);
            }
            catch
            {
                return false;
            }
        }
    }
}

