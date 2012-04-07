using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class BV_DM_CHU_DE_BV:  SQLConnectWeb { 
 public static string sTableName= "BV_DM_CHU_DE_BV"; 
   public string ID;
   public string TITLE;
   public string VISIBLE_BIT;
   public string SORT;
   public string STATUS;
   public string DESCRIPTION;
   public string CREATED_DATE;
   public string CREATED_BY;
   public string EDITED_DATE;
   public string EDITED_BY;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_TITLE="TITLE" ;
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 public static  string cl_SORT="SORT" ;
 public static  string cl_STATUS="STATUS" ;
 public static  string cl_DESCRIPTION="DESCRIPTION" ;
 public static  string cl_CREATED_DATE="CREATED_DATE" ;
 public static  string cl_CREATED_BY="CREATED_BY" ;
 public static  string cl_EDITED_DATE="EDITED_DATE" ;
 public static  string cl_EDITED_BY="EDITED_BY" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public BV_DM_CHU_DE_BV() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public BV_DM_CHU_DE_BV(
         string sID,
         string sTITLE,
         string sVISIBLE_BIT,
         string sSORT,
         string sSTATUS,
         string sDESCRIPTION,
         string sCREATED_DATE,
         string sCREATED_BY,
         string sEDITED_DATE,
         string sEDITED_BY){
         this.ID= sID;
         this.TITLE= sTITLE;
         this.VISIBLE_BIT= sVISIBLE_BIT;
         this.SORT= sSORT;
         this.STATUS= sSTATUS;
         this.DESCRIPTION= sDESCRIPTION;
         this.CREATED_DATE= sCREATED_DATE;
         this.CREATED_BY= sCREATED_BY;
         this.EDITED_DATE= sEDITED_DATE;
         this.EDITED_BY= sEDITED_BY;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static BV_DM_CHU_DE_BV Create_BV_DM_CHU_DE_BV ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new BV_DM_CHU_DE_BV(dt,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM BV_DM_CHU_DE_BV AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public BV_DM_CHU_DE_BV( DataTable table,int pos)
{
         this.ID= table.Rows[pos]["ID"].ToString();
         this.TITLE= table.Rows[pos]["TITLE"].ToString();
         this.VISIBLE_BIT= table.Rows[pos]["VISIBLE_BIT"].ToString();
         this.SORT= table.Rows[pos]["SORT"].ToString();
         this.STATUS= table.Rows[pos]["STATUS"].ToString();
         this.DESCRIPTION= table.Rows[pos]["DESCRIPTION"].ToString();
         this.CREATED_DATE= table.Rows[pos]["CREATED_DATE"].ToString();
         this.CREATED_BY= table.Rows[pos]["CREATED_BY"].ToString();
         this.EDITED_DATE= table.Rows[pos]["EDITED_DATE"].ToString();
         this.EDITED_BY= table.Rows[pos]["EDITED_BY"].ToString();
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
 public static DataTable SearchByTITLE(string sTITLE)
{
          string sqlSelect= s_Select()+ " WHERE TITLE  Like N'%"+ sTITLE + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByVISIBLE_BIT(string sVISIBLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE VISIBLE_BIT  Like N'%"+ sVISIBLE_BIT + "%'"; 
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
 public static DataTable SearchBySTATUS(string sSTATUS)
{
          string sqlSelect= s_Select()+ " WHERE STATUS  ="+ sSTATUS + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySTATUS(string sSTATUS,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE STATUS"+ sMatch +sSTATUS + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByDESCRIPTION(string sDESCRIPTION)
{
          string sqlSelect= s_Select()+ " WHERE DESCRIPTION  Like N'%"+ sDESCRIPTION + "%'"; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_DATE(string sCREATED_DATE)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_DATE  ="+ sCREATED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_DATE(string sCREATED_DATE,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_DATE"+ sMatch +sCREATED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_BY(string sCREATED_BY)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_BY  ="+ sCREATED_BY + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_BY(string sCREATED_BY,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_BY"+ sMatch +sCREATED_BY + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_DATE(string sEDITED_DATE)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_DATE  ="+ sEDITED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_DATE(string sEDITED_DATE,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_DATE"+ sMatch +sEDITED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_BY(string sEDITED_BY)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_BY  ="+ sEDITED_BY + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_BY(string sEDITED_BY,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_BY"+ sMatch +sEDITED_BY + ""; 
          DataTable dt=GetTable(sqlSelect,sTableName) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable Search( string sID
            , string sTITLE
            , string sVISIBLE_BIT
            , string sSORT
            , string sSTATUS
            , string sDESCRIPTION
            , string sCREATED_DATE
            , string sCREATED_BY
            , string sEDITED_DATE
            , string sEDITED_BY
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sTITLE!=null && sTITLE!="") 
            sqlselect +=" AND TITLE LIKE N'%" + sTITLE +"%'" ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
      if (sSORT!=null && sSORT!="") 
            sqlselect +=" AND SORT =" + sSORT ;
      if (sSTATUS!=null && sSTATUS!="") 
            sqlselect +=" AND STATUS =" + sSTATUS ;
      if (sDESCRIPTION!=null && sDESCRIPTION!="") 
            sqlselect +=" AND DESCRIPTION LIKE N'%" + sDESCRIPTION +"%'" ;
      if (sCREATED_DATE!=null && sCREATED_DATE!="") 
            sqlselect +=" AND CREATED_DATE LIKE '%" + sCREATED_DATE +"%'" ;
      if (sCREATED_BY!=null && sCREATED_BY!="") 
            sqlselect +=" AND CREATED_BY =" + sCREATED_BY ;
      if (sEDITED_DATE!=null && sEDITED_DATE!="") 
            sqlselect +=" AND EDITED_DATE LIKE '%" + sEDITED_DATE +"%'" ;
      if (sEDITED_BY!=null && sEDITED_BY!="") 
            sqlselect +=" AND EDITED_BY =" + sEDITED_BY ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect,sTableName);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static BV_DM_CHU_DE_BV Insert_Object(
string  sTITLE
            ,string  sVISIBLE_BIT
            ,string  sSORT
            ,string  sSTATUS
            ,string  sDESCRIPTION
            ,string  sCREATED_DATE
            ,string  sCREATED_BY
            ,string  sEDITED_DATE
            ,string  sEDITED_BY
            ) 
 { 
              string tem_sTITLE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTITLE,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");
              string tem_sSORT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSORT,"int");
              string tem_sSTATUS=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSTATUS,"bigint");
              string tem_sDESCRIPTION=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDESCRIPTION,"nvarchar");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"bigint");
              string tem_sEDITED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_DATE,"datetime");
              string tem_sEDITED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_BY,"bigint");

             string sqlSave=" INSERT INTO BV_DM_CHU_DE_BV("+
                   "TITLE," 
        +                   "VISIBLE_BIT," 
        +                   "SORT," 
        +                   "STATUS," 
        +                   "DESCRIPTION," 
        +                   "CREATED_DATE," 
        +                   "CREATED_BY," 
        +                   "EDITED_DATE," 
        +                   "EDITED_BY) VALUES("
 +tem_sTITLE+","
 +tem_sVISIBLE_BIT+","
 +tem_sSORT+","
 +tem_sSTATUS+","
 +tem_sDESCRIPTION+","
 +tem_sCREATED_DATE+","
 +tem_sCREATED_BY+","
 +tem_sEDITED_DATE+","
 +tem_sEDITED_BY +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          BV_DM_CHU_DE_BV newBV_DM_CHU_DE_BV= new BV_DM_CHU_DE_BV();
                 newBV_DM_CHU_DE_BV.ID=GetTable( " SELECT TOP 1 ID FROM BV_DM_CHU_DE_BV ORDER BY ID DESC ").Rows[0][0].ToString();
              newBV_DM_CHU_DE_BV.TITLE=sTITLE;
              newBV_DM_CHU_DE_BV.VISIBLE_BIT=sVISIBLE_BIT;
              newBV_DM_CHU_DE_BV.SORT=sSORT;
              newBV_DM_CHU_DE_BV.STATUS=sSTATUS;
              newBV_DM_CHU_DE_BV.DESCRIPTION=sDESCRIPTION;
              newBV_DM_CHU_DE_BV.CREATED_DATE=sCREATED_DATE;
              newBV_DM_CHU_DE_BV.CREATED_BY=sCREATED_BY;
              newBV_DM_CHU_DE_BV.EDITED_DATE=sEDITED_DATE;
              newBV_DM_CHU_DE_BV.EDITED_BY=sEDITED_BY;
            return newBV_DM_CHU_DE_BV; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sTITLE
                ,string sVISIBLE_BIT
                ,string sSORT
                ,string sSTATUS
                ,string sDESCRIPTION
                ,string sCREATED_DATE
                ,string sCREATED_BY
                ,string sEDITED_DATE
                ,string sEDITED_BY
                ) 
 { 
              string tem_sTITLE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTITLE,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");
              string tem_sSORT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSORT,"int");
              string tem_sSTATUS=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSTATUS,"bigint");
              string tem_sDESCRIPTION=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sDESCRIPTION,"nvarchar");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"bigint");
              string tem_sEDITED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_DATE,"datetime");
              string tem_sEDITED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_BY,"bigint");

 string sqlSave=" UPDATE BV_DM_CHU_DE_BV SET "+"TITLE ="+tem_sTITLE+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+","
 +"SORT ="+tem_sSORT+","
 +"STATUS ="+tem_sSTATUS+","
 +"DESCRIPTION ="+tem_sDESCRIPTION+","
 +"CREATED_DATE ="+tem_sCREATED_DATE+","
 +"CREATED_BY ="+tem_sCREATED_BY+","
 +"EDITED_DATE ="+tem_sEDITED_DATE+","
 +"EDITED_BY ="+tem_sEDITED_BY+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.TITLE=sTITLE;
                this.VISIBLE_BIT=sVISIBLE_BIT;
                this.SORT=sSORT;
                this.STATUS=sSTATUS;
                this.DESCRIPTION=sDESCRIPTION;
                this.CREATED_DATE=sCREATED_DATE;
                this.CREATED_BY=sCREATED_BY;
                this.EDITED_DATE=sEDITED_DATE;
                this.EDITED_BY=sEDITED_BY;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_ID(string sID)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ID=sID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TITLE(string sTITLE)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET TITLE='N"+ sTITLE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TITLE=sTITLE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.VISIBLE_BIT=sVISIBLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SORT(string sSORT)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET SORT='"+ sSORT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SORT=sSORT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_STATUS(string sSTATUS)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET STATUS='"+ sSTATUS+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.STATUS=sSTATUS;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DESCRIPTION(string sDESCRIPTION)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET DESCRIPTION='N"+ sDESCRIPTION+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DESCRIPTION=sDESCRIPTION;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CREATED_DATE(string sCREATED_DATE)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET CREATED_DATE='"+ sCREATED_DATE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CREATED_DATE=sCREATED_DATE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CREATED_BY(string sCREATED_BY)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET CREATED_BY='"+ sCREATED_BY+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CREATED_BY=sCREATED_BY;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_EDITED_DATE(string sEDITED_DATE)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET EDITED_DATE='"+ sEDITED_DATE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.EDITED_DATE=sEDITED_DATE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_EDITED_BY(string sEDITED_BY)
{
    string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET EDITED_BY='"+ sEDITED_BY+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.EDITED_BY=sEDITED_BY;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_TITLE(string sTITLE,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET TITLE='N"+sTITLE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SORT(string sSORT,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET SORT='"+sSORT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_STATUS(string sSTATUS,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET STATUS='"+sSTATUS+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DESCRIPTION(string sDESCRIPTION,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET DESCRIPTION='N"+sDESCRIPTION+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_DATE(string sCREATED_DATE,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET CREATED_DATE='"+sCREATED_DATE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_BY(string sCREATED_BY,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET CREATED_BY='"+sCREATED_BY+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EDITED_DATE(string sEDITED_DATE,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET EDITED_DATE='"+sEDITED_DATE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EDITED_BY(string sEDITED_BY,string s_ID)
{
  string sqlSave= " UPDATE BV_DM_CHU_DE_BV SET EDITED_BY='"+sEDITED_BY+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM BV_DM_CHU_DE_BV";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "BV_DM_CHU_DE_BV");
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
   private static DataTable dt_BV_DM_CHU_DE_BV;
   public static bool Change_dt_BV_DM_CHU_DE_BV = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_BV_DM_CHU_DE_BV()
   {
   if (dt_BV_DM_CHU_DE_BV == null || Change_dt_BV_DM_CHU_DE_BV == true)
     {
   dt_BV_DM_CHU_DE_BV = GetTableAll();
         Change_dt_BV_DM_CHU_DE_BV = true && AllowAutoChange ;
     }
     return dt_BV_DM_CHU_DE_BV;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
