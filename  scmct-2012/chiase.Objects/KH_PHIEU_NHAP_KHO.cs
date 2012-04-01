using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class KH_PHIEU_NHAP_KHO:  SQLConnectWeb { 
 public static string sTableName= "KH_PHIEU_NHAP_KHO"; 
   public string PNK_ID;
   public string MA_PNK;
   public string NGUOI_NHAP;
   public string NGAY_NHAP;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string MEM_ID;
   public string KHO_ID;
   public string DU_AN_ID;
   public string LY_DO_NHAP_ID;
   public string YEU_CAU_ID;
   public string CHUNG_TU;
   public string GHI_CHU;
   #region DataColumn Name ;
 public static  string cl_PNK_ID="PNK_ID" ;
 public static  string cl_PNK_ID_VN="PNK_ID";
 public static  string cl_MA_PNK="MA_PNK" ;
 public static  string cl_MA_PNK_VN="MA_PNK";
 public static  string cl_NGUOI_NHAP="NGUOI_NHAP" ;
 public static  string cl_NGUOI_NHAP_VN="NGUOI_NHAP";
 public static  string cl_NGAY_NHAP="NGAY_NHAP" ;
 public static  string cl_NGAY_NHAP_VN="NGAY_NHAP";
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGUOI_CAP_NHAT_VN="NGUOI_CAP_NHAT";
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT_VN="NGAY_CAP_NHAT";
 public static  string cl_MEM_ID="MEM_ID" ;
 public static  string cl_MEM_ID_VN="MEM_ID";
 public static  string cl_KHO_ID="KHO_ID" ;
 public static  string cl_KHO_ID_VN="KHO_ID";
 public static  string cl_DU_AN_ID="DU_AN_ID" ;
 public static  string cl_DU_AN_ID_VN="DU_AN_ID";
 public static  string cl_LY_DO_NHAP_ID="LY_DO_NHAP_ID" ;
 public static  string cl_LY_DO_NHAP_ID_VN="LY_DO_NHAP_ID";
 public static  string cl_YEU_CAU_ID="YEU_CAU_ID" ;
 public static  string cl_YEU_CAU_ID_VN="YEU_CAU_ID";
 public static  string cl_CHUNG_TU="CHUNG_TU" ;
 public static  string cl_CHUNG_TU_VN="CHUNG_TU";
 public static  string cl_GHI_CHU="GHI_CHU" ;
 public static  string cl_GHI_CHU_VN="GHI_CHU";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_NHAP_KHO() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_NHAP_KHO(
         string sPNK_ID,
         string sMA_PNK,
         string sNGUOI_NHAP,
         string sNGAY_NHAP,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sMEM_ID,
         string sKHO_ID,
         string sDU_AN_ID,
         string sLY_DO_NHAP_ID,
         string sYEU_CAU_ID,
         string sCHUNG_TU,
         string sGHI_CHU){
         this.PNK_ID= sPNK_ID;
         this.MA_PNK= sMA_PNK;
         this.NGUOI_NHAP= sNGUOI_NHAP;
         this.NGAY_NHAP= sNGAY_NHAP;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.MEM_ID= sMEM_ID;
         this.KHO_ID= sKHO_ID;
         this.DU_AN_ID= sDU_AN_ID;
         this.LY_DO_NHAP_ID= sLY_DO_NHAP_ID;
         this.YEU_CAU_ID= sYEU_CAU_ID;
         this.CHUNG_TU= sCHUNG_TU;
         this.GHI_CHU= sGHI_CHU;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static KH_PHIEU_NHAP_KHO Create_KH_PHIEU_NHAP_KHO ( string sPNK_ID  ){
    DataTable dt=dtSearchByPNK_ID(sPNK_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new KH_PHIEU_NHAP_KHO(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM KH_PHIEU_NHAP_KHO AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public KH_PHIEU_NHAP_KHO( DataView dv,int pos)
{
         this.PNK_ID= dv[pos][0].ToString();
         this.MA_PNK= dv[pos][1].ToString();
         this.NGUOI_NHAP= dv[pos][2].ToString();
         this.NGAY_NHAP= dv[pos][3].ToString();
         this.NGUOI_CAP_NHAT= dv[pos][4].ToString();
         this.NGAY_CAP_NHAT= dv[pos][5].ToString();
         this.MEM_ID= dv[pos][6].ToString();
         this.KHO_ID= dv[pos][7].ToString();
         this.DU_AN_ID= dv[pos][8].ToString();
         this.LY_DO_NHAP_ID= dv[pos][9].ToString();
         this.YEU_CAU_ID= dv[pos][10].ToString();
         this.CHUNG_TU= dv[pos][11].ToString();
         this.GHI_CHU= dv[pos][12].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPNK_ID(string sPNK_ID)
{
          string sqlSelect= s_Select()+ " WHERE PNK_ID  ="+ sPNK_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPNK_ID(string sPNK_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PNK_ID"+ sMatch +sPNK_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMA_PNK(string sMA_PNK)
{
          string sqlSelect= s_Select()+ " WHERE MA_PNK  Like N'%"+ sMA_PNK + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_NHAP(string sNGUOI_NHAP)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_NHAP  ="+ sNGUOI_NHAP + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_NHAP(string sNGUOI_NHAP,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_NHAP"+ sMatch +sNGUOI_NHAP + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_NHAP(string sNGAY_NHAP)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_NHAP  ="+ sNGAY_NHAP + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_NHAP(string sNGAY_NHAP,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_NHAP"+ sMatch +sNGAY_NHAP + ""; 
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
 public static DataTable dtSearchByMEM_ID(string sMEM_ID)
{
          string sqlSelect= s_Select()+ " WHERE MEM_ID  ="+ sMEM_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMEM_ID(string sMEM_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE MEM_ID"+ sMatch +sMEM_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByKHO_ID(string sKHO_ID)
{
          string sqlSelect= s_Select()+ " WHERE KHO_ID  ="+ sKHO_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByKHO_ID(string sKHO_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE KHO_ID"+ sMatch +sKHO_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDU_AN_ID(string sDU_AN_ID)
{
          string sqlSelect= s_Select()+ " WHERE DU_AN_ID  ="+ sDU_AN_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDU_AN_ID(string sDU_AN_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DU_AN_ID"+ sMatch +sDU_AN_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLY_DO_NHAP_ID(string sLY_DO_NHAP_ID)
{
          string sqlSelect= s_Select()+ " WHERE LY_DO_NHAP_ID  ="+ sLY_DO_NHAP_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLY_DO_NHAP_ID(string sLY_DO_NHAP_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LY_DO_NHAP_ID"+ sMatch +sLY_DO_NHAP_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByYEU_CAU_ID(string sYEU_CAU_ID)
{
          string sqlSelect= s_Select()+ " WHERE YEU_CAU_ID  ="+ sYEU_CAU_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByYEU_CAU_ID(string sYEU_CAU_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE YEU_CAU_ID"+ sMatch +sYEU_CAU_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCHUNG_TU(string sCHUNG_TU)
{
          string sqlSelect= s_Select()+ " WHERE CHUNG_TU  Like N'%"+ sCHUNG_TU + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sPNK_ID
            , string sMA_PNK
            , string sNGUOI_NHAP
            , string sNGAY_NHAP
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sMEM_ID
            , string sKHO_ID
            , string sDU_AN_ID
            , string sLY_DO_NHAP_ID
            , string sYEU_CAU_ID
            , string sCHUNG_TU
            , string sGHI_CHU
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sPNK_ID!=null && sPNK_ID!="") 
            sqlselect +=" AND PNK_ID =" + sPNK_ID ;
      if (sMA_PNK!=null && sMA_PNK!="") 
            sqlselect +=" AND MA_PNK LIKE N'%" + sMA_PNK +"%'" ;
      if (sNGUOI_NHAP!=null && sNGUOI_NHAP!="") 
            sqlselect +=" AND NGUOI_NHAP =" + sNGUOI_NHAP ;
      if (sNGAY_NHAP!=null && sNGAY_NHAP!="") 
            sqlselect +=" AND NGAY_NHAP LIKE '%" + sNGAY_NHAP +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT =" + sNGUOI_CAP_NHAT ;
      if (sNGAY_CAP_NHAT!=null && sNGAY_CAP_NHAT!="") 
            sqlselect +=" AND NGAY_CAP_NHAT LIKE '%" + sNGAY_CAP_NHAT +"%'" ;
      if (sMEM_ID!=null && sMEM_ID!="") 
            sqlselect +=" AND MEM_ID =" + sMEM_ID ;
      if (sKHO_ID!=null && sKHO_ID!="") 
            sqlselect +=" AND KHO_ID =" + sKHO_ID ;
      if (sDU_AN_ID!=null && sDU_AN_ID!="") 
            sqlselect +=" AND DU_AN_ID =" + sDU_AN_ID ;
      if (sLY_DO_NHAP_ID!=null && sLY_DO_NHAP_ID!="") 
            sqlselect +=" AND LY_DO_NHAP_ID =" + sLY_DO_NHAP_ID ;
      if (sYEU_CAU_ID!=null && sYEU_CAU_ID!="") 
            sqlselect +=" AND YEU_CAU_ID =" + sYEU_CAU_ID ;
      if (sCHUNG_TU!=null && sCHUNG_TU!="") 
            sqlselect +=" AND CHUNG_TU LIKE N'%" + sCHUNG_TU +"%'" ;
      if (sGHI_CHU!=null && sGHI_CHU!="") 
            sqlselect +=" AND GHI_CHU LIKE N'%" + sGHI_CHU +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static KH_PHIEU_NHAP_KHO Insert_Object(
string  sMA_PNK
            ,string  sNGUOI_NHAP
            ,string  sNGAY_NHAP
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sMEM_ID
            ,string  sKHO_ID
            ,string  sDU_AN_ID
            ,string  sLY_DO_NHAP_ID
            ,string  sYEU_CAU_ID
            ,string  sCHUNG_TU
            ,string  sGHI_CHU
            ) 
 { 
              string tem_sMA_PNK=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PNK,"varchar");
              string tem_sNGUOI_NHAP=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_NHAP,"bigint");
              string tem_sNGAY_NHAP=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_NHAP,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sKHO_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sLY_DO_NHAP_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLY_DO_NHAP_ID,"bigint");
              string tem_sYEU_CAU_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYEU_CAU_ID,"bigint");
              string tem_sCHUNG_TU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU,"nvarchar");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

             string sqlSave=" INSERT INTO KH_PHIEU_NHAP_KHO("+
                   "MA_PNK," 
        +                   "NGUOI_NHAP," 
        +                   "NGAY_NHAP," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "MEM_ID," 
        +                   "KHO_ID," 
        +                   "DU_AN_ID," 
        +                   "LY_DO_NHAP_ID," 
        +                   "YEU_CAU_ID," 
        +                   "CHUNG_TU," 
        +                   "GHI_CHU) VALUES("
 +tem_sMA_PNK+","
 +tem_sNGUOI_NHAP+","
 +tem_sNGAY_NHAP+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sMEM_ID+","
 +tem_sKHO_ID+","
 +tem_sDU_AN_ID+","
 +tem_sLY_DO_NHAP_ID+","
 +tem_sYEU_CAU_ID+","
 +tem_sCHUNG_TU+","
 +tem_sGHI_CHU +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          KH_PHIEU_NHAP_KHO newKH_PHIEU_NHAP_KHO= new KH_PHIEU_NHAP_KHO();
                 newKH_PHIEU_NHAP_KHO.PNK_ID=GetTable( " SELECT TOP 1 PNK_ID FROM KH_PHIEU_NHAP_KHO ORDER BY PNK_ID DESC ").Rows[0][0].ToString();
              newKH_PHIEU_NHAP_KHO.MA_PNK=sMA_PNK;
              newKH_PHIEU_NHAP_KHO.NGUOI_NHAP=sNGUOI_NHAP;
              newKH_PHIEU_NHAP_KHO.NGAY_NHAP=sNGAY_NHAP;
              newKH_PHIEU_NHAP_KHO.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newKH_PHIEU_NHAP_KHO.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newKH_PHIEU_NHAP_KHO.MEM_ID=sMEM_ID;
              newKH_PHIEU_NHAP_KHO.KHO_ID=sKHO_ID;
              newKH_PHIEU_NHAP_KHO.DU_AN_ID=sDU_AN_ID;
              newKH_PHIEU_NHAP_KHO.LY_DO_NHAP_ID=sLY_DO_NHAP_ID;
              newKH_PHIEU_NHAP_KHO.YEU_CAU_ID=sYEU_CAU_ID;
              newKH_PHIEU_NHAP_KHO.CHUNG_TU=sCHUNG_TU;
              newKH_PHIEU_NHAP_KHO.GHI_CHU=sGHI_CHU;
            return newKH_PHIEU_NHAP_KHO; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sMA_PNK
                ,string sNGUOI_NHAP
                ,string sNGAY_NHAP
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sMEM_ID
                ,string sKHO_ID
                ,string sDU_AN_ID
                ,string sLY_DO_NHAP_ID
                ,string sYEU_CAU_ID
                ,string sCHUNG_TU
                ,string sGHI_CHU
                ) 
 { 
              string tem_sMA_PNK=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PNK,"varchar");
              string tem_sNGUOI_NHAP=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_NHAP,"bigint");
              string tem_sNGAY_NHAP=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_NHAP,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sKHO_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sLY_DO_NHAP_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLY_DO_NHAP_ID,"bigint");
              string tem_sYEU_CAU_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYEU_CAU_ID,"bigint");
              string tem_sCHUNG_TU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU,"nvarchar");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

 string sqlSave=" UPDATE KH_PHIEU_NHAP_KHO SET "+"MA_PNK ="+tem_sMA_PNK+","
 +"NGUOI_NHAP ="+tem_sNGUOI_NHAP+","
 +"NGAY_NHAP ="+tem_sNGAY_NHAP+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"MEM_ID ="+tem_sMEM_ID+","
 +"KHO_ID ="+tem_sKHO_ID+","
 +"DU_AN_ID ="+tem_sDU_AN_ID+","
 +"LY_DO_NHAP_ID ="+tem_sLY_DO_NHAP_ID+","
 +"YEU_CAU_ID ="+tem_sYEU_CAU_ID+","
 +"CHUNG_TU ="+tem_sCHUNG_TU+","
 +"GHI_CHU ="+tem_sGHI_CHU+" WHERE PNK_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.PNK_ID,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.MA_PNK=sMA_PNK;
                this.NGUOI_NHAP=sNGUOI_NHAP;
                this.NGAY_NHAP=sNGAY_NHAP;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
                this.MEM_ID=sMEM_ID;
                this.KHO_ID=sKHO_ID;
                this.DU_AN_ID=sDU_AN_ID;
                this.LY_DO_NHAP_ID=sLY_DO_NHAP_ID;
                this.YEU_CAU_ID=sYEU_CAU_ID;
                this.CHUNG_TU=sCHUNG_TU;
                this.GHI_CHU=sGHI_CHU;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_PNK_ID(string sPNK_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET PNK_ID='"+ sPNK_ID+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PNK_ID=sPNK_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MA_PNK(string sMA_PNK)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET MA_PNK='N"+ sMA_PNK+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MA_PNK=sMA_PNK;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_NHAP(string sNGUOI_NHAP)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGUOI_NHAP='"+ sNGUOI_NHAP+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGUOI_NHAP=sNGUOI_NHAP;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_NHAP(string sNGAY_NHAP)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGAY_NHAP='"+ sNGAY_NHAP+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_NHAP=sNGAY_NHAP;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
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
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MEM_ID(string sMEM_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET MEM_ID='"+ sMEM_ID+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MEM_ID=sMEM_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_KHO_ID(string sKHO_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET KHO_ID='"+ sKHO_ID+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.KHO_ID=sKHO_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DU_AN_ID(string sDU_AN_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET DU_AN_ID='"+ sDU_AN_ID+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DU_AN_ID=sDU_AN_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LY_DO_NHAP_ID(string sLY_DO_NHAP_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET LY_DO_NHAP_ID='"+ sLY_DO_NHAP_ID+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.LY_DO_NHAP_ID=sLY_DO_NHAP_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_YEU_CAU_ID(string sYEU_CAU_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET YEU_CAU_ID='"+ sYEU_CAU_ID+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.YEU_CAU_ID=sYEU_CAU_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CHUNG_TU(string sCHUNG_TU)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET CHUNG_TU='N"+ sCHUNG_TU+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CHUNG_TU=sCHUNG_TU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE PNK_ID='"+ this.PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.GHI_CHU=sGHI_CHU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_MA_PNK(string sMA_PNK,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET MA_PNK='N"+sMA_PNK+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_NHAP(string sNGUOI_NHAP,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGUOI_NHAP='"+sNGUOI_NHAP+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_NHAP(string sNGAY_NHAP,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGAY_NHAP='"+sNGAY_NHAP+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MEM_ID(string sMEM_ID,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET MEM_ID='"+sMEM_ID+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_KHO_ID(string sKHO_ID,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET KHO_ID='"+sKHO_ID+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DU_AN_ID(string sDU_AN_ID,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET DU_AN_ID='"+sDU_AN_ID+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LY_DO_NHAP_ID(string sLY_DO_NHAP_ID,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET LY_DO_NHAP_ID='"+sLY_DO_NHAP_ID+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_YEU_CAU_ID(string sYEU_CAU_ID,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET YEU_CAU_ID='"+sYEU_CAU_ID+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CHUNG_TU(string sCHUNG_TU,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET CHUNG_TU='N"+sCHUNG_TU+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_PNK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_NHAP_KHO SET GHI_CHU='N"+sGHI_CHU+"' WHERE PNK_ID='"+ s_PNK_ID+"' ";
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
   string sqlSelect = " SELECT * FROM KH_PHIEU_NHAP_KHO";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "KH_PHIEU_NHAP_KHO");
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
   private static DataTable dt_KH_PHIEU_NHAP_KHO;
   public static bool Change_dt_KH_PHIEU_NHAP_KHO = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_KH_PHIEU_NHAP_KHO()
   {
   if (dt_KH_PHIEU_NHAP_KHO == null || Change_dt_KH_PHIEU_NHAP_KHO == true)
     {
   dt_KH_PHIEU_NHAP_KHO = dtGetTableAll();
         Change_dt_KH_PHIEU_NHAP_KHO = true && AllowAutoChange ;
     }
     return dt_KH_PHIEU_NHAP_KHO;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
