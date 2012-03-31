using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class TC_PHIEU_THU:  SQLConnectWeb { 
 public static string sTableName= "TC_PHIEU_THU"; 
   public string PT_ID;
   public string MA_PT;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string NGUOI_THU;
   public string NGAY_THU;
   public string TONG_TIEN;
   public string CHUNG_TU_GOC;
   public string NOI_DUNG_THU;
   public string DU_AN_ID;
   public string DOI_TUONG_THU;
   public string MEM_ID;
   public string YEU_CAU_ID;
   #region DataColumn Name ;
 public static  string cl_PT_ID="PT_ID" ;
 public static  string cl_PT_ID_VN="PT_ID";
 public static  string cl_MA_PT="MA_PT" ;
 public static  string cl_MA_PT_VN="MA_PT";
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGUOI_CAP_NHAT_VN="NGUOI_CAP_NHAT";
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT_VN="NGAY_CAP_NHAT";
 public static  string cl_NGUOI_THU="NGUOI_THU" ;
 public static  string cl_NGUOI_THU_VN="NGUOI_THU";
 public static  string cl_NGAY_THU="NGAY_THU" ;
 public static  string cl_NGAY_THU_VN="NGAY_THU";
 public static  string cl_TONG_TIEN="TONG_TIEN" ;
 public static  string cl_TONG_TIEN_VN="TONG_TIEN";
 public static  string cl_CHUNG_TU_GOC="CHUNG_TU_GOC" ;
 public static  string cl_CHUNG_TU_GOC_VN="CHUNG_TU_GOC";
 public static  string cl_NOI_DUNG_THU="NOI_DUNG_THU" ;
 public static  string cl_NOI_DUNG_THU_VN="NOI_DUNG_THU";
 public static  string cl_DU_AN_ID="DU_AN_ID" ;
 public static  string cl_DU_AN_ID_VN="DU_AN_ID";
 public static  string cl_DOI_TUONG_THU="DOI_TUONG_THU" ;
 public static  string cl_DOI_TUONG_THU_VN="DOI_TUONG_THU";
 public static  string cl_MEM_ID="MEM_ID" ;
 public static  string cl_MEM_ID_VN="MEM_ID";
 public static  string cl_YEU_CAU_ID="YEU_CAU_ID" ;
 public static  string cl_YEU_CAU_ID_VN="YEU_CAU_ID";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public TC_PHIEU_THU() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public TC_PHIEU_THU(
         string sPT_ID,
         string sMA_PT,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sNGUOI_THU,
         string sNGAY_THU,
         string sTONG_TIEN,
         string sCHUNG_TU_GOC,
         string sNOI_DUNG_THU,
         string sDU_AN_ID,
         string sDOI_TUONG_THU,
         string sMEM_ID,
         string sYEU_CAU_ID){
         this.PT_ID= sPT_ID;
         this.MA_PT= sMA_PT;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.NGUOI_THU= sNGUOI_THU;
         this.NGAY_THU= sNGAY_THU;
         this.TONG_TIEN= sTONG_TIEN;
         this.CHUNG_TU_GOC= sCHUNG_TU_GOC;
         this.NOI_DUNG_THU= sNOI_DUNG_THU;
         this.DU_AN_ID= sDU_AN_ID;
         this.DOI_TUONG_THU= sDOI_TUONG_THU;
         this.MEM_ID= sMEM_ID;
         this.YEU_CAU_ID= sYEU_CAU_ID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static TC_PHIEU_THU Create_TC_PHIEU_THU ( string sPT_ID  ){
    DataTable dt=dtSearchByPT_ID(sPT_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new TC_PHIEU_THU(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM TC_PHIEU_THU AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public TC_PHIEU_THU( DataView dv,int pos)
{
         this.PT_ID= dv[pos][0].ToString();
         this.MA_PT= dv[pos][1].ToString();
         this.NGUOI_CAP_NHAT= dv[pos][2].ToString();
         this.NGAY_CAP_NHAT= dv[pos][3].ToString();
         this.NGUOI_THU= dv[pos][4].ToString();
         this.NGAY_THU= dv[pos][5].ToString();
         this.TONG_TIEN= dv[pos][6].ToString();
         this.CHUNG_TU_GOC= dv[pos][7].ToString();
         this.NOI_DUNG_THU= dv[pos][8].ToString();
         this.DU_AN_ID= dv[pos][9].ToString();
         this.DOI_TUONG_THU= dv[pos][10].ToString();
         this.MEM_ID= dv[pos][11].ToString();
         this.YEU_CAU_ID= dv[pos][12].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPT_ID(string sPT_ID)
{
          string sqlSelect= s_Select()+ " WHERE PT_ID  ="+ sPT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPT_ID(string sPT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PT_ID"+ sMatch +sPT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMA_PT(string sMA_PT)
{
          string sqlSelect= s_Select()+ " WHERE MA_PT  Like N'%"+ sMA_PT + "%'"; 
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
 public static DataTable dtSearchByNGUOI_THU(string sNGUOI_THU)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_THU  ="+ sNGUOI_THU + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_THU(string sNGUOI_THU,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_THU"+ sMatch +sNGUOI_THU + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_THU(string sNGAY_THU)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_THU  ="+ sNGAY_THU + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_THU(string sNGAY_THU,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_THU"+ sMatch +sNGAY_THU + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTONG_TIEN(string sTONG_TIEN)
{
          string sqlSelect= s_Select()+ " WHERE TONG_TIEN  ="+ sTONG_TIEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTONG_TIEN(string sTONG_TIEN,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE TONG_TIEN"+ sMatch +sTONG_TIEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCHUNG_TU_GOC(string sCHUNG_TU_GOC)
{
          string sqlSelect= s_Select()+ " WHERE CHUNG_TU_GOC  Like N'%"+ sCHUNG_TU_GOC + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNOI_DUNG_THU(string sNOI_DUNG_THU)
{
          string sqlSelect= s_Select()+ " WHERE NOI_DUNG_THU  Like N'%"+ sNOI_DUNG_THU + "%'"; 
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
 public static DataTable dtSearchByDOI_TUONG_THU(string sDOI_TUONG_THU)
{
          string sqlSelect= s_Select()+ " WHERE DOI_TUONG_THU  Like N'%"+ sDOI_TUONG_THU + "%'"; 
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
 public static DataTable dtSearch( string sPT_ID
            , string sMA_PT
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sNGUOI_THU
            , string sNGAY_THU
            , string sTONG_TIEN
            , string sCHUNG_TU_GOC
            , string sNOI_DUNG_THU
            , string sDU_AN_ID
            , string sDOI_TUONG_THU
            , string sMEM_ID
            , string sYEU_CAU_ID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sPT_ID!=null && sPT_ID!="") 
            sqlselect +=" AND PT_ID =" + sPT_ID ;
      if (sMA_PT!=null && sMA_PT!="") 
            sqlselect +=" AND MA_PT LIKE N'%" + sMA_PT +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT =" + sNGUOI_CAP_NHAT ;
      if (sNGAY_CAP_NHAT!=null && sNGAY_CAP_NHAT!="") 
            sqlselect +=" AND NGAY_CAP_NHAT LIKE '%" + sNGAY_CAP_NHAT +"%'" ;
      if (sNGUOI_THU!=null && sNGUOI_THU!="") 
            sqlselect +=" AND NGUOI_THU =" + sNGUOI_THU ;
      if (sNGAY_THU!=null && sNGAY_THU!="") 
            sqlselect +=" AND NGAY_THU LIKE '%" + sNGAY_THU +"%'" ;
      if (sTONG_TIEN!=null && sTONG_TIEN!="") 
            sqlselect +=" AND TONG_TIEN =" + sTONG_TIEN ;
      if (sCHUNG_TU_GOC!=null && sCHUNG_TU_GOC!="") 
            sqlselect +=" AND CHUNG_TU_GOC LIKE N'%" + sCHUNG_TU_GOC +"%'" ;
      if (sNOI_DUNG_THU!=null && sNOI_DUNG_THU!="") 
            sqlselect +=" AND NOI_DUNG_THU LIKE N'%" + sNOI_DUNG_THU +"%'" ;
      if (sDU_AN_ID!=null && sDU_AN_ID!="") 
            sqlselect +=" AND DU_AN_ID =" + sDU_AN_ID ;
      if (sDOI_TUONG_THU!=null && sDOI_TUONG_THU!="") 
            sqlselect +=" AND DOI_TUONG_THU LIKE N'%" + sDOI_TUONG_THU +"%'" ;
      if (sMEM_ID!=null && sMEM_ID!="") 
            sqlselect +=" AND MEM_ID =" + sMEM_ID ;
      if (sYEU_CAU_ID!=null && sYEU_CAU_ID!="") 
            sqlselect +=" AND YEU_CAU_ID =" + sYEU_CAU_ID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static TC_PHIEU_THU Insert_Object(
string  sMA_PT
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sNGUOI_THU
            ,string  sNGAY_THU
            ,string  sTONG_TIEN
            ,string  sCHUNG_TU_GOC
            ,string  sNOI_DUNG_THU
            ,string  sDU_AN_ID
            ,string  sDOI_TUONG_THU
            ,string  sMEM_ID
            ,string  sYEU_CAU_ID
            ) 
 { 
              string tem_sMA_PT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PT,"nvarchar");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_THU,"bigint");
              string tem_sNGAY_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_THU,"datetime");
              string tem_sTONG_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTONG_TIEN,"float");
              string tem_sCHUNG_TU_GOC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU_GOC,"nvarchar");
              string tem_sNOI_DUNG_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG_THU,"nvarchar");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sDOI_TUONG_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDOI_TUONG_THU,"nvarchar");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sYEU_CAU_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYEU_CAU_ID,"bigint");

             string sqlSave=" INSERT INTO TC_PHIEU_THU("+
                   "MA_PT," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "NGUOI_THU," 
        +                   "NGAY_THU," 
        +                   "TONG_TIEN," 
        +                   "CHUNG_TU_GOC," 
        +                   "NOI_DUNG_THU," 
        +                   "DU_AN_ID," 
        +                   "DOI_TUONG_THU," 
        +                   "MEM_ID," 
        +                   "YEU_CAU_ID) VALUES("
 +tem_sMA_PT+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sNGUOI_THU+","
 +tem_sNGAY_THU+","
 +tem_sTONG_TIEN+","
 +tem_sCHUNG_TU_GOC+","
 +tem_sNOI_DUNG_THU+","
 +tem_sDU_AN_ID+","
 +tem_sDOI_TUONG_THU+","
 +tem_sMEM_ID+","
 +tem_sYEU_CAU_ID +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          TC_PHIEU_THU newTC_PHIEU_THU= new TC_PHIEU_THU();
                 newTC_PHIEU_THU.PT_ID=GetTable( " SELECT TOP 1 PT_ID FROM TC_PHIEU_THU ORDER BY PT_ID DESC ").Rows[0][0].ToString();
              newTC_PHIEU_THU.MA_PT=sMA_PT;
              newTC_PHIEU_THU.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newTC_PHIEU_THU.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newTC_PHIEU_THU.NGUOI_THU=sNGUOI_THU;
              newTC_PHIEU_THU.NGAY_THU=sNGAY_THU;
              newTC_PHIEU_THU.TONG_TIEN=sTONG_TIEN;
              newTC_PHIEU_THU.CHUNG_TU_GOC=sCHUNG_TU_GOC;
              newTC_PHIEU_THU.NOI_DUNG_THU=sNOI_DUNG_THU;
              newTC_PHIEU_THU.DU_AN_ID=sDU_AN_ID;
              newTC_PHIEU_THU.DOI_TUONG_THU=sDOI_TUONG_THU;
              newTC_PHIEU_THU.MEM_ID=sMEM_ID;
              newTC_PHIEU_THU.YEU_CAU_ID=sYEU_CAU_ID;
            return newTC_PHIEU_THU; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sMA_PT
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sNGUOI_THU
                ,string sNGAY_THU
                ,string sTONG_TIEN
                ,string sCHUNG_TU_GOC
                ,string sNOI_DUNG_THU
                ,string sDU_AN_ID
                ,string sDOI_TUONG_THU
                ,string sMEM_ID
                ,string sYEU_CAU_ID
                ) 
 { 
              string tem_sMA_PT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PT,"nvarchar");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_THU,"bigint");
              string tem_sNGAY_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_THU,"datetime");
              string tem_sTONG_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTONG_TIEN,"float");
              string tem_sCHUNG_TU_GOC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU_GOC,"nvarchar");
              string tem_sNOI_DUNG_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG_THU,"nvarchar");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sDOI_TUONG_THU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDOI_TUONG_THU,"nvarchar");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sYEU_CAU_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYEU_CAU_ID,"bigint");

 string sqlSave=" UPDATE TC_PHIEU_THU SET "+"MA_PT ="+tem_sMA_PT+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"NGUOI_THU ="+tem_sNGUOI_THU+","
 +"NGAY_THU ="+tem_sNGAY_THU+","
 +"TONG_TIEN ="+tem_sTONG_TIEN+","
 +"CHUNG_TU_GOC ="+tem_sCHUNG_TU_GOC+","
 +"NOI_DUNG_THU ="+tem_sNOI_DUNG_THU+","
 +"DU_AN_ID ="+tem_sDU_AN_ID+","
 +"DOI_TUONG_THU ="+tem_sDOI_TUONG_THU+","
 +"MEM_ID ="+tem_sMEM_ID+","
 +"YEU_CAU_ID ="+tem_sYEU_CAU_ID+" WHERE PT_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.PT_ID,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.MA_PT=sMA_PT;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
                this.NGUOI_THU=sNGUOI_THU;
                this.NGAY_THU=sNGAY_THU;
                this.TONG_TIEN=sTONG_TIEN;
                this.CHUNG_TU_GOC=sCHUNG_TU_GOC;
                this.NOI_DUNG_THU=sNOI_DUNG_THU;
                this.DU_AN_ID=sDU_AN_ID;
                this.DOI_TUONG_THU=sDOI_TUONG_THU;
                this.MEM_ID=sMEM_ID;
                this.YEU_CAU_ID=sYEU_CAU_ID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_PT_ID(string sPT_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET PT_ID='"+ sPT_ID+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PT_ID=sPT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MA_PT(string sMA_PT)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET MA_PT='N"+ sMA_PT+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MA_PT=sMA_PT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
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
    string sqlSave= " UPDATE TC_PHIEU_THU SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_THU(string sNGUOI_THU)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET NGUOI_THU='"+ sNGUOI_THU+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGUOI_THU=sNGUOI_THU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_THU(string sNGAY_THU)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET NGAY_THU='"+ sNGAY_THU+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_THU=sNGAY_THU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TONG_TIEN(string sTONG_TIEN)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET TONG_TIEN='"+ sTONG_TIEN+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TONG_TIEN=sTONG_TIEN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CHUNG_TU_GOC(string sCHUNG_TU_GOC)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET CHUNG_TU_GOC='N"+ sCHUNG_TU_GOC+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CHUNG_TU_GOC=sCHUNG_TU_GOC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NOI_DUNG_THU(string sNOI_DUNG_THU)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET NOI_DUNG_THU='N"+ sNOI_DUNG_THU+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NOI_DUNG_THU=sNOI_DUNG_THU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DU_AN_ID(string sDU_AN_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET DU_AN_ID='"+ sDU_AN_ID+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DU_AN_ID=sDU_AN_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DOI_TUONG_THU(string sDOI_TUONG_THU)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET DOI_TUONG_THU='N"+ sDOI_TUONG_THU+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DOI_TUONG_THU=sDOI_TUONG_THU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MEM_ID(string sMEM_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET MEM_ID='"+ sMEM_ID+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MEM_ID=sMEM_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_YEU_CAU_ID(string sYEU_CAU_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_THU SET YEU_CAU_ID='"+ sYEU_CAU_ID+ "' WHERE PT_ID='"+ this.PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.YEU_CAU_ID=sYEU_CAU_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_MA_PT(string sMA_PT,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET MA_PT='N"+sMA_PT+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_THU(string sNGUOI_THU,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET NGUOI_THU='"+sNGUOI_THU+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_THU(string sNGAY_THU,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET NGAY_THU='"+sNGAY_THU+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TONG_TIEN(string sTONG_TIEN,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET TONG_TIEN='"+sTONG_TIEN+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CHUNG_TU_GOC(string sCHUNG_TU_GOC,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET CHUNG_TU_GOC='N"+sCHUNG_TU_GOC+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NOI_DUNG_THU(string sNOI_DUNG_THU,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET NOI_DUNG_THU='N"+sNOI_DUNG_THU+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DU_AN_ID(string sDU_AN_ID,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET DU_AN_ID='"+sDU_AN_ID+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DOI_TUONG_THU(string sDOI_TUONG_THU,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET DOI_TUONG_THU='N"+sDOI_TUONG_THU+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MEM_ID(string sMEM_ID,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET MEM_ID='"+sMEM_ID+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_YEU_CAU_ID(string sYEU_CAU_ID,string s_PT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU SET YEU_CAU_ID='"+sYEU_CAU_ID+"' WHERE PT_ID='"+ s_PT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM TC_PHIEU_THU " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_TC_PHIEU_THU;
   public static bool Change_dt_TC_PHIEU_THU = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_TC_PHIEU_THU()
   {
   if (dt_TC_PHIEU_THU == null || Change_dt_TC_PHIEU_THU == true)
   {
   dt_TC_PHIEU_THU = dtGetAll();
   Change_dt_TC_PHIEU_THU = true && AllowAutoChange ;
   }
   return dt_TC_PHIEU_THU;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
