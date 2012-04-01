using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class ND_NHOM_ND:  SQLConnectWeb { 
 public static string sTableName= "ND_NHOM_ND"; 
   public string GROUPID;
   public string USERID;
   #region DataColumn Name ;
 public static  string cl_GROUPID="GROUPID" ;
 public static  string cl_GROUPID_VN="GROUPID";
 public static  string cl_USERID="USERID" ;
 public static  string cl_USERID_VN="USERID";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_NHOM_ND() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_NHOM_ND(
         string sGROUPID,
         string sUSERID){
         this.GROUPID= sGROUPID;
         this.USERID= sUSERID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static ND_NHOM_ND Create_ND_NHOM_ND ( string sGROUPID  ){
    DataTable dt=dtSearchByGROUPID(sGROUPID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new ND_NHOM_ND(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM ND_NHOM_ND AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public ND_NHOM_ND( DataView dv,int pos)
{
         this.GROUPID= dv[pos][0].ToString();
         this.USERID= dv[pos][1].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGROUPID(string sGROUPID)
{
          string sqlSelect= s_Select()+ " WHERE GROUPID  ="+ sGROUPID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGROUPID(string sGROUPID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE GROUPID"+ sMatch +sGROUPID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByUSERID(string sUSERID)
{
          string sqlSelect= s_Select()+ " WHERE USERID  ="+ sUSERID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByUSERID(string sUSERID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE USERID"+ sMatch +sUSERID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sGROUPID
            , string sUSERID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sGROUPID!=null && sGROUPID!="") 
            sqlselect +=" AND GROUPID =" + sGROUPID ;
      if (sUSERID!=null && sUSERID!="") 
            sqlselect +=" AND USERID =" + sUSERID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static ND_NHOM_ND Insert_Object(
string  sGROUPID
            ,string  sUSERID
            ) 
 { 
              string tem_sGROUPID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGROUPID,"bigint");
              string tem_sUSERID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sUSERID,"bigint");

             string sqlSave=" INSERT INTO ND_NHOM_ND("+
                   "GROUPID," 
        +                   "USERID) VALUES("
 +tem_sGROUPID+","
 +tem_sUSERID +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          ND_NHOM_ND newND_NHOM_ND= new ND_NHOM_ND();
              newND_NHOM_ND.GROUPID=sGROUPID;
              newND_NHOM_ND.USERID=sUSERID;
            return newND_NHOM_ND; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sGROUPID
                ,string sUSERID
                ) 
 { 
              string tem_sUSERID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sUSERID,"bigint");

 string sqlSave=" UPDATE ND_NHOM_ND SET "+"USERID ="+tem_sUSERID+" WHERE GROUPID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.GROUPID,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.USERID=sUSERID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_GROUPID(string sGROUPID)
{
    string sqlSave= " UPDATE ND_NHOM_ND SET GROUPID='"+ sGROUPID+ "' WHERE GROUPID='"+ this.GROUPID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.GROUPID=sGROUPID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_USERID(string sUSERID)
{
    string sqlSave= " UPDATE ND_NHOM_ND SET USERID='"+ sUSERID+ "' WHERE GROUPID='"+ this.GROUPID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.USERID=sUSERID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_GROUPID(string sGROUPID,string s_GROUPID)
{
  string sqlSave= " UPDATE ND_NHOM_ND SET GROUPID='"+sGROUPID+"' WHERE GROUPID='"+ s_GROUPID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_USERID(string sUSERID,string s_GROUPID)
{
  string sqlSave= " UPDATE ND_NHOM_ND SET USERID='"+sUSERID+"' WHERE GROUPID='"+ s_GROUPID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
#endregion
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtGetTableAll() 
 {
       return  dtGetTableAll(null, null);
 }
public static DataTable dtGetTableAll(string sWhere, params string[] orderFields)
{
   string sqlSelect = " SELECT * FROM ND_NHOM_ND";
   if (!string.IsNullOrEmpty(sWhere))
      sqlSelect += " where " + sWhere; 
   string order = "";
   if (orderFields != null && orderFields.Length > 0)
     order = string.Join(",", orderFields);
   if (order != "")
      sqlSelect += " ORDER BY " + order;
   return GetTable(sqlSelect);
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
public static DataTable dtGetTableFields(string sWhere, string[] orderFields, params string[] fields)
{
 string field = "";
 if (fields != null && fields.Length > 0)
    field = string.Join(",", fields);
 else field = "*";
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "ND_NHOM_ND");
 if (!string.IsNullOrEmpty(sWhere))
    sqlSelect += " where " + sWhere;
 string order = "";
 if (orderFields != null && orderFields.Length > 0)
    order = string.Join(",", orderFields);
 if (order != "")
    sqlSelect += " ORDER BY " + order;
 return GetTable(sqlSelect);
 }
 public static DataTable dtGetTableFields(params string[] fields)
 {
    return dtGetTableFields(null, null, fields);
 }
 public static DataTable dtGetTableFields(string[] orderFields, params string[] fields)
 {
    return dtGetTableFields(null, orderFields, fields);
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_ND_NHOM_ND;
   public static bool Change_dt_ND_NHOM_ND = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_ND_NHOM_ND()
   {
   if (dt_ND_NHOM_ND == null || Change_dt_ND_NHOM_ND == true)
     {
   dt_ND_NHOM_ND = dtGetTableAll();
         Change_dt_ND_NHOM_ND = true && AllowAutoChange ;
     }
     return dt_ND_NHOM_ND;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
