using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class KH_DM_KHO:  SQLConnectWeb { 
 public static string sTableName= "KH_DM_KHO"; 
   public string ID;
   public string NAME;
   public string DIA_CHI;
   public string DIEN_THOAI;
   public string NGUOI_QUAN_LY;
   public string VISIBLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_NAME="NAME" ;
 public static  string cl_DIA_CHI="DIA_CHI" ;
 public static  string cl_DIEN_THOAI="DIEN_THOAI" ;
 public static  string cl_NGUOI_QUAN_LY="NGUOI_QUAN_LY" ;
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_DM_KHO() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_DM_KHO(
         string sID,
         string sNAME,
         string sDIA_CHI,
         string sDIEN_THOAI,
         string sNGUOI_QUAN_LY,
         string sVISIBLE_BIT){
         this.ID= sID;
         this.NAME= sNAME;
         this.DIA_CHI= sDIA_CHI;
         this.DIEN_THOAI= sDIEN_THOAI;
         this.NGUOI_QUAN_LY= sNGUOI_QUAN_LY;
         this.VISIBLE_BIT= sVISIBLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static KH_DM_KHO Create_KH_DM_KHO ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new KH_DM_KHO(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM KH_DM_KHO AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public KH_DM_KHO( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.NAME= dv[pos][1].ToString();
         this.DIA_CHI= dv[pos][2].ToString();
         this.DIEN_THOAI= dv[pos][3].ToString();
         this.NGUOI_QUAN_LY= dv[pos][4].ToString();
         this.VISIBLE_BIT= dv[pos][5].ToString();
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
 public static DataTable SearchByDIA_CHI(string sDIA_CHI)
{
          string sqlSelect= s_Select()+ " WHERE DIA_CHI  Like N'%"+ sDIA_CHI + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDIEN_THOAI(string sDIEN_THOAI)
{
          string sqlSelect= s_Select()+ " WHERE DIEN_THOAI  Like N'%"+ sDIEN_THOAI + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_QUAN_LY(string sNGUOI_QUAN_LY)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_QUAN_LY  Like N'%"+ sNGUOI_QUAN_LY + "%'"; 
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
            , string sDIA_CHI
            , string sDIEN_THOAI
            , string sNGUOI_QUAN_LY
            , string sVISIBLE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sDIA_CHI!=null && sDIA_CHI!="") 
            sqlselect +=" AND DIA_CHI LIKE N'%" + sDIA_CHI +"%'" ;
      if (sDIEN_THOAI!=null && sDIEN_THOAI!="") 
            sqlselect +=" AND DIEN_THOAI LIKE N'%" + sDIEN_THOAI +"%'" ;
      if (sNGUOI_QUAN_LY!=null && sNGUOI_QUAN_LY!="") 
            sqlselect +=" AND NGUOI_QUAN_LY LIKE N'%" + sNGUOI_QUAN_LY +"%'" ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static KH_DM_KHO Insert_Object(
string  sNAME
            ,string  sDIA_CHI
            ,string  sDIEN_THOAI
            ,string  sNGUOI_QUAN_LY
            ,string  sVISIBLE_BIT
            ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sDIA_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDIA_CHI,"nvarchar");
              string tem_sDIEN_THOAI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDIEN_THOAI,"nvarchar");
              string tem_sNGUOI_QUAN_LY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_QUAN_LY,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

             string sqlSave=" INSERT INTO KH_DM_KHO("+
                   "NAME," 
        +                   "DIA_CHI," 
        +                   "DIEN_THOAI," 
        +                   "NGUOI_QUAN_LY," 
        +                   "VISIBLE_BIT) VALUES("
 +tem_sNAME+","
 +tem_sDIA_CHI+","
 +tem_sDIEN_THOAI+","
 +tem_sNGUOI_QUAN_LY+","
 +tem_sVISIBLE_BIT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          KH_DM_KHO newKH_DM_KHO= new KH_DM_KHO();
                 newKH_DM_KHO.ID=GetTable( " SELECT TOP 1 ID FROM KH_DM_KHO ORDER BY ID DESC ").Rows[0][0].ToString();
              newKH_DM_KHO.NAME=sNAME;
              newKH_DM_KHO.DIA_CHI=sDIA_CHI;
              newKH_DM_KHO.DIEN_THOAI=sDIEN_THOAI;
              newKH_DM_KHO.NGUOI_QUAN_LY=sNGUOI_QUAN_LY;
              newKH_DM_KHO.VISIBLE_BIT=sVISIBLE_BIT;
            return newKH_DM_KHO; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sNAME
                ,string sDIA_CHI
                ,string sDIEN_THOAI
                ,string sNGUOI_QUAN_LY
                ,string sVISIBLE_BIT
                ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sDIA_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDIA_CHI,"nvarchar");
              string tem_sDIEN_THOAI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDIEN_THOAI,"nvarchar");
              string tem_sNGUOI_QUAN_LY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_QUAN_LY,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

 string sqlSave=" UPDATE KH_DM_KHO SET "+"NAME ="+tem_sNAME+","
 +"DIA_CHI ="+tem_sDIA_CHI+","
 +"DIEN_THOAI ="+tem_sDIEN_THOAI+","
 +"NGUOI_QUAN_LY ="+tem_sNGUOI_QUAN_LY+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.NAME=sNAME;
                this.DIA_CHI=sDIA_CHI;
                this.DIEN_THOAI=sDIEN_THOAI;
                this.NGUOI_QUAN_LY=sNGUOI_QUAN_LY;
                this.VISIBLE_BIT=sVISIBLE_BIT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE KH_DM_KHO SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
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
    string sqlSave= " UPDATE KH_DM_KHO SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DIA_CHI(string sDIA_CHI)
{
    string sqlSave= " UPDATE KH_DM_KHO SET DIA_CHI='N"+ sDIA_CHI+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DIA_CHI=sDIA_CHI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DIEN_THOAI(string sDIEN_THOAI)
{
    string sqlSave= " UPDATE KH_DM_KHO SET DIEN_THOAI='N"+ sDIEN_THOAI+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DIEN_THOAI=sDIEN_THOAI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_QUAN_LY(string sNGUOI_QUAN_LY)
{
    string sqlSave= " UPDATE KH_DM_KHO SET NGUOI_QUAN_LY='N"+ sNGUOI_QUAN_LY+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_QUAN_LY=sNGUOI_QUAN_LY;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE KH_DM_KHO SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
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
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE KH_DM_KHO SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DIA_CHI(string sDIA_CHI,string s_ID)
{
  string sqlSave= " UPDATE KH_DM_KHO SET DIA_CHI='N"+sDIA_CHI+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DIEN_THOAI(string sDIEN_THOAI,string s_ID)
{
  string sqlSave= " UPDATE KH_DM_KHO SET DIEN_THOAI='N"+sDIEN_THOAI+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_QUAN_LY(string sNGUOI_QUAN_LY,string s_ID)
{
  string sqlSave= " UPDATE KH_DM_KHO SET NGUOI_QUAN_LY='N"+sNGUOI_QUAN_LY+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE KH_DM_KHO SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM KH_DM_KHO";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "KH_DM_KHO");
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
   private static DataTable dt_KH_DM_KHO;
   public static bool Change_dt_KH_DM_KHO = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_KH_DM_KHO()
   {
   if (dt_KH_DM_KHO == null || Change_dt_KH_DM_KHO == true)
     {
   dt_KH_DM_KHO = GetTableAll();
         Change_dt_KH_DM_KHO = true && AllowAutoChange ;
     }
     return dt_KH_DM_KHO;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
