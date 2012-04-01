using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class DM_HANG_HOA_NHOM:  SQLConnectWeb { 
 public static string sTableName= "DM_HANG_HOA_NHOM"; 
   public string ID;
   public string NAME;
   public string PARENT_ID;
   public string ROOT_ID;
   public string VISIBLE_BIT;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_ID_VN="ID";
 public static  string cl_NAME="NAME" ;
 public static  string cl_NAME_VN="NAME";
 public static  string cl_PARENT_ID="PARENT_ID" ;
 public static  string cl_PARENT_ID_VN="PARENT_ID";
 public static  string cl_ROOT_ID="ROOT_ID" ;
 public static  string cl_ROOT_ID_VN="ROOT_ID";
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 public static  string cl_VISIBLE_BIT_VN="VISIBLE_BIT";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public DM_HANG_HOA_NHOM() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public DM_HANG_HOA_NHOM(
         string sID,
         string sNAME,
         string sPARENT_ID,
         string sROOT_ID,
         string sVISIBLE_BIT){
         this.ID= sID;
         this.NAME= sNAME;
         this.PARENT_ID= sPARENT_ID;
         this.ROOT_ID= sROOT_ID;
         this.VISIBLE_BIT= sVISIBLE_BIT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static DM_HANG_HOA_NHOM Create_DM_HANG_HOA_NHOM ( string sID  ){
    DataTable dt=dtSearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new DM_HANG_HOA_NHOM(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM DM_HANG_HOA_NHOM AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public DM_HANG_HOA_NHOM( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.NAME= dv[pos][1].ToString();
         this.PARENT_ID= dv[pos][2].ToString();
         this.ROOT_ID= dv[pos][3].ToString();
         this.VISIBLE_BIT= dv[pos][4].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByID(string sID)
{
          string sqlSelect= s_Select()+ " WHERE ID  ="+ sID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByID(string sID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ID"+ sMatch +sID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPARENT_ID(string sPARENT_ID)
{
          string sqlSelect= s_Select()+ " WHERE PARENT_ID  ="+ sPARENT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPARENT_ID(string sPARENT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PARENT_ID"+ sMatch +sPARENT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByROOT_ID(string sROOT_ID)
{
          string sqlSelect= s_Select()+ " WHERE ROOT_ID  ="+ sROOT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByROOT_ID(string sROOT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ROOT_ID"+ sMatch +sROOT_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByVISIBLE_BIT(string sVISIBLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE VISIBLE_BIT  Like N'%"+ sVISIBLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sID
            , string sNAME
            , string sPARENT_ID
            , string sROOT_ID
            , string sVISIBLE_BIT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sPARENT_ID!=null && sPARENT_ID!="") 
            sqlselect +=" AND PARENT_ID =" + sPARENT_ID ;
      if (sROOT_ID!=null && sROOT_ID!="") 
            sqlselect +=" AND ROOT_ID =" + sROOT_ID ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DM_HANG_HOA_NHOM Insert_Object(
string  sNAME
            ,string  sPARENT_ID
            ,string  sROOT_ID
            ,string  sVISIBLE_BIT
            ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sPARENT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPARENT_ID,"bigint");
              string tem_sROOT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sROOT_ID,"bigint");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

             string sqlSave=" INSERT INTO DM_HANG_HOA_NHOM("+
                   "NAME," 
        +                   "PARENT_ID," 
        +                   "ROOT_ID," 
        +                   "VISIBLE_BIT) VALUES("
 +tem_sNAME+","
 +tem_sPARENT_ID+","
 +tem_sROOT_ID+","
 +tem_sVISIBLE_BIT +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          DM_HANG_HOA_NHOM newDM_HANG_HOA_NHOM= new DM_HANG_HOA_NHOM();
                 newDM_HANG_HOA_NHOM.ID=GetTable( " SELECT TOP 1 ID FROM DM_HANG_HOA_NHOM ORDER BY ID DESC ").Rows[0][0].ToString();
              newDM_HANG_HOA_NHOM.NAME=sNAME;
              newDM_HANG_HOA_NHOM.PARENT_ID=sPARENT_ID;
              newDM_HANG_HOA_NHOM.ROOT_ID=sROOT_ID;
              newDM_HANG_HOA_NHOM.VISIBLE_BIT=sVISIBLE_BIT;
            return newDM_HANG_HOA_NHOM; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sNAME
                ,string sPARENT_ID
                ,string sROOT_ID
                ,string sVISIBLE_BIT
                ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sPARENT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPARENT_ID,"bigint");
              string tem_sROOT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sROOT_ID,"bigint");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");

 string sqlSave=" UPDATE DM_HANG_HOA_NHOM SET "+"NAME ="+tem_sNAME+","
 +"PARENT_ID ="+tem_sPARENT_ID+","
 +"ROOT_ID ="+tem_sROOT_ID+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.NAME=sNAME;
                this.PARENT_ID=sPARENT_ID;
                this.ROOT_ID=sROOT_ID;
                this.VISIBLE_BIT=sVISIBLE_BIT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NAME(string sNAME)
{
    string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PARENT_ID(string sPARENT_ID)
{
    string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET PARENT_ID='"+ sPARENT_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PARENT_ID=sPARENT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ROOT_ID(string sROOT_ID)
{
    string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET ROOT_ID='"+ sROOT_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ROOT_ID=sROOT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.VISIBLE_BIT=sVISIBLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PARENT_ID(string sPARENT_ID,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET PARENT_ID='"+sPARENT_ID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ROOT_ID(string sROOT_ID,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET ROOT_ID='"+sROOT_ID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE DM_HANG_HOA_NHOM SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM DM_HANG_HOA_NHOM";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "DM_HANG_HOA_NHOM");
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
   private static DataTable dt_DM_HANG_HOA_NHOM;
   public static bool Change_dt_DM_HANG_HOA_NHOM = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_DM_HANG_HOA_NHOM()
   {
   if (dt_DM_HANG_HOA_NHOM == null || Change_dt_DM_HANG_HOA_NHOM == true)
     {
   dt_DM_HANG_HOA_NHOM = dtGetTableAll();
         Change_dt_DM_HANG_HOA_NHOM = true && AllowAutoChange ;
     }
     return dt_DM_HANG_HOA_NHOM;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
