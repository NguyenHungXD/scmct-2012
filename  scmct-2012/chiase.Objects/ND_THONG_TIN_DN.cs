using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class ND_THONG_TIN_DN:  SQLConnectWeb { 
 public static string sTableName= "ND_THONG_TIN_DN"; 
   public string USERID;
   public string USERNAME;
   public string PWD;
   public string PWD1;
   public string PWD2;
   public string BLAST;
   public string LASTED_ACCESS;
   public string CREATED_BY;
   public string CREATED_DATE;
   public string EDITED_BY;
   public string EDITED_DATE;
   public string ISCHANGEPWD_BIT;
   public string ISACTIVE_BIT;
   public string MEM_ID;
   #region DataColumn Name ;
 public static  string cl_USERID="USERID" ;
 public static  string cl_USERNAME="USERNAME" ;
 public static  string cl_PWD="PWD" ;
 public static  string cl_PWD1="PWD1" ;
 public static  string cl_PWD2="PWD2" ;
 public static  string cl_BLAST="BLAST" ;
 public static  string cl_LASTED_ACCESS="LASTED_ACCESS" ;
 public static  string cl_CREATED_BY="CREATED_BY" ;
 public static  string cl_CREATED_DATE="CREATED_DATE" ;
 public static  string cl_EDITED_BY="EDITED_BY" ;
 public static  string cl_EDITED_DATE="EDITED_DATE" ;
 public static  string cl_ISCHANGEPWD_BIT="ISCHANGEPWD_BIT" ;
 public static  string cl_ISACTIVE_BIT="ISACTIVE_BIT" ;
 public static  string cl_MEM_ID="MEM_ID" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_THONG_TIN_DN() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_THONG_TIN_DN(
         string sUSERID,
         string sUSERNAME,
         string sPWD,
         string sPWD1,
         string sPWD2,
         string sBLAST,
         string sLASTED_ACCESS,
         string sCREATED_BY,
         string sCREATED_DATE,
         string sEDITED_BY,
         string sEDITED_DATE,
         string sISCHANGEPWD_BIT,
         string sISACTIVE_BIT,
         string sMEM_ID){
         this.USERID= sUSERID;
         this.USERNAME= sUSERNAME;
         this.PWD= sPWD;
         this.PWD1= sPWD1;
         this.PWD2= sPWD2;
         this.BLAST= sBLAST;
         this.LASTED_ACCESS= sLASTED_ACCESS;
         this.CREATED_BY= sCREATED_BY;
         this.CREATED_DATE= sCREATED_DATE;
         this.EDITED_BY= sEDITED_BY;
         this.EDITED_DATE= sEDITED_DATE;
         this.ISCHANGEPWD_BIT= sISCHANGEPWD_BIT;
         this.ISACTIVE_BIT= sISACTIVE_BIT;
         this.MEM_ID= sMEM_ID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static ND_THONG_TIN_DN Create_ND_THONG_TIN_DN ( string sUSERID  ){
    DataTable dt=SearchByUSERID(sUSERID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new ND_THONG_TIN_DN(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM ND_THONG_TIN_DN AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public ND_THONG_TIN_DN( DataView dv,int pos)
{
         this.USERID= dv[pos][0].ToString();
         this.USERNAME= dv[pos][1].ToString();
         this.PWD= dv[pos][2].ToString();
         this.PWD1= dv[pos][3].ToString();
         this.PWD2= dv[pos][4].ToString();
         this.BLAST= dv[pos][5].ToString();
         this.LASTED_ACCESS= dv[pos][6].ToString();
         this.CREATED_BY= dv[pos][7].ToString();
         this.CREATED_DATE= dv[pos][8].ToString();
         this.EDITED_BY= dv[pos][9].ToString();
         this.EDITED_DATE= dv[pos][10].ToString();
         this.ISCHANGEPWD_BIT= dv[pos][11].ToString();
         this.ISACTIVE_BIT= dv[pos][12].ToString();
         this.MEM_ID= dv[pos][13].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByUSERID(string sUSERID)
{
          string sqlSelect= s_Select()+ " WHERE USERID  ="+ sUSERID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByUSERID(string sUSERID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE USERID"+ sMatch +sUSERID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByUSERNAME(string sUSERNAME)
{
          string sqlSelect= s_Select()+ " WHERE USERNAME  Like N'%"+ sUSERNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPWD(string sPWD)
{
          string sqlSelect= s_Select()+ " WHERE PWD  Like N'%"+ sPWD + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPWD1(string sPWD1)
{
          string sqlSelect= s_Select()+ " WHERE PWD1  Like N'%"+ sPWD1 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPWD2(string sPWD2)
{
          string sqlSelect= s_Select()+ " WHERE PWD2  Like N'%"+ sPWD2 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByBLAST(string sBLAST)
{
          string sqlSelect= s_Select()+ " WHERE BLAST  Like N'%"+ sBLAST + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByLASTED_ACCESS(string sLASTED_ACCESS)
{
          string sqlSelect= s_Select()+ " WHERE LASTED_ACCESS  ="+ sLASTED_ACCESS + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByLASTED_ACCESS(string sLASTED_ACCESS,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LASTED_ACCESS"+ sMatch +sLASTED_ACCESS + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_BY(string sCREATED_BY)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_BY  ="+ sCREATED_BY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_BY(string sCREATED_BY,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_BY"+ sMatch +sCREATED_BY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_DATE(string sCREATED_DATE)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_DATE  ="+ sCREATED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByCREATED_DATE(string sCREATED_DATE,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CREATED_DATE"+ sMatch +sCREATED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_BY(string sEDITED_BY)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_BY  ="+ sEDITED_BY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_BY(string sEDITED_BY,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_BY"+ sMatch +sEDITED_BY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_DATE(string sEDITED_DATE)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_DATE  ="+ sEDITED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEDITED_DATE(string sEDITED_DATE,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE EDITED_DATE"+ sMatch +sEDITED_DATE + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISCHANGEPWD_BIT(string sISCHANGEPWD_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ISCHANGEPWD_BIT  Like N'%"+ sISCHANGEPWD_BIT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByISACTIVE_BIT(string sISACTIVE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE ISACTIVE_BIT  Like N'%"+ sISACTIVE_BIT + "%'"; 
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
 public static DataTable Search( string sUSERID
            , string sUSERNAME
            , string sPWD
            , string sPWD1
            , string sPWD2
            , string sBLAST
            , string sLASTED_ACCESS
            , string sCREATED_BY
            , string sCREATED_DATE
            , string sEDITED_BY
            , string sEDITED_DATE
            , string sISCHANGEPWD_BIT
            , string sISACTIVE_BIT
            , string sMEM_ID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sUSERID!=null && sUSERID!="") 
            sqlselect +=" AND USERID =" + sUSERID ;
      if (sUSERNAME!=null && sUSERNAME!="") 
            sqlselect +=" AND USERNAME LIKE N'%" + sUSERNAME +"%'" ;
      if (sPWD!=null && sPWD!="") 
            sqlselect +=" AND PWD LIKE N'%" + sPWD +"%'" ;
      if (sPWD1!=null && sPWD1!="") 
            sqlselect +=" AND PWD1 LIKE N'%" + sPWD1 +"%'" ;
      if (sPWD2!=null && sPWD2!="") 
            sqlselect +=" AND PWD2 LIKE N'%" + sPWD2 +"%'" ;
      if (sBLAST!=null && sBLAST!="") 
            sqlselect +=" AND BLAST LIKE N'%" + sBLAST +"%'" ;
      if (sLASTED_ACCESS!=null && sLASTED_ACCESS!="") 
            sqlselect +=" AND LASTED_ACCESS LIKE '%" + sLASTED_ACCESS +"%'" ;
      if (sCREATED_BY!=null && sCREATED_BY!="") 
            sqlselect +=" AND CREATED_BY =" + sCREATED_BY ;
      if (sCREATED_DATE!=null && sCREATED_DATE!="") 
            sqlselect +=" AND CREATED_DATE LIKE '%" + sCREATED_DATE +"%'" ;
      if (sEDITED_BY!=null && sEDITED_BY!="") 
            sqlselect +=" AND EDITED_BY =" + sEDITED_BY ;
      if (sEDITED_DATE!=null && sEDITED_DATE!="") 
            sqlselect +=" AND EDITED_DATE LIKE '%" + sEDITED_DATE +"%'" ;
      if (sISCHANGEPWD_BIT!=null && sISCHANGEPWD_BIT!="") 
            sqlselect +=" AND ISCHANGEPWD_BIT LIKE N'%" + sISCHANGEPWD_BIT +"%'" ;
      if (sISACTIVE_BIT!=null && sISACTIVE_BIT!="") 
            sqlselect +=" AND ISACTIVE_BIT LIKE N'%" + sISACTIVE_BIT +"%'" ;
      if (sMEM_ID!=null && sMEM_ID!="") 
            sqlselect +=" AND MEM_ID =" + sMEM_ID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static ND_THONG_TIN_DN Insert_Object(
string  sUSERNAME
            ,string  sPWD
            ,string  sPWD1
            ,string  sPWD2
            ,string  sBLAST
            ,string  sLASTED_ACCESS
            ,string  sCREATED_BY
            ,string  sCREATED_DATE
            ,string  sEDITED_BY
            ,string  sEDITED_DATE
            ,string  sISCHANGEPWD_BIT
            ,string  sISACTIVE_BIT
            ,string  sMEM_ID
            ) 
 { 
              string tem_sUSERNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sUSERNAME,"nvarchar");
              string tem_sPWD=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPWD,"nvarchar");
              string tem_sPWD1=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPWD1,"nvarchar");
              string tem_sPWD2=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPWD2,"nvarchar");
              string tem_sBLAST=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBLAST,"nvarchar");
              string tem_sLASTED_ACCESS=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLASTED_ACCESS,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"bigint");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sEDITED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_BY,"bigint");
              string tem_sEDITED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_DATE,"datetime");
              string tem_sISCHANGEPWD_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISCHANGEPWD_BIT,"char");
              string tem_sISACTIVE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISACTIVE_BIT,"char");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");

             string sqlSave=" INSERT INTO ND_THONG_TIN_DN("+
                   "USERNAME," 
        +                   "PWD," 
        +                   "PWD1," 
        +                   "PWD2," 
        +                   "BLAST," 
        +                   "LASTED_ACCESS," 
        +                   "CREATED_BY," 
        +                   "CREATED_DATE," 
        +                   "EDITED_BY," 
        +                   "EDITED_DATE," 
        +                   "ISCHANGEPWD_BIT," 
        +                   "ISACTIVE_BIT," 
        +                   "MEM_ID) VALUES("
 +tem_sUSERNAME+","
 +tem_sPWD+","
 +tem_sPWD1+","
 +tem_sPWD2+","
 +tem_sBLAST+","
 +tem_sLASTED_ACCESS+","
 +tem_sCREATED_BY+","
 +tem_sCREATED_DATE+","
 +tem_sEDITED_BY+","
 +tem_sEDITED_DATE+","
 +tem_sISCHANGEPWD_BIT+","
 +tem_sISACTIVE_BIT+","
 +tem_sMEM_ID +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          ND_THONG_TIN_DN newND_THONG_TIN_DN= new ND_THONG_TIN_DN();
                 newND_THONG_TIN_DN.USERID=GetTable( " SELECT TOP 1 USERID FROM ND_THONG_TIN_DN ORDER BY USERID DESC ").Rows[0][0].ToString();
              newND_THONG_TIN_DN.USERNAME=sUSERNAME;
              newND_THONG_TIN_DN.PWD=sPWD;
              newND_THONG_TIN_DN.PWD1=sPWD1;
              newND_THONG_TIN_DN.PWD2=sPWD2;
              newND_THONG_TIN_DN.BLAST=sBLAST;
              newND_THONG_TIN_DN.LASTED_ACCESS=sLASTED_ACCESS;
              newND_THONG_TIN_DN.CREATED_BY=sCREATED_BY;
              newND_THONG_TIN_DN.CREATED_DATE=sCREATED_DATE;
              newND_THONG_TIN_DN.EDITED_BY=sEDITED_BY;
              newND_THONG_TIN_DN.EDITED_DATE=sEDITED_DATE;
              newND_THONG_TIN_DN.ISCHANGEPWD_BIT=sISCHANGEPWD_BIT;
              newND_THONG_TIN_DN.ISACTIVE_BIT=sISACTIVE_BIT;
              newND_THONG_TIN_DN.MEM_ID=sMEM_ID;
            return newND_THONG_TIN_DN; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sUSERNAME
                ,string sPWD
                ,string sPWD1
                ,string sPWD2
                ,string sBLAST
                ,string sLASTED_ACCESS
                ,string sCREATED_BY
                ,string sCREATED_DATE
                ,string sEDITED_BY
                ,string sEDITED_DATE
                ,string sISCHANGEPWD_BIT
                ,string sISACTIVE_BIT
                ,string sMEM_ID
                ) 
 { 
              string tem_sUSERNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sUSERNAME,"nvarchar");
              string tem_sPWD=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPWD,"nvarchar");
              string tem_sPWD1=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPWD1,"nvarchar");
              string tem_sPWD2=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPWD2,"nvarchar");
              string tem_sBLAST=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBLAST,"nvarchar");
              string tem_sLASTED_ACCESS=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sLASTED_ACCESS,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"bigint");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sEDITED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_BY,"bigint");
              string tem_sEDITED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_DATE,"datetime");
              string tem_sISCHANGEPWD_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISCHANGEPWD_BIT,"char");
              string tem_sISACTIVE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sISACTIVE_BIT,"char");
              string tem_sMEM_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_ID,"bigint");

 string sqlSave=" UPDATE ND_THONG_TIN_DN SET "+"USERNAME ="+tem_sUSERNAME+","
 +"PWD ="+tem_sPWD+","
 +"PWD1 ="+tem_sPWD1+","
 +"PWD2 ="+tem_sPWD2+","
 +"BLAST ="+tem_sBLAST+","
 +"LASTED_ACCESS ="+tem_sLASTED_ACCESS+","
 +"CREATED_BY ="+tem_sCREATED_BY+","
 +"CREATED_DATE ="+tem_sCREATED_DATE+","
 +"EDITED_BY ="+tem_sEDITED_BY+","
 +"EDITED_DATE ="+tem_sEDITED_DATE+","
 +"ISCHANGEPWD_BIT ="+tem_sISCHANGEPWD_BIT+","
 +"ISACTIVE_BIT ="+tem_sISACTIVE_BIT+","
 +"MEM_ID ="+tem_sMEM_ID+" WHERE USERID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.USERID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.USERNAME=sUSERNAME;
                this.PWD=sPWD;
                this.PWD1=sPWD1;
                this.PWD2=sPWD2;
                this.BLAST=sBLAST;
                this.LASTED_ACCESS=sLASTED_ACCESS;
                this.CREATED_BY=sCREATED_BY;
                this.CREATED_DATE=sCREATED_DATE;
                this.EDITED_BY=sEDITED_BY;
                this.EDITED_DATE=sEDITED_DATE;
                this.ISCHANGEPWD_BIT=sISCHANGEPWD_BIT;
                this.ISACTIVE_BIT=sISACTIVE_BIT;
                this.MEM_ID=sMEM_ID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_USERID(string sUSERID)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET USERID='"+ sUSERID+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.USERID=sUSERID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_USERNAME(string sUSERNAME)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET USERNAME='N"+ sUSERNAME+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.USERNAME=sUSERNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PWD(string sPWD)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET PWD='N"+ sPWD+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PWD=sPWD;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PWD1(string sPWD1)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET PWD1='N"+ sPWD1+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PWD1=sPWD1;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PWD2(string sPWD2)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET PWD2='N"+ sPWD2+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PWD2=sPWD2;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BLAST(string sBLAST)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET BLAST='N"+ sBLAST+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BLAST=sBLAST;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LASTED_ACCESS(string sLASTED_ACCESS)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET LASTED_ACCESS='"+ sLASTED_ACCESS+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.LASTED_ACCESS=sLASTED_ACCESS;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CREATED_BY(string sCREATED_BY)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET CREATED_BY='"+ sCREATED_BY+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CREATED_BY=sCREATED_BY;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CREATED_DATE(string sCREATED_DATE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET CREATED_DATE='"+ sCREATED_DATE+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.CREATED_DATE=sCREATED_DATE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_EDITED_BY(string sEDITED_BY)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET EDITED_BY='"+ sEDITED_BY+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.EDITED_BY=sEDITED_BY;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_EDITED_DATE(string sEDITED_DATE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET EDITED_DATE='"+ sEDITED_DATE+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.EDITED_DATE=sEDITED_DATE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISCHANGEPWD_BIT(string sISCHANGEPWD_BIT)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET ISCHANGEPWD_BIT='N"+ sISCHANGEPWD_BIT+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISCHANGEPWD_BIT=sISCHANGEPWD_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISACTIVE_BIT(string sISACTIVE_BIT)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET ISACTIVE_BIT='N"+ sISACTIVE_BIT+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISACTIVE_BIT=sISACTIVE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MEM_ID(string sMEM_ID)
{
    string sqlSave= " UPDATE ND_THONG_TIN_DN SET MEM_ID='"+ sMEM_ID+ "' WHERE USERID='"+ this.USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MEM_ID=sMEM_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_USERNAME(string sUSERNAME,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET USERNAME='N"+sUSERNAME+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PWD(string sPWD,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET PWD='N"+sPWD+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PWD1(string sPWD1,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET PWD1='N"+sPWD1+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PWD2(string sPWD2,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET PWD2='N"+sPWD2+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BLAST(string sBLAST,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET BLAST='N"+sBLAST+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LASTED_ACCESS(string sLASTED_ACCESS,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET LASTED_ACCESS='"+sLASTED_ACCESS+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_BY(string sCREATED_BY,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET CREATED_BY='"+sCREATED_BY+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_DATE(string sCREATED_DATE,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET CREATED_DATE='"+sCREATED_DATE+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EDITED_BY(string sEDITED_BY,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET EDITED_BY='"+sEDITED_BY+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EDITED_DATE(string sEDITED_DATE,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET EDITED_DATE='"+sEDITED_DATE+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISCHANGEPWD_BIT(string sISCHANGEPWD_BIT,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET ISCHANGEPWD_BIT='N"+sISCHANGEPWD_BIT+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISACTIVE_BIT(string sISACTIVE_BIT,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET ISACTIVE_BIT='N"+sISACTIVE_BIT+"' WHERE USERID='"+ s_USERID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MEM_ID(string sMEM_ID,string s_USERID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_DN SET MEM_ID='"+sMEM_ID+"' WHERE USERID='"+ s_USERID+"' ";
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
   string sqlSelect = " SELECT * FROM ND_THONG_TIN_DN";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "ND_THONG_TIN_DN");
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
   private static DataTable dt_ND_THONG_TIN_DN;
   public static bool Change_dt_ND_THONG_TIN_DN = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_ND_THONG_TIN_DN()
   {
   if (dt_ND_THONG_TIN_DN == null || Change_dt_ND_THONG_TIN_DN == true)
     {
   dt_ND_THONG_TIN_DN = GetTableAll();
         Change_dt_ND_THONG_TIN_DN = true && AllowAutoChange ;
     }
     return dt_ND_THONG_TIN_DN;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
