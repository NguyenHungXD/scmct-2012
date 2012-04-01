using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class TC_PHIEU_CHI:  SQLConnectWeb { 
 public static string sTableName= "TC_PHIEU_CHI"; 
   public string PC_ID;
   public string MA_PC;
   public string NGUOI_CAP_NHAT;
   public string NGAY_CAP_NHAT;
   public string NGUOI_CHI;
   public string NGAY_CHI;
   public string TONG_TIEN;
   public string CHUNG_TU_GOC;
   public string NOI_DUNG_CHI;
   public string DU_AN_ID;
   public string DOI_TUONG_CHI;
   public string MEM_ID;
   #region DataColumn Name ;
 public static  string cl_PC_ID="PC_ID" ;
 public static  string cl_PC_ID_VN="PC_ID";
 public static  string cl_MA_PC="MA_PC" ;
 public static  string cl_MA_PC_VN="MA_PC";
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGUOI_CAP_NHAT_VN="NGUOI_CAP_NHAT";
 public static  string cl_NGAY_CAP_NHAT="NGAY_CAP_NHAT" ;
 public static  string cl_NGAY_CAP_NHAT_VN="NGAY_CAP_NHAT";
 public static  string cl_NGUOI_CHI="NGUOI_CHI" ;
 public static  string cl_NGUOI_CHI_VN="NGUOI_CHI";
 public static  string cl_NGAY_CHI="NGAY_CHI" ;
 public static  string cl_NGAY_CHI_VN="NGAY_CHI";
 public static  string cl_TONG_TIEN="TONG_TIEN" ;
 public static  string cl_TONG_TIEN_VN="TONG_TIEN";
 public static  string cl_CHUNG_TU_GOC="CHUNG_TU_GOC" ;
 public static  string cl_CHUNG_TU_GOC_VN="CHUNG_TU_GOC";
 public static  string cl_NOI_DUNG_CHI="NOI_DUNG_CHI" ;
 public static  string cl_NOI_DUNG_CHI_VN="NOI_DUNG_CHI";
 public static  string cl_DU_AN_ID="DU_AN_ID" ;
 public static  string cl_DU_AN_ID_VN="DU_AN_ID";
 public static  string cl_DOI_TUONG_CHI="DOI_TUONG_CHI" ;
 public static  string cl_DOI_TUONG_CHI_VN="DOI_TUONG_CHI";
 public static  string cl_MEM_ID="MEM_ID" ;
 public static  string cl_MEM_ID_VN="MEM_ID";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public TC_PHIEU_CHI() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public TC_PHIEU_CHI(
         string sPC_ID,
         string sMA_PC,
         string sNGUOI_CAP_NHAT,
         string sNGAY_CAP_NHAT,
         string sNGUOI_CHI,
         string sNGAY_CHI,
         string sTONG_TIEN,
         string sCHUNG_TU_GOC,
         string sNOI_DUNG_CHI,
         string sDU_AN_ID,
         string sDOI_TUONG_CHI,
         string sMEM_ID){
         this.PC_ID= sPC_ID;
         this.MA_PC= sMA_PC;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAY_CAP_NHAT= sNGAY_CAP_NHAT;
         this.NGUOI_CHI= sNGUOI_CHI;
         this.NGAY_CHI= sNGAY_CHI;
         this.TONG_TIEN= sTONG_TIEN;
         this.CHUNG_TU_GOC= sCHUNG_TU_GOC;
         this.NOI_DUNG_CHI= sNOI_DUNG_CHI;
         this.DU_AN_ID= sDU_AN_ID;
         this.DOI_TUONG_CHI= sDOI_TUONG_CHI;
         this.MEM_ID= sMEM_ID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static TC_PHIEU_CHI Create_TC_PHIEU_CHI ( string sPC_ID  ){
    DataTable dt=dtSearchByPC_ID(sPC_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new TC_PHIEU_CHI(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM TC_PHIEU_CHI AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public TC_PHIEU_CHI( DataView dv,int pos)
{
         this.PC_ID= dv[pos][0].ToString();
         this.MA_PC= dv[pos][1].ToString();
         this.NGUOI_CAP_NHAT= dv[pos][2].ToString();
         this.NGAY_CAP_NHAT= dv[pos][3].ToString();
         this.NGUOI_CHI= dv[pos][4].ToString();
         this.NGAY_CHI= dv[pos][5].ToString();
         this.TONG_TIEN= dv[pos][6].ToString();
         this.CHUNG_TU_GOC= dv[pos][7].ToString();
         this.NOI_DUNG_CHI= dv[pos][8].ToString();
         this.DU_AN_ID= dv[pos][9].ToString();
         this.DOI_TUONG_CHI= dv[pos][10].ToString();
         this.MEM_ID= dv[pos][11].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPC_ID(string sPC_ID)
{
          string sqlSelect= s_Select()+ " WHERE PC_ID  ="+ sPC_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPC_ID(string sPC_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PC_ID"+ sMatch +sPC_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMA_PC(string sMA_PC)
{
          string sqlSelect= s_Select()+ " WHERE MA_PC  Like N'%"+ sMA_PC + "%'"; 
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
 public static DataTable dtSearchByNGUOI_CHI(string sNGUOI_CHI)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CHI  ="+ sNGUOI_CHI + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOI_CHI(string sNGUOI_CHI,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_CHI"+ sMatch +sNGUOI_CHI + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_CHI(string sNGAY_CHI)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CHI  ="+ sNGAY_CHI + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAY_CHI(string sNGAY_CHI,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_CHI"+ sMatch +sNGAY_CHI + ""; 
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
 public static DataTable dtSearchByNOI_DUNG_CHI(string sNOI_DUNG_CHI)
{
          string sqlSelect= s_Select()+ " WHERE NOI_DUNG_CHI  Like N'%"+ sNOI_DUNG_CHI + "%'"; 
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
 public static DataTable dtSearchByDOI_TUONG_CHI(string sDOI_TUONG_CHI)
{
          string sqlSelect= s_Select()+ " WHERE DOI_TUONG_CHI  Like N'%"+ sDOI_TUONG_CHI + "%'"; 
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
 public static DataTable dtSearch( string sPC_ID
            , string sMA_PC
            , string sNGUOI_CAP_NHAT
            , string sNGAY_CAP_NHAT
            , string sNGUOI_CHI
            , string sNGAY_CHI
            , string sTONG_TIEN
            , string sCHUNG_TU_GOC
            , string sNOI_DUNG_CHI
            , string sDU_AN_ID
            , string sDOI_TUONG_CHI
            , string sMEM_ID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sPC_ID!=null && sPC_ID!="") 
            sqlselect +=" AND PC_ID =" + sPC_ID ;
      if (sMA_PC!=null && sMA_PC!="") 
            sqlselect +=" AND MA_PC LIKE N'%" + sMA_PC +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT =" + sNGUOI_CAP_NHAT ;
      if (sNGAY_CAP_NHAT!=null && sNGAY_CAP_NHAT!="") 
            sqlselect +=" AND NGAY_CAP_NHAT LIKE '%" + sNGAY_CAP_NHAT +"%'" ;
      if (sNGUOI_CHI!=null && sNGUOI_CHI!="") 
            sqlselect +=" AND NGUOI_CHI =" + sNGUOI_CHI ;
      if (sNGAY_CHI!=null && sNGAY_CHI!="") 
            sqlselect +=" AND NGAY_CHI LIKE '%" + sNGAY_CHI +"%'" ;
      if (sTONG_TIEN!=null && sTONG_TIEN!="") 
            sqlselect +=" AND TONG_TIEN =" + sTONG_TIEN ;
      if (sCHUNG_TU_GOC!=null && sCHUNG_TU_GOC!="") 
            sqlselect +=" AND CHUNG_TU_GOC LIKE N'%" + sCHUNG_TU_GOC +"%'" ;
      if (sNOI_DUNG_CHI!=null && sNOI_DUNG_CHI!="") 
            sqlselect +=" AND NOI_DUNG_CHI LIKE N'%" + sNOI_DUNG_CHI +"%'" ;
      if (sDU_AN_ID!=null && sDU_AN_ID!="") 
            sqlselect +=" AND DU_AN_ID =" + sDU_AN_ID ;
      if (sDOI_TUONG_CHI!=null && sDOI_TUONG_CHI!="") 
            sqlselect +=" AND DOI_TUONG_CHI LIKE N'%" + sDOI_TUONG_CHI +"%'" ;
      if (sMEM_ID!=null && sMEM_ID!="") 
            sqlselect +=" AND MEM_ID =" + sMEM_ID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static TC_PHIEU_CHI Insert_Object(
string  sPC_ID
            ,string  sMA_PC
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ,string  sNGUOI_CHI
            ,string  sNGAY_CHI
            ,string  sTONG_TIEN
            ,string  sCHUNG_TU_GOC
            ,string  sNOI_DUNG_CHI
            ,string  sDU_AN_ID
            ,string  sDOI_TUONG_CHI
            ,string  sMEM_ID
            ) 
 { 
              string tem_sPC_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPC_ID,"bigint");
              string tem_sMA_PC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PC,"nvarchar");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CHI,"bigint");
              string tem_sNGAY_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CHI,"datetime");
              string tem_sTONG_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTONG_TIEN,"float");
              string tem_sCHUNG_TU_GOC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU_GOC,"nvarchar");
              string tem_sNOI_DUNG_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG_CHI,"nvarchar");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sDOI_TUONG_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDOI_TUONG_CHI,"nvarchar");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");

             string sqlSave=" INSERT INTO TC_PHIEU_CHI("+
                   "PC_ID," 
        +                   "MA_PC," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAY_CAP_NHAT," 
        +                   "NGUOI_CHI," 
        +                   "NGAY_CHI," 
        +                   "TONG_TIEN," 
        +                   "CHUNG_TU_GOC," 
        +                   "NOI_DUNG_CHI," 
        +                   "DU_AN_ID," 
        +                   "DOI_TUONG_CHI," 
        +                   "MEM_ID) VALUES("
 +tem_sPC_ID+","
 +tem_sMA_PC+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAY_CAP_NHAT+","
 +tem_sNGUOI_CHI+","
 +tem_sNGAY_CHI+","
 +tem_sTONG_TIEN+","
 +tem_sCHUNG_TU_GOC+","
 +tem_sNOI_DUNG_CHI+","
 +tem_sDU_AN_ID+","
 +tem_sDOI_TUONG_CHI+","
 +tem_sMEM_ID +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          TC_PHIEU_CHI newTC_PHIEU_CHI= new TC_PHIEU_CHI();
              newTC_PHIEU_CHI.PC_ID=sPC_ID;
              newTC_PHIEU_CHI.MA_PC=sMA_PC;
              newTC_PHIEU_CHI.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newTC_PHIEU_CHI.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
              newTC_PHIEU_CHI.NGUOI_CHI=sNGUOI_CHI;
              newTC_PHIEU_CHI.NGAY_CHI=sNGAY_CHI;
              newTC_PHIEU_CHI.TONG_TIEN=sTONG_TIEN;
              newTC_PHIEU_CHI.CHUNG_TU_GOC=sCHUNG_TU_GOC;
              newTC_PHIEU_CHI.NOI_DUNG_CHI=sNOI_DUNG_CHI;
              newTC_PHIEU_CHI.DU_AN_ID=sDU_AN_ID;
              newTC_PHIEU_CHI.DOI_TUONG_CHI=sDOI_TUONG_CHI;
              newTC_PHIEU_CHI.MEM_ID=sMEM_ID;
            return newTC_PHIEU_CHI; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sPC_ID
                ,string sMA_PC
                ,string sNGUOI_CAP_NHAT
                ,string sNGAY_CAP_NHAT
                ,string sNGUOI_CHI
                ,string sNGAY_CHI
                ,string sTONG_TIEN
                ,string sCHUNG_TU_GOC
                ,string sNOI_DUNG_CHI
                ,string sDU_AN_ID
                ,string sDOI_TUONG_CHI
                ,string sMEM_ID
                ) 
 { 
              string tem_sMA_PC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_PC,"nvarchar");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"bigint");
              string tem_sNGAY_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT,"datetime");
              string tem_sNGUOI_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CHI,"bigint");
              string tem_sNGAY_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CHI,"datetime");
              string tem_sTONG_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTONG_TIEN,"float");
              string tem_sCHUNG_TU_GOC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCHUNG_TU_GOC,"nvarchar");
              string tem_sNOI_DUNG_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG_CHI,"nvarchar");
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sDOI_TUONG_CHI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDOI_TUONG_CHI,"nvarchar");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");

 string sqlSave=" UPDATE TC_PHIEU_CHI SET "+"MA_PC ="+tem_sMA_PC+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAY_CAP_NHAT ="+tem_sNGAY_CAP_NHAT+","
 +"NGUOI_CHI ="+tem_sNGUOI_CHI+","
 +"NGAY_CHI ="+tem_sNGAY_CHI+","
 +"TONG_TIEN ="+tem_sTONG_TIEN+","
 +"CHUNG_TU_GOC ="+tem_sCHUNG_TU_GOC+","
 +"NOI_DUNG_CHI ="+tem_sNOI_DUNG_CHI+","
 +"DU_AN_ID ="+tem_sDU_AN_ID+","
 +"DOI_TUONG_CHI ="+tem_sDOI_TUONG_CHI+","
 +"MEM_ID ="+tem_sMEM_ID+" WHERE PC_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.PC_ID,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.MA_PC=sMA_PC;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
                this.NGUOI_CHI=sNGUOI_CHI;
                this.NGAY_CHI=sNGAY_CHI;
                this.TONG_TIEN=sTONG_TIEN;
                this.CHUNG_TU_GOC=sCHUNG_TU_GOC;
                this.NOI_DUNG_CHI=sNOI_DUNG_CHI;
                this.DU_AN_ID=sDU_AN_ID;
                this.DOI_TUONG_CHI=sDOI_TUONG_CHI;
                this.MEM_ID=sMEM_ID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_PC_ID(string sPC_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET PC_ID='"+ sPC_ID+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PC_ID=sPC_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MA_PC(string sMA_PC)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET MA_PC='N"+ sMA_PC+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MA_PC=sMA_PC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
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
    string sqlSave= " UPDATE TC_PHIEU_CHI SET NGAY_CAP_NHAT='"+ sNGAY_CAP_NHAT+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_CAP_NHAT=sNGAY_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CHI(string sNGUOI_CHI)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET NGUOI_CHI='"+ sNGUOI_CHI+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGUOI_CHI=sNGUOI_CHI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_CHI(string sNGAY_CHI)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET NGAY_CHI='"+ sNGAY_CHI+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NGAY_CHI=sNGAY_CHI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TONG_TIEN(string sTONG_TIEN)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET TONG_TIEN='"+ sTONG_TIEN+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
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
    string sqlSave= " UPDATE TC_PHIEU_CHI SET CHUNG_TU_GOC='N"+ sCHUNG_TU_GOC+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CHUNG_TU_GOC=sCHUNG_TU_GOC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NOI_DUNG_CHI(string sNOI_DUNG_CHI)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET NOI_DUNG_CHI='N"+ sNOI_DUNG_CHI+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NOI_DUNG_CHI=sNOI_DUNG_CHI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DU_AN_ID(string sDU_AN_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET DU_AN_ID='"+ sDU_AN_ID+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DU_AN_ID=sDU_AN_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DOI_TUONG_CHI(string sDOI_TUONG_CHI)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET DOI_TUONG_CHI='N"+ sDOI_TUONG_CHI+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DOI_TUONG_CHI=sDOI_TUONG_CHI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MEM_ID(string sMEM_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_CHI SET MEM_ID='"+ sMEM_ID+ "' WHERE PC_ID='"+ this.PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MEM_ID=sMEM_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_PC_ID(string sPC_ID,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET PC_ID='"+sPC_ID+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MA_PC(string sMA_PC,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET MA_PC='N"+sMA_PC+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CAP_NHAT(string sNGAY_CAP_NHAT,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET NGAY_CAP_NHAT='"+sNGAY_CAP_NHAT+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CHI(string sNGUOI_CHI,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET NGUOI_CHI='"+sNGUOI_CHI+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_CHI(string sNGAY_CHI,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET NGAY_CHI='"+sNGAY_CHI+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TONG_TIEN(string sTONG_TIEN,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET TONG_TIEN='"+sTONG_TIEN+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CHUNG_TU_GOC(string sCHUNG_TU_GOC,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET CHUNG_TU_GOC='N"+sCHUNG_TU_GOC+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NOI_DUNG_CHI(string sNOI_DUNG_CHI,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET NOI_DUNG_CHI='N"+sNOI_DUNG_CHI+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DU_AN_ID(string sDU_AN_ID,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET DU_AN_ID='"+sDU_AN_ID+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DOI_TUONG_CHI(string sDOI_TUONG_CHI,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET DOI_TUONG_CHI='N"+sDOI_TUONG_CHI+"' WHERE PC_ID='"+ s_PC_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MEM_ID(string sMEM_ID,string s_PC_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_CHI SET MEM_ID='"+sMEM_ID+"' WHERE PC_ID='"+ s_PC_ID+"' ";
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
   string sqlSelect = " SELECT * FROM TC_PHIEU_CHI";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "TC_PHIEU_CHI");
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
   private static DataTable dt_TC_PHIEU_CHI;
   public static bool Change_dt_TC_PHIEU_CHI = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_TC_PHIEU_CHI()
   {
   if (dt_TC_PHIEU_CHI == null || Change_dt_TC_PHIEU_CHI == true)
     {
   dt_TC_PHIEU_CHI = dtGetTableAll();
         Change_dt_TC_PHIEU_CHI = true && AllowAutoChange ;
     }
     return dt_TC_PHIEU_CHI;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
