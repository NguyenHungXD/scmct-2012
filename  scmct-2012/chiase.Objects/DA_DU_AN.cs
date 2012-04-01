using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class DA_DU_AN:  SQLConnectWeb { 
 public static string sTableName= "DA_DU_AN"; 
   public string ID;
   public string MA_DU_AN;
   public string TEN_DU_AN;
   public string NGAY_TAO;
   public string NGUOI_TAO;
   public string NGAY_BAT_DAU;
   public string NGAY_KET_THUC;
   public string CHI_TIET;
   public string TRANG_THAI_ID;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string GHI_CHU;
   public string ENABLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_MA_DU_AN="MA_DU_AN" ;
 public static  string cl_TEN_DU_AN="TEN_DU_AN" ;
 public static  string cl_NGAY_TAO="NGAY_TAO" ;
 public static  string cl_NGUOI_TAO="NGUOI_TAO" ;
 public static  string cl_NGAY_BAT_DAU="NGAY_BAT_DAU" ;
 public static  string cl_NGAY_KET_THUC="NGAY_KET_THUC" ;
 public static  string cl_CHI_TIET="CHI_TIET" ;
 public static  string cl_TRANG_THAI_ID="TRANG_THAI_ID" ;
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_GHI_CHU="GHI_CHU" ;
 public static  string cl_ENABLE_BIT="ENABLE_BIT" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public DA_DU_AN() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public DA_DU_AN(
         string sID,
         string sMA_DU_AN,
         string sTEN_DU_AN,
         string sNGAY_TAO,
         string sNGUOI_TAO,
         string sNGAY_BAT_DAU,
         string sNGAY_KET_THUC,
         string sCHI_TIET,
         string sTRANG_THAI_ID,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sGHI_CHU,
         string sENABLE_BIT){
         this.ID= sID;
         this.MA_DU_AN= sMA_DU_AN;
         this.TEN_DU_AN= sTEN_DU_AN;
         this.NGAY_TAO= sNGAY_TAO;
         this.NGUOI_TAO= sNGUOI_TAO;
         this.NGAY_BAT_DAU= sNGAY_BAT_DAU;
         this.NGAY_KET_THUC= sNGAY_KET_THUC;
         this.CHI_TIET= sCHI_TIET;
         this.TRANG_THAI_ID= sTRANG_THAI_ID;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.GHI_CHU= sGHI_CHU;
         this.ENABLE_BIT= sENABLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static DA_DU_AN Create_DA_DU_AN ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new DA_DU_AN(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM DA_DU_AN AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public DA_DU_AN( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.MA_DU_AN= dv[pos][1].ToString();
         this.TEN_DU_AN= dv[pos][2].ToString();
         this.NGAY_TAO= dv[pos][3].ToString();
         this.NGUOI_TAO= dv[pos][4].ToString();
         this.NGAY_BAT_DAU= dv[pos][5].ToString();
         this.NGAY_KET_THUC= dv[pos][6].ToString();
         this.CHI_TIET= dv[pos][7].ToString();
         this.TRANG_THAI_ID= dv[pos][8].ToString();
         this.NGUOI_CAP_NHAT= dv[pos][9].ToString();
         this.NGAY_CAP_NHAT= dv[pos][10].ToString();
         this.GHI_CHU= dv[pos][11].ToString();
         this.ENABLE_BIT= dv[pos][12].ToString();
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
 public static DataTable SearchByMA_DU_AN(string sMA_DU_AN)
{
          string sqlSelect= s_Select()+ " WHERE MA_DU_AN  Like N'%"+ sMA_DU_AN + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTEN_DU_AN(string sTEN_DU_AN)
{
          string sqlSelect= s_Select()+ " WHERE TEN_DU_AN  Like N'%"+ sTEN_DU_AN + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_TAO(string sNGAY_TAO)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_TAO  ="+ sNGAY_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_TAO(string sNGAY_TAO,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_TAO"+ sMatch +sNGAY_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_TAO(string sNGUOI_TAO)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_TAO  ="+ sNGUOI_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_TAO(string sNGUOI_TAO,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_TAO"+ sMatch +sNGUOI_TAO + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_BAT_DAU(string sNGAY_BAT_DAU)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_BAT_DAU  ="+ sNGAY_BAT_DAU + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_BAT_DAU(string sNGAY_BAT_DAU,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_BAT_DAU"+ sMatch +sNGAY_BAT_DAU + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_KET_THUC(string sNGAY_KET_THUC)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_KET_THUC  ="+ sNGAY_KET_THUC + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_KET_THUC(string sNGAY_KET_THUC,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_KET_THUC"+ sMatch +sNGAY_KET_THUC + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCHI_TIET(string sCHI_TIET)
{
          string sqlSelect= s_Select()+ " WHERE CHI_TIET  Like N'%"+ sCHI_TIET + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTRANG_THAI_ID(string sTRANG_THAI_ID)
{
          string sqlSelect= s_Select()+ " WHERE TRANG_THAI_ID  ="+ sTRANG_THAI_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTRANG_THAI_ID(string sTRANG_THAI_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE TRANG_THAI_ID"+ sMatch +sTRANG_THAI_ID + ""; 
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
 public static DataTable SearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByENABLE_BIT(string sENABLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ENABLE_BIT  Like N'%"+ sENABLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sID
            , string sMA_DU_AN
            , string sTEN_DU_AN
            , string sNGAY_TAO
            , string sNGUOI_TAO
            , string sNGAY_BAT_DAU
            , string sNGAY_KET_THUC
            , string sCHI_TIET
            , string sTRANG_THAI_ID
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sGHI_CHU
            , string sENABLE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sMA_DU_AN!=null && sMA_DU_AN!="") 
            sqlselect +=" AND MA_DU_AN LIKE N'%" + sMA_DU_AN +"%'" ;
      if (sTEN_DU_AN!=null && sTEN_DU_AN!="") 
            sqlselect +=" AND TEN_DU_AN LIKE N'%" + sTEN_DU_AN +"%'" ;
      if (sNGAY_TAO!=null && sNGAY_TAO!="") 
            sqlselect +=" AND NGAY_TAO LIKE '%" + sNGAY_TAO +"%'" ;
      if (sNGUOI_TAO!=null && sNGUOI_TAO!="") 
            sqlselect +=" AND NGUOI_TAO =" + sNGUOI_TAO ;
      if (sNGAY_BAT_DAU!=null && sNGAY_BAT_DAU!="") 
            sqlselect +=" AND NGAY_BAT_DAU LIKE '%" + sNGAY_BAT_DAU +"%'" ;
      if (sNGAY_KET_THUC!=null && sNGAY_KET_THUC!="") 
            sqlselect +=" AND NGAY_KET_THUC LIKE '%" + sNGAY_KET_THUC +"%'" ;
      if (sCHI_TIET!=null && sCHI_TIET!="") 
            sqlselect +=" AND CHI_TIET LIKE N'%" + sCHI_TIET +"%'" ;
      if (sTRANG_THAI_ID!=null && sTRANG_THAI_ID!="") 
            sqlselect +=" AND TRANG_THAI_ID =" + sTRANG_THAI_ID ;
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
 public static DA_DU_AN Insert_Object(
string  sMA_DU_AN
            ,string  sTEN_DU_AN
            ,string  sNGAY_TAO
            ,string  sNGUOI_TAO
            ,string  sNGAY_BAT_DAU
            ,string  sNGAY_KET_THUC
            ,string  sCHI_TIET
            ,string  sTRANG_THAI_ID
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sGHI_CHU
            ,string  sENABLE_BIT
            ) 
 { 
              string tem_sMA_DU_AN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_DU_AN,"nvarchar");
              string tem_sTEN_DU_AN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTEN_DU_AN,"nvarchar");
              string tem_sNGAY_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_TAO,"datetime");
              string tem_sNGUOI_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_TAO,"bigint");
              string tem_sNGAY_BAT_DAU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_BAT_DAU,"datetime");
              string tem_sNGAY_KET_THUC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_KET_THUC,"datetime");
              string tem_sCHI_TIET=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHI_TIET,"nvarchar");
              string tem_sTRANG_THAI_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTRANG_THAI_ID,"bigint");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");
              string tem_sENABLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sENABLE_BIT,"nchar");

             string sqlSave=" INSERT INTO DA_DU_AN("+
                   "MA_DU_AN," 
        +                   "TEN_DU_AN," 
        +                   "NGAY_TAO," 
        +                   "NGUOI_TAO," 
        +                   "NGAY_BAT_DAU," 
        +                   "NGAY_KET_THUC," 
        +                   "CHI_TIET," 
        +                   "TRANG_THAI_ID," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "GHI_CHU," 
        +                   "ENABLE_BIT) VALUES("
 +tem_sMA_DU_AN+","
 +tem_sTEN_DU_AN+","
 +tem_sNGAY_TAO+","
 +tem_sNGUOI_TAO+","
 +tem_sNGAY_BAT_DAU+","
 +tem_sNGAY_KET_THUC+","
 +tem_sCHI_TIET+","
 +tem_sTRANG_THAI_ID+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sGHI_CHU+","
 +tem_sENABLE_BIT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          DA_DU_AN newDA_DU_AN= new DA_DU_AN();
                 newDA_DU_AN.ID=GetTable( " SELECT TOP 1 ID FROM DA_DU_AN ORDER BY ID DESC ").Rows[0][0].ToString();
              newDA_DU_AN.MA_DU_AN=sMA_DU_AN;
              newDA_DU_AN.TEN_DU_AN=sTEN_DU_AN;
              newDA_DU_AN.NGAY_TAO=sNGAY_TAO;
              newDA_DU_AN.NGUOI_TAO=sNGUOI_TAO;
              newDA_DU_AN.NGAY_BAT_DAU=sNGAY_BAT_DAU;
              newDA_DU_AN.NGAY_KET_THUC=sNGAY_KET_THUC;
              newDA_DU_AN.CHI_TIET=sCHI_TIET;
              newDA_DU_AN.TRANG_THAI_ID=sTRANG_THAI_ID;
              newDA_DU_AN.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newDA_DU_AN.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newDA_DU_AN.GHI_CHU=sGHI_CHU;
              newDA_DU_AN.ENABLE_BIT=sENABLE_BIT;
            return newDA_DU_AN; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sMA_DU_AN
                ,string sTEN_DU_AN
                ,string sNGAY_TAO
                ,string sNGUOI_TAO
                ,string sNGAY_BAT_DAU
                ,string sNGAY_KET_THUC
                ,string sCHI_TIET
                ,string sTRANG_THAI_ID
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sGHI_CHU
                ,string sENABLE_BIT
                ) 
 { 
              string tem_sMA_DU_AN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_DU_AN,"nvarchar");
              string tem_sTEN_DU_AN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTEN_DU_AN,"nvarchar");
              string tem_sNGAY_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_TAO,"datetime");
              string tem_sNGUOI_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_TAO,"bigint");
              string tem_sNGAY_BAT_DAU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_BAT_DAU,"datetime");
              string tem_sNGAY_KET_THUC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_KET_THUC,"datetime");
              string tem_sCHI_TIET=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHI_TIET,"nvarchar");
              string tem_sTRANG_THAI_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTRANG_THAI_ID,"bigint");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");
              string tem_sENABLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sENABLE_BIT,"nchar");

 string sqlSave=" UPDATE DA_DU_AN SET "+"MA_DU_AN ="+tem_sMA_DU_AN+","
 +"TEN_DU_AN ="+tem_sTEN_DU_AN+","
 +"NGAY_TAO ="+tem_sNGAY_TAO+","
 +"NGUOI_TAO ="+tem_sNGUOI_TAO+","
 +"NGAY_BAT_DAU ="+tem_sNGAY_BAT_DAU+","
 +"NGAY_KET_THUC ="+tem_sNGAY_KET_THUC+","
 +"CHI_TIET ="+tem_sCHI_TIET+","
 +"TRANG_THAI_ID ="+tem_sTRANG_THAI_ID+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"GHI_CHU ="+tem_sGHI_CHU+","
 +"ENABLE_BIT ="+tem_sENABLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.MA_DU_AN=sMA_DU_AN;
                this.TEN_DU_AN=sTEN_DU_AN;
                this.NGAY_TAO=sNGAY_TAO;
                this.NGUOI_TAO=sNGUOI_TAO;
                this.NGAY_BAT_DAU=sNGAY_BAT_DAU;
                this.NGAY_KET_THUC=sNGAY_KET_THUC;
                this.CHI_TIET=sCHI_TIET;
                this.TRANG_THAI_ID=sTRANG_THAI_ID;
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
    string sqlSave= " UPDATE DA_DU_AN SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MA_DU_AN(string sMA_DU_AN)
{
    string sqlSave= " UPDATE DA_DU_AN SET MA_DU_AN='N"+ sMA_DU_AN+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MA_DU_AN=sMA_DU_AN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TEN_DU_AN(string sTEN_DU_AN)
{
    string sqlSave= " UPDATE DA_DU_AN SET TEN_DU_AN='N"+ sTEN_DU_AN+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TEN_DU_AN=sTEN_DU_AN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_TAO(string sNGAY_TAO)
{
    string sqlSave= " UPDATE DA_DU_AN SET NGAY_TAO='"+ sNGAY_TAO+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_TAO=sNGAY_TAO;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_TAO(string sNGUOI_TAO)
{
    string sqlSave= " UPDATE DA_DU_AN SET NGUOI_TAO='"+ sNGUOI_TAO+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_TAO=sNGUOI_TAO;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_BAT_DAU(string sNGAY_BAT_DAU)
{
    string sqlSave= " UPDATE DA_DU_AN SET NGAY_BAT_DAU='"+ sNGAY_BAT_DAU+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_BAT_DAU=sNGAY_BAT_DAU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_KET_THUC(string sNGAY_KET_THUC)
{
    string sqlSave= " UPDATE DA_DU_AN SET NGAY_KET_THUC='"+ sNGAY_KET_THUC+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_KET_THUC=sNGAY_KET_THUC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CHI_TIET(string sCHI_TIET)
{
    string sqlSave= " UPDATE DA_DU_AN SET CHI_TIET='N"+ sCHI_TIET+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CHI_TIET=sCHI_TIET;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TRANG_THAI_ID(string sTRANG_THAI_ID)
{
    string sqlSave= " UPDATE DA_DU_AN SET TRANG_THAI_ID='"+ sTRANG_THAI_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TRANG_THAI_ID=sTRANG_THAI_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE DA_DU_AN SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE ID='"+ this.ID+"' ";
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
    string sqlSave= " UPDATE DA_DU_AN SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE DA_DU_AN SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.GHI_CHU=sGHI_CHU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ENABLE_BIT(string sENABLE_BIT)
{
    string sqlSave= " UPDATE DA_DU_AN SET ENABLE_BIT='N"+ sENABLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ENABLE_BIT=sENABLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_MA_DU_AN(string sMA_DU_AN,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET MA_DU_AN='N"+sMA_DU_AN+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TEN_DU_AN(string sTEN_DU_AN,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET TEN_DU_AN='N"+sTEN_DU_AN+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_TAO(string sNGAY_TAO,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET NGAY_TAO='"+sNGAY_TAO+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_TAO(string sNGUOI_TAO,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET NGUOI_TAO='"+sNGUOI_TAO+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_BAT_DAU(string sNGAY_BAT_DAU,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET NGAY_BAT_DAU='"+sNGAY_BAT_DAU+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_KET_THUC(string sNGAY_KET_THUC,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET NGAY_KET_THUC='"+sNGAY_KET_THUC+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CHI_TIET(string sCHI_TIET,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET CHI_TIET='N"+sCHI_TIET+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TRANG_THAI_ID(string sTRANG_THAI_ID,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET TRANG_THAI_ID='"+sTRANG_THAI_ID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET GHI_CHU='N"+sGHI_CHU+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ENABLE_BIT(string sENABLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE DA_DU_AN SET ENABLE_BIT='N"+sENABLE_BIT+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM DA_DU_AN";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "DA_DU_AN");
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
   private static DataTable dt_DA_DU_AN;
   public static bool Change_dt_DA_DU_AN = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_DA_DU_AN()
   {
   if (dt_DA_DU_AN == null || Change_dt_DA_DU_AN == true)
     {
   dt_DA_DU_AN = GetTableAll();
         Change_dt_DA_DU_AN = true && AllowAutoChange ;
     }
     return dt_DA_DU_AN;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
