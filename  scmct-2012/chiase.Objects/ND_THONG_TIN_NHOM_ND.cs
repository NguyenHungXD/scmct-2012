using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class ND_THONG_TIN_NHOM_ND:  SQLConnectWeb { 
 public static string sTableName= "ND_THONG_TIN_NHOM_ND"; 
   public string ID;
   public string CODE;
   public string NAME;
   public string PARENT_ID;
   public string ROOT_ID;
   public string DESCRIPTION;
   public string VISIBLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_CODE="CODE" ;
 public static  string cl_NAME="NAME" ;
 public static  string cl_PARENT_ID="PARENT_ID" ;
 public static  string cl_ROOT_ID="ROOT_ID" ;
 public static  string cl_DESCRIPTION="DESCRIPTION" ;
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_THONG_TIN_NHOM_ND() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_THONG_TIN_NHOM_ND(
         string sID,
         string sCODE,
         string sNAME,
         string sPARENT_ID,
         string sROOT_ID,
         string sDESCRIPTION,
         string sVISIBLE_BIT){
         this.ID= sID;
         this.CODE= sCODE;
         this.NAME= sNAME;
         this.PARENT_ID= sPARENT_ID;
         this.ROOT_ID= sROOT_ID;
         this.DESCRIPTION= sDESCRIPTION;
         this.VISIBLE_BIT= sVISIBLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static ND_THONG_TIN_NHOM_ND Create_ND_THONG_TIN_NHOM_ND ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new ND_THONG_TIN_NHOM_ND(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM ND_THONG_TIN_NHOM_ND AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public ND_THONG_TIN_NHOM_ND( DataTable table,int pos)
{
         this.ID= table.Rows[pos]["ID"].ToString();
         this.CODE= table.Rows[pos]["CODE"].ToString();
         this.NAME= table.Rows[pos]["NAME"].ToString();
         this.PARENT_ID= table.Rows[pos]["PARENT_ID"].ToString();
         this.ROOT_ID= table.Rows[pos]["ROOT_ID"].ToString();
         this.DESCRIPTION= table.Rows[pos]["DESCRIPTION"].ToString();
         this.VISIBLE_BIT= table.Rows[pos]["VISIBLE_BIT"].ToString();
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
 public static DataTable SearchByCODE(string sCODE)
{
          string sqlSelect= s_Select()+ " WHERE CODE  Like N'%"+ sCODE + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPARENT_ID(string sPARENT_ID)
{
          string sqlSelect= s_Select()+ " WHERE PARENT_ID  ="+ sPARENT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPARENT_ID(string sPARENT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PARENT_ID"+ sMatch +sPARENT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByROOT_ID(string sROOT_ID)
{
          string sqlSelect= s_Select()+ " WHERE ROOT_ID  ="+ sROOT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByROOT_ID(string sROOT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ROOT_ID"+ sMatch +sROOT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDESCRIPTION(string sDESCRIPTION)
{
          string sqlSelect= s_Select()+ " WHERE DESCRIPTION  Like N'%"+ sDESCRIPTION + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByVISIBLE_BIT(string sVISIBLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE VISIBLE_BIT  Like N'%"+ sVISIBLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sID
            , string sCODE
            , string sNAME
            , string sPARENT_ID
            , string sROOT_ID
            , string sDESCRIPTION
            , string sVISIBLE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sCODE!=null && sCODE!="") 
            sqlselect +=" AND CODE LIKE N'%" + sCODE +"%'" ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sPARENT_ID!=null && sPARENT_ID!="") 
            sqlselect +=" AND PARENT_ID =" + sPARENT_ID ;
      if (sROOT_ID!=null && sROOT_ID!="") 
            sqlselect +=" AND ROOT_ID =" + sROOT_ID ;
      if (sDESCRIPTION!=null && sDESCRIPTION!="") 
            sqlselect +=" AND DESCRIPTION LIKE N'%" + sDESCRIPTION +"%'" ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static ND_THONG_TIN_NHOM_ND Insert_Object(
string  sCODE
            ,string  sNAME
            ,string  sPARENT_ID
            ,string  sROOT_ID
            ,string  sDESCRIPTION
            ,string  sVISIBLE_BIT
            ) 
 { 
              string tem_sCODE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCODE,"nvarchar");
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sPARENT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPARENT_ID,"bigint");
              string tem_sROOT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sROOT_ID,"bigint");
              string tem_sDESCRIPTION=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDESCRIPTION,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

             string sqlSave=" INSERT INTO ND_THONG_TIN_NHOM_ND("+
                   "CODE," 
        +                   "NAME," 
        +                   "PARENT_ID," 
        +                   "ROOT_ID," 
        +                   "DESCRIPTION," 
        +                   "VISIBLE_BIT) VALUES("
 +tem_sCODE+","
 +tem_sNAME+","
 +tem_sPARENT_ID+","
 +tem_sROOT_ID+","
 +tem_sDESCRIPTION+","
 +tem_sVISIBLE_BIT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          ND_THONG_TIN_NHOM_ND newND_THONG_TIN_NHOM_ND= new ND_THONG_TIN_NHOM_ND();
                 newND_THONG_TIN_NHOM_ND.ID=GetTable( " SELECT TOP 1 ID FROM ND_THONG_TIN_NHOM_ND ORDER BY ID DESC ").Rows[0][0].ToString();
              newND_THONG_TIN_NHOM_ND.CODE=sCODE;
              newND_THONG_TIN_NHOM_ND.NAME=sNAME;
              newND_THONG_TIN_NHOM_ND.PARENT_ID=sPARENT_ID;
              newND_THONG_TIN_NHOM_ND.ROOT_ID=sROOT_ID;
              newND_THONG_TIN_NHOM_ND.DESCRIPTION=sDESCRIPTION;
              newND_THONG_TIN_NHOM_ND.VISIBLE_BIT=sVISIBLE_BIT;
            return newND_THONG_TIN_NHOM_ND; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sCODE
                ,string sNAME
                ,string sPARENT_ID
                ,string sROOT_ID
                ,string sDESCRIPTION
                ,string sVISIBLE_BIT
                ) 
 { 
              string tem_sCODE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCODE,"nvarchar");
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sPARENT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPARENT_ID,"bigint");
              string tem_sROOT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sROOT_ID,"bigint");
              string tem_sDESCRIPTION=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDESCRIPTION,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

 string sqlSave=" UPDATE ND_THONG_TIN_NHOM_ND SET "+"CODE ="+tem_sCODE+","
 +"NAME ="+tem_sNAME+","
 +"PARENT_ID ="+tem_sPARENT_ID+","
 +"ROOT_ID ="+tem_sROOT_ID+","
 +"DESCRIPTION ="+tem_sDESCRIPTION+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.CODE=sCODE;
                this.NAME=sNAME;
                this.PARENT_ID=sPARENT_ID;
                this.ROOT_ID=sROOT_ID;
                this.DESCRIPTION=sDESCRIPTION;
                this.VISIBLE_BIT=sVISIBLE_BIT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CODE(string sCODE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET CODE='N"+ sCODE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CODE=sCODE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NAME(string sNAME)
{
    string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PARENT_ID(string sPARENT_ID)
{
    string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET PARENT_ID='"+ sPARENT_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PARENT_ID=sPARENT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ROOT_ID(string sROOT_ID)
{
    string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET ROOT_ID='"+ sROOT_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ROOT_ID=sROOT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DESCRIPTION(string sDESCRIPTION)
{
    string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET DESCRIPTION='N"+ sDESCRIPTION+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DESCRIPTION=sDESCRIPTION;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.VISIBLE_BIT=sVISIBLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_CODE(string sCODE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET CODE='N"+sCODE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PARENT_ID(string sPARENT_ID,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET PARENT_ID='"+sPARENT_ID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ROOT_ID(string sROOT_ID,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET ROOT_ID='"+sROOT_ID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DESCRIPTION(string sDESCRIPTION,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET DESCRIPTION='N"+sDESCRIPTION+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_NHOM_ND SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM ND_THONG_TIN_NHOM_ND";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "ND_THONG_TIN_NHOM_ND");
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
   private static DataTable dt_ND_THONG_TIN_NHOM_ND;
   public static bool Change_dt_ND_THONG_TIN_NHOM_ND = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_ND_THONG_TIN_NHOM_ND()
   {
   if (dt_ND_THONG_TIN_NHOM_ND == null || Change_dt_ND_THONG_TIN_NHOM_ND == true)
     {
   dt_ND_THONG_TIN_NHOM_ND = GetTableAll();
         Change_dt_ND_THONG_TIN_NHOM_ND = true && AllowAutoChange ;
     }
     return dt_ND_THONG_TIN_NHOM_ND;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
