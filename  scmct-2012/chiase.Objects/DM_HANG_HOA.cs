using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class DM_HANG_HOA:  SQLConnectWeb { 
 public static string sTableName= "DM_HANG_HOA"; 
   public string ID;
   public string MA_HH;
   public string NAME;
   public string NHH_ID;
   public string MO_TA;
   public string VISIBLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_MA_HH="MA_HH" ;
 public static  string cl_NAME="NAME" ;
 public static  string cl_NHH_ID="NHH_ID" ;
 public static  string cl_MO_TA="MO_TA" ;
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public DM_HANG_HOA() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public DM_HANG_HOA(
         string sID,
         string sMA_HH,
         string sNAME,
         string sNHH_ID,
         string sMO_TA,
         string sVISIBLE_BIT){
         this.ID= sID;
         this.MA_HH= sMA_HH;
         this.NAME= sNAME;
         this.NHH_ID= sNHH_ID;
         this.MO_TA= sMO_TA;
         this.VISIBLE_BIT= sVISIBLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static DM_HANG_HOA Create_DM_HANG_HOA ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new DM_HANG_HOA(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM DM_HANG_HOA AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public DM_HANG_HOA( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.MA_HH= dv[pos][1].ToString();
         this.NAME= dv[pos][2].ToString();
         this.NHH_ID= dv[pos][3].ToString();
         this.MO_TA= dv[pos][4].ToString();
         this.VISIBLE_BIT= dv[pos][5].ToString();
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
 public static DataTable SearchByMA_HH(string sMA_HH)
{
          string sqlSelect= s_Select()+ " WHERE MA_HH  Like N'%"+ sMA_HH + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNHH_ID(string sNHH_ID)
{
          string sqlSelect= s_Select()+ " WHERE NHH_ID  ="+ sNHH_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNHH_ID(string sNHH_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NHH_ID"+ sMatch +sNHH_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMO_TA(string sMO_TA)
{
          string sqlSelect= s_Select()+ " WHERE MO_TA  Like N'%"+ sMO_TA + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByVISIBLE_BIT(string sVISIBLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE VISIBLE_BIT  Like N'%"+ sVISIBLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sID
            , string sMA_HH
            , string sNAME
            , string sNHH_ID
            , string sMO_TA
            , string sVISIBLE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sMA_HH!=null && sMA_HH!="") 
            sqlselect +=" AND MA_HH LIKE N'%" + sMA_HH +"%'" ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sNHH_ID!=null && sNHH_ID!="") 
            sqlselect +=" AND NHH_ID =" + sNHH_ID ;
      if (sMO_TA!=null && sMO_TA!="") 
            sqlselect +=" AND MO_TA LIKE N'%" + sMO_TA +"%'" ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DM_HANG_HOA Insert_Object(
string  sMA_HH
            ,string  sNAME
            ,string  sNHH_ID
            ,string  sMO_TA
            ,string  sVISIBLE_BIT
            ) 
 { 
              string tem_sMA_HH=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_HH,"nvarchar");
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sNHH_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNHH_ID,"bigint");
              string tem_sMO_TA=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMO_TA,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

             string sqlSave=" INSERT INTO DM_HANG_HOA("+
                   "MA_HH," 
        +                   "NAME," 
        +                   "NHH_ID," 
        +                   "MO_TA," 
        +                   "VISIBLE_BIT) VALUES("
 +tem_sMA_HH+","
 +tem_sNAME+","
 +tem_sNHH_ID+","
 +tem_sMO_TA+","
 +tem_sVISIBLE_BIT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          DM_HANG_HOA newDM_HANG_HOA= new DM_HANG_HOA();
                 newDM_HANG_HOA.ID=GetTable( " SELECT TOP 1 ID FROM DM_HANG_HOA ORDER BY ID DESC ").Rows[0][0].ToString();
              newDM_HANG_HOA.MA_HH=sMA_HH;
              newDM_HANG_HOA.NAME=sNAME;
              newDM_HANG_HOA.NHH_ID=sNHH_ID;
              newDM_HANG_HOA.MO_TA=sMO_TA;
              newDM_HANG_HOA.VISIBLE_BIT=sVISIBLE_BIT;
            return newDM_HANG_HOA; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sMA_HH
                ,string sNAME
                ,string sNHH_ID
                ,string sMO_TA
                ,string sVISIBLE_BIT
                ) 
 { 
              string tem_sMA_HH=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMA_HH,"nvarchar");
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sNHH_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNHH_ID,"bigint");
              string tem_sMO_TA=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMO_TA,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

 string sqlSave=" UPDATE DM_HANG_HOA SET "+"MA_HH ="+tem_sMA_HH+","
 +"NAME ="+tem_sNAME+","
 +"NHH_ID ="+tem_sNHH_ID+","
 +"MO_TA ="+tem_sMO_TA+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.MA_HH=sMA_HH;
                this.NAME=sNAME;
                this.NHH_ID=sNHH_ID;
                this.MO_TA=sMO_TA;
                this.VISIBLE_BIT=sVISIBLE_BIT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE DM_HANG_HOA SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MA_HH(string sMA_HH)
{
    string sqlSave= " UPDATE DM_HANG_HOA SET MA_HH='N"+ sMA_HH+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MA_HH=sMA_HH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NAME(string sNAME)
{
    string sqlSave= " UPDATE DM_HANG_HOA SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NHH_ID(string sNHH_ID)
{
    string sqlSave= " UPDATE DM_HANG_HOA SET NHH_ID='"+ sNHH_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NHH_ID=sNHH_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MO_TA(string sMO_TA)
{
    string sqlSave= " UPDATE DM_HANG_HOA SET MO_TA='N"+ sMO_TA+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MO_TA=sMO_TA;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE DM_HANG_HOA SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.VISIBLE_BIT=sVISIBLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_MA_HH(string sMA_HH,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA SET MA_HH='N"+sMA_HH+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NHH_ID(string sNHH_ID,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA SET NHH_ID='"+sNHH_ID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MO_TA(string sMO_TA,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA SET MO_TA='N"+sMO_TA+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM DM_HANG_HOA";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "DM_HANG_HOA");
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
   private static DataTable dt_DM_HANG_HOA;
   public static bool Change_dt_DM_HANG_HOA = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_DM_HANG_HOA()
   {
   if (dt_DM_HANG_HOA == null || Change_dt_DM_HANG_HOA == true)
     {
   dt_DM_HANG_HOA = GetTableAll();
         Change_dt_DM_HANG_HOA = true && AllowAutoChange ;
     }
     return dt_DM_HANG_HOA;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
