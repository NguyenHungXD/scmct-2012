using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class DA_DM_TRANG_THAI_DU_AN:  SQLConnectWeb { 
 public static string sTableName= "DA_DM_TRANG_THAI_DU_AN"; 
   public string ID;
   public string NAME;
   public string ENABLE_BIT;
   public string CREATED_DATE;
   public string CREATED_BY;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_NAME="NAME" ;
 public static  string cl_ENABLE_BIT="ENABLE_BIT" ;
 public static  string cl_CREATED_DATE="CREATED_DATE" ;
 public static  string cl_CREATED_BY="CREATED_BY" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public DA_DM_TRANG_THAI_DU_AN() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public DA_DM_TRANG_THAI_DU_AN(
         string sID,
         string sNAME,
         string sENABLE_BIT,
         string sCREATED_DATE,
         string sCREATED_BY){
         this.ID= sID;
         this.NAME= sNAME;
         this.ENABLE_BIT= sENABLE_BIT;
         this.CREATED_DATE= sCREATED_DATE;
         this.CREATED_BY= sCREATED_BY;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static DA_DM_TRANG_THAI_DU_AN Create_DA_DM_TRANG_THAI_DU_AN ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new DA_DM_TRANG_THAI_DU_AN(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM DA_DM_TRANG_THAI_DU_AN AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public DA_DM_TRANG_THAI_DU_AN( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.NAME= dv[pos][1].ToString();
         this.ENABLE_BIT= dv[pos][2].ToString();
         this.CREATED_DATE= dv[pos][3].ToString();
         this.CREATED_BY= dv[pos][4].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByID(string sID)
{
          string sqlSelect= s_Select()+ " WHERE ID  ="+ sID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByID(string sID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ID"+ sMatch +sID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByENABLE_BIT(string sENABLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ENABLE_BIT  Like N'%"+ sENABLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_DATE(string sCREATED_DATE)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_DATE  ="+ sCREATED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_DATE(string sCREATED_DATE,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_DATE"+ sMatch +sCREATED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_BY(string sCREATED_BY)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_BY  ="+ sCREATED_BY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_BY(string sCREATED_BY,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_BY"+ sMatch +sCREATED_BY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sID
            , string sNAME
            , string sENABLE_BIT
            , string sCREATED_DATE
            , string sCREATED_BY
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sENABLE_BIT!=null && sENABLE_BIT!="") 
            sqlselect +=" AND ENABLE_BIT LIKE N'%" + sENABLE_BIT +"%'" ;
      if (sCREATED_DATE!=null && sCREATED_DATE!="") 
            sqlselect +=" AND CREATED_DATE LIKE '%" + sCREATED_DATE +"%'" ;
      if (sCREATED_BY!=null && sCREATED_BY!="") 
            sqlselect +=" AND CREATED_BY LIKE '%" + sCREATED_BY +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DA_DM_TRANG_THAI_DU_AN Insert_Object(
string  sNAME
            ,string  sENABLE_BIT
            ,string  sCREATED_DATE
            ,string  sCREATED_BY
            ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sENABLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sENABLE_BIT,"char");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"datetime");

             string sqlSave=" INSERT INTO DA_DM_TRANG_THAI_DU_AN("+
                   "NAME," 
        +                   "ENABLE_BIT," 
        +                   "CREATED_DATE," 
        +                   "CREATED_BY) VALUES("
 +tem_sNAME+","
 +tem_sENABLE_BIT+","
 +tem_sCREATED_DATE+","
 +tem_sCREATED_BY +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          DA_DM_TRANG_THAI_DU_AN newDA_DM_TRANG_THAI_DU_AN= new DA_DM_TRANG_THAI_DU_AN();
                 newDA_DM_TRANG_THAI_DU_AN.ID=GetTable( " SELECT TOP 1 ID FROM DA_DM_TRANG_THAI_DU_AN ORDER BY ID DESC ").Rows[0][0].ToString();
              newDA_DM_TRANG_THAI_DU_AN.NAME=sNAME;
              newDA_DM_TRANG_THAI_DU_AN.ENABLE_BIT=sENABLE_BIT;
              newDA_DM_TRANG_THAI_DU_AN.CREATED_DATE=sCREATED_DATE;
              newDA_DM_TRANG_THAI_DU_AN.CREATED_BY=sCREATED_BY;
            return newDA_DM_TRANG_THAI_DU_AN; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sNAME
                ,string sENABLE_BIT
                ,string sCREATED_DATE
                ,string sCREATED_BY
                ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sENABLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sENABLE_BIT,"char");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"datetime");

 string sqlSave=" UPDATE DA_DM_TRANG_THAI_DU_AN SET "+"NAME ="+tem_sNAME+","
 +"ENABLE_BIT ="+tem_sENABLE_BIT+","
 +"CREATED_DATE ="+tem_sCREATED_DATE+","
 +"CREATED_BY ="+tem_sCREATED_BY+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.NAME=sNAME;
                this.ENABLE_BIT=sENABLE_BIT;
                this.CREATED_DATE=sCREATED_DATE;
                this.CREATED_BY=sCREATED_BY;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NAME(string sNAME)
{
    string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ENABLE_BIT(string sENABLE_BIT)
{
    string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET ENABLE_BIT='N"+ sENABLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ENABLE_BIT=sENABLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CREATED_DATE(string sCREATED_DATE)
{
    string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET CREATED_DATE='"+ sCREATED_DATE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CREATED_DATE=sCREATED_DATE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CREATED_BY(string sCREATED_BY)
{
    string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET CREATED_BY='"+ sCREATED_BY+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CREATED_BY=sCREATED_BY;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ENABLE_BIT(string sENABLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET ENABLE_BIT='N"+sENABLE_BIT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_DATE(string sCREATED_DATE,string s_ID)
{
  string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET CREATED_DATE='"+sCREATED_DATE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_BY(string sCREATED_BY,string s_ID)
{
  string sqlSave= " UPDATE DA_DM_TRANG_THAI_DU_AN SET CREATED_BY='"+sCREATED_BY+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM DA_DM_TRANG_THAI_DU_AN";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "DA_DM_TRANG_THAI_DU_AN");
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
   private static DataTable dt_DA_DM_TRANG_THAI_DU_AN;
   public static bool Change_dt_DA_DM_TRANG_THAI_DU_AN = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_DA_DM_TRANG_THAI_DU_AN()
   {
   if (dt_DA_DM_TRANG_THAI_DU_AN == null || Change_dt_DA_DM_TRANG_THAI_DU_AN == true)
     {
   dt_DA_DM_TRANG_THAI_DU_AN = GetTableAll();
         Change_dt_DA_DM_TRANG_THAI_DU_AN = true && AllowAutoChange ;
     }
     return dt_DA_DM_TRANG_THAI_DU_AN;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
