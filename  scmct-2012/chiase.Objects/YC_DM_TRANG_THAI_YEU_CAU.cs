using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class YC_DM_TRANG_THAI_YEU_CAU:  SQLConnectWeb { 
 public static string sTableName= "YC_DM_TRANG_THAI_YEU_CAU"; 
   public string ID;
   public string NAME;
   public string VISIBLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_ID_VN="ID";
 public static  string cl_NAME="NAME" ;
 public static  string cl_NAME_VN="NAME";
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 public static  string cl_VISIBLE_BIT_VN="VISIBLE_BIT";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public YC_DM_TRANG_THAI_YEU_CAU() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public YC_DM_TRANG_THAI_YEU_CAU(
         string sID,
         string sNAME,
         string sVISIBLE_BIT){
         this.ID= sID;
         this.NAME= sNAME;
         this.VISIBLE_BIT= sVISIBLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static YC_DM_TRANG_THAI_YEU_CAU Create_YC_DM_TRANG_THAI_YEU_CAU ( string sID  ){
    DataTable dt=dtSearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new YC_DM_TRANG_THAI_YEU_CAU(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM YC_DM_TRANG_THAI_YEU_CAU AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public YC_DM_TRANG_THAI_YEU_CAU( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.NAME= dv[pos][1].ToString();
         this.VISIBLE_BIT= dv[pos][2].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByID(string sID)
{
          string sqlSelect= s_Select()+ " WHERE ID  ="+ sID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByID(string sID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ID"+ sMatch +sID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByVISIBLE_BIT(string sVISIBLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE VISIBLE_BIT  Like N'%"+ sVISIBLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sID
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
 public static YC_DM_TRANG_THAI_YEU_CAU Insert_Object(
string  sNAME
            ,string  sVISIBLE_BIT
            ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

             string sqlSave=" INSERT INTO YC_DM_TRANG_THAI_YEU_CAU("+
                   "NAME," 
        +                   "VISIBLE_BIT) VALUES("
 +tem_sNAME+","
 +tem_sVISIBLE_BIT +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          YC_DM_TRANG_THAI_YEU_CAU newYC_DM_TRANG_THAI_YEU_CAU= new YC_DM_TRANG_THAI_YEU_CAU();
                 newYC_DM_TRANG_THAI_YEU_CAU.ID=GetTable( " SELECT TOP 1 ID FROM YC_DM_TRANG_THAI_YEU_CAU ORDER BY ID DESC ").Rows[0][0].ToString();
              newYC_DM_TRANG_THAI_YEU_CAU.NAME=sNAME;
              newYC_DM_TRANG_THAI_YEU_CAU.VISIBLE_BIT=sVISIBLE_BIT;
            return newYC_DM_TRANG_THAI_YEU_CAU; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sNAME
                ,string sVISIBLE_BIT
                ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

 string sqlSave=" UPDATE YC_DM_TRANG_THAI_YEU_CAU SET "+"NAME ="+tem_sNAME+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
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
    string sqlSave= " UPDATE YC_DM_TRANG_THAI_YEU_CAU SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NAME(string sNAME)
{
    string sqlSave= " UPDATE YC_DM_TRANG_THAI_YEU_CAU SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE YC_DM_TRANG_THAI_YEU_CAU SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.VISIBLE_BIT=sVISIBLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_TRANG_THAI_YEU_CAU SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_TRANG_THAI_YEU_CAU SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM YC_DM_TRANG_THAI_YEU_CAU " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_YC_DM_TRANG_THAI_YEU_CAU;
   public static bool Change_dt_YC_DM_TRANG_THAI_YEU_CAU = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_YC_DM_TRANG_THAI_YEU_CAU()
   {
   if (dt_YC_DM_TRANG_THAI_YEU_CAU == null || Change_dt_YC_DM_TRANG_THAI_YEU_CAU == true)
   {
   dt_YC_DM_TRANG_THAI_YEU_CAU = dtGetAll();
   Change_dt_YC_DM_TRANG_THAI_YEU_CAU = true && AllowAutoChange ;
   }
   return dt_YC_DM_TRANG_THAI_YEU_CAU;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
