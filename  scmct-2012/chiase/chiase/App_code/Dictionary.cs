
using DK2C.DataAccess.Web;
using System;
using System.Collections.Generic;
using System.Data;
namespace chiase
{
    public class Dictionary : SQLConnectWeb
    {
        public static bool AllowAutoChange = true;
        public string CH_abc;
        public string CH_Descript;
        public static bool Change_dt_Dictionary = true;
        public static string cl_CH_abc = "CH_abc";
        public static string cl_CH_abc_VN = "CH_abc";
        public static string cl_CH_Descript = "CH_Descript";
        public static string cl_CH_Descript_VN = "CH_Descript";
        public static string cl_EN_abc = "EN_abc";
        public static string cl_EN_abc_VN = "EN_abc";
        public static string cl_EN_Descript = "EN_Descript";
        public static string cl_EN_Descript_VN = "EN_Descript";
        public static string cl_ID = "ID";
        public static string cl_ID_VN = "ID";
        public static string cl_VN_abc = "VN_abc";
        public static string cl_VN_abc_VN = "VN_abc";
        public static string cl_VN_Descript = "VN_Descript";
        public static string cl_VN_Descript_VN = "VN_Descript";
        private static DataTable dt_Dictionary;
        public string EN_abc;
        public string EN_Descript;
        public string ID;
        public static string sTableName = "Dictionary";
        public string VN_abc;
        public string VN_Descript;

        public Dictionary()
        {
        }

        public Dictionary(DataView dv, int pos)
        {
            this.ID = dv[pos][0].ToString();
            this.VN_abc = dv[pos][1].ToString();
            this.VN_Descript = dv[pos][2].ToString();
            this.EN_abc = dv[pos][3].ToString();
            this.EN_Descript = dv[pos][4].ToString();
            this.CH_abc = dv[pos][5].ToString();
            this.CH_Descript = dv[pos][6].ToString();
        }

        public Dictionary(string sID, string sVN_abc, string sVN_Descript, string sEN_abc, string sEN_Descript, string sCH_abc, string sCH_Descript)
        {
            this.ID = sID;
            this.VN_abc = sVN_abc;
            this.VN_Descript = sVN_Descript;
            this.EN_abc = sEN_abc;
            this.EN_Descript = sEN_Descript;
            this.CH_abc = sCH_abc;
            this.CH_Descript = sCH_Descript;
        }

        public static Dictionary Create_Dictionary(string sID)
        {
            DataTable dt = dtSearchByID(sID);
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                return new Dictionary(dt.DefaultView, 0);
            }
            return null;
        }

        public static DataTable dtGetAll()
        {
            return GetTable(s_Select());
        }

