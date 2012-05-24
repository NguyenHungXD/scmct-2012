
using DK2C.DataAccess.Web;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
namespace chiase
{
    public static class DictionaryDB
    {
        private static string[] arrIDLanguage_temp = null;
        public static DataTable dtDictionary = null;
        public static Page WebPage = new Page();

        public static event RequireChangeTextHandle RequireChangeText;

        public static void AutoFillInDatabase()
        {
            int i;
            string sColName;
            DataTable dt = SQLConnectWeb.GetTable("select name  from sysobjects where type='u' and  name not like '%proper%'");
            for (i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dt2 = SQLConnectWeb.GetTable("sp_columns " + dt.Rows[i][0].ToString());
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    sColName = dt2.Rows[j]["COLUMN_NAME"].ToString();
                    SQLConnectWeb.Exec(" if Not Exists (SELECT ID FROM Dictionary WHERE ID=N'" + sColName + "')   INSERT INTO Dictionary (ID,EN_abc,EN_Descript) Values(N'" + sColName + "',N'" + sColName + "',N'" + sColName + "')");
                }
            }
            for (i = 0; i < dt.Rows.Count; i++)
            {
                sColName = dt.Rows[i][0].ToString().Replace("cab_", "").Replace("hs_", "");
                SQLConnectWeb.Exec(" if Not Exists (SELECT ID FROM Dictionary WHERE ID=N'" + sColName + "')   INSERT INTO Dictionary (ID,EN_abc,EN_Descript) Values(N'" + sColName + "',N'" + sColName + "',N'" + sColName + "')");
            }
        }

        public static string GetParameter(string ParamterName)
        {
            string fileName = WebPage.Server.MapPath("~/App_Data/" + ParamterName + ".txt");
            if (!File.Exists(fileName))
            {
                return null;
            }
            string s = File.ReadAllText(fileName);
            switch (s)
            {
                case null:
                case "":
                    return null;
            }
            return s;
        }

