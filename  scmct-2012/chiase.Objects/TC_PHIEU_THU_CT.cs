using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class TC_PHIEU_THU_CT:  SQLConnectWeb { 
 public static string sTableName= "TC_PHIEU_THU_CT"; 
   public string PTCT_ID;
   public string PT_ID;
   public string DIEN_GIAI;
   public string SO_TIEN;
   public string GHI_CHU;
   #region DataColumn Name ;
 public static  string cl_PTCT_ID="PTCT_ID" ;
 public static  string cl_PTCT_ID_VN="PTCT_ID";
 public static  string cl_PT_ID="PT_ID" ;
 public static  string cl_PT_ID_VN="PT_ID";
 public static  string cl_DIEN_GIAI="DIEN_GIAI" ;
 public static  string cl_DIEN_GIAI_VN="DIEN_GIAI";
 public static  string cl_SO_TIEN="SO_TIEN" ;
 public static  string cl_SO_TIEN_VN="SO_TIEN";
 public static  string cl_GHI_CHU="GHI_CHU" ;
 public static  string cl_GHI_CHU_VN="GHI_CHU";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public TC_PHIEU_THU_CT() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public TC_PHIEU_THU_CT(
         string sPTCT_ID,
         string sPT_ID,
         string sDIEN_GIAI,
         string sSO_TIEN,
         string sGHI_CHU){
         this.PTCT_ID= sPTCT_ID;
         this.PT_ID= sPT_ID;
         this.DIEN_GIAI= sDIEN_GIAI;
         this.SO_TIEN= sSO_TIEN;
         this.GHI_CHU= sGHI_CHU;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static TC_PHIEU_THU_CT Create_TC_PHIEU_THU_CT ( string sPTCT_ID  ){
    DataTable dt=dtSearchByPTCT_ID(sPTCT_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new TC_PHIEU_THU_CT(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM TC_PHIEU_THU_CT AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public TC_PHIEU_THU_CT( DataView dv,int pos)
{
         this.PTCT_ID= dv[pos][0].ToString();
         this.PT_ID= dv[pos][1].ToString();
         this.DIEN_GIAI= dv[pos][2].ToString();
         this.SO_TIEN= dv[pos][3].ToString();
         this.GHI_CHU= dv[pos][4].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPTCT_ID(string sPTCT_ID)
{
          string sqlSelect= s_Select()+ " WHERE PTCT_ID  ="+ sPTCT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPTCT_ID(string sPTCT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PTCT_ID"+ sMatch +sPTCT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
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
 public static DataTable dtSearchByDIEN_GIAI(string sDIEN_GIAI)
{
          string sqlSelect= s_Select()+ " WHERE DIEN_GIAI  Like N'%"+ sDIEN_GIAI + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySO_TIEN(string sSO_TIEN)
{
          string sqlSelect= s_Select()+ " WHERE SO_TIEN  ="+ sSO_TIEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySO_TIEN(string sSO_TIEN,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SO_TIEN"+ sMatch +sSO_TIEN + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sPTCT_ID
            , string sPT_ID
            , string sDIEN_GIAI
            , string sSO_TIEN
            , string sGHI_CHU
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sPTCT_ID!=null && sPTCT_ID!="") 
            sqlselect +=" AND PTCT_ID =" + sPTCT_ID ;
      if (sPT_ID!=null && sPT_ID!="") 
            sqlselect +=" AND PT_ID =" + sPT_ID ;
      if (sDIEN_GIAI!=null && sDIEN_GIAI!="") 
            sqlselect +=" AND DIEN_GIAI LIKE N'%" + sDIEN_GIAI +"%'" ;
      if (sSO_TIEN!=null && sSO_TIEN!="") 
            sqlselect +=" AND SO_TIEN =" + sSO_TIEN ;
      if (sGHI_CHU!=null && sGHI_CHU!="") 
            sqlselect +=" AND GHI_CHU LIKE N'%" + sGHI_CHU +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static TC_PHIEU_THU_CT Insert_Object(
string  sPT_ID
            ,string  sDIEN_GIAI
            ,string  sSO_TIEN
            ,string  sGHI_CHU
            ) 
 { 
              string tem_sPT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPT_ID,"bigint");
              string tem_sDIEN_GIAI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDIEN_GIAI,"nvarchar");
              string tem_sSO_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSO_TIEN,"float");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

             string sqlSave=" INSERT INTO TC_PHIEU_THU_CT("+
                   "PT_ID," 
        +                   "DIEN_GIAI," 
        +                   "SO_TIEN," 
        +                   "GHI_CHU) VALUES("
 +tem_sPT_ID+","
 +tem_sDIEN_GIAI+","
 +tem_sSO_TIEN+","
 +tem_sGHI_CHU +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          TC_PHIEU_THU_CT newTC_PHIEU_THU_CT= new TC_PHIEU_THU_CT();
                 newTC_PHIEU_THU_CT.PTCT_ID=GetTable( " SELECT TOP 1 PTCT_ID FROM TC_PHIEU_THU_CT ORDER BY PTCT_ID DESC ").Rows[0][0].ToString();
              newTC_PHIEU_THU_CT.PT_ID=sPT_ID;
              newTC_PHIEU_THU_CT.DIEN_GIAI=sDIEN_GIAI;
              newTC_PHIEU_THU_CT.SO_TIEN=sSO_TIEN;
              newTC_PHIEU_THU_CT.GHI_CHU=sGHI_CHU;
            return newTC_PHIEU_THU_CT; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sPT_ID
                ,string sDIEN_GIAI
                ,string sSO_TIEN
                ,string sGHI_CHU
                ) 
 { 
              string tem_sPT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPT_ID,"bigint");
              string tem_sDIEN_GIAI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDIEN_GIAI,"nvarchar");
              string tem_sSO_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSO_TIEN,"float");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");

 string sqlSave=" UPDATE TC_PHIEU_THU_CT SET "+"PT_ID ="+tem_sPT_ID+","
 +"DIEN_GIAI ="+tem_sDIEN_GIAI+","
 +"SO_TIEN ="+tem_sSO_TIEN+","
 +"GHI_CHU ="+tem_sGHI_CHU+" WHERE PTCT_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.PTCT_ID,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.PT_ID=sPT_ID;
                this.DIEN_GIAI=sDIEN_GIAI;
                this.SO_TIEN=sSO_TIEN;
                this.GHI_CHU=sGHI_CHU;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_PTCT_ID(string sPTCT_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_THU_CT SET PTCT_ID='"+ sPTCT_ID+ "' WHERE PTCT_ID='"+ this.PTCT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PTCT_ID=sPTCT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PT_ID(string sPT_ID)
{
    string sqlSave= " UPDATE TC_PHIEU_THU_CT SET PT_ID='"+ sPT_ID+ "' WHERE PTCT_ID='"+ this.PTCT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PT_ID=sPT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DIEN_GIAI(string sDIEN_GIAI)
{
    string sqlSave= " UPDATE TC_PHIEU_THU_CT SET DIEN_GIAI='N"+ sDIEN_GIAI+ "' WHERE PTCT_ID='"+ this.PTCT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DIEN_GIAI=sDIEN_GIAI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SO_TIEN(string sSO_TIEN)
{
    string sqlSave= " UPDATE TC_PHIEU_THU_CT SET SO_TIEN='"+ sSO_TIEN+ "' WHERE PTCT_ID='"+ this.PTCT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.SO_TIEN=sSO_TIEN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE TC_PHIEU_THU_CT SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE PTCT_ID='"+ this.PTCT_ID+"' ";
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
 public static bool Update_PT_ID(string sPT_ID,string s_PTCT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU_CT SET PT_ID='"+sPT_ID+"' WHERE PTCT_ID='"+ s_PTCT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DIEN_GIAI(string sDIEN_GIAI,string s_PTCT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU_CT SET DIEN_GIAI='N"+sDIEN_GIAI+"' WHERE PTCT_ID='"+ s_PTCT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SO_TIEN(string sSO_TIEN,string s_PTCT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU_CT SET SO_TIEN='"+sSO_TIEN+"' WHERE PTCT_ID='"+ s_PTCT_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_PTCT_ID)
{
  string sqlSave= " UPDATE TC_PHIEU_THU_CT SET GHI_CHU='N"+sGHI_CHU+"' WHERE PTCT_ID='"+ s_PTCT_ID+"' ";
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
   string sqlSelect = " SELECT * FROM TC_PHIEU_THU_CT";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "TC_PHIEU_THU_CT");
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
   private static DataTable dt_TC_PHIEU_THU_CT;
   public static bool Change_dt_TC_PHIEU_THU_CT = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_TC_PHIEU_THU_CT()
   {
   if (dt_TC_PHIEU_THU_CT == null || Change_dt_TC_PHIEU_THU_CT == true)
     {
   dt_TC_PHIEU_THU_CT = dtGetTableAll();
         Change_dt_TC_PHIEU_THU_CT = true && AllowAutoChange ;
     }
     return dt_TC_PHIEU_THU_CT;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
