using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class BV_DM_TRANG_THAI_BAI_VIET:  SQLConnectWeb { 
 public static string sTableName= "BV_DM_TRANG_THAI_BAI_VIET"; 
   public string ID;
   public string NAME;
   public string VISIBLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_NAME="NAME" ;
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public BV_DM_TRANG_THAI_BAI_VIET() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public BV_DM_TRANG_THAI_BAI_VIET(
         string sID,
         string sNAME,
         string sVISIBLE_BIT){
         this.ID= sID;
         this.NAME= sNAME;
         this.VISIBLE_BIT= sVISIBLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static BV_DM_TRANG_THAI_BAI_VIET Create_BV_DM_TRANG_THAI_BAI_VIET ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new BV_DM_TRANG_THAI_BAI_VIET(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM BV_DM_TRANG_THAI_BAI_VIET AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public BV_DM_TRANG_THAI_BAI_VIET( DataTable table,int pos)
{
         this.ID= table.Rows[pos]["ID"].ToString();
         this.NAME= table.Rows[pos]["NAME"].ToString();
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
 public static DataTable SearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
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
            , string sNAME
            , string sVISIBLE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static BV_DM_TRANG_THAI_BAI_VIET Insert_Object(
string  sID
            ,string  sNAME
            ,string  sVISIBLE_BIT
            ) 
 { 
              string tem_sID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sID,"bigint");
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

             string sqlSave=" INSERT INTO BV_DM_TRANG_THAI_BAI_VIET("+
                   "ID," 
        +                   "NAME," 
        +                   "VISIBLE_BIT) VALUES("
 +tem_sID+","
 +tem_sNAME+","
 +tem_sVISIBLE_BIT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          BV_DM_TRANG_THAI_BAI_VIET newBV_DM_TRANG_THAI_BAI_VIET= new BV_DM_TRANG_THAI_BAI_VIET();
              newBV_DM_TRANG_THAI_BAI_VIET.ID=sID;
              newBV_DM_TRANG_THAI_BAI_VIET.NAME=sNAME;
              newBV_DM_TRANG_THAI_BAI_VIET.VISIBLE_BIT=sVISIBLE_BIT;
            return newBV_DM_TRANG_THAI_BAI_VIET; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sID
                ,string sNAME
                ,string sVISIBLE_BIT
                ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

 string sqlSave=" UPDATE BV_DM_TRANG_THAI_BAI_VIET SET "+"NAME ="+tem_sNAME+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.NAME=sNAME;
                this.VISIBLE_BIT=sVISIBLE_BIT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE BV_DM_TRANG_THAI_BAI_VIET SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
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
    string sqlSave= " UPDATE BV_DM_TRANG_THAI_BAI_VIET SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE BV_DM_TRANG_THAI_BAI_VIET SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
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
 public static bool Update_ID(string sID,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_TRANG_THAI_BAI_VIET SET ID='"+sID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_TRANG_THAI_BAI_VIET SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_TRANG_THAI_BAI_VIET SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM BV_DM_TRANG_THAI_BAI_VIET";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "BV_DM_TRANG_THAI_BAI_VIET");
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
   private static DataTable dt_BV_DM_TRANG_THAI_BAI_VIET;
   public static bool Change_dt_BV_DM_TRANG_THAI_BAI_VIET = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_BV_DM_TRANG_THAI_BAI_VIET()
   {
   if (dt_BV_DM_TRANG_THAI_BAI_VIET == null || Change_dt_BV_DM_TRANG_THAI_BAI_VIET == true)
     {
   dt_BV_DM_TRANG_THAI_BAI_VIET = GetTableAll();
         Change_dt_BV_DM_TRANG_THAI_BAI_VIET = true && AllowAutoChange ;
     }
     return dt_BV_DM_TRANG_THAI_BAI_VIET;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