        public static int int_Search(DataTable dtSearch, string s_Filter)
        {
            try
            {
                DataRow[] DR = dtSearch.Select(s_Filter);
                if (DR.Length == 0)
                {
                    return -1;
                }
                return dtSearch.Rows.IndexOf(DR[0]);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static void OnRequireChangeText()
        {
            if (RequireChangeText != null)
            {
                RequireChangeText();
            }
        }

        public static void RefreshStockDictionary(string ID)
        {
            dtDictionary = Dictionary.dtSearchByID(ID);
        }

        public static string s_ReadFile(string s_FileName)
        {
            if (!File.Exists(s_FileName))
            {
                return "";
            }
            StreamReader sR = new StreamReader(s_FileName);
            string S = sR.ReadToEnd();
            sR.Close();
            return S;
        }

        public static bool s_WriteFile(string s_FileName, string value)
        {
            try
            {
                if (!File.Exists(s_FileName))
                {
                    File.WriteAllText(s_FileName, value);
                }
                else
                {
                    StreamWriter sW = new StreamWriter(s_FileName);
                    sW.Write(value);
                    sW.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SaveLanguage(string sIDLanguage, int langType, bool isShort, string Text)
        {
            if (Text.Trim() != "")
            {
                string sNewText = null;
                bool isExistID = false;
                int indext = -1;
                sNewText = sGetValueLanguage(sIDLanguage, langType, isShort, ref isExistID, ref indext);
                if (!isExistID || (sNewText != null))
                {
                    return true;
                }
                bool OK = false;
                bool AllowSave = false;
                switch (langType)
                {
                    case 1:
                        AllowSave = true;
                        if (!isShort)
                        {
                            OK = Dictionary.Update_VN_Descript(Text, sIDLanguage);
                            break;
                        }
                        OK = Dictionary.Update_VN_abc(Text, sIDLanguage);
                        break;

                    case 2:
                        AllowSave = true;
                        if (!isShort)
                        {
                            OK = Dictionary.Update_EN_Descript(Text, sIDLanguage);
                            break;
                        }
                        OK = Dictionary.Update_EN_abc(Text, sIDLanguage);
                        break;

                    case 3:
                        AllowSave = true;
                        if (!isShort)
                        {
                            OK = Dictionary.Update_CH_Descript(Text, sIDLanguage);
                            break;
                        }
                        OK = Dictionary.Update_CH_abc(Text, sIDLanguage);
                        break;
                }
                if (AllowSave)
                {
                    return OK;
                }
            }
            return true;
        }

        private static string sGetDictionaryPath()
        {
            return WebPage.Server.MapPath("~/App_Data/Dictionary/clhsLibrary.cs");
        }

        public static string sGetValueLanguage(Dictionary currentDic)
        {
            bool isShort = bool_CurrentWriteType;
            string sText = currentDic.ID;
            switch (SystemLanguage)
            {
                case 1:
                    if (!isShort)
                    {
                        return currentDic.VN_Descript;
                    }
                    return currentDic.VN_abc;

                case 2:
                    if (!isShort)
                    {
                        return currentDic.EN_Descript;
                    }
                    return currentDic.EN_abc;

                case 3:
                    if (!isShort)
                    {
                        return currentDic.CH_Descript;
                    }
                    return currentDic.CH_abc;

                case 4:
                    if (!isShort)
                    {
                        return (currentDic.EN_Descript + "(" + currentDic.VN_Descript + ")");
                    }
                    return (currentDic.EN_abc + "(" + currentDic.VN_abc + ")");

                case 5:
                    if (!isShort)
                    {
                        return (currentDic.VN_Descript + "(" + currentDic.EN_Descript + ")");
                    }
                    return (currentDic.VN_abc + "(" + currentDic.EN_abc + ")");

                case 6:
                    if (!isShort)
                    {
                        return (currentDic.EN_Descript + "(" + currentDic.CH_Descript + ")");
                    }
                    return (currentDic.EN_abc + "(" + currentDic.CH_abc + ")");

                case 7:
                    if (!isShort)
                    {
                        return (currentDic.CH_Descript + "(" + currentDic.EN_Descript + ")");
                    }
                    return (currentDic.CH_abc + "(" + currentDic.EN_abc + ")");

                case 8:
                    if (!isShort)
                    {
                        return (currentDic.CH_Descript + "(" + currentDic.VN_Descript + ")");
                    }
                    return (currentDic.CH_abc + "(" + currentDic.VN_abc + ")");

                case 9:
                    if (!isShort)
                    {
                        return (currentDic.VN_Descript + "(" + currentDic.CH_Descript + ")");
                    }
                    return (currentDic.VN_abc + "(" + currentDic.CH_abc + ")");
            }
            return sText;
        }

        public static string sGetValueLanguage(string sIDLanguage)
        {
            return sGetValueLanguage(sIDLanguage, SystemLanguage, bool_CurrentWriteType);
        }

        public static string sGetValueLanguage(string sIDLanguage, int langType)
        {
            bool isShort = true;
            return sGetValueLanguage(sIDLanguage, langType, isShort);
        }

        public static string sGetValueLanguage(string sIDLanguage, int langType, bool isShort)
        {
            bool isExistID = false;
            int indext = -1;
            return sGetValueLanguage(sIDLanguage, langType, isShort, ref isExistID, ref indext);
        }

        private static string sGetValueLanguage(string sIDLanguage, int langType, bool isShort, ref bool isExistID, ref int indext)
        {
            if (sIDLanguage == null)
            {
                return null;
            }
            sIDLanguage = sIDLanguage.Trim();
            if ((sIDLanguage == "") || (sIDLanguage == "NULL"))
            {
                return "";
            }
            isExistID = false;
            RefreshStockDictionary(sIDLanguage);
            if ((dtDictionary == null) || (dtDictionary.Rows.Count == 0))
            {
                return sIDLanguage;
            }
            int n = int_Search(dtDictionary, "ID='" + sIDLanguage + "'");
            indext = n;
            if (indext == -1)
            {
                if (((sIDLanguage.Length <= 2) || (sIDLanguage.Substring(sIDLanguage.Length - 2, 2) != "ID")) && ((sIDLanguage.Length <= 3) || !(sIDLanguage.Substring(0, 3).ToLower() == "frm")))
                {
                    return sIDLanguage;
                }
                if ((sIDLanguage.Length > 2) && (sIDLanguage.Substring(sIDLanguage.Length - 2, 2) == "ID"))
                {
                    sIDLanguage = sIDLanguage.Substring(0, sIDLanguage.Length - 2);
                }
                if ((sIDLanguage.Length > 3) && (sIDLanguage.Substring(0, 3).ToLower() == "frm"))
                {
                    sIDLanguage = sIDLanguage.Remove(0, 3);
                }
                return sGetValueLanguage(sIDLanguage, langType, isShort, ref isExistID, ref indext);
            }
            string sText = null;
            isExistID = true;
            switch (langType)
            {
                case 1:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][2].ToString();
                        break;
                    }
                    sText = dtDictionary.Rows[n][1].ToString();
                    break;

                case 2:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][4].ToString();
                        break;
                    }
                    sText = dtDictionary.Rows[n][3].ToString();
                    break;

                case 3:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][6].ToString();
                        break;
                    }
                    sText = dtDictionary.Rows[n][5].ToString();
                    break;

                case 4:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][4].ToString() + "(" + dtDictionary.Rows[n][2].ToString() + ")";
                        break;
                    }
                    sText = dtDictionary.Rows[n][3].ToString() + "(" + dtDictionary.Rows[n][1].ToString() + ")";
                    break;

                case 5:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][2].ToString() + "(" + dtDictionary.Rows[n][4].ToString() + ")";
                        break;
                    }
                    sText = dtDictionary.Rows[n][1].ToString() + "(" + dtDictionary.Rows[n][3].ToString() + ")";
                    break;

                case 6:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][4].ToString() + "(" + dtDictionary.Rows[n][6].ToString() + ")";
                        break;
                    }
                    sText = dtDictionary.Rows[n][3].ToString() + "(" + dtDictionary.Rows[n][5].ToString() + ")";
                    break;

                case 7:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][6].ToString() + "(" + dtDictionary.Rows[n][4].ToString() + ")";
                        break;
                    }
                    sText = dtDictionary.Rows[n][5].ToString() + "(" + dtDictionary.Rows[n][3].ToString() + ")";
                    break;

                case 8:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][6].ToString() + "(" + dtDictionary.Rows[n][2].ToString() + ")";
                        break;
                    }
                    sText = dtDictionary.Rows[n][5].ToString() + "(" + dtDictionary.Rows[n][1].ToString() + ")";
                    break;

                case 9:
                    if (!isShort)
                    {
                        sText = dtDictionary.Rows[n][2].ToString() + "(" + dtDictionary.Rows[n][6].ToString() + ")";
                        break;
                    }
                    sText = dtDictionary.Rows[n][1].ToString() + "(" + dtDictionary.Rows[n][5].ToString() + ")";
                    break;
            }
            if (((sText == null) || !(sText != "")) || !(sText != "()"))
            {
                return sIDLanguage;
            }
            if (sText.Length > 2)
            {
                if (sText.LastIndexOf("()") == (sText.Length - 2))
                {
                    return sText.Substring(0, sText.Length - 2);
                }
                if (sText.LastIndexOf("(") == 0)
                {
                    return sText.Substring(1, sText.Length - 2);
                }
            }
            return sText;
        }

        public static void vRefreshConectDB()
        {
            SQLConnectWeb.NewConnect();
            vRefreshListLanguage();
        }

        public static void vRefreshListLanguage()
        {
            dtDictionary = Dictionary.dtGetAll();
            if ((dtDictionary != null) && (dtDictionary.Rows.Count != 0))
            {
                string slistDic = "          NULL,\r\n";
                for (int i = 0; i < dtDictionary.Rows.Count; i++)
                {
                    slistDic = slistDic + "          " + dtDictionary.Rows[i][0].ToString() + ",\r\n";
                }
                int m = slistDic.LastIndexOf(",\r\n");
                slistDic = slistDic.Remove(m, 1);
                string sValueAll = "namespace  hsLibrary\r\n  {\r\n   public     class clDictionary\r\n       {\r\n           public enum hsDictionary\r\n           {\r\n" + slistDic + "  }\r\n}\r\n}//    \r\n";
                s_WriteFile(sClDictionaryPath, sValueAll);
            }
        }

        private static void vRefreshListLanguage1()
        {
            dtDictionary = Dictionary.dtGetAll();
            if ((dtDictionary != null) && (dtDictionary.Rows.Count != 0))
            {
                arrIDLanguage_temp = new string[0];
                for (int i = 0; i < dtDictionary.Rows.Count; i++)
                {
                    Array.Resize<string>(ref arrIDLanguage_temp, arrIDLanguage_temp.Length + 1);
                    arrIDLanguage_temp[arrIDLanguage_temp.Length - 1] = dtDictionary.Rows[i][0].ToString();
                }
            }
        }

        private static string[] arrIDLanguage
        {
            get
            {
                if (arrIDLanguage_temp == null)
                {
                    vRefreshListLanguage();
                }
                return arrIDLanguage_temp;
            }
        }

        public static bool bool_CurrentWriteType
        {
            get
            {
                return (GetParameter("SystemLanguage_IsShort") == "1");
            }
        }

        public static DictionaryOption.WriteType CurrentWriteType
        {
            get
            {
                return DictionaryOption.GetWriteType(GetParameter("SystemLanguage_IsShort") == "1");
            }
        }

        public static bool IsBothWriteType
        {
            get
            {
                return (GetParameter("IsBothWriteType") == "1");
            }
        }

        public static bool IsChiness
        {
            get
            {
                return ((SystemLanguage == 3) || (SystemLanguage >= 6));
            }
        }

        public static DictionaryOption.Language lan_SystemLanguage
        {
            get
            {
                return DictionaryOption.GetLanguage(SystemLanguage);
            }
        }

        private static string sClDictionaryPath
        {
            get
            {
                return sGetDictionaryPath();
            }
        }

        public static int SystemLanguage
        {
            get
            {
                string s = GetParameter("SystemLanguage");
                if ((s != null) && (s != ""))
                {
                    return int.Parse(s);
                }
                return 1;
            }
        }

        public delegate void RequireChangeTextHandle();
    }

}