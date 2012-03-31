using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class TAP_TIN_DINH_KEM:  SQLConnectWeb { 
 public static string sTableName= "TAP_TIN_DINH_KEM"; 
   public string TTDK_ID;
   public string TEN_TAP_TIN;
   public string PATH;
   public string SO_LUOT_TAI;
   public string BAI_VIET_ID;
   #region DataColumn Name ;
 public static  string cl_TTDK_ID="TTDK_ID" ;
 public static  string cl_TTDK_ID_VN="TTDK_ID";
 public static  string cl_TEN_TAP_TIN="TEN_TAP_TIN" ;
 public static  string cl_TEN_TAP_TIN_VN="TEN_TAP_TIN";
 public static  string cl_PATH="PATH" ;
 public static  string cl_PATH_VN="PATH";
 public static  string cl_SO_LUOT_TAI="SO_LUOT_TAI" ;
 public static  string cl_SO_LUOT_TAI_VN="SO_LUOT_TAI";
 public static  string cl_BAI_VIET_ID="BAI_VIET_ID" ;
 public static  string cl_BAI_VIET_ID_VN="BAI_VIET_ID";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public TAP_TIN_DINH_KEM() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public TAP_TIN_DINH_KEM(
         string sTTDK_ID,
         string sTEN_TAP_TIN,
         string sPATH,
         string sSO_LUOT_TAI,
         string sBAI_VIET_ID){
         this.TTDK_ID= sTTDK_ID;
         this.TEN_TAP_TIN= sTEN_TAP_TIN;
         this.PATH= sPATH;
         this.SO_LUOT_TAI= sSO_LUOT_TAI;
         this.BAI_VIET_ID= sBAI_VIET_ID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static TAP_TIN_DINH_KEM Create_TAP_TIN_DINH_KEM ( string sTTDK_ID  ){
    DataTable dt=dtSearchByTTDK_ID(sTTDK_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new TAP_TIN_DINH_KEM(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM TAP_TIN_DINH_KEM AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public TAP_TIN_DINH_KEM( DataView dv,int pos)
{
         this.TTDK_ID= dv[pos][0].ToString();
         this.TEN_TAP_TIN= dv[pos][1].ToString();
         this.PATH= dv[pos][2].ToString();
         this.SO_LUOT_TAI= dv[pos][3].ToString();
         this.BAI_VIET_ID= dv[pos][4].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTTDK_ID(string sTTDK_ID)
{
          string sqlSelect= s_Select()+ " WHERE TTDK_ID  ="+ sTTDK_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTTDK_ID(string sTTDK_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE TTDK_ID"+ sMatch +sTTDK_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTEN_TAP_TIN(string sTEN_TAP_TIN)
{
          string sqlSelect= s_Select()+ " WHERE TEN_TAP_TIN  Like N'%"+ sTEN_TAP_TIN + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPATH(string sPATH)
{
          string sqlSelect= s_Select()+ " WHERE PATH  Like N'%"+ sPATH + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySO_LUOT_TAI(string sSO_LUOT_TAI)
{
          string sqlSelect= s_Select()+ " WHERE SO_LUOT_TAI  ="+ sSO_LUOT_TAI + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySO_LUOT_TAI(string sSO_LUOT_TAI,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SO_LUOT_TAI"+ sMatch +sSO_LUOT_TAI + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBAI_VIET_ID(string sBAI_VIET_ID)
{
          string sqlSelect= s_Select()+ " WHERE BAI_VIET_ID  ="+ sBAI_VIET_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBAI_VIET_ID(string sBAI_VIET_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BAI_VIET_ID"+ sMatch +sBAI_VIET_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sTTDK_ID
            , string sTEN_TAP_TIN
            , string sPATH
            , string sSO_LUOT_TAI
            , string sBAI_VIET_ID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sTTDK_ID!=null && sTTDK_ID!="") 
            sqlselect +=" AND TTDK_ID =" + sTTDK_ID ;
      if (sTEN_TAP_TIN!=null && sTEN_TAP_TIN!="") 
            sqlselect +=" AND TEN_TAP_TIN LIKE N'%" + sTEN_TAP_TIN +"%'" ;
      if (sPATH!=null && sPATH!="") 
            sqlselect +=" AND PATH LIKE N'%" + sPATH +"%'" ;
      if (sSO_LUOT_TAI!=null && sSO_LUOT_TAI!="") 
            sqlselect +=" AND SO_LUOT_TAI =" + sSO_LUOT_TAI ;
      if (sBAI_VIET_ID!=null && sBAI_VIET_ID!="") 
            sqlselect +=" AND BAI_VIET_ID =" + sBAI_VIET_ID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static TAP_TIN_DINH_KEM Insert_Object(
string  sTTDK_ID
            ,string  sTEN_TAP_TIN
            ,string  sPATH
            ,string  sSO_LUOT_TAI
            ,string  sBAI_VIET_ID
            ) 
 { 
              string tem_sTTDK_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTTDK_ID,"bigint");
              string tem_sTEN_TAP_TIN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTEN_TAP_TIN,"nvarchar");
              string tem_sPATH=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPATH,"nvarchar");
              string tem_sSO_LUOT_TAI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSO_LUOT_TAI,"float");
              string tem_sBAI_VIET_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBAI_VIET_ID,"bigint");

             string sqlSave=" INSERT INTO TAP_TIN_DINH_KEM("+
                   "TTDK_ID," 
        +                   "TEN_TAP_TIN," 
        +                   "PATH," 
        +                   "SO_LUOT_TAI," 
        +                   "BAI_VIET_ID) VALUES("
 +tem_sTTDK_ID+","
 +tem_sTEN_TAP_TIN+","
 +tem_sPATH+","
 +tem_sSO_LUOT_TAI+","
 +tem_sBAI_VIET_ID +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          TAP_TIN_DINH_KEM newTAP_TIN_DINH_KEM= new TAP_TIN_DINH_KEM();
              newTAP_TIN_DINH_KEM.TTDK_ID=sTTDK_ID;
              newTAP_TIN_DINH_KEM.TEN_TAP_TIN=sTEN_TAP_TIN;
              newTAP_TIN_DINH_KEM.PATH=sPATH;
              newTAP_TIN_DINH_KEM.SO_LUOT_TAI=sSO_LUOT_TAI;
              newTAP_TIN_DINH_KEM.BAI_VIET_ID=sBAI_VIET_ID;
            return newTAP_TIN_DINH_KEM; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sTTDK_ID
                ,string sTEN_TAP_TIN
                ,string sPATH
                ,string sSO_LUOT_TAI
                ,string sBAI_VIET_ID
                ) 
 { 
              string tem_sTEN_TAP_TIN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTEN_TAP_TIN,"nvarchar");
              string tem_sPATH=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPATH,"nvarchar");
              string tem_sSO_LUOT_TAI=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSO_LUOT_TAI,"float");
              string tem_sBAI_VIET_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBAI_VIET_ID,"bigint");

 string sqlSave=" UPDATE TAP_TIN_DINH_KEM SET "+"TEN_TAP_TIN ="+tem_sTEN_TAP_TIN+","
 +"PATH ="+tem_sPATH+","
 +"SO_LUOT_TAI ="+tem_sSO_LUOT_TAI+","
 +"BAI_VIET_ID ="+tem_sBAI_VIET_ID+" WHERE TTDK_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.TTDK_ID,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.TEN_TAP_TIN=sTEN_TAP_TIN;
                this.PATH=sPATH;
                this.SO_LUOT_TAI=sSO_LUOT_TAI;
                this.BAI_VIET_ID=sBAI_VIET_ID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_TTDK_ID(string sTTDK_ID)
{
    string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET TTDK_ID='"+ sTTDK_ID+ "' WHERE TTDK_ID='"+ this.TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TTDK_ID=sTTDK_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TEN_TAP_TIN(string sTEN_TAP_TIN)
{
    string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET TEN_TAP_TIN='N"+ sTEN_TAP_TIN+ "' WHERE TTDK_ID='"+ this.TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TEN_TAP_TIN=sTEN_TAP_TIN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PATH(string sPATH)
{
    string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET PATH='N"+ sPATH+ "' WHERE TTDK_ID='"+ this.TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PATH=sPATH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SO_LUOT_TAI(string sSO_LUOT_TAI)
{
    string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET SO_LUOT_TAI='"+ sSO_LUOT_TAI+ "' WHERE TTDK_ID='"+ this.TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.SO_LUOT_TAI=sSO_LUOT_TAI;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BAI_VIET_ID(string sBAI_VIET_ID)
{
    string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET BAI_VIET_ID='"+ sBAI_VIET_ID+ "' WHERE TTDK_ID='"+ this.TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.BAI_VIET_ID=sBAI_VIET_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_TTDK_ID(string sTTDK_ID,string s_TTDK_ID)
{
  string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET TTDK_ID='"+sTTDK_ID+"' WHERE TTDK_ID='"+ s_TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TEN_TAP_TIN(string sTEN_TAP_TIN,string s_TTDK_ID)
{
  string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET TEN_TAP_TIN='N"+sTEN_TAP_TIN+"' WHERE TTDK_ID='"+ s_TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PATH(string sPATH,string s_TTDK_ID)
{
  string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET PATH='N"+sPATH+"' WHERE TTDK_ID='"+ s_TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SO_LUOT_TAI(string sSO_LUOT_TAI,string s_TTDK_ID)
{
  string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET SO_LUOT_TAI='"+sSO_LUOT_TAI+"' WHERE TTDK_ID='"+ s_TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BAI_VIET_ID(string sBAI_VIET_ID,string s_TTDK_ID)
{
  string sqlSave= " UPDATE TAP_TIN_DINH_KEM SET BAI_VIET_ID='"+sBAI_VIET_ID+"' WHERE TTDK_ID='"+ s_TTDK_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM TAP_TIN_DINH_KEM " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_TAP_TIN_DINH_KEM;
   public static bool Change_dt_TAP_TIN_DINH_KEM = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_TAP_TIN_DINH_KEM()
   {
   if (dt_TAP_TIN_DINH_KEM == null || Change_dt_TAP_TIN_DINH_KEM == true)
   {
   dt_TAP_TIN_DINH_KEM = dtGetAll();
   Change_dt_TAP_TIN_DINH_KEM = true && AllowAutoChange ;
   }
   return dt_TAP_TIN_DINH_KEM;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
