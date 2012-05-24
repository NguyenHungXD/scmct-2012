
using DK2C.DataAccess.Web;
using System;
using System.Data;
namespace chiase
{
    public class Qly_Session : SQLConnectWeb
    {
        public static bool AllowAutoChange = true;
        public static bool Change_dt_Qly_Session = true;
        public static string cl_ClientID = "ClientID";
        public static string cl_ClientID_VN = "ClientID";
        public static string cl_FullName = "FullName";
        public static string cl_FullName_VN = "FullName";
        public static string cl_Id = "Id";
        public static string cl_Id_VN = "Id";
        public static string cl_IdBacSi = "IdBacSi";
        public static string cl_IdBacSi_VN = "IdBacSi";
        public static string cl_Role = "Role";
        public static string cl_Role_VN = "Role";
        public static string cl_UserID = "UserID";
        public static string cl_UserID_VN = "UserID";
        public static string cl_UserName = "UserName";
        public static string cl_UserName_VN = "UserName";
        public string ClientID;
        private static DataTable dt_Qly_Session;
        public string FullName;
        public string Id;
        public string IdBacSi;
        public string Role;
        public static string sTableName = "Qly_Session";
        public string UserID;
        public string UserName;

        public Qly_Session()
        {
        }

        public Qly_Session(DataView dv, int pos)
        {
            this.Id = dv[pos]["Id"].ToString();
            this.ClientID = dv[pos]["ClientID"].ToString();
            this.UserID = dv[pos]["UserID"].ToString();
            this.UserName = dv[pos]["UserName"].ToString();
            this.FullName = dv[pos]["FullName"].ToString();
            this.Role = dv[pos]["Role"].ToString();
            this.IdBacSi = dv[pos]["IdBacSi"].ToString();
        }

        public Qly_Session(string sId, string sClientID, string sUserID, string sUserName, string sFullName, string sRole, string sIdBacSi)
        {
            this.Id = sId;
            this.ClientID = sClientID;
            this.UserID = sUserID;
            this.UserName = sUserName;
            this.FullName = sFullName;
            this.Role = sRole;
            this.IdBacSi = sIdBacSi;
        }

        public static Qly_Session Create_Qly_Session(string sId)
        {
            DataTable table = dtSearchById(sId);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return new Qly_Session(table.DefaultView, 0);
            }
            return null;
        }

        public static DataTable dtGetAll()
        {
            string strSelect = " SELECT * FROM Qly_Session ";
            return SQLConnectWeb.GetTable(strSelect);
        }

        public static DataTable dtSearch(string sId, string sClientID, string sUserID, string sUserName, string sFullName, string sRole, string sIdBacSi)
        {
            string strSelect = s_Select() + " WHERE";
            if ((sId != null) && (sId != ""))
            {
                strSelect = strSelect + " AND Id =" + sId;
            }
            if ((sClientID != null) && (sClientID != ""))
            {
                strSelect = strSelect + " AND ClientID LIKE N'%" + sClientID + "%'";
            }
            if ((sUserID != null) && (sUserID != ""))
            {
                strSelect = strSelect + " AND UserID LIKE N'%" + sUserID + "%'";
            }
            if ((sUserName != null) && (sUserName != ""))
            {
                strSelect = strSelect + " AND UserName LIKE N'%" + sUserName + "%'";
            }
            if ((sFullName != null) && (sFullName != ""))
            {
                strSelect = strSelect + " AND FullName LIKE N'%" + sFullName + "%'";
            }
            if ((sRole != null) && (sRole != ""))
            {
                strSelect = strSelect + " AND Role LIKE N'%" + sRole + "%'";
            }
            if ((sIdBacSi != null) && (sIdBacSi != ""))
            {
                strSelect = strSelect + " AND IdBacSi =" + sIdBacSi;
            }
            strSelect = strSelect.Replace("WHERE AND", "WHERE");
            int index = strSelect.IndexOf("WHERE");
            if (index == (strSelect.Length - 5))
            {
                strSelect = strSelect.Remove(index, 5);
            }
            return SQLConnectWeb.GetTable(strSelect);
        }