        public static DataTable dtGetFromdB()
        {
            List<string> lstID = new List<string>();
            string sArrID = "";
            DataTable dt = GetTable("SELECT NAME FROM SYSOBJECTS WHERE TYPE='U'");
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                return null;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sTablName = dt.Rows[i][0].ToString();
                if (lstID.IndexOf(sTableName) == -1)
                {
                    lstID.Add(sTableName);
                    sArrID = sArrID + "'" + sTableName + "',";
                }
                DataTable dt2 = GetTable("SP_COLUMNS " + sTablName);
                if (dt2 != null)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        string sColName = dt2.Rows[j]["COLUMN_NAME"].ToString();
                        if (lstID.IndexOf(sColName) == -1)
                        {
                            lstID.Add(sColName);
                            sArrID = sArrID + "'" + sColName + "',";
                        }
                    }
                }
            }
            sArrID = sArrID.Remove(sArrID.Length - 1, 1);
            return GetTable("SELECT * FROM  Dictionary WHERE ID IN (" + sArrID + ")");
        }

        public static DataTable dtGetFromTableName(string sTablName)
        {
            List<string> lstID = new List<string>();
            string sArrID = "";
            if (lstID.IndexOf(sTableName) == -1)
            {
                lstID.Add(sTableName);
                sArrID = sArrID + "'" + sTablName + "',";
            }
            DataTable dt2 = GetTable("SP_COLUMNS " + sTablName);
            if (dt2 != null)
            {
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    string sColName = dt2.Rows[j]["COLUMN_NAME"].ToString();
                    if (lstID.IndexOf(sColName) == -1)
                    {
                        lstID.Add(sColName);
                        sArrID = sArrID + "'" + sColName + "',";
                    }
                }
            }
            sArrID = sArrID.Remove(sArrID.Length - 1, 1);
            return GetTable("SELECT * FROM  Dictionary WHERE ID IN (" + sArrID + ")");
        }

        public static DataTable dtGetListIDLanguage()
        {
            return GetTable("SELECT " + cl_ID + " FROM " + sTableName);
        }

        public static DataTable dtSearch(string sID, string sVN_abc, string sVN_Descript, string sEN_abc, string sEN_Descript, string sCH_abc, string sCH_Descript)
        {
            string sqlselect = s_Select() + " WHERE";
            if ((sID != null) && (sID != ""))
            {
                sqlselect = sqlselect + " AND ID LIKE N'%" + sID + "%'";
            }
            if ((sVN_abc != null) && (sVN_abc != ""))
            {
                sqlselect = sqlselect + " AND VN_abc LIKE N'%" + sVN_abc + "%'";
            }
            if ((sVN_Descript != null) && (sVN_Descript != ""))
            {
                sqlselect = sqlselect + " AND VN_Descript LIKE N'%" + sVN_Descript + "%'";
            }
            if ((sEN_abc != null) && (sEN_abc != ""))
            {
                sqlselect = sqlselect + " AND EN_abc LIKE N'%" + sEN_abc + "%'";
            }
            if ((sEN_Descript != null) && (sEN_Descript != ""))
            {
                sqlselect = sqlselect + " AND EN_Descript LIKE N'%" + sEN_Descript + "%'";
            }
            if ((sCH_abc != null) && (sCH_abc != ""))
            {
                sqlselect = sqlselect + " AND CH_abc LIKE N'%" + sCH_abc + "%'";
            }
            if ((sCH_Descript != null) && (sCH_Descript != ""))
            {
                sqlselect = sqlselect + " AND CH_Descript LIKE N'%" + sCH_Descript + "%'";
            }
            sqlselect = sqlselect.Replace("WHERE AND", "WHERE");
            int n = sqlselect.IndexOf("WHERE");
            if (n == (sqlselect.Length - 5))
            {
                sqlselect = sqlselect.Remove(n, 5);
            }
            return GetTable(sqlselect);
        }

        public static DataTable dtSearchByCH_abc(string sCH_abc)
        {
            return GetTable(s_Select() + " WHERE CH_abc  Like N'%" + sCH_abc + "%'");
        }

        public static DataTable dtSearchByCH_Descript(string sCH_Descript)
        {
            return GetTable(s_Select() + " WHERE CH_Descript  Like N'%" + sCH_Descript + "%'");
        }

        public static DataTable dtSearchByEN_abc(string sEN_abc)
        {
            return GetTable(s_Select() + " WHERE EN_abc  Like N'%" + sEN_abc + "%'");
        }

        public static DataTable dtSearchByEN_Descript(string sEN_Descript)
        {
            return GetTable(s_Select() + " WHERE EN_Descript  Like N'%" + sEN_Descript + "%'");
        }

        public static DataTable dtSearchByID(string sID)
        {
            return GetTable(s_Select() + " WHERE ID  = '" + sID + "'");
        }

        public static DataTable dtSearchByVN_abc(string sVN_abc)
        {
            return GetTable(s_Select() + " WHERE VN_abc  Like N'%" + sVN_abc + "%'");
        }

        public static DataTable dtSearchByVN_Descript(string sVN_Descript)
        {
            return GetTable(s_Select() + " WHERE VN_Descript  Like N'%" + sVN_Descript + "%'");
        }

        public static DataTable dtSearchExtra(string sID, string sVN_abc, string sVN_Descript, string sEN_abc, string sEN_Descript, string sCH_abc, string sCH_Descript)
        {
            string sqlselect = s_Select() + " WHERE";
            if ((sID != null) && (sID != ""))
            {
                sqlselect = sqlselect + " AND ID = '" + sID + "'";
            }
            if ((sVN_abc != null) && (sVN_abc != ""))
            {
                sqlselect = sqlselect + " AND VN_abc ='" + sVN_abc + "'";
            }
            if ((sVN_Descript != null) && (sVN_Descript != ""))
            {
                sqlselect = sqlselect + " AND VN_Descript = N'" + sVN_Descript + "'";
            }
            if ((sEN_abc != null) && (sEN_abc != ""))
            {
                sqlselect = sqlselect + " AND EN_abc = N'" + sEN_abc + "'";
            }
            if ((sEN_Descript != null) && (sEN_Descript != ""))
            {
                sqlselect = sqlselect + " AND EN_Descript = N'" + sEN_Descript + "'";
            }
            if ((sCH_abc != null) && (sCH_abc != ""))
            {
                sqlselect = sqlselect + " AND CH_abc = N'" + sCH_abc + "'";
            }
            if ((sCH_Descript != null) && (sCH_Descript != ""))
            {
                sqlselect = sqlselect + " AND CH_Descript = N'" + sCH_Descript + "'";
            }
            sqlselect = sqlselect.Replace("WHERE AND", "WHERE");
            int n = sqlselect.IndexOf("WHERE");
            if (n == (sqlselect.Length - 5))
            {
                sqlselect = sqlselect.Remove(n, 5);
            }
            return GetTable(sqlselect);
        }

        public static DataTable dtSearchLikeID(string sID)
        {
            return GetTable(s_Select() + " WHERE ID  Like N'%" + sID + "%'");
        }

        public static DataTable get_Dictionary()
        {
            if ((dt_Dictionary == null) || Change_dt_Dictionary)
            {
                dt_Dictionary = dtGetAll();
                Change_dt_Dictionary = AllowAutoChange;
            }
            return dt_Dictionary;
        }

        public static Dictionary Insert_Object(string sID, string sVN_abc, string sVN_Descript, string sEN_abc, string sEN_Descript, string sCH_abc, string sCH_Descript)
        {
            string tem_sID = SQLConnectWeb.GetSaveValue(sID, "nvarchar");
            string tem_sVN_abc = SQLConnectWeb.GetSaveValue(sVN_abc, "nvarchar");
            string tem_sVN_Descript = SQLConnectWeb.GetSaveValue(sVN_Descript, "nvarchar");
            string tem_sEN_abc = SQLConnectWeb.GetSaveValue(sEN_abc, "nvarchar");
            string tem_sEN_Descript = SQLConnectWeb.GetSaveValue(sEN_Descript, "nvarchar");
            string tem_sCH_abc = SQLConnectWeb.GetSaveValue(sCH_abc, "nvarchar");
            string tem_sCH_Descript = SQLConnectWeb.GetSaveValue(sCH_Descript, "nvarchar");
            if (Exec(" INSERT INTO Dictionary(ID,VN_abc,VN_Descript,EN_abc,EN_Descript,CH_abc,CH_Descript) VALUES(" + tem_sID + "," + tem_sVN_abc + "," + tem_sVN_Descript + "," + tem_sEN_abc + "," + tem_sEN_Descript + "," + tem_sCH_abc + "," + tem_sCH_Descript + ")") == 1)
            {
                return new Dictionary { ID = sID, VN_abc = sVN_abc, VN_Descript = sVN_Descript, EN_abc = sEN_abc, EN_Descript = sEN_Descript, CH_abc = sCH_abc, CH_Descript = sCH_Descript };
            }
            return null;
        }

        private static string s_Select()
        {
            return " SELECT T.* FROM Dictionary AS T";
        }

        public bool Save_Object(string sID, string sVN_abc, string sVN_Descript, string sEN_abc, string sEN_Descript, string sCH_abc, string sCH_Descript)
        {
            string tem_sVN_abc = SQLConnectWeb.GetSaveValue(sVN_abc, "nvarchar");
            string tem_sVN_Descript = SQLConnectWeb.GetSaveValue(sVN_Descript, "nvarchar");
            string tem_sEN_abc = SQLConnectWeb.GetSaveValue(sEN_abc, "nvarchar");
            string tem_sEN_Descript = SQLConnectWeb.GetSaveValue(sEN_Descript, "nvarchar");
            string tem_sCH_abc = SQLConnectWeb.GetSaveValue(sCH_abc, "nvarchar");
            string tem_sCH_Descript = SQLConnectWeb.GetSaveValue(sCH_Descript, "nvarchar");
            bool OK = Exec(" UPDATE Dictionary SET VN_abc =" + tem_sVN_abc + ",VN_Descript =" + tem_sVN_Descript + ",EN_abc =" + tem_sEN_abc + ",EN_Descript =" + tem_sEN_Descript + ",CH_abc =" + tem_sCH_abc + ",CH_Descript =" + tem_sCH_Descript + " WHERE ID=" + SQLConnectWeb.GetSaveValue(this.ID, "nvarchar")) == 1;
            if (OK)
            {
                this.VN_abc = sVN_abc;
                this.VN_Descript = sVN_Descript;
                this.EN_abc = sEN_abc;
                this.EN_Descript = sEN_Descript;
                this.CH_abc = sCH_abc;
                this.CH_Descript = sCH_Descript;
            }
            return OK;
        }

        public bool Update_CH_abc(string sCH_abc)
        {
            bool OK = Exec(" UPDATE Dictionary SET CH_abc=N'" + sCH_abc + "' WHERE ID=N'" + this.ID + "' ") == 1;
            if (OK)
            {
                this.CH_abc = sCH_abc;
            }
            return OK;
        }

        public static bool Update_CH_abc(string sCH_abc, string s_ID)
        {
            return (Exec(" UPDATE Dictionary SET CH_abc=N'" + sCH_abc + "' WHERE ID=N'" + s_ID + "' ") == 1);
        }

        public bool Update_CH_Descript(string sCH_Descript)
        {
            bool OK = Exec(" UPDATE Dictionary SET CH_Descript=N'" + sCH_Descript + "' WHERE ID=N'" + this.ID + "' ") == 1;
            if (OK)
            {
                this.CH_Descript = sCH_Descript;
            }
            return OK;
        }

        public static bool Update_CH_Descript(string sCH_Descript, string s_ID)
        {
            return (Exec(" UPDATE Dictionary SET CH_Descript=N'" + sCH_Descript + "' WHERE ID=N'" + s_ID + "' ") == 1);
        }

        public bool Update_EN_abc(string sEN_abc)
        {
            bool OK = Exec(" UPDATE Dictionary SET EN_abc=N'" + sEN_abc + "' WHERE ID=N'" + this.ID + "' ") == 1;
            if (OK)
            {
                this.EN_abc = sEN_abc;
            }
            return OK;
        }

        public static bool Update_EN_abc(string sEN_abc, string s_ID)
        {
            return (Exec(" UPDATE Dictionary SET EN_abc=N'" + sEN_abc + "' WHERE ID=N'" + s_ID + "' ") == 1);
        }

        public bool Update_EN_Descript(string sEN_Descript)
        {
            bool OK = Exec(" UPDATE Dictionary SET EN_Descript=N'" + sEN_Descript + "' WHERE ID=N'" + this.ID + "' ") == 1;
            if (OK)
            {
                this.EN_Descript = sEN_Descript;
            }
            return OK;
        }

        public static bool Update_EN_Descript(string sEN_Descript, string s_ID)
        {
            return (Exec(" UPDATE Dictionary SET EN_Descript=N'" + sEN_Descript + "' WHERE ID=N'" + s_ID + "' ") == 1);
        }

        public bool Update_ID(string sID)
        {
            bool OK = Exec(" UPDATE Dictionary SET ID=N'" + sID + "' WHERE ID=N'" + this.ID + "' ") == 1;
            if (OK)
            {
                this.ID = sID;
            }
            return OK;
        }

        public static bool Update_ID(string sID, string s_ID)
        {
            return (Exec(" UPDATE Dictionary SET ID=N'" + sID + "' WHERE ID=N'" + s_ID + "' ") == 1);
        }

        public bool Update_VN_abc(string sVN_abc)
        {
            bool OK = Exec(" UPDATE Dictionary SET VN_abc=N'" + sVN_abc + "' WHERE ID=N'" + this.ID + "' ") == 1;
            if (OK)
            {
                this.VN_abc = sVN_abc;
            }
            return OK;
        }

        public static bool Update_VN_abc(string sVN_abc, string s_ID)
        {
            return (Exec(" UPDATE Dictionary SET VN_abc=N'" + sVN_abc + "' WHERE ID=N'" + s_ID + "' ") == 1);
        }

        public bool Update_VN_Descript(string sVN_Descript)
        {
            bool OK = Exec(" UPDATE Dictionary SET VN_Descript=N'" + sVN_Descript + "' WHERE ID=N'" + this.ID + "' ") == 1;
            if (OK)
            {
                this.VN_Descript = sVN_Descript;
            }
            return OK;
        }

        public static bool Update_VN_Descript(string sVN_Descript, string s_ID)
        {
            return (Exec(" UPDATE Dictionary SET VN_Descript=N'" + sVN_Descript + "' WHERE ID=N'" + s_ID + "' ") == 1);
        }
    }


}