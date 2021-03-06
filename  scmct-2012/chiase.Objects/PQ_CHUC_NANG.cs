using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class PQ_CHUC_NANG:  SQLConnectWeb { 
 public static string sTableName= "PQ_CHUC_NANG"; 
   public string ID;
   public string NAME;
   public string DESCRIPTION;
   public string VISIBLE_BIT;
   public string ISREAD;
   public string ISINSERT;
   public string ISDELETE;
   public string ISUPDATE;
   public string PARENT_ID;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_NAME="NAME" ;
 public static  string cl_DESCRIPTION="DESCRIPTION" ;
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 public static  string cl_ISREAD="ISREAD" ;
 public static  string cl_ISINSERT="ISINSERT" ;
 public static  string cl_ISDELETE="ISDELETE" ;
 public static  string cl_ISUPDATE="ISUPDATE" ;
 public static  string cl_PARENT_ID="PARENT_ID" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public PQ_CHUC_NANG() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public PQ_CHUC_NANG(
         string sID,
         string sNAME,
         string sDESCRIPTION,
         string sVISIBLE_BIT,
         string sISREAD,
         string sISINSERT,
         string sISDELETE,
         string sISUPDATE,
         string sPARENT_ID){
         this.ID= sID;
         this.NAME= sNAME;
         this.DESCRIPTION= sDESCRIPTION;
         this.VISIBLE_BIT= sVISIBLE_BIT;
         this.ISREAD= sISREAD;
         this.ISINSERT= sISINSERT;
         this.ISDELETE= sISDELETE;
         this.ISUPDATE= sISUPDATE;
         this.PARENT_ID= sPARENT_ID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static PQ_CHUC_NANG Create_PQ_CHUC_NANG ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new PQ_CHUC_NANG(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM PQ_CHUC_NANG AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public PQ_CHUC_NANG( DataTable table,int pos)
{
         this.ID= table.Rows[pos]["ID"].ToString();
         this.NAME= table.Rows[pos]["NAME"].ToString();
         this.DESCRIPTION= table.Rows[pos]["DESCRIPTION"].ToString();
         this.VISIBLE_BIT= table.Rows[pos]["VISIBLE_BIT"].ToString();
         this.ISREAD= table.Rows[pos]["ISREAD"].ToString();
         this.ISINSERT= table.Rows[pos]["ISINSERT"].ToString();
         this.ISDELETE= table.Rows[pos]["ISDELETE"].ToString();
         this.ISUPDATE= table.Rows[pos]["ISUPDATE"].ToString();
         this.PARENT_ID= table.Rows[pos]["PARENT_ID"].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByID(string sID)
{
          string sqlSelect= s_Select()+ " WHERE ID  ="+ sID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByID(string sID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ID"+ sMatch +sID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDESCRIPTION(string sDESCRIPTION)
{
          string sqlSelect= s_Select()+ " WHERE DESCRIPTION  Like N'%"+ sDESCRIPTION + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByVISIBLE_BIT(string sVISIBLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE VISIBLE_BIT  Like N'%"+ sVISIBLE_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISREAD(string sISREAD)
{
          string sqlSelect= s_Select()+ " WHERE ISREAD  Like N'%"+ sISREAD + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISINSERT(string sISINSERT)
{
          string sqlSelect= s_Select()+ " WHERE ISINSERT  Like N'%"+ sISINSERT + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISDELETE(string sISDELETE)
{
          string sqlSelect= s_Select()+ " WHERE ISDELETE  Like N'%"+ sISDELETE + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISUPDATE(string sISUPDATE)
{
          string sqlSelect= s_Select()+ " WHERE ISUPDATE  Like N'%"+ sISUPDATE + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPARENT_ID(string sPARENT_ID)
{
          string sqlSelect= s_Select()+ " WHERE PARENT_ID  ="+ sPARENT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPARENT_ID(string sPARENT_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PARENT_ID"+ sMatch +sPARENT_ID + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sID
            , string sNAME
            , string sDESCRIPTION
            , string sVISIBLE_BIT
            , string sISREAD
            , string sISINSERT
            , string sISDELETE
            , string sISUPDATE
            , string sPARENT_ID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sDESCRIPTION!=null && sDESCRIPTION!="") 
            sqlselect +=" AND DESCRIPTION LIKE N'%" + sDESCRIPTION +"%'" ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
      if (sISREAD!=null && sISREAD!="") 
            sqlselect +=" AND ISREAD LIKE N'%" + sISREAD +"%'" ;
      if (sISINSERT!=null && sISINSERT!="") 
            sqlselect +=" AND ISINSERT LIKE N'%" + sISINSERT +"%'" ;
      if (sISDELETE!=null && sISDELETE!="") 
            sqlselect +=" AND ISDELETE LIKE N'%" + sISDELETE +"%'" ;
      if (sISUPDATE!=null && sISUPDATE!="") 
            sqlselect +=" AND ISUPDATE LIKE N'%" + sISUPDATE +"%'" ;
      if (sPARENT_ID!=null && sPARENT_ID!="") 
            sqlselect +=" AND PARENT_ID =" + sPARENT_ID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect,sTableName);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static PQ_CHUC_NANG Insert_Object(
string  sNAME
            ,string  sDESCRIPTION
            ,string  sVISIBLE_BIT
            ,string  sISREAD
            ,string  sISINSERT
            ,string  sISDELETE
            ,string  sISUPDATE
            ,string  sPARENT_ID
            ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sDESCRIPTION=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDESCRIPTION,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");
              string tem_sISREAD=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISREAD,"char");
              string tem_sISINSERT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISINSERT,"char");
              string tem_sISDELETE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISDELETE,"char");
              string tem_sISUPDATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISUPDATE,"char");
              string tem_sPARENT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPARENT_ID,"bigint");

             string sqlSave=" INSERT INTO PQ_CHUC_NANG("+
                   "NAME," 
        +                   "DESCRIPTION," 
        +                   "VISIBLE_BIT," 
        +                   "ISREAD," 
        +                   "ISINSERT," 
        +                   "ISDELETE," 
        +                   "ISUPDATE," 
        +                   "PARENT_ID) VALUES("
 +tem_sNAME+","
 +tem_sDESCRIPTION+","
 +tem_sVISIBLE_BIT+","
 +tem_sISREAD+","
 +tem_sISINSERT+","
 +tem_sISDELETE+","
 +tem_sISUPDATE+","
 +tem_sPARENT_ID +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          PQ_CHUC_NANG newPQ_CHUC_NANG= new PQ_CHUC_NANG();
                 newPQ_CHUC_NANG.ID=GetTable( " SELECT TOP 1 ID FROM PQ_CHUC_NANG ORDER BY ID DESC ").Rows[0][0].ToString();
              newPQ_CHUC_NANG.NAME=sNAME;
              newPQ_CHUC_NANG.DESCRIPTION=sDESCRIPTION;
              newPQ_CHUC_NANG.VISIBLE_BIT=sVISIBLE_BIT;
              newPQ_CHUC_NANG.ISREAD=sISREAD;
              newPQ_CHUC_NANG.ISINSERT=sISINSERT;
              newPQ_CHUC_NANG.ISDELETE=sISDELETE;
              newPQ_CHUC_NANG.ISUPDATE=sISUPDATE;
              newPQ_CHUC_NANG.PARENT_ID=sPARENT_ID;
            return newPQ_CHUC_NANG; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sNAME
                ,string sDESCRIPTION
                ,string sVISIBLE_BIT
                ,string sISREAD
                ,string sISINSERT
                ,string sISDELETE
                ,string sISUPDATE
                ,string sPARENT_ID
                ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sDESCRIPTION=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDESCRIPTION,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");
              string tem_sISREAD=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISREAD,"char");
              string tem_sISINSERT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISINSERT,"char");
              string tem_sISDELETE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISDELETE,"char");
              string tem_sISUPDATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISUPDATE,"char");
              string tem_sPARENT_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPARENT_ID,"bigint");

 string sqlSave=" UPDATE PQ_CHUC_NANG SET "+"NAME ="+tem_sNAME+","
 +"DESCRIPTION ="+tem_sDESCRIPTION+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+","
 +"ISREAD ="+tem_sISREAD+","
 +"ISINSERT ="+tem_sISINSERT+","
 +"ISDELETE ="+tem_sISDELETE+","
 +"ISUPDATE ="+tem_sISUPDATE+","
 +"PARENT_ID ="+tem_sPARENT_ID+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.NAME=sNAME;
                this.DESCRIPTION=sDESCRIPTION;
                this.VISIBLE_BIT=sVISIBLE_BIT;
                this.ISREAD=sISREAD;
                this.ISINSERT=sISINSERT;
                this.ISDELETE=sISDELETE;
                this.ISUPDATE=sISUPDATE;
                this.PARENT_ID=sPARENT_ID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NAME(string sNAME)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DESCRIPTION(string sDESCRIPTION)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET DESCRIPTION='N"+ sDESCRIPTION+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DESCRIPTION=sDESCRIPTION;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.VISIBLE_BIT=sVISIBLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISREAD(string sISREAD)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET ISREAD='N"+ sISREAD+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISREAD=sISREAD;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISINSERT(string sISINSERT)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET ISINSERT='N"+ sISINSERT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISINSERT=sISINSERT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISDELETE(string sISDELETE)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET ISDELETE='N"+ sISDELETE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISDELETE=sISDELETE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISUPDATE(string sISUPDATE)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET ISUPDATE='N"+ sISUPDATE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISUPDATE=sISUPDATE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PARENT_ID(string sPARENT_ID)
{
    string sqlSave= " UPDATE PQ_CHUC_NANG SET PARENT_ID='"+ sPARENT_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PARENT_ID=sPARENT_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DESCRIPTION(string sDESCRIPTION,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET DESCRIPTION='N"+sDESCRIPTION+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISREAD(string sISREAD,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET ISREAD='N"+sISREAD+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISINSERT(string sISINSERT,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET ISINSERT='N"+sISINSERT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISDELETE(string sISDELETE,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET ISDELETE='N"+sISDELETE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISUPDATE(string sISUPDATE,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET ISUPDATE='N"+sISUPDATE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PARENT_ID(string sPARENT_ID,string s_ID)
{
  string sqlSave= " UPDATE PQ_CHUC_NANG SET PARENT_ID='"+sPARENT_ID+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM PQ_CHUC_NANG";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "PQ_CHUC_NANG");
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
   private static DataTable dt_PQ_CHUC_NANG;
   public static bool Change_dt_PQ_CHUC_NANG = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_PQ_CHUC_NANG()
   {
   if (dt_PQ_CHUC_NANG == null || Change_dt_PQ_CHUC_NANG == true)
     {
   dt_PQ_CHUC_NANG = GetTableAll();
         Change_dt_PQ_CHUC_NANG = true && AllowAutoChange ;
     }
     return dt_PQ_CHUC_NANG;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