        public static DataTable dtSearchByClientID(string sClientID)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE ClientID  Like N'%" + sClientID + "%'");
        }

        public static DataTable dtSearchByFullName(string sFullName)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE FullName  Like N'%" + sFullName + "%'");
        }

        public static DataTable dtSearchById(string sId)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE Id  =" + sId + "");
        }

        public static DataTable dtSearchById(string sId, string sMatch)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE Id" + sMatch + sId + "");
        }

        public static DataTable dtSearchByIdBacSi(string sIdBacSi)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE IdBacSi  =" + sIdBacSi + "");
        }

        public static DataTable dtSearchByIdBacSi(string sIdBacSi, string sMatch)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE IdBacSi" + sMatch + sIdBacSi + "");
        }

        public static DataTable dtSearchByRole(string sRole)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE Role  Like N'%" + sRole + "%'");
        }

        public static DataTable dtSearchByUserID(string sUserID)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE UserID  Like N'%" + sUserID + "%'");
        }

        public static DataTable dtSearchByUserName(string sUserName)
        {
            return SQLConnectWeb.GetTable(s_Select() + " WHERE UserName  Like N'%" + sUserName + "%'");
        }

        public static DataTable get_Qly_Session()
        {
            if ((dt_Qly_Session == null) || Change_dt_Qly_Session)
            {
                dt_Qly_Session = dtGetAll();
                Change_dt_Qly_Session = AllowAutoChange;
            }
            return dt_Qly_Session;
        }

        public static Qly_Session Insert_Object(string sClientID, string sUserID, string sUserName, string sFullName, string sRole, string sIdBacSi)
        {
            string str = SQLConnectWeb.GetSaveValue(sClientID, "nvarchar");
            string str2 = SQLConnectWeb.GetSaveValue(sUserID, "nvarchar");
            string str3 = SQLConnectWeb.GetSaveValue(sUserName, "nvarchar");
            string str4 = SQLConnectWeb.GetSaveValue(sFullName, "nvarchar");
            string str5 = SQLConnectWeb.GetSaveValue(sRole, "nvarchar");
            string str6 = SQLConnectWeb.GetSaveValue(sIdBacSi, "bigint");
            if (SQLConnectWeb.Exec(" INSERT INTO Qly_Session(ClientID,UserID,UserName,FullName,Role,IdBacSi) VALUES(" + str + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + ")") == 1)
            {
                return new Qly_Session { Id = SQLConnectWeb.GetTable(" SELECT TOP 1 Id FROM Qly_Session ORDER BY Id DESC ").Rows[0][0].ToString(), ClientID = sClientID, UserID = sUserID, UserName = sUserName, FullName = sFullName, Role = sRole, IdBacSi = sIdBacSi };
            }
            return null;
        }

        private static string s_Select()
        {
            return " SELECT T.* FROM Qly_Session AS T";
        }

        public bool Save_Object(string sClientID, string sUserID, string sUserName, string sFullName, string sRole, string sIdBacSi)
        {
            string str = SQLConnectWeb.GetSaveValue(sClientID, "nvarchar");
            string str2 = SQLConnectWeb.GetSaveValue(sUserID, "nvarchar");
            string str3 = SQLConnectWeb.GetSaveValue(sUserName, "nvarchar");
            string str4 = SQLConnectWeb.GetSaveValue(sFullName, "nvarchar");
            string str5 = SQLConnectWeb.GetSaveValue(sRole, "nvarchar");
            string str6 = SQLConnectWeb.GetSaveValue(sIdBacSi, "bigint");
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET ClientID =" + str + ",UserID =" + str2 + ",UserName =" + str3 + ",FullName =" + str4 + ",Role =" + str5 + ",IdBacSi =" + str6 + " WHERE Id=" + SQLConnectWeb.GetSaveValue(this.Id, "bigint identity")) == 1;
            if (flag)
            {
                this.ClientID = sClientID;
                this.UserID = sUserID;
                this.UserName = sUserName;
                this.FullName = sFullName;
                this.Role = sRole;
                this.IdBacSi = sIdBacSi;
            }
            return flag;
        }

        public bool Update_ClientID(string sClientID)
        {
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET ClientID='N" + sClientID + "' WHERE Id='" + this.Id + "' ") == 1;
            if (flag)
            {
                this.ClientID = sClientID;
            }
            return flag;
        }

        public static bool Update_ClientID(string sClientID, string s_Id)
        {
            return (SQLConnectWeb.Exec(" UPDATE Qly_Session SET ClientID='N" + sClientID + "' WHERE Id='" + s_Id + "' ") == 1);
        }

        public bool Update_FullName(string sFullName)
        {
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET FullName='N" + sFullName + "' WHERE Id='" + this.Id + "' ") == 1;
            if (flag)
            {
                this.FullName = sFullName;
            }
            return flag;
        }

        public static bool Update_FullName(string sFullName, string s_Id)
        {
            return (SQLConnectWeb.Exec(" UPDATE Qly_Session SET FullName='N" + sFullName + "' WHERE Id='" + s_Id + "' ") == 1);
        }

        public bool Update_Id(string sId)
        {
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET Id='" + sId + "' WHERE Id='" + this.Id + "' ") == 1;
            if (flag)
            {
                this.Id = sId;
            }
            return flag;
        }

        public bool Update_IdBacSi(string sIdBacSi)
        {
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET IdBacSi='" + sIdBacSi + "' WHERE Id='" + this.Id + "' ") == 1;
            if (flag)
            {
                this.IdBacSi = sIdBacSi;
            }
            return flag;
        }

        public static bool Update_IdBacSi(string sIdBacSi, string s_Id)
        {
            return (SQLConnectWeb.Exec(" UPDATE Qly_Session SET IdBacSi='" + sIdBacSi + "' WHERE Id='" + s_Id + "' ") == 1);
        }

        public bool Update_Role(string sRole)
        {
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET Role='N" + sRole + "' WHERE Id='" + this.Id + "' ") == 1;
            if (flag)
            {
                this.Role = sRole;
            }
            return flag;
        }

        public static bool Update_Role(string sRole, string s_Id)
        {
            return (SQLConnectWeb.Exec(" UPDATE Qly_Session SET Role='N" + sRole + "' WHERE Id='" + s_Id + "' ") == 1);
        }

        public bool Update_UserID(string sUserID)
        {
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET UserID='N" + sUserID + "' WHERE Id='" + this.Id + "' ") == 1;
            if (flag)
            {
                this.UserID = sUserID;
            }
            return flag;
        }

        public static bool Update_UserID(string sUserID, string s_Id)
        {
            return (SQLConnectWeb.Exec(" UPDATE Qly_Session SET UserID='N" + sUserID + "' WHERE Id='" + s_Id + "' ") == 1);
        }

        public bool Update_UserName(string sUserName)
        {
            bool flag = SQLConnectWeb.Exec(" UPDATE Qly_Session SET UserName='N" + sUserName + "' WHERE Id='" + this.Id + "' ") == 1;
            if (flag)
            {
                this.UserName = sUserName;
            }
            return flag;
        }

        public static bool Update_UserName(string sUserName, string s_Id)
        {
            return (SQLConnectWeb.Exec(" UPDATE Qly_Session SET UserName='N" + sUserName + "' WHERE Id='" + s_Id + "' ") == 1);
        }
    }


}