using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class PQ_NHOM_DN_CHUC_NANG:  SQLConnectWeb { 
 public static string sTableName= "PQ_NHOM_DN_CHUC_NANG"; 
   public string FEATUREID;
   public string GROUPID;
   public string ISREAD_BIT;
   public string ISINSERT_BIT;
   public string ISUPDATE_BIT;
   public string ISDELETE_BIT;
   #region DataColumn Name ;
 public static  string cl_FEATUREID="FEATUREID" ;
 public static  string cl_GROUPID="GROUPID" ;
 public static  string cl_ISREAD_BIT="ISREAD_BIT" ;
 public static  string cl_ISINSERT_BIT="ISINSERT_BIT" ;
 public static  string cl_ISUPDATE_BIT="ISUPDATE_BIT" ;
 public static  string cl_ISDELETE_BIT="ISDELETE_BIT" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public PQ_NHOM_DN_CHUC_NANG() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public PQ_NHOM_DN_CHUC_NANG(
         string sFEATUREID,
         string sGROUPID,
         string sISREAD_BIT,
         string sISINSERT_BIT,
         string sISUPDATE_BIT,
         string sISDELETE_BIT){
         this.FEATUREID= sFEATUREID;
         this.GROUPID= sGROUPID;
         this.ISREAD_BIT= sISREAD_BIT;
         this.ISINSERT_BIT= sISINSERT_BIT;
         this.ISUPDATE_BIT= sISUPDATE_BIT;
         this.ISDELETE_BIT= sISDELETE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static PQ_NHOM_DN_CHUC_NANG Create_PQ_NHOM_DN_CHUC_NANG ( string sFEATUREID  ){
    DataTable dt=SearchByFEATUREID(sFEATUREID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new PQ_NHOM_DN_CHUC_NANG(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM PQ_NHOM_DN_CHUC_NANG AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public PQ_NHOM_DN_CHUC_NANG( DataTable table,int pos)
{
         this.FEATUREID= table.Rows[pos]["FEATUREID"].ToString();
         this.GROUPID= table.Rows[pos]["GROUPID"].ToString();
         this.ISREAD_BIT= table.Rows[pos]["ISREAD_BIT"].ToString();
         this.ISINSERT_BIT= table.Rows[pos]["ISINSERT_BIT"].ToString();
         this.ISUPDATE_BIT= table.Rows[pos]["ISUPDATE_BIT"].ToString();
         this.ISDELETE_BIT= table.Rows[pos]["ISDELETE_BIT"].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByFEATUREID(string sFEATUREID)
{
          string sqlSelect= s_Select()+ " WHERE FEATUREID  ="+ sFEATUREID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByFEATUREID(string sFEATUREID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE FEATUREID"+ sMatch +sFEATUREID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByGROUPID(string sGROUPID)
{
          string sqlSelect= s_Select()+ " WHERE GROUPID  ="+ sGROUPID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByGROUPID(string sGROUPID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE GROUPID"+ sMatch +sGROUPID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISREAD_BIT(string sISREAD_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ISREAD_BIT  Like N'%"+ sISREAD_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISINSERT_BIT(string sISINSERT_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ISINSERT_BIT  Like N'%"+ sISINSERT_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISUPDATE_BIT(string sISUPDATE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ISUPDATE_BIT  Like N'%"+ sISUPDATE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISDELETE_BIT(string sISDELETE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ISDELETE_BIT  Like N'%"+ sISDELETE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sFEATUREID
            , string sGROUPID
            , string sISREAD_BIT
            , string sISINSERT_BIT
            , string sISUPDATE_BIT
            , string sISDELETE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sFEATUREID!=null && sFEATUREID!="") 
            sqlselect +=" AND FEATUREID =" + sFEATUREID ;
      if (sGROUPID!=null && sGROUPID!="") 
            sqlselect +=" AND GROUPID =" + sGROUPID ;
      if (sISREAD_BIT!=null && sISREAD_BIT!="") 
            sqlselect +=" AND ISREAD_BIT LIKE N'%" + sISREAD_BIT +"%'" ;
      if (sISINSERT_BIT!=null && sISINSERT_BIT!="") 
            sqlselect +=" AND ISINSERT_BIT LIKE N'%" + sISINSERT_BIT +"%'" ;
      if (sISUPDATE_BIT!=null && sISUPDATE_BIT!="") 
            sqlselect +=" AND ISUPDATE_BIT LIKE N'%" + sISUPDATE_BIT +"%'" ;
      if (sISDELETE_BIT!=null && sISDELETE_BIT!="") 
            sqlselect +=" AND ISDELETE_BIT LIKE N'%" + sISDELETE_BIT +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static PQ_NHOM_DN_CHUC_NANG Insert_Object(
string  sFEATUREID
            ,string  sGROUPID
            ,string  sISREAD_BIT
            ,string  sISINSERT_BIT
            ,string  sISUPDATE_BIT
            ,string  sISDELETE_BIT
            ) 
 { 
              string tem_sFEATUREID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sFEATUREID,"bigint");
              string tem_sGROUPID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGROUPID,"bigint");
              string tem_sISREAD_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISREAD_BIT,"char");
              string tem_sISINSERT_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISINSERT_BIT,"char");
              string tem_sISUPDATE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISUPDATE_BIT,"char");
              string tem_sISDELETE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISDELETE_BIT,"char");

             string sqlSave=" INSERT INTO PQ_NHOM_DN_CHUC_NANG("+
                   "FEATUREID," 
        +                   "GROUPID," 
        +                   "ISREAD_BIT," 
        +                   "ISINSERT_BIT," 
        +                   "ISUPDATE_BIT," 
        +                   "ISDELETE_BIT) VALUES("
 +tem_sFEATUREID+","
 +tem_sGROUPID+","
 +tem_sISREAD_BIT+","
 +tem_sISINSERT_BIT+","
 +tem_sISUPDATE_BIT+","
 +tem_sISDELETE_BIT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          PQ_NHOM_DN_CHUC_NANG newPQ_NHOM_DN_CHUC_NANG= new PQ_NHOM_DN_CHUC_NANG();
              newPQ_NHOM_DN_CHUC_NANG.FEATUREID=sFEATUREID;
              newPQ_NHOM_DN_CHUC_NANG.GROUPID=sGROUPID;
              newPQ_NHOM_DN_CHUC_NANG.ISREAD_BIT=sISREAD_BIT;
              newPQ_NHOM_DN_CHUC_NANG.ISINSERT_BIT=sISINSERT_BIT;
              newPQ_NHOM_DN_CHUC_NANG.ISUPDATE_BIT=sISUPDATE_BIT;
              newPQ_NHOM_DN_CHUC_NANG.ISDELETE_BIT=sISDELETE_BIT;
            return newPQ_NHOM_DN_CHUC_NANG; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sFEATUREID
                ,string sGROUPID
                ,string sISREAD_BIT
                ,string sISINSERT_BIT
                ,string sISUPDATE_BIT
                ,string sISDELETE_BIT
                ) 
 { 
              string tem_sGROUPID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGROUPID,"bigint");
              string tem_sISREAD_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISREAD_BIT,"char");
              string tem_sISINSERT_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISINSERT_BIT,"char");
              string tem_sISUPDATE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISUPDATE_BIT,"char");
              string tem_sISDELETE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISDELETE_BIT,"char");

 string sqlSave=" UPDATE PQ_NHOM_DN_CHUC_NANG SET "+"GROUPID ="+tem_sGROUPID+","
 +"ISREAD_BIT ="+tem_sISREAD_BIT+","
 +"ISINSERT_BIT ="+tem_sISINSERT_BIT+","
 +"ISUPDATE_BIT ="+tem_sISUPDATE_BIT+","
 +"ISDELETE_BIT ="+tem_sISDELETE_BIT+" WHERE FEATUREID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.FEATUREID,"bigint");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.GROUPID=sGROUPID;
                this.ISREAD_BIT=sISREAD_BIT;
                this.ISINSERT_BIT=sISINSERT_BIT;
                this.ISUPDATE_BIT=sISUPDATE_BIT;
                this.ISDELETE_BIT=sISDELETE_BIT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_FEATUREID(string sFEATUREID)
{
    string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET FEATUREID='"+ sFEATUREID+ "' WHERE FEATUREID='"+ this.FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.FEATUREID=sFEATUREID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GROUPID(string sGROUPID)
{
    string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET GROUPID='"+ sGROUPID+ "' WHERE FEATUREID='"+ this.FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.GROUPID=sGROUPID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISREAD_BIT(string sISREAD_BIT)
{
    string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISREAD_BIT='N"+ sISREAD_BIT+ "' WHERE FEATUREID='"+ this.FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISREAD_BIT=sISREAD_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISINSERT_BIT(string sISINSERT_BIT)
{
    string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISINSERT_BIT='N"+ sISINSERT_BIT+ "' WHERE FEATUREID='"+ this.FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISINSERT_BIT=sISINSERT_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISUPDATE_BIT(string sISUPDATE_BIT)
{
    string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISUPDATE_BIT='N"+ sISUPDATE_BIT+ "' WHERE FEATUREID='"+ this.FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISUPDATE_BIT=sISUPDATE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISDELETE_BIT(string sISDELETE_BIT)
{
    string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISDELETE_BIT='N"+ sISDELETE_BIT+ "' WHERE FEATUREID='"+ this.FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISDELETE_BIT=sISDELETE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_FEATUREID(string sFEATUREID,string s_FEATUREID)
{
  string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET FEATUREID='"+sFEATUREID+"' WHERE FEATUREID='"+ s_FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GROUPID(string sGROUPID,string s_FEATUREID)
{
  string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET GROUPID='"+sGROUPID+"' WHERE FEATUREID='"+ s_FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISREAD_BIT(string sISREAD_BIT,string s_FEATUREID)
{
  string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISREAD_BIT='N"+sISREAD_BIT+"' WHERE FEATUREID='"+ s_FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISINSERT_BIT(string sISINSERT_BIT,string s_FEATUREID)
{
  string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISINSERT_BIT='N"+sISINSERT_BIT+"' WHERE FEATUREID='"+ s_FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISUPDATE_BIT(string sISUPDATE_BIT,string s_FEATUREID)
{
  string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISUPDATE_BIT='N"+sISUPDATE_BIT+"' WHERE FEATUREID='"+ s_FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISDELETE_BIT(string sISDELETE_BIT,string s_FEATUREID)
{
  string sqlSave= " UPDATE PQ_NHOM_DN_CHUC_NANG SET ISDELETE_BIT='N"+sISDELETE_BIT+"' WHERE FEATUREID='"+ s_FEATUREID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
#endregion
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable GetTableAll() 
 {
       return  GetTableAll(null, null);
 }
public static DataTable GetTableAll(string sWhere, params string[] orderFields)
{
   string sqlSelect = " SELECT * FROM PQ_NHOM_DN_CHUC_NANG";
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
public static DataTable GetTableFields(string sWhere, string[] orderFields, params string[] fields)
{
 string field = "";
 if (fields != null && fields.Length > 0)
    field = string.Join(",", fields);
 else field = "*";
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "PQ_NHOM_DN_CHUC_NANG");
 if (!string.IsNullOrEmpty(sWhere))
    sqlSelect += " where " + sWhere;
 string order = "";
 if (orderFields != null && orderFields.Length > 0)
    order = string.Join(",", orderFields);
 if (order != "")
    sqlSelect += " ORDER BY " + order;
 return GetTable(sqlSelect);
 }
 public static DataTable GetTableFields(params string[] fields)
 {
    return GetTableFields(null, null, fields);
 }
 public static DataTable GetTableFields(string[] orderFields, params string[] fields)
 {
    return GetTableFields(null, orderFields, fields);
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_PQ_NHOM_DN_CHUC_NANG;
   public static bool Change_dt_PQ_NHOM_DN_CHUC_NANG = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_PQ_NHOM_DN_CHUC_NANG()
   {
   if (dt_PQ_NHOM_DN_CHUC_NANG == null || Change_dt_PQ_NHOM_DN_CHUC_NANG == true)
     {
   dt_PQ_NHOM_DN_CHUC_NANG = GetTableAll();
         Change_dt_PQ_NHOM_DN_CHUC_NANG = true && AllowAutoChange ;
     }
     return dt_PQ_NHOM_DN_CHUC_NANG;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
