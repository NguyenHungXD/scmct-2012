using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class DA_NHAN_SU:  SQLConnectWeb { 
 public static string sTableName= "DA_NHAN_SU"; 
   public string DATV_ID;
   public string DU_AN_ID;
   public string MEM_ID;
   public string NGAY_THAM_GIA;
   public string NGAY_KET_THUC;
   public string GHI_CHU;
   #region DataColumn Name ;
 public static  string cl_DATV_ID="DATV_ID" ;
 public static  string cl_DU_AN_ID="DU_AN_ID" ;
 public static  string cl_MEM_ID="MEM_ID" ;
 public static  string cl_NGAY_THAM_GIA="NGAY_THAM_GIA" ;
 public static  string cl_NGAY_KET_THUC="NGAY_KET_THUC" ;
 public static  string cl_GHI_CHU="GHI_CHU" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public DA_NHAN_SU() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public DA_NHAN_SU(
         string sDATV_ID,
         string sDU_AN_ID,
         string sMEM_ID,
         string sNGAY_THAM_GIA,
         string sNGAY_KET_THUC,
         string sGHI_CHU){
         this.DATV_ID= sDATV_ID;
         this.DU_AN_ID= sDU_AN_ID;
         this.MEM_ID= sMEM_ID;
         this.NGAY_THAM_GIA= sNGAY_THAM_GIA;
         this.NGAY_KET_THUC= sNGAY_KET_THUC;
         this.GHI_CHU= sGHI_CHU;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static DA_NHAN_SU Create_DA_NHAN_SU ( string sDATV_ID  ){
    DataTable dt=SearchByDATV_ID(sDATV_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new DA_NHAN_SU(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM DA_NHAN_SU AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public DA_NHAN_SU( DataView dv,int pos)
{
         this.DATV_ID= dv[pos][0].ToString();
         this.DU_AN_ID= dv[pos][1].ToString();
         this.MEM_ID= dv[pos][2].ToString();
         this.NGAY_THAM_GIA= dv[pos][3].ToString();
         this.NGAY_KET_THUC= dv[pos][4].ToString();
         this.GHI_CHU= dv[pos][5].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDATV_ID(string sDATV_ID)
{
          string sqlSelect= s_Select()+ " WHERE DATV_ID  ="+ sDATV_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDATV_ID(string sDATV_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DATV_ID"+ sMatch +sDATV_ID + ""; 
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
 public static DataTable SearchByMEM_ID(string sMEM_ID)
{
          string sqlSelect= s_Select()+ " WHERE MEM_ID  ="+ sMEM_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMEM_ID(string sMEM_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE MEM_ID"+ sMatch +sMEM_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_THAM_GIA(string sNGAY_THAM_GIA)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_THAM_GIA  ="+ sNGAY_THAM_GIA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNGAY_THAM_GIA(string sNGAY_THAM_GIA,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAY_THAM_GIA"+ sMatch +sNGAY_THAM_GIA + ""; 
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
 public static DataTable SearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sDATV_ID
            , string sDU_AN_ID
            , string sMEM_ID
            , string sNGAY_THAM_GIA
            , string sNGAY_KET_THUC
            , string sGHI_CHU
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sDATV_ID!=null && sDATV_ID!="") 
            sqlselect +=" AND DATV_ID =" + sDATV_ID ;
      if (sDU_AN_ID!=null && sDU_AN_ID!="") 
            sqlselect +=" AND DU_AN_ID =" + sDU_AN_ID ;
      if (sMEM_ID!=null && sMEM_ID!="") 
            sqlselect +=" AND MEM_ID =" + sMEM_ID ;
      if (sNGAY_THAM_GIA!=null && sNGAY_THAM_GIA!="") 
            sqlselect +=" AND NGAY_THAM_GIA LIKE '%" + sNGAY_THAM_GIA +"%'" ;
      if (sNGAY_KET_THUC!=null && sNGAY_KET_THUC!="") 
            sqlselect +=" AND NGAY_KET_THUC LIKE '%" + sNGAY_KET_THUC +"%'" ;
      if (sGHI_CHU!=null && sGHI_CHU!="") 
            sqlselect +=" AND GHI_CHU LIKE N'%" + sGHI_CHU +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DA_NHAN_SU Insert_Object(
string  sDU_AN_ID
            ,string  sMEM_ID
            ,string  sNGAY_THAM_GIA
            ,string  sNGAY_KET_THUC
            ,string  sGHI_CHU
            ) 
 { 
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sNGAY_THAM_GIA=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_THAM_GIA,"datetime");
              string tem_sNGAY_KET_THUC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_KET_THUC,"datetime");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

             string sqlSave=" INSERT INTO DA_NHAN_SU("+
                   "DU_AN_ID," 
        +                   "MEM_ID," 
        +                   "NGAY_THAM_GIA," 
        +                   "NGAY_KET_THUC," 
        +                   "GHI_CHU) VALUES("
 +tem_sDU_AN_ID+","
 +tem_sMEM_ID+","
 +tem_sNGAY_THAM_GIA+","
 +tem_sNGAY_KET_THUC+","
 +tem_sGHI_CHU +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          DA_NHAN_SU newDA_NHAN_SU= new DA_NHAN_SU();
                 newDA_NHAN_SU.DATV_ID=GetTable( " SELECT TOP 1 DATV_ID FROM DA_NHAN_SU ORDER BY DATV_ID DESC ").Rows[0][0].ToString();
              newDA_NHAN_SU.DU_AN_ID=sDU_AN_ID;
              newDA_NHAN_SU.MEM_ID=sMEM_ID;
              newDA_NHAN_SU.NGAY_THAM_GIA=sNGAY_THAM_GIA;
              newDA_NHAN_SU.NGAY_KET_THUC=sNGAY_KET_THUC;
              newDA_NHAN_SU.GHI_CHU=sGHI_CHU;
            return newDA_NHAN_SU; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sDU_AN_ID
                ,string sMEM_ID
                ,string sNGAY_THAM_GIA
                ,string sNGAY_KET_THUC
                ,string sGHI_CHU
                ) 
 { 
              string tem_sDU_AN_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDU_AN_ID,"bigint");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");
              string tem_sNGAY_THAM_GIA=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_THAM_GIA,"datetime");
              string tem_sNGAY_KET_THUC=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNGAY_KET_THUC,"datetime");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

 string sqlSave=" UPDATE DA_NHAN_SU SET "+"DU_AN_ID ="+tem_sDU_AN_ID+","
 +"MEM_ID ="+tem_sMEM_ID+","
 +"NGAY_THAM_GIA ="+tem_sNGAY_THAM_GIA+","
 +"NGAY_KET_THUC ="+tem_sNGAY_KET_THUC+","
 +"GHI_CHU ="+tem_sGHI_CHU+" WHERE DATV_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.DATV_ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.DU_AN_ID=sDU_AN_ID;
                this.MEM_ID=sMEM_ID;
                this.NGAY_THAM_GIA=sNGAY_THAM_GIA;
                this.NGAY_KET_THUC=sNGAY_KET_THUC;
                this.GHI_CHU=sGHI_CHU;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_DATV_ID(string sDATV_ID)
{
    string sqlSave= " UPDATE DA_NHAN_SU SET DATV_ID='"+ sDATV_ID+ "' WHERE DATV_ID='"+ this.DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DATV_ID=sDATV_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DU_AN_ID(string sDU_AN_ID)
{
    string sqlSave= " UPDATE DA_NHAN_SU SET DU_AN_ID='"+ sDU_AN_ID+ "' WHERE DATV_ID='"+ this.DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DU_AN_ID=sDU_AN_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MEM_ID(string sMEM_ID)
{
    string sqlSave= " UPDATE DA_NHAN_SU SET MEM_ID='"+ sMEM_ID+ "' WHERE DATV_ID='"+ this.DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MEM_ID=sMEM_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_THAM_GIA(string sNGAY_THAM_GIA)
{
    string sqlSave= " UPDATE DA_NHAN_SU SET NGAY_THAM_GIA='"+ sNGAY_THAM_GIA+ "' WHERE DATV_ID='"+ this.DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_THAM_GIA=sNGAY_THAM_GIA;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAY_KET_THUC(string sNGAY_KET_THUC)
{
    string sqlSave= " UPDATE DA_NHAN_SU SET NGAY_KET_THUC='"+ sNGAY_KET_THUC+ "' WHERE DATV_ID='"+ this.DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAY_KET_THUC=sNGAY_KET_THUC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE DA_NHAN_SU SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE DATV_ID='"+ this.DATV_ID+"' ";
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
 public static bool Update_DU_AN_ID(string sDU_AN_ID,string s_DATV_ID)
{
  string sqlSave= " UPDATE DA_NHAN_SU SET DU_AN_ID='"+sDU_AN_ID+"' WHERE DATV_ID='"+ s_DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MEM_ID(string sMEM_ID,string s_DATV_ID)
{
  string sqlSave= " UPDATE DA_NHAN_SU SET MEM_ID='"+sMEM_ID+"' WHERE DATV_ID='"+ s_DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_THAM_GIA(string sNGAY_THAM_GIA,string s_DATV_ID)
{
  string sqlSave= " UPDATE DA_NHAN_SU SET NGAY_THAM_GIA='"+sNGAY_THAM_GIA+"' WHERE DATV_ID='"+ s_DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAY_KET_THUC(string sNGAY_KET_THUC,string s_DATV_ID)
{
  string sqlSave= " UPDATE DA_NHAN_SU SET NGAY_KET_THUC='"+sNGAY_KET_THUC+"' WHERE DATV_ID='"+ s_DATV_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_DATV_ID)
{
  string sqlSave= " UPDATE DA_NHAN_SU SET GHI_CHU='N"+sGHI_CHU+"' WHERE DATV_ID='"+ s_DATV_ID+"' ";
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
   string sqlSelect = " SELECT * FROM DA_NHAN_SU";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "DA_NHAN_SU");
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
   private static DataTable dt_DA_NHAN_SU;
   public static bool Change_dt_DA_NHAN_SU = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_DA_NHAN_SU()
   {
   if (dt_DA_NHAN_SU == null || Change_dt_DA_NHAN_SU == true)
     {
   dt_DA_NHAN_SU = GetTableAll();
         Change_dt_DA_NHAN_SU = true && AllowAutoChange ;
     }
     return dt_DA_NHAN_SU;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
