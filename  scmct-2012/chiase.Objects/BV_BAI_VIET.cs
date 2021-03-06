using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class BV_BAI_VIET:  SQLConnectWeb { 
 public static string sTableName= "BV_BAI_VIET"; 
   public string BAI_VIET_ID;
   public string TIEU_DE;
   public string NGUOI_TAO;
   public string NGAY_TAO;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string NOI_DUNG;
   public string TRANG_THAI_ID;
   public string BAI_VIET_CHA_ID;
   public string DU_AN_ID;
   public string CHU_DE_ID;
   public string SORT;
   public string XEM;
   #region DataColumn Name ;
 public static  string cl_BAI_VIET_ID="BAI_VIET_ID" ;
 public static  string cl_TIEU_DE="TIEU_DE" ;
 public static  string cl_NGUOI_TAO="NGUOI_TAO" ;
 public static  string cl_NGAY_TAO="NGAY_TAO" ;
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_NOI_DUNG="NOI_DUNG" ;
 public static  string cl_TRANG_THAI_ID="TRANG_THAI_ID" ;
 public static  string cl_BAI_VIET_CHA_ID="BAI_VIET_CHA_ID" ;
 public static  string cl_DU_AN_ID="DU_AN_ID" ;
 public static  string cl_CHU_DE_ID="CHU_DE_ID" ;
 public static  string cl_SORT="SORT" ;
 public static  string cl_XEM="XEM" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public BV_BAI_VIET() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public BV_BAI_VIET(
         string sBAI_VIET_ID,
         string sTIEU_DE,
         string sNGUOI_TAO,
         string sNGAY_TAO,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sNOI_DUNG,
         string sTRANG_THAI_ID,
         string sBAI_VIET_CHA_ID,
         string sDU_AN_ID,
         string sCHU_DE_ID,
         string sSORT,
         string sXEM){
         this.BAI_VIET_ID= sBAI_VIET_ID;
         this.TIEU_DE= sTIEU_DE;
         this.NGUOI_TAO= sNGUOI_TAO;
         this.NGAY_TAO= sNGAY_TAO;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.NOI_DUNG= sNOI_DUNG;
         this.TRANG_THAI_ID= sTRANG_THAI_ID;
         this.BAI_VIET_CHA_ID= sBAI_VIET_CHA_ID;
         this.DU_AN_ID= sDU_AN_ID;
         this.CHU_DE_ID= sCHU_DE_ID;
         this.SORT= sSORT;
         this.XEM= sXEM;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static BV_BAI_VIET Create_BV_BAI_VIET ( string sBAI_VIET_ID  ){
    DataTable dt=SearchByBAI_VIET_ID(sBAI_VIET_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new BV_BAI_VIET(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM BV_BAI_VIET AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public BV_BAI_VIET( DataTable table,int pos)
{
         this.BAI_VIET_ID= table.Rows[pos]["BAI_VIET_ID"].ToString();
         this.TIEU_DE= table.Rows[pos]["TIEU_DE"].ToString();
         this.NGUOI_TAO= table.Rows[pos]["NGUOI_TAO"].ToString();
         this.NGAY_TAO= table.Rows[pos]["NGAY_TAO"].ToString();
         this.NGUOI_CAP_NHAT= table.Rows[pos]["NGUOI_CAP_NHAT"].ToString();
         this.NGAY_CAP_NHAT= table.Rows[pos]["NGAY_CAP_NHAT"].ToString();
         this.NOI_DUNG= table.Rows[pos]["NOI_DUNG"].ToString();
         this.TRANG_THAI_ID= table.Rows[pos]["TRANG_THAI_ID"].ToString();
         this.BAI_VIET_CHA_ID= table.Rows[pos]["BAI_VIET_CHA_ID"].ToString();
         this.DU_AN_ID= table.Rows[pos]["DU_AN_ID"].ToString();
         this.CHU_DE_ID= table.Rows[pos]["CHU_DE_ID"].ToString();
         this.SORT= table.Rows[pos]["SORT"].ToString();
         this.XEM= table.Rows[pos]["XEM"].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByBAI_VIET_ID(string sBAI_VIET_ID)
{
          string sqlSelect= s_Select()+ " WHERE BAI_VIET_ID  ="+ sBAI_VIET_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByBAI_VIET_ID(string sBAI_VIET_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BAI_VIET_ID"+ sMatch +sBAI_VIET_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTIEU_DE(string sTIEU_DE)
{
          string sqlSelect= s_Select()+ " WHERE TIEU_DE  Like N'%"+ sTIEU_DE + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_TAO(string sNGUOI_TAO)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_TAO  ="+ sNGUOI_TAO + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_TAO(string sNGUOI_TAO,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_TAO"+ sMatch +sNGUOI_TAO + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_TAO(string sNGAY_TAO)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_TAO  ="+ sNGAY_TAO + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_TAO(string sNGAY_TAO,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_TAO"+ sMatch +sNGAY_TAO + ""; 
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
 public static DataTable SearchByNOI_DUNG(string sNOI_DUNG)
{
          string sqlSelect= s_Select()+ " WHERE NOI_DUNG  Like '%"+ sNOI_DUNG + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTRANG_THAI_ID(string sTRANG_THAI_ID)
{
          string sqlSelect= s_Select()+ " WHERE TRANG_THAI_ID  ="+ sTRANG_THAI_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTRANG_THAI_ID(string sTRANG_THAI_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE TRANG_THAI_ID"+ sMatch +sTRANG_THAI_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByBAI_VIET_CHA_ID(string sBAI_VIET_CHA_ID)
{
          string sqlSelect= s_Select()+ " WHERE BAI_VIET_CHA_ID  ="+ sBAI_VIET_CHA_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByBAI_VIET_CHA_ID(string sBAI_VIET_CHA_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BAI_VIET_CHA_ID"+ sMatch +sBAI_VIET_CHA_ID + ""; 
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
 public static DataTable SearchByCHU_DE_ID(string sCHU_DE_ID)
{
          string sqlSelect= s_Select()+ " WHERE CHU_DE_ID  ="+ sCHU_DE_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCHU_DE_ID(string sCHU_DE_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CHU_DE_ID"+ sMatch +sCHU_DE_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySORT(string sSORT)
{
          string sqlSelect= s_Select()+ " WHERE SORT  ="+ sSORT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySORT(string sSORT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SORT"+ sMatch +sSORT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByXEM(string sXEM)
{
          string sqlSelect= s_Select()+ " WHERE XEM  ="+ sXEM + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByXEM(string sXEM,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE XEM"+ sMatch +sXEM + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sBAI_VIET_ID
            , string sTIEU_DE
            , string sNGUOI_TAO
            , string sNGAY_TAO
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sNOI_DUNG
            , string sTRANG_THAI_ID
            , string sBAI_VIET_CHA_ID
            , string sDU_AN_ID
            , string sCHU_DE_ID
            , string sSORT
            , string sXEM
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sBAI_VIET_ID!=null && sBAI_VIET_ID!="") 
            sqlselect +=" AND BAI_VIET_ID =" + sBAI_VIET_ID ;
      if (sTIEU_DE!=null && sTIEU_DE!="") 
            sqlselect +=" AND TIEU_DE LIKE N'%" + sTIEU_DE +"%'" ;
      if (sNGUOI_TAO!=null && sNGUOI_TAO!="") 
            sqlselect +=" AND NGUOI_TAO =" + sNGUOI_TAO ;
      if (sNGAY_TAO!=null && sNGAY_TAO!="") 
            sqlselect +=" AND NGAY_TAO LIKE '%" + sNGAY_TAO +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT =" + sNGUOI_CAP_NHAT ;
      if (sNGAY_CAP_NHAT!=null && sNGAY_CAP_NHAT!="") 
            sqlselect +=" AND NGAY_CAP_NHAT LIKE '%" + sNGAY_CAP_NHAT +"%'" ;
      if (sNOI_DUNG!=null && sNOI_DUNG!="") 
            sqlselect +=" AND NOI_DUNG LIKE '%" + sNOI_DUNG +"%'" ;
      if (sTRANG_THAI_ID!=null && sTRANG_THAI_ID!="") 
            sqlselect +=" AND TRANG_THAI_ID =" + sTRANG_THAI_ID ;
      if (sBAI_VIET_CHA_ID!=null && sBAI_VIET_CHA_ID!="") 
            sqlselect +=" AND BAI_VIET_CHA_ID =" + sBAI_VIET_CHA_ID ;
      if (sDU_AN_ID!=null && sDU_AN_ID!="") 
            sqlselect +=" AND DU_AN_ID =" + sDU_AN_ID ;
      if (sCHU_DE_ID!=null && sCHU_DE_ID!="") 
            sqlselect +=" AND CHU_DE_ID =" + sCHU_DE_ID ;
      if (sSORT!=null && sSORT!="") 
            sqlselect +=" AND SORT =" + sSORT ;
      if (sXEM!=null && sXEM!="") 
            sqlselect +=" AND XEM =" + sXEM ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect,sTableName);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static BV_BAI_VIET Insert_Object(
string  sTIEU_DE
            ,string  sNGUOI_TAO
            ,string  sNGAY_TAO
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sNOI_DUNG
            ,string  sTRANG_THAI_ID
            ,string  sBAI_VIET_CHA_ID
            ,string  sDU_AN_ID
            ,string  sCHU_DE_ID
            ,string  sSORT
            ,string  sXEM
            ) 
 { 
              string tem_sTIEU_DE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTIEU_DE,"nvarchar");
              string tem_sNGUOI_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_TAO,"bigint");
              string tem_sNGAY_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_TAO,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNOI_DUNG=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG,"ntext");
              string tem_sTRANG_THAI_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTRANG_THAI_ID,"bigint");
              string tem_sBAI_VIET_CHA_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBAI_VIET_CHA_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sCHU_DE_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHU_DE_ID,"bigint");
              string tem_sSORT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSORT,"int");
              string tem_sXEM=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sXEM,"bigint");

             string sqlSave=" INSERT INTO BV_BAI_VIET("+
                   "TIEU_DE," 
        +                   "NGUOI_TAO," 
        +                   "NGAY_TAO," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "NOI_DUNG," 
        +                   "TRANG_THAI_ID," 
        +                   "BAI_VIET_CHA_ID," 
        +                   "DU_AN_ID," 
        +                   "CHU_DE_ID," 
        +                   "SORT," 
        +                   "XEM) VALUES("
 +tem_sTIEU_DE+","
 +tem_sNGUOI_TAO+","
 +tem_sNGAY_TAO+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sNOI_DUNG+","
 +tem_sTRANG_THAI_ID+","
 +tem_sBAI_VIET_CHA_ID+","
 +tem_sDU_AN_ID+","
 +tem_sCHU_DE_ID+","
 +tem_sSORT+","
 +tem_sXEM +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          BV_BAI_VIET newBV_BAI_VIET= new BV_BAI_VIET();
                 newBV_BAI_VIET.BAI_VIET_ID=GetTable( " SELECT TOP 1 BAI_VIET_ID FROM BV_BAI_VIET ORDER BY BAI_VIET_ID DESC ").Rows[0][0].ToString();
              newBV_BAI_VIET.TIEU_DE=sTIEU_DE;
              newBV_BAI_VIET.NGUOI_TAO=sNGUOI_TAO;
              newBV_BAI_VIET.NGAY_TAO=sNGAY_TAO;
              newBV_BAI_VIET.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newBV_BAI_VIET.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newBV_BAI_VIET.NOI_DUNG=sNOI_DUNG;
              newBV_BAI_VIET.TRANG_THAI_ID=sTRANG_THAI_ID;
              newBV_BAI_VIET.BAI_VIET_CHA_ID=sBAI_VIET_CHA_ID;
              newBV_BAI_VIET.DU_AN_ID=sDU_AN_ID;
              newBV_BAI_VIET.CHU_DE_ID=sCHU_DE_ID;
              newBV_BAI_VIET.SORT=sSORT;
              newBV_BAI_VIET.XEM=sXEM;
            return newBV_BAI_VIET; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sTIEU_DE
                ,string sNGUOI_TAO
                ,string sNGAY_TAO
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sNOI_DUNG
                ,string sTRANG_THAI_ID
                ,string sBAI_VIET_CHA_ID
                ,string sDU_AN_ID
                ,string sCHU_DE_ID
                ,string sSORT
                ,string sXEM
                ) 
 { 
              string tem_sTIEU_DE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTIEU_DE,"nvarchar");
              string tem_sNGUOI_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_TAO,"bigint");
              string tem_sNGAY_TAO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_TAO,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNOI_DUNG=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG,"ntext");
              string tem_sTRANG_THAI_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTRANG_THAI_ID,"bigint");
              string tem_sBAI_VIET_CHA_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBAI_VIET_CHA_ID,"bigint");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sCHU_DE_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHU_DE_ID,"bigint");
              string tem_sSORT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSORT,"int");
              string tem_sXEM=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sXEM,"bigint");

 string sqlSave=" UPDATE BV_BAI_VIET SET "+"TIEU_DE ="+tem_sTIEU_DE+","
 +"NGUOI_TAO ="+tem_sNGUOI_TAO+","
 +"NGAY_TAO ="+tem_sNGAY_TAO+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"NOI_DUNG ="+tem_sNOI_DUNG+","
 +"TRANG_THAI_ID ="+tem_sTRANG_THAI_ID+","
 +"BAI_VIET_CHA_ID ="+tem_sBAI_VIET_CHA_ID+","
 +"DU_AN_ID ="+tem_sDU_AN_ID+","
 +"CHU_DE_ID ="+tem_sCHU_DE_ID+","
 +"SORT ="+tem_sSORT+","
 +"XEM ="+tem_sXEM+" WHERE BAI_VIET_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.BAI_VIET_ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.TIEU_DE=sTIEU_DE;
                this.NGUOI_TAO=sNGUOI_TAO;
                this.NGAY_TAO=sNGAY_TAO;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
                this.NOI_DUNG=sNOI_DUNG;
                this.TRANG_THAI_ID=sTRANG_THAI_ID;
                this.BAI_VIET_CHA_ID=sBAI_VIET_CHA_ID;
                this.DU_AN_ID=sDU_AN_ID;
                this.CHU_DE_ID=sCHU_DE_ID;
                this.SORT=sSORT;
                this.XEM=sXEM;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_BAI_VIET_ID(string sBAI_VIET_ID)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET BAI_VIET_ID='"+ sBAI_VIET_ID+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BAI_VIET_ID=sBAI_VIET_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TIEU_DE(string sTIEU_DE)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET TIEU_DE='N"+ sTIEU_DE+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TIEU_DE=sTIEU_DE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_TAO(string sNGUOI_TAO)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET NGUOI_TAO='"+ sNGUOI_TAO+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_TAO=sNGUOI_TAO;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_TAO(string sNGAY_TAO)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET NGAY_TAO='"+ sNGAY_TAO+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_TAO=sNGAY_TAO;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
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
    string sqlSave= " UPDATE BV_BAI_VIET SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NOI_DUNG(string sNOI_DUNG)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET NOI_DUNG='"+ sNOI_DUNG+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NOI_DUNG=sNOI_DUNG;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TRANG_THAI_ID(string sTRANG_THAI_ID)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET TRANG_THAI_ID='"+ sTRANG_THAI_ID+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TRANG_THAI_ID=sTRANG_THAI_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BAI_VIET_CHA_ID(string sBAI_VIET_CHA_ID)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET BAI_VIET_CHA_ID='"+ sBAI_VIET_CHA_ID+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BAI_VIET_CHA_ID=sBAI_VIET_CHA_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DU_AN_ID(string sDU_AN_ID)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET DU_AN_ID='"+ sDU_AN_ID+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DU_AN_ID=sDU_AN_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CHU_DE_ID(string sCHU_DE_ID)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET CHU_DE_ID='"+ sCHU_DE_ID+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CHU_DE_ID=sCHU_DE_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SORT(string sSORT)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET SORT='"+ sSORT+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SORT=sSORT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_XEM(string sXEM)
{
    string sqlSave= " UPDATE BV_BAI_VIET SET XEM='"+ sXEM+ "' WHERE BAI_VIET_ID='"+ this.BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.XEM=sXEM;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_TIEU_DE(string sTIEU_DE,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET TIEU_DE='N"+sTIEU_DE+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_TAO(string sNGUOI_TAO,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET NGUOI_TAO='"+sNGUOI_TAO+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_TAO(string sNGAY_TAO,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET NGAY_TAO='"+sNGAY_TAO+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NOI_DUNG(string sNOI_DUNG,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET NOI_DUNG='"+sNOI_DUNG+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TRANG_THAI_ID(string sTRANG_THAI_ID,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET TRANG_THAI_ID='"+sTRANG_THAI_ID+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BAI_VIET_CHA_ID(string sBAI_VIET_CHA_ID,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET BAI_VIET_CHA_ID='"+sBAI_VIET_CHA_ID+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DU_AN_ID(string sDU_AN_ID,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET DU_AN_ID='"+sDU_AN_ID+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CHU_DE_ID(string sCHU_DE_ID,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET CHU_DE_ID='"+sCHU_DE_ID+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SORT(string sSORT,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET SORT='"+sSORT+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_XEM(string sXEM,string s_BAI_VIET_ID)
{
  string sqlSave= " UPDATE BV_BAI_VIET SET XEM='"+sXEM+"' WHERE BAI_VIET_ID='"+ s_BAI_VIET_ID+"' ";
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
   string sqlSelect = " SELECT * FROM BV_BAI_VIET";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "BV_BAI_VIET");
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
   private static DataTable dt_BV_BAI_VIET;
   public static bool Change_dt_BV_BAI_VIET = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_BV_BAI_VIET()
   {
   if (dt_BV_BAI_VIET == null || Change_dt_BV_BAI_VIET == true)
     {
   dt_BV_BAI_VIET = GetTableAll();
         Change_dt_BV_BAI_VIET = true && AllowAutoChange ;
     }
     return dt_BV_BAI_VIET;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
