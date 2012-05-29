using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class YC_YEU_CAU:  SQLConnectWeb { 
 public static string sTableName= "YC_YEU_CAU"; 
   public string YEU_CAU_ID;
   public string TIEU_DE;
   public string NOI_DUNG;
   public string TRANG_THAI_ID;
   public string LOAI_YC_ID;
   public string NGUOI_YEU_CAU;
   public string NGAY_YEU_CAU;
   public string NGUOI_CAP_NHAT;
   public string NGAYC_CAP_NHAT;
   #region DataColumn Name ;
 public static  string cl_YEU_CAU_ID="YEU_CAU_ID" ;
 public static  string cl_TIEU_DE="TIEU_DE" ;
 public static  string cl_NOI_DUNG="NOI_DUNG" ;
 public static  string cl_TRANG_THAI_ID="TRANG_THAI_ID" ;
 public static  string cl_LOAI_YC_ID="LOAI_YC_ID" ;
 public static  string cl_NGUOI_YEU_CAU="NGUOI_YEU_CAU" ;
 public static  string cl_NGAY_YEU_CAU="NGAY_YEU_CAU" ;
 public static  string cl_NGUOI_CAP_NHAT="NGUOI_CAP_NHAT" ;
 public static  string cl_NGAYC_CAP_NHAT="NGAYC_CAP_NHAT" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public YC_YEU_CAU() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public YC_YEU_CAU(
         string sYEU_CAU_ID,
         string sTIEU_DE,
         string sNOI_DUNG,
         string sTRANG_THAI_ID,
         string sLOAI_YC_ID,
         string sNGUOI_YEU_CAU,
         string sNGAY_YEU_CAU,
         string sNGUOI_CAP_NHAT,
         string sNGAYC_CAP_NHAT){
         this.YEU_CAU_ID= sYEU_CAU_ID;
         this.TIEU_DE= sTIEU_DE;
         this.NOI_DUNG= sNOI_DUNG;
         this.TRANG_THAI_ID= sTRANG_THAI_ID;
         this.LOAI_YC_ID= sLOAI_YC_ID;
         this.NGUOI_YEU_CAU= sNGUOI_YEU_CAU;
         this.NGAY_YEU_CAU= sNGAY_YEU_CAU;
         this.NGUOI_CAP_NHAT= sNGUOI_CAP_NHAT;
         this.NGAYC_CAP_NHAT= sNGAYC_CAP_NHAT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static YC_YEU_CAU Create_YC_YEU_CAU ( string sYEU_CAU_ID  ){
    DataTable dt=SearchByYEU_CAU_ID(sYEU_CAU_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new YC_YEU_CAU(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM YC_YEU_CAU AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public YC_YEU_CAU( DataTable table,int pos)
{
         this.YEU_CAU_ID= table.Rows[pos]["YEU_CAU_ID"].ToString();
         this.TIEU_DE= table.Rows[pos]["TIEU_DE"].ToString();
         this.NOI_DUNG= table.Rows[pos]["NOI_DUNG"].ToString();
         this.TRANG_THAI_ID= table.Rows[pos]["TRANG_THAI_ID"].ToString();
         this.LOAI_YC_ID= table.Rows[pos]["LOAI_YC_ID"].ToString();
         this.NGUOI_YEU_CAU= table.Rows[pos]["NGUOI_YEU_CAU"].ToString();
         this.NGAY_YEU_CAU= table.Rows[pos]["NGAY_YEU_CAU"].ToString();
         this.NGUOI_CAP_NHAT= table.Rows[pos]["NGUOI_CAP_NHAT"].ToString();
         this.NGAYC_CAP_NHAT= table.Rows[pos]["NGAYC_CAP_NHAT"].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
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
 public static DataTable SearchByTIEU_DE(string sTIEU_DE)
{
          string sqlSelect= s_Select()+ " WHERE TIEU_DE  Like N'%"+ sTIEU_DE + "%'"; 
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
 public static DataTable SearchByLOAI_YC_ID(string sLOAI_YC_ID)
{
          string sqlSelect= s_Select()+ " WHERE LOAI_YC_ID  ="+ sLOAI_YC_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByLOAI_YC_ID(string sLOAI_YC_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LOAI_YC_ID"+ sMatch +sLOAI_YC_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_YEU_CAU(string sNGUOI_YEU_CAU)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_YEU_CAU  ="+ sNGUOI_YEU_CAU + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGUOI_YEU_CAU(string sNGUOI_YEU_CAU,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOI_YEU_CAU"+ sMatch +sNGUOI_YEU_CAU + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_YEU_CAU(string sNGAY_YEU_CAU)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_YEU_CAU  ="+ sNGAY_YEU_CAU + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_YEU_CAU(string sNGAY_YEU_CAU,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_YEU_CAU"+ sMatch +sNGAY_YEU_CAU + ""; 
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
 public static DataTable SearchByNGAYC_CAP_NHAT(string sNGAYC_CAP_NHAT)
{
          string sqlSelect= s_Select()+ " WHERE NGAYC_CAP_NHAT  ="+ sNGAYC_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAYC_CAP_NHAT(string sNGAYC_CAP_NHAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAYC_CAP_NHAT"+ sMatch +sNGAYC_CAP_NHAT + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sYEU_CAU_ID
            , string sTIEU_DE
            , string sNOI_DUNG
            , string sTRANG_THAI_ID
            , string sLOAI_YC_ID
            , string sNGUOI_YEU_CAU
            , string sNGAY_YEU_CAU
            , string sNGUOI_CAP_NHAT
            , string sNGAYC_CAP_NHAT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sYEU_CAU_ID!=null && sYEU_CAU_ID!="") 
            sqlselect +=" AND YEU_CAU_ID =" + sYEU_CAU_ID ;
      if (sTIEU_DE!=null && sTIEU_DE!="") 
            sqlselect +=" AND TIEU_DE LIKE N'%" + sTIEU_DE +"%'" ;
      if (sNOI_DUNG!=null && sNOI_DUNG!="") 
            sqlselect +=" AND NOI_DUNG LIKE '%" + sNOI_DUNG +"%'" ;
      if (sTRANG_THAI_ID!=null && sTRANG_THAI_ID!="") 
            sqlselect +=" AND TRANG_THAI_ID =" + sTRANG_THAI_ID ;
      if (sLOAI_YC_ID!=null && sLOAI_YC_ID!="") 
            sqlselect +=" AND LOAI_YC_ID =" + sLOAI_YC_ID ;
      if (sNGUOI_YEU_CAU!=null && sNGUOI_YEU_CAU!="") 
            sqlselect +=" AND NGUOI_YEU_CAU =" + sNGUOI_YEU_CAU ;
      if (sNGAY_YEU_CAU!=null && sNGAY_YEU_CAU!="") 
            sqlselect +=" AND NGAY_YEU_CAU LIKE '%" + sNGAY_YEU_CAU +"%'" ;
      if (sNGUOI_CAP_NHAT!=null && sNGUOI_CAP_NHAT!="") 
            sqlselect +=" AND NGUOI_CAP_NHAT LIKE '%" + sNGUOI_CAP_NHAT +"%'" ;
      if (sNGAYC_CAP_NHAT!=null && sNGAYC_CAP_NHAT!="") 
            sqlselect +=" AND NGAYC_CAP_NHAT =" + sNGAYC_CAP_NHAT ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect,sTableName);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static YC_YEU_CAU Insert_Object(
string  sTIEU_DE
            ,string  sNOI_DUNG
            ,string  sTRANG_THAI_ID
            ,string  sLOAI_YC_ID
            ,string  sNGUOI_YEU_CAU
            ,string  sNGAY_YEU_CAU
            ,string  sNGUOI_CAP_NHAT
            ,string  sNGAY_CAP_NHAT
            ) 
 { 
              string tem_sTIEU_DE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTIEU_DE,"nvarchar");
              string tem_sNOI_DUNG=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG,"ntext");
              string tem_sTRANG_THAI_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTRANG_THAI_ID,"bigint");
              string tem_sLOAI_YC_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLOAI_YC_ID,"bigint");
              string tem_sNGUOI_YEU_CAU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_YEU_CAU,"bigint");
              string tem_sNGAY_YEU_CAU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_YEU_CAU,"datetime");
              string tem_sNGUOI_CAP_NHAT = DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT, "bigint");
              string tem_sNGAYC_CAP_NHAT = DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_CAP_NHAT, "datetime");

             string sqlSave=" INSERT INTO YC_YEU_CAU("+
                   "TIEU_DE," 
        +                   "NOI_DUNG," 
        +                   "TRANG_THAI_ID," 
        +                   "LOAI_YC_ID," 
        +                   "NGUOI_YEU_CAU," 
        +                   "NGAY_YEU_CAU," 
        +                   "NGUOI_CAP_NHAT," 
        +                   "NGAYC_CAP_NHAT) VALUES("
 +tem_sTIEU_DE+","
 +tem_sNOI_DUNG+","
 +tem_sTRANG_THAI_ID+","
 +tem_sLOAI_YC_ID+","
 +tem_sNGUOI_YEU_CAU+","
 +tem_sNGAY_YEU_CAU+","
 +tem_sNGUOI_CAP_NHAT+","
 +tem_sNGAYC_CAP_NHAT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          YC_YEU_CAU newYC_YEU_CAU= new YC_YEU_CAU();
                 newYC_YEU_CAU.YEU_CAU_ID=GetTable( " SELECT TOP 1 YEU_CAU_ID FROM YC_YEU_CAU ORDER BY YEU_CAU_ID DESC ").Rows[0][0].ToString();
              newYC_YEU_CAU.TIEU_DE=sTIEU_DE;
              newYC_YEU_CAU.NOI_DUNG=sNOI_DUNG;
              newYC_YEU_CAU.TRANG_THAI_ID=sTRANG_THAI_ID;
              newYC_YEU_CAU.LOAI_YC_ID=sLOAI_YC_ID;
              newYC_YEU_CAU.NGUOI_YEU_CAU=sNGUOI_YEU_CAU;
              newYC_YEU_CAU.NGAY_YEU_CAU=sNGAY_YEU_CAU;
              newYC_YEU_CAU.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
              newYC_YEU_CAU.NGAYC_CAP_NHAT=sNGAY_CAP_NHAT;
            return newYC_YEU_CAU; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sTIEU_DE
                ,string sNOI_DUNG
                ,string sTRANG_THAI_ID
                ,string sLOAI_YC_ID
                ,string sNGUOI_YEU_CAU
                ,string sNGAY_YEU_CAU
                ,string sNGUOI_CAP_NHAT
                ,string sNGAYC_CAP_NHAT
                ) 
 { 
              string tem_sTIEU_DE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTIEU_DE,"nvarchar");
              string tem_sNOI_DUNG=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOI_DUNG,"ntext");
              string tem_sTRANG_THAI_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTRANG_THAI_ID,"bigint");
              string tem_sLOAI_YC_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLOAI_YC_ID,"bigint");
              string tem_sNGUOI_YEU_CAU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_YEU_CAU,"bigint");
              string tem_sNGAY_YEU_CAU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_YEU_CAU,"datetime");
              string tem_sNGUOI_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGUOI_CAP_NHAT,"datetime");
              string tem_sNGAYC_CAP_NHAT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAYC_CAP_NHAT,"bigint");

 string sqlSave=" UPDATE YC_YEU_CAU SET "+"TIEU_DE ="+tem_sTIEU_DE+","
 +"NOI_DUNG ="+tem_sNOI_DUNG+","
 +"TRANG_THAI_ID ="+tem_sTRANG_THAI_ID+","
 +"LOAI_YC_ID ="+tem_sLOAI_YC_ID+","
 +"NGUOI_YEU_CAU ="+tem_sNGUOI_YEU_CAU+","
 +"NGAY_YEU_CAU ="+tem_sNGAY_YEU_CAU+","
 +"NGUOI_CAP_NHAT ="+tem_sNGUOI_CAP_NHAT+","
 +"NGAYC_CAP_NHAT ="+tem_sNGAYC_CAP_NHAT+" WHERE YEU_CAU_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.YEU_CAU_ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.TIEU_DE=sTIEU_DE;
                this.NOI_DUNG=sNOI_DUNG;
                this.TRANG_THAI_ID=sTRANG_THAI_ID;
                this.LOAI_YC_ID=sLOAI_YC_ID;
                this.NGUOI_YEU_CAU=sNGUOI_YEU_CAU;
                this.NGAY_YEU_CAU=sNGAY_YEU_CAU;
                this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
                this.NGAYC_CAP_NHAT=sNGAYC_CAP_NHAT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_YEU_CAU_ID(string sYEU_CAU_ID)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET YEU_CAU_ID='"+ sYEU_CAU_ID+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.YEU_CAU_ID=sYEU_CAU_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TIEU_DE(string sTIEU_DE)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET TIEU_DE='N"+ sTIEU_DE+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TIEU_DE=sTIEU_DE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NOI_DUNG(string sNOI_DUNG)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET NOI_DUNG='"+ sNOI_DUNG+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
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
    string sqlSave= " UPDATE YC_YEU_CAU SET TRANG_THAI_ID='"+ sTRANG_THAI_ID+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TRANG_THAI_ID=sTRANG_THAI_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LOAI_YC_ID(string sLOAI_YC_ID)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET LOAI_YC_ID='"+ sLOAI_YC_ID+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.LOAI_YC_ID=sLOAI_YC_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_YEU_CAU(string sNGUOI_YEU_CAU)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET NGUOI_YEU_CAU='"+ sNGUOI_YEU_CAU+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_YEU_CAU=sNGUOI_YEU_CAU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_YEU_CAU(string sNGAY_YEU_CAU)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET NGAY_YEU_CAU='"+ sNGAY_YEU_CAU+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_YEU_CAU=sNGAY_YEU_CAU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET NGUOI_CAP_NHAT='"+ sNGUOI_CAP_NHAT+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOI_CAP_NHAT=sNGUOI_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAYC_CAP_NHAT(string sNGAYC_CAP_NHAT)
{
    string sqlSave= " UPDATE YC_YEU_CAU SET NGAYC_CAP_NHAT='"+ sNGAYC_CAP_NHAT+ "' WHERE YEU_CAU_ID='"+ this.YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAYC_CAP_NHAT=sNGAYC_CAP_NHAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_TIEU_DE(string sTIEU_DE,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET TIEU_DE='N"+sTIEU_DE+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NOI_DUNG(string sNOI_DUNG,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET NOI_DUNG='"+sNOI_DUNG+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TRANG_THAI_ID(string sTRANG_THAI_ID,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET TRANG_THAI_ID='"+sTRANG_THAI_ID+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LOAI_YC_ID(string sLOAI_YC_ID,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET LOAI_YC_ID='"+sLOAI_YC_ID+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_YEU_CAU(string sNGUOI_YEU_CAU,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET NGUOI_YEU_CAU='"+sNGUOI_YEU_CAU+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_YEU_CAU(string sNGAY_YEU_CAU,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET NGAY_YEU_CAU='"+sNGAY_YEU_CAU+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOI_CAP_NHAT(string sNGUOI_CAP_NHAT,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET NGUOI_CAP_NHAT='"+sNGUOI_CAP_NHAT+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAYC_CAP_NHAT(string sNGAYC_CAP_NHAT,string s_YEU_CAU_ID)
{
  string sqlSave= " UPDATE YC_YEU_CAU SET NGAYC_CAP_NHAT='"+sNGAYC_CAP_NHAT+"' WHERE YEU_CAU_ID='"+ s_YEU_CAU_ID+"' ";
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
   string sqlSelect = " SELECT * FROM YC_YEU_CAU";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "YC_YEU_CAU");
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
   private static DataTable dt_YC_YEU_CAU;
   public static bool Change_dt_YC_YEU_CAU = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_YC_YEU_CAU()
   {
   if (dt_YC_YEU_CAU == null || Change_dt_YC_YEU_CAU == true)
     {
   dt_YC_YEU_CAU = GetTableAll();
         Change_dt_YC_YEU_CAU = true && AllowAutoChange ;
     }
     return dt_YC_YEU_CAU;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
