using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class KH_PHIEU_XUAT_KHO:  SQLConnectWeb { 
 public static string sTableName= "KH_PHIEU_XUAT_KHO"; 
   public string PXK_ID;
   public string MA_PXK;
   public string NGUOI_XUAT;
   public string NGAY_XUAT;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string NGUOI_NHAN;
   public string MEM_ID;
   public string KHO_ID;
   public string DU_AN_ID;
   public string LY_DO_XUAT_ID;
   public string CHUNG_TU;
   public string GHI_CHU;
   public string YEU_CAU_ID;
   #region DataColumn Name ;
 public static  string cl_PXK_ID="PXK_ID" ;
 public static  string cl_MA_PXK="MA_PXK" ;
 public static  string cl_NGUOI_XUAT="NGUOI_XUAT" ;
 public static  string cl_NGAY_XUAT="NGAY_XUAT" ;
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_NGUOI_NHAN="NGUOI_NHAN" ;
 public static  string cl_MEM_ID="MEM_ID" ;
 public static  string cl_KHO_ID="KHO_ID" ;
 public static  string cl_DU_AN_ID="DU_AN_ID" ;
 public static  string cl_LY_DO_XUAT_ID="LY_DO_XUAT_ID" ;
 public static  string cl_CHUNG_TU="CHUNG_TU" ;
 public static  string cl_GHI_CHU="GHI_CHU" ;
 public static  string cl_YEU_CAU_ID="YEU_CAU_ID" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_XUAT_KHO() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_XUAT_KHO(
         string sPXK_ID,
         string sMA_PXK,
         string sNGUOI_XUAT,
         string sNGAY_XUAT,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sNGUOI_NHAN,
         string sMEM_ID,
         string sKHO_ID,
         string sDU_AN_ID,
         string sLY_DO_XUAT_ID,
         string sCHUNG_TU,
         string sGHI_CHU,
         string sYEU_CAU_ID){
         this.PXK_ID= sPXK_ID;
         this.MA_PXK= sMA_PXK;
         this.NGUOI_XUAT= sNGUOI_XUAT;
         this.NGAY_XUAT= sNGAY_XUAT;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.NGUOI_NHAN= sNGUOI_NHAN;
         this.MEM_ID= sMEM_ID;
         this.KHO_ID= sKHO_ID;
         this.DU_AN_ID= sDU_AN_ID;
         this.LY_DO_XUAT_ID= sLY_DO_XUAT_ID;
         this.CHUNG_TU= sCHUNG_TU;
         this.GHI_CHU= sGHI_CHU;
         this.YEU_CAU_ID= sYEU_CAU_ID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static KH_PHIEU_XUAT_KHO Create_KH_PHIEU_XUAT_KHO ( string sPXK_ID  ){
    DataTable dt=SearchByPXK_ID(sPXK_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new KH_PHIEU_XUAT_KHO(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM KH_PHIEU_XUAT_KHO AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public KH_PHIEU_XUAT_KHO( DataTable table,int pos)
{
         this.PXK_ID= table.Rows[pos]["PXK_ID"].ToString();
         this.MA_PXK= table.Rows[pos]["MA_PXK"].ToString();
         this.NGUOI_XUAT= table.Rows[pos]["NGUOI_XUAT"].ToString();
         this.NGAY_XUAT= table.Rows[pos]["NGAY_XUAT"].ToString();
         this.NGUOI_CAP_NHAT= table.Rows[pos]["NGUOI_CAP_NHAT"].ToString();
         this.NGAY_CAP_NHAT= table.Rows[pos]["NGAY_CAP_NHAT"].ToString();
         this.NGUOI_NHAN= table.Rows[pos]["NGUOI_NHAN"].ToString();
         this.MEM_ID= table.Rows[pos]["MEM_ID"].ToString();
         this.KHO_ID= table.Rows[pos]["KHO_ID"].ToString();
         this.DU_AN_ID= table.Rows[pos]["DU_AN_ID"].ToString();
         this.LY_DO_XUAT_ID= table.Rows[pos]["LY_DO_XUAT_ID"].ToString();
         this.CHUNG_TU= table.Rows[pos]["CHUNG_TU"].ToString();
         this.GHI_CHU= table.Rows[pos]["GHI_CHU"].ToString();
         this.YEU_CAU_ID= table.Rows[pos]["YEU_CAU_ID"].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPXK_ID(string sPXK_ID)
{
          string sqlSelect= s_Select()+ " WHERE PXK_ID  ="+ sPXK_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPXK_ID(string sPXK_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PXK_ID"+ sMatch +sPXK_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMA_PXK(string sMA_PXK)
{
          string sqlSelect= s_Select()+ " WHERE MA_PXK  Like N'%"+ sMA_PXK + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_XUAT(string sNGUOI_XUAT)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_XUAT  ="+ sNGUOI_XUAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_XUAT(string sNGUOI_XUAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_XUAT"+ sMatch +sNGUOI_XUAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_XUAT(string sNGAY_XUAT)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_XUAT  ="+ sNGAY_XUAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_XUAT(string sNGAY_XUAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_XUAT"+ sMatch +sNGAY_XUAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CAP_NHAT  ="+ sNGUOI_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CAP_NHAT"+ sMatch +sNGUOI_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_CAP_NHAT(string sNGAY_CAP_NHAT)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CAP_NHAT  ="+ sNGAY_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CAP_NHAT"+ sMatch +sNGAY_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_NHAN(string sNGUOI_NHAN)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_NHAN  Like N'%"+ sNGUOI_NHAN + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMEM_ID(string sMEM_ID)
{
          string sqlSelect= s_Select()+ " WHERE MEM_ID  ="+ sMEM_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMEM_ID(string sMEM_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE MEM_ID"+ sMatch +sMEM_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByKHO_ID(string sKHO_ID)
{
          string sqlSelect= s_Select()+ " WHERE KHO_ID  ="+ sKHO_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByKHO_ID(string sKHO_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE KHO_ID"+ sMatch +sKHO_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDU_AN_ID(string sDU_AN_ID)
{
          string sqlSelect= s_Select()+ " WHERE DU_AN_ID  ="+ sDU_AN_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDU_AN_ID(string sDU_AN_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DU_AN_ID"+ sMatch +sDU_AN_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByLY_DO_XUAT_ID(string sLY_DO_XUAT_ID)
{
          string sqlSelect= s_Select()+ " WHERE LY_DO_XUAT_ID  ="+ sLY_DO_XUAT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByLY_DO_XUAT_ID(string sLY_DO_XUAT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LY_DO_XUAT_ID"+ sMatch +sLY_DO_XUAT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCHUNG_TU(string sCHUNG_TU)
{
          string sqlSelect= s_Select()+ " WHERE CHUNG_TU  Like N'%"+ sCHUNG_TU + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByYEU_CAU_ID(string sYEU_CAU_ID)
{
          string sqlSelect= s_Select()+ " WHERE YEU_CAU_ID  ="+ sYEU_CAU_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByYEU_CAU_ID(string sYEU_CAU_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE YEU_CAU_ID"+ sMatch +sYEU_CAU_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sPXK_ID
            , string sMA_PXK
            , string sNGUOI_XUAT
            , string sNGAY_XUAT
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sNGUOI_NHAN
            , string sMEM_ID
            , string sKHO_ID
            , string sDU_AN_ID
            , string sLY_DO_XUAT_ID
            , string sCHUNG_TU
            , string sGHI_CHU
            , string sYEU_CAU_ID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sPXK_ID!=null && sPXK_ID!="") 
            sqlselect +=" AND PXK_ID =" + sPXK_ID ;
      if (sMA_PXK!=null && sMA_PXK!="") 
            sqlselect +=" AND MA_PXK LIKE N'%" + sMA_PXK +"%'" ;
      if (sNGUOI_XUAT!=null && sNGUOI_XUAT!="") 
            sqlselect +=" AND NGUOI_XUAT =" + sNGUOI_XUAT ;
      if (sNGAY_XUAT!=null && sNGAY_XUAT!="") 
            sqlselect +=" AND NGAY_XUAT LIKE '%" + sNGAY_XUAT +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT =" + sNGUOI_CAP_NHAT ;
      if (sNGAY_CAP_NHAT!=null && sNGAY_CAP_NHAT!="") 
            sqlselect +=" AND NGAY_CAP_NHAT LIKE '%" + sNGAY_CAP_NHAT +"%'" ;
      if (sNGUOI_NHAN!=null && sNGUOI_NHAN!="") 
            sqlselect +=" AND NGUOI_NHAN LIKE N'%" + sNGUOI_NHAN +"%'" ;
      if (sMEM_ID!=null && sMEM_ID!="") 
            sqlselect +=" AND MEM_ID =" + sMEM_ID ;
      if (sKHO_ID!=null && sKHO_ID!="") 
            sqlselect +=" AND KHO_ID =" + sKHO_ID ;
      if (sDU_AN_ID!=null && sDU_AN_ID!="") 
            sqlselect +=" AND DU_AN_ID =" + sDU_AN_ID ;
      if (sLY_DO_XUAT_ID!=null && sLY_DO_XUAT_ID!="") 
            sqlselect +=" AND LY_DO_XUAT_ID =" + sLY_DO_XUAT_ID ;
      if (sCHUNG_TU!=null && sCHUNG_TU!="") 
            sqlselect +=" AND CHUNG_TU LIKE N'%" + sCHUNG_TU +"%'" ;
      if (sGHI_CHU!=null && sGHI_CHU!="") 
            sqlselect +=" AND GHI_CHU LIKE N'%" + sGHI_CHU +"%'" ;
      if (sYEU_CAU_ID!=null && sYEU_CAU_ID!="") 
            sqlselect +=" AND YEU_CAU_ID =" + sYEU_CAU_ID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect,sTableName);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static KH_PHIEU_XUAT_KHO Insert_Object(
string  sMA_PXK
            ,string  sNGUOI_XUAT
            ,string  sNGAY_XUAT
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sNGUOI_NHAN
            ,string  sMEM_ID
            ,string  sKHO_ID
            ,string  sDU_AN_ID
            ,string  sLY_DO_XUAT_ID
            ,string  sCHUNG_TU
            ,string  sGHI_CHU
            ,string  sYEU_CAU_ID
            ) 
 { 
              string tem_sMA_PXK=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PXK,"varchar");
              string tem_sNGUOI_XUAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_XUAT,"bigint");
              string tem_sNGAY_XUAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_XUAT,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_NHAN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_NHAN,"varchar");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sKHO_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sLY_DO_XUAT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLY_DO_XUAT_ID,"bigint");
              string tem_sCHUNG_TU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU,"nvarchar");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");
              string tem_sYEU_CAU_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYEU_CAU_ID,"bigint");

             string sqlSave=" INSERT INTO KH_PHIEU_XUAT_KHO("+
                   "MA_PXK," 
        +                   "NGUOI_XUAT," 
        +                   "NGAY_XUAT," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "NGUOI_NHAN," 
        +                   "MEM_ID," 
        +                   "KHO_ID," 
        +                   "DU_AN_ID," 
        +                   "LY_DO_XUAT_ID," 
        +                   "CHUNG_TU," 
        +                   "GHI_CHU," 
        +                   "YEU_CAU_ID) VALUES("
 +tem_sMA_PXK+","
 +tem_sNGUOI_XUAT+","
 +tem_sNGAY_XUAT+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sNGUOI_NHAN+","
 +tem_sMEM_ID+","
 +tem_sKHO_ID+","
 +tem_sDU_AN_ID+","
 +tem_sLY_DO_XUAT_ID+","
 +tem_sCHUNG_TU+","
 +tem_sGHI_CHU+","
 +tem_sYEU_CAU_ID +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          KH_PHIEU_XUAT_KHO newKH_PHIEU_XUAT_KHO= new KH_PHIEU_XUAT_KHO();
                 newKH_PHIEU_XUAT_KHO.PXK_ID=GetTable( " SELECT TOP 1 PXK_ID FROM KH_PHIEU_XUAT_KHO ORDER BY PXK_ID DESC ").Rows[0][0].ToString();
              newKH_PHIEU_XUAT_KHO.MA_PXK=sMA_PXK;
              newKH_PHIEU_XUAT_KHO.NGUOI_XUAT=sNGUOI_XUAT;
              newKH_PHIEU_XUAT_KHO.NGAY_XUAT=sNGAY_XUAT;
              newKH_PHIEU_XUAT_KHO.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newKH_PHIEU_XUAT_KHO.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newKH_PHIEU_XUAT_KHO.NGUOI_NHAN=sNGUOI_NHAN;
              newKH_PHIEU_XUAT_KHO.MEM_ID=sMEM_ID;
              newKH_PHIEU_XUAT_KHO.KHO_ID=sKHO_ID;
              newKH_PHIEU_XUAT_KHO.DU_AN_ID=sDU_AN_ID;
              newKH_PHIEU_XUAT_KHO.LY_DO_XUAT_ID=sLY_DO_XUAT_ID;
              newKH_PHIEU_XUAT_KHO.CHUNG_TU=sCHUNG_TU;
              newKH_PHIEU_XUAT_KHO.GHI_CHU=sGHI_CHU;
              newKH_PHIEU_XUAT_KHO.YEU_CAU_ID=sYEU_CAU_ID;
            return newKH_PHIEU_XUAT_KHO; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sMA_PXK
                ,string sNGUOI_XUAT
                ,string sNGAY_XUAT
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sNGUOI_NHAN
                ,string sMEM_ID
                ,string sKHO_ID
                ,string sDU_AN_ID
                ,string sLY_DO_XUAT_ID
                ,string sCHUNG_TU
                ,string sGHI_CHU
                ,string sYEU_CAU_ID
                ) 
 { 
              string tem_sMA_PXK=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PXK,"varchar");
              string tem_sNGUOI_XUAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_XUAT,"bigint");
              string tem_sNGAY_XUAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_XUAT,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_NHAN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_NHAN,"varchar");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sKHO_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sKHO_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sLY_DO_XUAT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLY_DO_XUAT_ID,"bigint");
              string tem_sCHUNG_TU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU,"nvarchar");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");
              string tem_sYEU_CAU_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYEU_CAU_ID,"bigint");

 string sqlSave=" UPDATE KH_PHIEU_XUAT_KHO SET "+"MA_PXK ="+tem_sMA_PXK+","
 +"NGUOI_XUAT ="+tem_sNGUOI_XUAT+","
 +"NGAY_XUAT ="+tem_sNGAY_XUAT+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"NGUOI_NHAN ="+tem_sNGUOI_NHAN+","
 +"MEM_ID ="+tem_sMEM_ID+","
 +"KHO_ID ="+tem_sKHO_ID+","
 +"DU_AN_ID ="+tem_sDU_AN_ID+","
 +"LY_DO_XUAT_ID ="+tem_sLY_DO_XUAT_ID+","
 +"CHUNG_TU ="+tem_sCHUNG_TU+","
 +"GHI_CHU ="+tem_sGHI_CHU+","
 +"YEU_CAU_ID ="+tem_sYEU_CAU_ID+" WHERE PXK_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.PXK_ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.MA_PXK=sMA_PXK;
                this.NGUOI_XUAT=sNGUOI_XUAT;
                this.NGAY_XUAT=sNGAY_XUAT;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
                this.NGUOI_NHAN=sNGUOI_NHAN;
                this.MEM_ID=sMEM_ID;
                this.KHO_ID=sKHO_ID;
                this.DU_AN_ID=sDU_AN_ID;
                this.LY_DO_XUAT_ID=sLY_DO_XUAT_ID;
                this.CHUNG_TU=sCHUNG_TU;
                this.GHI_CHU=sGHI_CHU;
                this.YEU_CAU_ID=sYEU_CAU_ID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_PXK_ID(string sPXK_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET PXK_ID='"+ sPXK_ID+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PXK_ID=sPXK_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MA_PXK(string sMA_PXK)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET MA_PXK='N"+ sMA_PXK+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MA_PXK=sMA_PXK;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_XUAT(string sNGUOI_XUAT)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGUOI_XUAT='"+ sNGUOI_XUAT+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_XUAT=sNGUOI_XUAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_XUAT(string sNGAY_XUAT)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGAY_XUAT='"+ sNGAY_XUAT+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_XUAT=sNGAY_XUAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
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
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_NHAN(string sNGUOI_NHAN)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGUOI_NHAN='N"+ sNGUOI_NHAN+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_NHAN=sNGUOI_NHAN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MEM_ID(string sMEM_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET MEM_ID='"+ sMEM_ID+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MEM_ID=sMEM_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_KHO_ID(string sKHO_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET KHO_ID='"+ sKHO_ID+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.KHO_ID=sKHO_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DU_AN_ID(string sDU_AN_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET DU_AN_ID='"+ sDU_AN_ID+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DU_AN_ID=sDU_AN_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LY_DO_XUAT_ID(string sLY_DO_XUAT_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET LY_DO_XUAT_ID='"+ sLY_DO_XUAT_ID+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.LY_DO_XUAT_ID=sLY_DO_XUAT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CHUNG_TU(string sCHUNG_TU)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET CHUNG_TU='N"+ sCHUNG_TU+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CHUNG_TU=sCHUNG_TU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.GHI_CHU=sGHI_CHU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_YEU_CAU_ID(string sYEU_CAU_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET YEU_CAU_ID='"+ sYEU_CAU_ID+ "' WHERE PXK_ID='"+ this.PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.YEU_CAU_ID=sYEU_CAU_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_MA_PXK(string sMA_PXK,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET MA_PXK='N"+sMA_PXK+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_XUAT(string sNGUOI_XUAT,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGUOI_XUAT='"+sNGUOI_XUAT+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_XUAT(string sNGAY_XUAT,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGAY_XUAT='"+sNGAY_XUAT+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_NHAN(string sNGUOI_NHAN,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET NGUOI_NHAN='N"+sNGUOI_NHAN+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MEM_ID(string sMEM_ID,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET MEM_ID='"+sMEM_ID+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_KHO_ID(string sKHO_ID,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET KHO_ID='"+sKHO_ID+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DU_AN_ID(string sDU_AN_ID,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET DU_AN_ID='"+sDU_AN_ID+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LY_DO_XUAT_ID(string sLY_DO_XUAT_ID,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET LY_DO_XUAT_ID='"+sLY_DO_XUAT_ID+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CHUNG_TU(string sCHUNG_TU,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET CHUNG_TU='N"+sCHUNG_TU+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET GHI_CHU='N"+sGHI_CHU+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_YEU_CAU_ID(string sYEU_CAU_ID,string s_PXK_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO SET YEU_CAU_ID='"+sYEU_CAU_ID+"' WHERE PXK_ID='"+ s_PXK_ID+"' ";
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
   string sqlSelect = " SELECT * FROM KH_PHIEU_XUAT_KHO";
   if (!string.IsNullOrEmpty(sWhere))
      sqlSelect += " where " + sWhere; 
   string order = "";
   if (orderFields != null && orderFields.Length > 0)
     order = string.Join(",", orderFields);
   if (order != "")
      sqlSelect += " ORDER BY " + order;
   return GetTable(sqlSelect,sTableName);
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
public static DataTable GetTableFields(string sWhere, string[] orderFields, params string[] fields)
{
 string field = "";
 if (fields != null && fields.Length > 0)
    field = string.Join(",", fields);
 else field = "*";
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "KH_PHIEU_XUAT_KHO");
 if (!string.IsNullOrEmpty(sWhere))
    sqlSelect += " where " + sWhere;
 string order = "";
 if (orderFields != null && orderFields.Length > 0)
    order = string.Join(",", orderFields);
 if (order != "")
    sqlSelect += " ORDER BY " + order;
 return GetTable(sqlSelect,sTableName);
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
   private static DataTable dt_KH_PHIEU_XUAT_KHO;
   public static bool Change_dt_KH_PHIEU_XUAT_KHO = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_KH_PHIEU_XUAT_KHO()
   {
   if (dt_KH_PHIEU_XUAT_KHO == null || Change_dt_KH_PHIEU_XUAT_KHO == true)
     {
   dt_KH_PHIEU_XUAT_KHO = GetTableAll();
         Change_dt_KH_PHIEU_XUAT_KHO = true && AllowAutoChange ;
     }
     return dt_KH_PHIEU_XUAT_KHO;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
