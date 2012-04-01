using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class ND_TEN_NHOM_ND:  SQLConnectWeb { 
 public static string sTableName= "ND_TEN_NHOM_ND"; 
   public string GROUPID;
   public string GROUPNAME;
   #region DataColumn Name ;
 public static  string cl_GROUPID="GROUPID" ;
 public static  string cl_GROUPID_VN="GROUPID";
 public static  string cl_GROUPNAME="GROUPNAME" ;
 public static  string cl_GROUPNAME_VN="GROUPNAME";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_TEN_NHOM_ND() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_TEN_NHOM_ND(
         string sGROUPID,
         string sGROUPNAME){
         this.GROUPID= sGROUPID;
         this.GROUPNAME= sGROUPNAME;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static ND_TEN_NHOM_ND Create_ND_TEN_NHOM_ND ( string sGROUPID  ){
    DataTable dt=dtSearchByGROUPID(sGROUPID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new ND_TEN_NHOM_ND(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM ND_TEN_NHOM_ND AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public ND_TEN_NHOM_ND( DataView dv,int pos)
{
         this.GROUPID= dv[pos][0].ToString();
         this.GROUPNAME= dv[pos][1].ToString();
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
 public static DataTable dtSearchByGROUPNAME(string sGROUPNAME)
{
          string sqlSelect= s_Select()+ " WHERE GROUPNAME  Like N'%"+ sGROUPNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sGROUPID
            , string sGROUPNAME
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sGROUPID!=null && sGROUPID!="") 
            sqlselect +=" AND GROUPID =" + sGROUPID ;
      if (sGROUPNAME!=null && sGROUPNAME!="") 
            sqlselect +=" AND GROUPNAME LIKE N'%" + sGROUPNAME +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static ND_TEN_NHOM_ND Insert_Object(
string  sGROUPNAME
            ) 
 { 
              string tem_sGROUPNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGROUPNAME,"nvarchar");

             string sqlSave=" INSERT INTO ND_TEN_NHOM_ND("+
                   "GROUPNAME) VALUES("
 +tem_sGROUPNAME +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          ND_TEN_NHOM_ND newND_TEN_NHOM_ND= new ND_TEN_NHOM_ND();
                 newND_TEN_NHOM_ND.GROUPID=GetTable( " SELECT TOP 1 GROUPID FROM ND_TEN_NHOM_ND ORDER BY GROUPID DESC ").Rows[0][0].ToString();
              newND_TEN_NHOM_ND.GROUPNAME=sGROUPNAME;
            return newND_TEN_NHOM_ND; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sGROUPNAME
                ) 
 { 
              string tem_sGROUPNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGROUPNAME,"nvarchar");

 string sqlSave=" UPDATE ND_TEN_NHOM_ND SET "+"GROUPNAME ="+tem_sGROUPNAME+" WHERE GROUPID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.GROUPID,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.GROUPNAME=sGROUPNAME;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_GROUPID(string sGROUPID)
{
    string sqlSave= " UPDATE ND_TEN_NHOM_ND SET GROUPID='"+ sGROUPID+ "' WHERE GROUPID='"+ this.GROUPID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.GROUPID=sGROUPID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GROUPNAME(string sGROUPNAME)
{
    string sqlSave= " UPDATE ND_TEN_NHOM_ND SET GROUPNAME='N"+ sGROUPNAME+ "' WHERE GROUPID='"+ this.GROUPID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.GROUPNAME=sGROUPNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_GROUPNAME(string sGROUPNAME,string s_GROUPID)
{
  string sqlSave= " UPDATE ND_TEN_NHOM_ND SET GROUPNAME='N"+sGROUPNAME+"' WHERE GROUPID='"+ s_GROUPID+"' ";
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
   string sqlSelect = " SELECT * FROM ND_TEN_NHOM_ND";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "ND_TEN_NHOM_ND");
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
   private static DataTable dt_ND_TEN_NHOM_ND;
   public static bool Change_dt_ND_TEN_NHOM_ND = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_ND_TEN_NHOM_ND()
   {
   if (dt_ND_TEN_NHOM_ND == null || Change_dt_ND_TEN_NHOM_ND == true)
     {
   dt_ND_TEN_NHOM_ND = dtGetTableAll();
         Change_dt_ND_TEN_NHOM_ND = true && AllowAutoChange ;
     }
     return dt_ND_TEN_NHOM_ND;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
