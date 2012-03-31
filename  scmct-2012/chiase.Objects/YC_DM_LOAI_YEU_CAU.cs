using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class YC_DM_LOAI_YEU_CAU:  SQLConnectWeb { 
 public static string sTableName= "YC_DM_LOAI_YEU_CAU"; 
   public string ID;
   public string TEN_LOAI_YC;
   public string NGUOI_TAO;
   public string NGAY_TAO;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string GHI_CHU;
   public string ENABLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_ID_VN="ID";
 public static  string cl_TEN_LOAI_YC="TEN_LOAI_YC" ;
 public static  string cl_TEN_LOAI_YC_VN="TEN_LOAI_YC";
 public static  string cl_NGUOI_TAO="NGUOI_TAO" ;
 public static  string cl_NGUOI_TAO_VN="NGUOI_TAO";
 public static  string cl_NGAY_TAO="NGAY_TAO" ;
 public static  string cl_NGAY_TAO_VN="NGAY_TAO";
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGUOI_CAP_NHAT_VN="NGUOI_CAP_NHAT";
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT_VN="NGAY_CAP_NHAT";
 public static  string cl_GHI_CHU="GHI_CHU" ;
 public static  string cl_GHI_CHU_VN="GHI_CHU";
 public static  string cl_ENABLE_BIT="ENABLE_BIT" ;
 public static  string cl_ENABLE_BIT_VN="ENABLE_BIT";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public YC_DM_LOAI_YEU_CAU() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public YC_DM_LOAI_YEU_CAU(
         string sID,
         string sTEN_LOAI_YC,
         string sNGUOI_TAO,
         string sNGAY_TAO,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sGHI_CHU,
         string sENABLE_BIT){
         this.ID= sID;
         this.TEN_LOAI_YC= sTEN_LOAI_YC;
         this.NGUOI_TAO= sNGUOI_TAO;
         this.NGAY_TAO= sNGAY_TAO;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.GHI_CHU= sGHI_CHU;
         this.ENABLE_BIT= sENABLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static YC_DM_LOAI_YEU_CAU Create_YC_DM_LOAI_YEU_CAU ( string sID  ){
    DataTable dt=dtSearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new YC_DM_LOAI_YEU_CAU(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM YC_DM_LOAI_YEU_CAU AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public YC_DM_LOAI_YEU_CAU( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.TEN_LOAI_YC= dv[pos][1].ToString();
         this.NGUOI_TAO= dv[pos][2].ToString();
         this.NGAY_TAO= dv[pos][3].ToString();
         this.NGUOI_CAP_NHAT= dv[pos][4].ToString();
         this.NGAY_CAP_NHAT= dv[pos][5].ToString();
         this.GHI_CHU= dv[pos][6].ToString();
         this.ENABLE_BIT= dv[pos][7].ToString();
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
 public static DataTable dtSearchByTEN_LOAI_YC(string sTEN_LOAI_YC)
{
          string sqlSelect= s_Select()+ " WHERE TEN_LOAI_YC  Like N'%"+ sTEN_LOAI_YC + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_TAO(string sNGUOI_TAO)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_TAO  ="+ sNGUOI_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_TAO(string sNGUOI_TAO,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_TAO"+ sMatch +sNGUOI_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_TAO(string sNGAY_TAO)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_TAO  ="+ sNGAY_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_TAO(string sNGAY_TAO,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_TAO"+ sMatch +sNGAY_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CAP_NHAT  ="+ sNGUOI_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CAP_NHAT"+ sMatch +sNGUOI_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_CAP_NHAT(string sNGAY_CAP_NHAT)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CAP_NHAT  ="+ sNGAY_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CAP_NHAT"+ sMatch +sNGAY_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByENABLE_BIT(string sENABLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ENABLE_BIT  Like N'%"+ sENABLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sID
            , string sTEN_LOAI_YC
            , string sNGUOI_TAO
            , string sNGAY_TAO
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sGHI_CHU
            , string sENABLE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sTEN_LOAI_YC!=null && sTEN_LOAI_YC!="") 
            sqlselect +=" AND TEN_LOAI_YC LIKE N'%" + sTEN_LOAI_YC +"%'" ;
      if (sNGUOI_TAO!=null && sNGUOI_TAO!="") 
            sqlselect +=" AND NGUOI_TAO =" + sNGUOI_TAO ;
      if (sNGAY_TAO!=null && sNGAY_TAO!="") 
            sqlselect +=" AND NGAY_TAO LIKE '%" + sNGAY_TAO +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT =" + sNGUOI_CAP_NHAT ;
      if (sNGAY_CAP_NHAT!=null && sNGAY_CAP_NHAT!="") 
            sqlselect +=" AND NGAY_CAP_NHAT LIKE '%" + sNGAY_CAP_NHAT +"%'" ;
      if (sGHI_CHU!=null && sGHI_CHU!="") 
            sqlselect +=" AND GHI_CHU LIKE N'%" + sGHI_CHU +"%'" ;
      if (sENABLE_BIT!=null && sENABLE_BIT!="") 
            sqlselect +=" AND ENABLE_BIT LIKE N'%" + sENABLE_BIT +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static YC_DM_LOAI_YEU_CAU Insert_Object(
string  sTEN_LOAI_YC
            ,string  sNGUOI_TAO
            ,string  sNGAY_TAO
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sGHI_CHU
            ,string  sENABLE_BIT
            ) 
 { 
              string tem_sTEN_LOAI_YC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTEN_LOAI_YC,"nvarchar");
              string tem_sNGUOI_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_TAO,"bigint");
              string tem_sNGAY_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_TAO,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nchar");
              string tem_sENABLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sENABLE_BIT,"nchar");

             string sqlSave=" INSERT INTO YC_DM_LOAI_YEU_CAU("+
                   "TEN_LOAI_YC," 
        +                   "NGUOI_TAO," 
        +                   "NGAY_TAO," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "GHI_CHU," 
        +                   "ENABLE_BIT) VALUES("
 +tem_sTEN_LOAI_YC+","
 +tem_sNGUOI_TAO+","
 +tem_sNGAY_TAO+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sGHI_CHU+","
 +tem_sENABLE_BIT +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          YC_DM_LOAI_YEU_CAU newYC_DM_LOAI_YEU_CAU= new YC_DM_LOAI_YEU_CAU();
                 newYC_DM_LOAI_YEU_CAU.ID=GetTable( " SELECT TOP 1 ID FROM YC_DM_LOAI_YEU_CAU ORDER BY ID DESC ").Rows[0][0].ToString();
              newYC_DM_LOAI_YEU_CAU.TEN_LOAI_YC=sTEN_LOAI_YC;
              newYC_DM_LOAI_YEU_CAU.NGUOI_TAO=sNGUOI_TAO;
              newYC_DM_LOAI_YEU_CAU.NGAY_TAO=sNGAY_TAO;
              newYC_DM_LOAI_YEU_CAU.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newYC_DM_LOAI_YEU_CAU.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newYC_DM_LOAI_YEU_CAU.GHI_CHU=sGHI_CHU;
              newYC_DM_LOAI_YEU_CAU.ENABLE_BIT=sENABLE_BIT;
            return newYC_DM_LOAI_YEU_CAU; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sTEN_LOAI_YC
                ,string sNGUOI_TAO
                ,string sNGAY_TAO
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sGHI_CHU
                ,string sENABLE_BIT
                ) 
 { 
              string tem_sTEN_LOAI_YC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTEN_LOAI_YC,"nvarchar");
              string tem_sNGUOI_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_TAO,"bigint");
              string tem_sNGAY_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_TAO,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nchar");
              string tem_sENABLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sENABLE_BIT,"nchar");

 string sqlSave=" UPDATE YC_DM_LOAI_YEU_CAU SET "+"TEN_LOAI_YC ="+tem_sTEN_LOAI_YC+","
 +"NGUOI_TAO ="+tem_sNGUOI_TAO+","
 +"NGAY_TAO ="+tem_sNGAY_TAO+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"GHI_CHU ="+tem_sGHI_CHU+","
 +"ENABLE_BIT ="+tem_sENABLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.TEN_LOAI_YC=sTEN_LOAI_YC;
                this.NGUOI_TAO=sNGUOI_TAO;
                this.NGAY_TAO=sNGAY_TAO;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
                this.GHI_CHU=sGHI_CHU;
                this.ENABLE_BIT=sENABLE_BIT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TEN_LOAI_YC(string sTEN_LOAI_YC)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET TEN_LOAI_YC='N"+ sTEN_LOAI_YC+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TEN_LOAI_YC=sTEN_LOAI_YC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_TAO(string sNGUOI_TAO)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGUOI_TAO='"+ sNGUOI_TAO+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGUOI_TAO=sNGUOI_TAO;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_TAO(string sNGAY_TAO)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGAY_TAO='"+ sNGAY_TAO+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_TAO=sNGAY_TAO;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.GHI_CHU=sGHI_CHU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ENABLE_BIT(string sENABLE_BIT)
{
    string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET ENABLE_BIT='N"+ sENABLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ENABLE_BIT=sENABLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_TEN_LOAI_YC(string sTEN_LOAI_YC,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET TEN_LOAI_YC='N"+sTEN_LOAI_YC+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_TAO(string sNGUOI_TAO,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGUOI_TAO='"+sNGUOI_TAO+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_TAO(string sNGAY_TAO,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGAY_TAO='"+sNGAY_TAO+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET GHI_CHU='N"+sGHI_CHU+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ENABLE_BIT(string sENABLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE YC_DM_LOAI_YEU_CAU SET ENABLE_BIT='N"+sENABLE_BIT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM YC_DM_LOAI_YEU_CAU " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_YC_DM_LOAI_YEU_CAU;
   public static bool Change_dt_YC_DM_LOAI_YEU_CAU = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_YC_DM_LOAI_YEU_CAU()
   {
   if (dt_YC_DM_LOAI_YEU_CAU == null || Change_dt_YC_DM_LOAI_YEU_CAU == true)
   {
   dt_YC_DM_LOAI_YEU_CAU = dtGetAll();
   Change_dt_YC_DM_LOAI_YEU_CAU = true && AllowAutoChange ;
   }
   return dt_YC_DM_LOAI_YEU_CAU;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
