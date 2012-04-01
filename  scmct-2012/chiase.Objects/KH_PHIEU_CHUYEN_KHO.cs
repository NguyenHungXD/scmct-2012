using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class KH_PHIEU_CHUYEN_KHO:  SQLConnectWeb { 
 public static string sTableName= "KH_PHIEU_CHUYEN_KHO"; 
   public string PCK_ID;
   public string MA_PCK;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string NGUOI_CHUYEN;
   public string NGAY_CHUYEN;
   public string KHO_XUAT_ID;
   public string KHO_NHAP_ID;
   public string DU_AN_ID;
   public string GHI_CHU;
   #region DataColumn Name ;
 public static  string cl_PCK_ID="PCK_ID" ;
 public static  string cl_MA_PCK="MA_PCK" ;
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_NGUOI_CHUYEN="NGUOI_CHUYEN" ;
 public static  string cl_NGAY_CHUYEN="NGAY_CHUYEN" ;
 public static  string cl_KHO_XUAT_ID="KHO_XUAT_ID" ;
 public static  string cl_KHO_NHAP_ID="KHO_NHAP_ID" ;
 public static  string cl_DU_AN_ID="DU_AN_ID" ;
 public static  string cl_GHI_CHU="GHI_CHU" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_CHUYEN_KHO() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_CHUYEN_KHO(
         string sPCK_ID,
         string sMA_PCK,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sNGUOI_CHUYEN,
         string sNGAY_CHUYEN,
         string sKHO_XUAT_ID,
         string sKHO_NHAP_ID,
         string sDU_AN_ID,
         string sGHI_CHU){
         this.PCK_ID= sPCK_ID;
         this.MA_PCK= sMA_PCK;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.NGUOI_CHUYEN= sNGUOI_CHUYEN;
         this.NGAY_CHUYEN= sNGAY_CHUYEN;
         this.KHO_XUAT_ID= sKHO_XUAT_ID;
         this.KHO_NHAP_ID= sKHO_NHAP_ID;
         this.DU_AN_ID= sDU_AN_ID;
         this.GHI_CHU= sGHI_CHU;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static KH_PHIEU_CHUYEN_KHO Create_KH_PHIEU_CHUYEN_KHO ( string sPCK_ID  ){
    DataTable dt=SearchByPCK_ID(sPCK_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new KH_PHIEU_CHUYEN_KHO(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM KH_PHIEU_CHUYEN_KHO AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public KH_PHIEU_CHUYEN_KHO( DataView dv,int pos)
{
         this.PCK_ID= dv[pos][0].ToString();
         this.MA_PCK= dv[pos][1].ToString();
         this.NGUOI_CAP_NHAT= dv[pos][2].ToString();
         this.NGAY_CAP_NHAT= dv[pos][3].ToString();
         this.NGUOI_CHUYEN= dv[pos][4].ToString();
         this.NGAY_CHUYEN= dv[pos][5].ToString();
         this.KHO_XUAT_ID= dv[pos][6].ToString();
         this.KHO_NHAP_ID= dv[pos][7].ToString();
         this.DU_AN_ID= dv[pos][8].ToString();
         this.GHI_CHU= dv[pos][9].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPCK_ID(string sPCK_ID)
{
          string sqlSelect= s_Select()+ " WHERE PCK_ID  ="+ sPCK_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPCK_ID(string sPCK_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PCK_ID"+ sMatch +sPCK_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMA_PCK(string sMA_PCK)
{
          string sqlSelect= s_Select()+ " WHERE MA_PCK  Like N'%"+ sMA_PCK + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CAP_NHAT  ="+ sNGUOI_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CAP_NHAT"+ sMatch +sNGUOI_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_CAP_NHAT(string sNGAY_CAP_NHAT)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CAP_NHAT  ="+ sNGAY_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CAP_NHAT"+ sMatch +sNGAY_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_CHUYEN(string sNGUOI_CHUYEN)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CHUYEN  ="+ sNGUOI_CHUYEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_CHUYEN(string sNGUOI_CHUYEN,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CHUYEN"+ sMatch +sNGUOI_CHUYEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_CHUYEN(string sNGAY_CHUYEN)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CHUYEN  ="+ sNGAY_CHUYEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_CHUYEN(string sNGAY_CHUYEN,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CHUYEN"+ sMatch +sNGAY_CHUYEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByKHO_XUAT_ID(string sKHO_XUAT_ID)
{
          string sqlSelect= s_Select()+ " WHERE KHO_XUAT_ID  ="+ sKHO_XUAT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByKHO_XUAT_ID(string sKHO_XUAT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE KHO_XUAT_ID"+ sMatch +sKHO_XUAT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByKHO_NHAP_ID(string sKHO_NHAP_ID)
{
          string sqlSelect= s_Select()+ " WHERE KHO_NHAP_ID  ="+ sKHO_NHAP_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByKHO_NHAP_ID(string sKHO_NHAP_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE KHO_NHAP_ID"+ sMatch +sKHO_NHAP_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDU_AN_ID(string sDU_AN_ID)
{
          string sqlSelect= s_Select()+ " WHERE DU_AN_ID  ="+ sDU_AN_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDU_AN_ID(string sDU_AN_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DU_AN_ID"+ sMatch +sDU_AN_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sPCK_ID
            , string sMA_PCK
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sNGUOI_CHUYEN
            , string sNGAY_CHUYEN
            , string sKHO_XUAT_ID
            , string sKHO_NHAP_ID
            , string sDU_AN_ID
            , string sGHI_CHU
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sPCK_ID!=null && sPCK_ID!="") 
            sqlselect +=" AND PCK_ID =" + sPCK_ID ;
      if (sMA_PCK!=null && sMA_PCK!="") 
            sqlselect +=" AND MA_PCK LIKE N'%" + sMA_PCK +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT =" + sNGUOI_CAP_NHAT ;
      if (sNGAY_CAP_NHAT!=null && sNGAY_CAP_NHAT!="") 
            sqlselect +=" AND NGAY_CAP_NHAT LIKE '%" + sNGAY_CAP_NHAT +"%'" ;
      if (sNGUOI_CHUYEN!=null && sNGUOI_CHUYEN!="") 
            sqlselect +=" AND NGUOI_CHUYEN =" + sNGUOI_CHUYEN ;
      if (sNGAY_CHUYEN!=null && sNGAY_CHUYEN!="") 
            sqlselect +=" AND NGAY_CHUYEN LIKE '%" + sNGAY_CHUYEN +"%'" ;
      if (sKHO_XUAT_ID!=null && sKHO_XUAT_ID!="") 
            sqlselect +=" AND KHO_XUAT_ID =" + sKHO_XUAT_ID ;
      if (sKHO_NHAP_ID!=null && sKHO_NHAP_ID!="") 
            sqlselect +=" AND KHO_NHAP_ID =" + sKHO_NHAP_ID ;
      if (sDU_AN_ID!=null && sDU_AN_ID!="") 
            sqlselect +=" AND DU_AN_ID =" + sDU_AN_ID ;
      if (sGHI_CHU!=null && sGHI_CHU!="") 
            sqlselect +=" AND GHI_CHU LIKE N'%" + sGHI_CHU +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static KH_PHIEU_CHUYEN_KHO Insert_Object(
string  sMA_PCK
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sNGUOI_CHUYEN
            ,string  sNGAY_CHUYEN
            ,string  sKHO_XUAT_ID
            ,string  sKHO_NHAP_ID
            ,string  sDU_AN_ID
            ,string  sGHI_CHU
            ) 
 { 
              string tem_sMA_PCK=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PCK,"nvarchar");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_CHUYEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CHUYEN,"bigint");
              string tem_sNGAY_CHUYEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CHUYEN,"datetime");
              string tem_sKHO_XUAT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_XUAT_ID,"bigint");
              string tem_sKHO_NHAP_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_NHAP_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

             string sqlSave=" INSERT INTO KH_PHIEU_CHUYEN_KHO("+
                   "MA_PCK," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "NGUOI_CHUYEN," 
        +                   "NGAY_CHUYEN," 
        +                   "KHO_XUAT_ID," 
        +                   "KHO_NHAP_ID," 
        +                   "DU_AN_ID," 
        +                   "GHI_CHU) VALUES("
 +tem_sMA_PCK+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sNGUOI_CHUYEN+","
 +tem_sNGAY_CHUYEN+","
 +tem_sKHO_XUAT_ID+","
 +tem_sKHO_NHAP_ID+","
 +tem_sDU_AN_ID+","
 +tem_sGHI_CHU +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          KH_PHIEU_CHUYEN_KHO newKH_PHIEU_CHUYEN_KHO= new KH_PHIEU_CHUYEN_KHO();
                 newKH_PHIEU_CHUYEN_KHO.PCK_ID=GetTable( " SELECT TOP 1 PCK_ID FROM KH_PHIEU_CHUYEN_KHO ORDER BY PCK_ID DESC ").Rows[0][0].ToString();
              newKH_PHIEU_CHUYEN_KHO.MA_PCK=sMA_PCK;
              newKH_PHIEU_CHUYEN_KHO.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newKH_PHIEU_CHUYEN_KHO.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newKH_PHIEU_CHUYEN_KHO.NGUOI_CHUYEN=sNGUOI_CHUYEN;
              newKH_PHIEU_CHUYEN_KHO.NGAY_CHUYEN=sNGAY_CHUYEN;
              newKH_PHIEU_CHUYEN_KHO.KHO_XUAT_ID=sKHO_XUAT_ID;
              newKH_PHIEU_CHUYEN_KHO.KHO_NHAP_ID=sKHO_NHAP_ID;
              newKH_PHIEU_CHUYEN_KHO.DU_AN_ID=sDU_AN_ID;
              newKH_PHIEU_CHUYEN_KHO.GHI_CHU=sGHI_CHU;
            return newKH_PHIEU_CHUYEN_KHO; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sMA_PCK
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sNGUOI_CHUYEN
                ,string sNGAY_CHUYEN
                ,string sKHO_XUAT_ID
                ,string sKHO_NHAP_ID
                ,string sDU_AN_ID
                ,string sGHI_CHU
                ) 
 { 
              string tem_sMA_PCK=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PCK,"nvarchar");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_CHUYEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CHUYEN,"bigint");
              string tem_sNGAY_CHUYEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CHUYEN,"datetime");
              string tem_sKHO_XUAT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_XUAT_ID,"bigint");
              string tem_sKHO_NHAP_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_NHAP_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

 string sqlSave=" UPDATE KH_PHIEU_CHUYEN_KHO SET "+"MA_PCK ="+tem_sMA_PCK+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"NGUOI_CHUYEN ="+tem_sNGUOI_CHUYEN+","
 +"NGAY_CHUYEN ="+tem_sNGAY_CHUYEN+","
 +"KHO_XUAT_ID ="+tem_sKHO_XUAT_ID+","
 +"KHO_NHAP_ID ="+tem_sKHO_NHAP_ID+","
 +"DU_AN_ID ="+tem_sDU_AN_ID+","
 +"GHI_CHU ="+tem_sGHI_CHU+" WHERE PCK_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.PCK_ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.MA_PCK=sMA_PCK;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
                this.NGUOI_CHUYEN=sNGUOI_CHUYEN;
                this.NGAY_CHUYEN=sNGAY_CHUYEN;
                this.KHO_XUAT_ID=sKHO_XUAT_ID;
                this.KHO_NHAP_ID=sKHO_NHAP_ID;
                this.DU_AN_ID=sDU_AN_ID;
                this.GHI_CHU=sGHI_CHU;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_PCK_ID(string sPCK_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET PCK_ID='"+ sPCK_ID+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PCK_ID=sPCK_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MA_PCK(string sMA_PCK)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET MA_PCK='N"+ sMA_PCK+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MA_PCK=sMA_PCK;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CHUYEN(string sNGUOI_CHUYEN)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGUOI_CHUYEN='"+ sNGUOI_CHUYEN+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_CHUYEN=sNGUOI_CHUYEN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_CHUYEN(string sNGAY_CHUYEN)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGAY_CHUYEN='"+ sNGAY_CHUYEN+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_CHUYEN=sNGAY_CHUYEN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_KHO_XUAT_ID(string sKHO_XUAT_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET KHO_XUAT_ID='"+ sKHO_XUAT_ID+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.KHO_XUAT_ID=sKHO_XUAT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_KHO_NHAP_ID(string sKHO_NHAP_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET KHO_NHAP_ID='"+ sKHO_NHAP_ID+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.KHO_NHAP_ID=sKHO_NHAP_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DU_AN_ID(string sDU_AN_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET DU_AN_ID='"+ sDU_AN_ID+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DU_AN_ID=sDU_AN_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE PCK_ID='"+ this.PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.GHI_CHU=sGHI_CHU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_MA_PCK(string sMA_PCK,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET MA_PCK='N"+sMA_PCK+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CHUYEN(string sNGUOI_CHUYEN,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGUOI_CHUYEN='"+sNGUOI_CHUYEN+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CHUYEN(string sNGAY_CHUYEN,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET NGAY_CHUYEN='"+sNGAY_CHUYEN+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_KHO_XUAT_ID(string sKHO_XUAT_ID,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET KHO_XUAT_ID='"+sKHO_XUAT_ID+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_KHO_NHAP_ID(string sKHO_NHAP_ID,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET KHO_NHAP_ID='"+sKHO_NHAP_ID+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DU_AN_ID(string sDU_AN_ID,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET DU_AN_ID='"+sDU_AN_ID+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_PCK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_CHUYEN_KHO SET GHI_CHU='N"+sGHI_CHU+"' WHERE PCK_ID='"+ s_PCK_ID+"' ";
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
   string sqlSelect = " SELECT * FROM KH_PHIEU_CHUYEN_KHO";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "KH_PHIEU_CHUYEN_KHO");
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
   private static DataTable dt_KH_PHIEU_CHUYEN_KHO;
   public static bool Change_dt_KH_PHIEU_CHUYEN_KHO = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_KH_PHIEU_CHUYEN_KHO()
   {
   if (dt_KH_PHIEU_CHUYEN_KHO == null || Change_dt_KH_PHIEU_CHUYEN_KHO == true)
     {
   dt_KH_PHIEU_CHUYEN_KHO = GetTableAll();
         Change_dt_KH_PHIEU_CHUYEN_KHO = true && AllowAutoChange ;
     }
     return dt_KH_PHIEU_CHUYEN_KHO;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
