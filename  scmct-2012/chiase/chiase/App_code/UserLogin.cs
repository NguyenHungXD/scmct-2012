using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;
using DK2C.DataAccess.Web;

namespace chiase
{
    public class UserLogin : SQLConnectWeb
    {
        public static bool HavePermision(System.Web.UI.Page currPage, string PermName)
        {
            return true;
            string ID = UserID(currPage);
            if (IsAdmin(currPage))
                return true;
            if (ID == null || ID == "" || ID == "0") return false;
            string sqlSelect = ""
                            + " select count(*) from UserProfile A" + "\r\n"
                            + " left join Permision B on A.PermID=B.PermID" + "\r\n"
                            + " where B.PermName='" + PermName + "' and A.Status=1 and B.Status=1 and A.UserID=" + ID + "" + "\r\n";
            DataTable dt = GetTable(sqlSelect);
            if (dt == null) return false;
            if (dt.Rows[0][0].ToString() == "0") return false;
            return true;
        }
        public static string FullName(Page P)
        {
            DataTable table = GetTable("select * from Qly_Session where  ClientID  ='" + P.Request.UserHostAddress.ToString() + "'");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return "0";
            }
            return table.Rows[0]["FullName"].ToString();
        }

        public static string GroupID(Page P)
        {
            DataTable table = GetTable("select * from Qly_Session where  ClientID  ='" + P.Request.UserHostAddress.ToString() + "'");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return "0";
            }
            return table.Rows[0]["Role"].ToString();
        }

        public static string IdBacSi(Page P)
        {
            DataTable table = GetTable("select * from Qly_Session where  ClientID  ='" + P.Request.UserHostAddress.ToString() + "'");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return "0";
            }
            return table.Rows[0]["IdBacSi"].ToString();
        }

        public static bool IsAdmin(Page P)
        {
            DataTable table = GetTable("select * from Qly_Session where  ClientID  ='" + P.Request.UserHostAddress.ToString() + "'");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return false;
            }
            return (table.Rows[0]["Role"].ToString().ToLower() == "4");
        }

        public static bool RemoveLogin(Page P)
        {
            ExecSQL("DELETE  from Qly_Session where  ClientID='" + P.Request.UserHostAddress.ToString() + "'");
            return true;
        }

        public static bool SaveGroup(Page P, string sGroupID)
        {
            DataTable table = GetTable("select * from Qly_Session where  ClientID  ='" + P.Request.UserHostAddress.ToString() + "'");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return false;
            }
            string str3 = table.Rows[0]["ClientID"].ToString();
            return ExecSQL("UPDATE Qly_Session SET Role=" + sGroupID + " WHERE ClientID='" + str3 + "'");
        }

        public static bool SaveUserLogin(Page P, string s_UserName, string sUserID, string sFullName, string sRole, string sIdBacSi)
        {
            string sClientID = P.Request.UserHostAddress.ToString();
            DataTable table = GetTable("select * from Qly_Session where  ClientID='" + sClientID + "'");
            if (table == null)
            {
                return false;
            }
            if (table.Rows.Count == 0)
            {
                return (Qly_Session.Insert_Object(sClientID, sUserID, s_UserName, sFullName, sRole, sIdBacSi) != null);
            }
            return new Qly_Session { Id = table.Rows[0]["Id"].ToString() }.Save_Object(sClientID, sUserID, s_UserName, sFullName, sRole, sIdBacSi);
        }

        public static string UserID(Page P)
        {
            DataTable table = GetTable("select * from Qly_Session where  ClientID  ='" + P.Request.UserHostAddress.ToString() + "'");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return "0";
            }
            return table.Rows[0]["UserID"].ToString();
        }

        public static string UserName(Page P)
        {
            DataTable table = GetTable("select * from Qly_Session where  ClientID  ='" + P.Request.UserHostAddress.ToString() + "'");
            if ((table == null) || (table.Rows.Count == 0))
            {
                return "0";
            }
            return table.Rows[0]["UserName"].ToString();
        }
    }
}