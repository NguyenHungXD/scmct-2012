using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class KH_PHIEU_XUAT_KHO_CT:  SQLConnectWeb { 
 public static string sTableName= "KH_PHIEU_XUAT_KHO_CT"; 
   public string PXK_CT_ID;
   public string PXK_ID;
   public string HH_ID;
   public string SO_LUONG;
   public string DON_GIA;
   public string THANH_TIEN;
   public string GHI_CHU;
   public string PNK_CT_ID;
   #region DataColumn Name ;
 public static  string cl_PXK_CT_ID="PXK_CT_ID" ;
 public static  string cl_PXK_ID="PXK_ID" ;
 public static  string cl_HH_ID="HH_ID" ;
 public static  string cl_SO_LUONG="SO_LUONG" ;
 public static  string cl_DON_GIA="DON_GIA" ;
 public static  string cl_THANH_TIEN="THANH_TIEN" ;
 public static  string cl_GHI_CHU="GHI_CHU" ;
 public static  string cl_PNK_CT_ID="PNK_CT_ID" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_XUAT_KHO_CT() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public KH_PHIEU_XUAT_KHO_CT(
         string sPXK_CT_ID,
         string sPXK_ID,
         string sHH_ID,
         string sSO_LUONG,
         string sDON_GIA,
         string sTHANH_TIEN,
         string sGHI_CHU,
         string sPNK_CT_ID){
         this.PXK_CT_ID= sPXK_CT_ID;
         this.PXK_ID= sPXK_ID;
         this.HH_ID= sHH_ID;
         this.SO_LUONG= sSO_LUONG;
         this.DON_GIA= sDON_GIA;
         this.THANH_TIEN= sTHANH_TIEN;
         this.GHI_CHU= sGHI_CHU;
         this.PNK_CT_ID= sPNK_CT_ID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static KH_PHIEU_XUAT_KHO_CT Create_KH_PHIEU_XUAT_KHO_CT ( string sPXK_CT_ID  ){
    DataTable dt=SearchByPXK_CT_ID(sPXK_CT_ID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new KH_PHIEU_XUAT_KHO_CT(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM KH_PHIEU_XUAT_KHO_CT AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public KH_PHIEU_XUAT_KHO_CT( DataTable table,int pos)
{
         this.PXK_CT_ID= table.Rows[pos]["PXK_CT_ID"].ToString();
         this.PXK_ID= table.Rows[pos]["PXK_ID"].ToString();
         this.HH_ID= table.Rows[pos]["HH_ID"].ToString();
         this.SO_LUONG= table.Rows[pos]["SO_LUONG"].ToString();
         this.DON_GIA= table.Rows[pos]["DON_GIA"].ToString();
         this.THANH_TIEN= table.Rows[pos]["THANH_TIEN"].ToString();
         this.GHI_CHU= table.Rows[pos]["GHI_CHU"].ToString();
         this.PNK_CT_ID= table.Rows[pos]["PNK_CT_ID"].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPXK_CT_ID(string sPXK_CT_ID)
{
          string sqlSelect= s_Select()+ " WHERE PXK_CT_ID  ="+ sPXK_CT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPXK_CT_ID(string sPXK_CT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PXK_CT_ID"+ sMatch +sPXK_CT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
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
 public static DataTable SearchByHH_ID(string sHH_ID)
{
          string sqlSelect= s_Select()+ " WHERE HH_ID  ="+ sHH_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByHH_ID(string sHH_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE HH_ID"+ sMatch +sHH_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySO_LUONG(string sSO_LUONG)
{
          string sqlSelect= s_Select()+ " WHERE SO_LUONG  ="+ sSO_LUONG + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySO_LUONG(string sSO_LUONG,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SO_LUONG"+ sMatch +sSO_LUONG + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDON_GIA(string sDON_GIA)
{
          string sqlSelect= s_Select()+ " WHERE DON_GIA  ="+ sDON_GIA + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDON_GIA(string sDON_GIA,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DON_GIA"+ sMatch +sDON_GIA + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTHANH_TIEN(string sTHANH_TIEN)
{
          string sqlSelect= s_Select()+ " WHERE THANH_TIEN  ="+ sTHANH_TIEN + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTHANH_TIEN(string sTHANH_TIEN,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE THANH_TIEN"+ sMatch +sTHANH_TIEN + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByGHI_CHU(string sGHI_CHU)
{
          string sqlSelect= s_Select()+ " WHERE GHI_CHU  Like N'%"+ sGHI_CHU + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPNK_CT_ID(string sPNK_CT_ID)
{
          string sqlSelect= s_Select()+ " WHERE PNK_CT_ID  ="+ sPNK_CT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPNK_CT_ID(string sPNK_CT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PNK_CT_ID"+ sMatch +sPNK_CT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sPXK_CT_ID
            , string sPXK_ID
            , string sHH_ID
            , string sSO_LUONG
            , string sDON_GIA
            , string sTHANH_TIEN
            , string sGHI_CHU
            , string sPNK_CT_ID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sPXK_CT_ID!=null && sPXK_CT_ID!="") 
            sqlselect +=" AND PXK_CT_ID =" + sPXK_CT_ID ;
      if (sPXK_ID!=null && sPXK_ID!="") 
            sqlselect +=" AND PXK_ID =" + sPXK_ID ;
      if (sHH_ID!=null && sHH_ID!="") 
            sqlselect +=" AND HH_ID =" + sHH_ID ;
      if (sSO_LUONG!=null && sSO_LUONG!="") 
            sqlselect +=" AND SO_LUONG =" + sSO_LUONG ;
      if (sDON_GIA!=null && sDON_GIA!="") 
            sqlselect +=" AND DON_GIA =" + sDON_GIA ;
      if (sTHANH_TIEN!=null && sTHANH_TIEN!="") 
            sqlselect +=" AND THANH_TIEN =" + sTHANH_TIEN ;
      if (sGHI_CHU!=null && sGHI_CHU!="") 
            sqlselect +=" AND GHI_CHU LIKE N'%" + sGHI_CHU +"%'" ;
      if (sPNK_CT_ID!=null && sPNK_CT_ID!="") 
            sqlselect +=" AND PNK_CT_ID =" + sPNK_CT_ID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect,sTableName);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static KH_PHIEU_XUAT_KHO_CT Insert_Object(
string  sPXK_ID
            ,string  sHH_ID
            ,string  sSO_LUONG
            ,string  sDON_GIA
            ,string  sTHANH_TIEN
            ,string  sGHI_CHU
            ,string  sPNK_CT_ID
            ) 
 { 
              string tem_sPXK_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPXK_ID,"bigint");
              string tem_sHH_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sHH_ID,"bigint");
              string tem_sSO_LUONG=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSO_LUONG,"float");
              string tem_sDON_GIA=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDON_GIA,"float");
              string tem_sTHANH_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTHANH_TIEN,"float");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");
              string tem_sPNK_CT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPNK_CT_ID,"bigint");

             string sqlSave=" INSERT INTO KH_PHIEU_XUAT_KHO_CT("+
                   "PXK_ID," 
        +                   "HH_ID," 
        +                   "SO_LUONG," 
        +                   "DON_GIA," 
        +                   "THANH_TIEN," 
        +                   "GHI_CHU," 
        +                   "PNK_CT_ID) VALUES("
 +tem_sPXK_ID+","
 +tem_sHH_ID+","
 +tem_sSO_LUONG+","
 +tem_sDON_GIA+","
 +tem_sTHANH_TIEN+","
 +tem_sGHI_CHU+","
 +tem_sPNK_CT_ID +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          KH_PHIEU_XUAT_KHO_CT newKH_PHIEU_XUAT_KHO_CT= new KH_PHIEU_XUAT_KHO_CT();
                 newKH_PHIEU_XUAT_KHO_CT.PXK_CT_ID=GetTable( " SELECT TOP 1 PXK_CT_ID FROM KH_PHIEU_XUAT_KHO_CT ORDER BY PXK_CT_ID DESC ").Rows[0][0].ToString();
              newKH_PHIEU_XUAT_KHO_CT.PXK_ID=sPXK_ID;
              newKH_PHIEU_XUAT_KHO_CT.HH_ID=sHH_ID;
              newKH_PHIEU_XUAT_KHO_CT.SO_LUONG=sSO_LUONG;
              newKH_PHIEU_XUAT_KHO_CT.DON_GIA=sDON_GIA;
              newKH_PHIEU_XUAT_KHO_CT.THANH_TIEN=sTHANH_TIEN;
              newKH_PHIEU_XUAT_KHO_CT.GHI_CHU=sGHI_CHU;
              newKH_PHIEU_XUAT_KHO_CT.PNK_CT_ID=sPNK_CT_ID;
            return newKH_PHIEU_XUAT_KHO_CT; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sPXK_ID
                ,string sHH_ID
                ,string sSO_LUONG
                ,string sDON_GIA
                ,string sTHANH_TIEN
                ,string sGHI_CHU
                ,string sPNK_CT_ID
                ) 
 { 
              string tem_sPXK_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPXK_ID,"bigint");
              string tem_sHH_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sHH_ID,"bigint");
              string tem_sSO_LUONG=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSO_LUONG,"float");
              string tem_sDON_GIA=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDON_GIA,"float");
              string tem_sTHANH_TIEN=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTHANH_TIEN,"float");
              string tem_sGHI_CHU=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sGHI_CHU,"nvarchar");
              string tem_sPNK_CT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPNK_CT_ID,"bigint");

 string sqlSave=" UPDATE KH_PHIEU_XUAT_KHO_CT SET "+"PXK_ID ="+tem_sPXK_ID+","
 +"HH_ID ="+tem_sHH_ID+","
 +"SO_LUONG ="+tem_sSO_LUONG+","
 +"DON_GIA ="+tem_sDON_GIA+","
 +"THANH_TIEN ="+tem_sTHANH_TIEN+","
 +"GHI_CHU ="+tem_sGHI_CHU+","
 +"PNK_CT_ID ="+tem_sPNK_CT_ID+" WHERE PXK_CT_ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.PXK_CT_ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.PXK_ID=sPXK_ID;
                this.HH_ID=sHH_ID;
                this.SO_LUONG=sSO_LUONG;
                this.DON_GIA=sDON_GIA;
                this.THANH_TIEN=sTHANH_TIEN;
                this.GHI_CHU=sGHI_CHU;
                this.PNK_CT_ID=sPNK_CT_ID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_PXK_CT_ID(string sPXK_CT_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET PXK_CT_ID='"+ sPXK_CT_ID+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PXK_CT_ID=sPXK_CT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PXK_ID(string sPXK_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET PXK_ID='"+ sPXK_ID+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PXK_ID=sPXK_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_HH_ID(string sHH_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET HH_ID='"+ sHH_ID+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.HH_ID=sHH_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SO_LUONG(string sSO_LUONG)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET SO_LUONG='"+ sSO_LUONG+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SO_LUONG=sSO_LUONG;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DON_GIA(string sDON_GIA)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET DON_GIA='"+ sDON_GIA+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DON_GIA=sDON_GIA;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_THANH_TIEN(string sTHANH_TIEN)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET THANH_TIEN='"+ sTHANH_TIEN+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.THANH_TIEN=sTHANH_TIEN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GHI_CHU(string sGHI_CHU)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET GHI_CHU='N"+ sGHI_CHU+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.GHI_CHU=sGHI_CHU;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PNK_CT_ID(string sPNK_CT_ID)
{
    string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET PNK_CT_ID='"+ sPNK_CT_ID+ "' WHERE PXK_CT_ID='"+ this.PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PNK_CT_ID=sPNK_CT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_PXK_ID(string sPXK_ID,string s_PXK_CT_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET PXK_ID='"+sPXK_ID+"' WHERE PXK_CT_ID='"+ s_PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_HH_ID(string sHH_ID,string s_PXK_CT_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET HH_ID='"+sHH_ID+"' WHERE PXK_CT_ID='"+ s_PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SO_LUONG(string sSO_LUONG,string s_PXK_CT_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET SO_LUONG='"+sSO_LUONG+"' WHERE PXK_CT_ID='"+ s_PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DON_GIA(string sDON_GIA,string s_PXK_CT_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET DON_GIA='"+sDON_GIA+"' WHERE PXK_CT_ID='"+ s_PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_THANH_TIEN(string sTHANH_TIEN,string s_PXK_CT_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET THANH_TIEN='"+sTHANH_TIEN+"' WHERE PXK_CT_ID='"+ s_PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GHI_CHU(string sGHI_CHU,string s_PXK_CT_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET GHI_CHU='N"+sGHI_CHU+"' WHERE PXK_CT_ID='"+ s_PXK_CT_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PNK_CT_ID(string sPNK_CT_ID,string s_PXK_CT_ID)
{
  string sqlSave= " UPDATE KH_PHIEU_XUAT_KHO_CT SET PNK_CT_ID='"+sPNK_CT_ID+"' WHERE PXK_CT_ID='"+ s_PXK_CT_ID+"' ";
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
   string sqlSelect = " SELECT * FROM KH_PHIEU_XUAT_KHO_CT";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "KH_PHIEU_XUAT_KHO_CT");
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
   private static DataTable dt_KH_PHIEU_XUAT_KHO_CT;
   public static bool Change_dt_KH_PHIEU_XUAT_KHO_CT = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_KH_PHIEU_XUAT_KHO_CT()
   {
   if (dt_KH_PHIEU_XUAT_KHO_CT == null || Change_dt_KH_PHIEU_XUAT_KHO_CT == true)
     {
   dt_KH_PHIEU_XUAT_KHO_CT = GetTableAll();
         Change_dt_KH_PHIEU_XUAT_KHO_CT = true && AllowAutoChange ;
     }
     return dt_KH_PHIEU_XUAT_KHO_CT;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
