using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DK2C.DataAccess.Web;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace chiase.Objects
  { 
 public class ND_THONG_TIN_ND:  SQLConnectWeb { 
 public static string sTableName= "ND_THONG_TIN_ND"; 
   public string ID;
   public string NAME;
   public string MEM_GROUP_ID;
   public string ADDRESS;
   public string BIRTH_DAY;
   public string SEX;
   public string PHONE;
   public string FAX;
   public string EMAIL;
   public string WEBSITE;
   public string YAHOO;
   public string SKYPE;
   public string TAX_CODE;
   public string NOTE;
   public string AVATAR_PATH;
   public string VISIBLE_BIT;
   public string CREATED_DATE;
   public string CREATED_BY;
   public string EDITED_DATE;
   public string EDITED_BY;
   #region DataColumn Name ;
 public static  string cl_ID="ID" ;
 public static  string cl_NAME="NAME" ;
 public static  string cl_MEM_GROUP_ID="MEM_GROUP_ID" ;
 public static  string cl_ADDRESS="ADDRESS" ;
 public static  string cl_BIRTH_DAY="BIRTH_DAY" ;
 public static  string cl_SEX="SEX" ;
 public static  string cl_PHONE="PHONE" ;
 public static  string cl_FAX="FAX" ;
 public static  string cl_EMAIL="EMAIL" ;
 public static  string cl_WEBSITE="WEBSITE" ;
 public static  string cl_YAHOO="YAHOO" ;
 public static  string cl_SKYPE="SKYPE" ;
 public static  string cl_TAX_CODE="TAX_CODE" ;
 public static  string cl_NOTE="NOTE" ;
 public static  string cl_AVATAR_PATH="AVATAR_PATH" ;
 public static  string cl_VISIBLE_BIT="VISIBLE_BIT" ;
 public static  string cl_CREATED_DATE="CREATED_DATE" ;
 public static  string cl_CREATED_BY="CREATED_BY" ;
 public static  string cl_EDITED_DATE="EDITED_DATE" ;
 public static  string cl_EDITED_BY="EDITED_BY" ;
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_THONG_TIN_ND() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public ND_THONG_TIN_ND(
         string sID,
         string sNAME,
         string sMEM_GROUP_ID,
         string sADDRESS,
         string sBIRTH_DAY,
         string sSEX,
         string sPHONE,
         string sFAX,
         string sEMAIL,
         string sWEBSITE,
         string sYAHOO,
         string sSKYPE,
         string sTAX_CODE,
         string sNOTE,
         string sAVATAR_PATH,
         string sVISIBLE_BIT,
         string sCREATED_DATE,
         string sCREATED_BY,
         string sEDITED_DATE,
         string sEDITED_BY){
         this.ID= sID;
         this.NAME= sNAME;
         this.MEM_GROUP_ID= sMEM_GROUP_ID;
         this.ADDRESS= sADDRESS;
         this.BIRTH_DAY= sBIRTH_DAY;
         this.SEX= sSEX;
         this.PHONE= sPHONE;
         this.FAX= sFAX;
         this.EMAIL= sEMAIL;
         this.WEBSITE= sWEBSITE;
         this.YAHOO= sYAHOO;
         this.SKYPE= sSKYPE;
         this.TAX_CODE= sTAX_CODE;
         this.NOTE= sNOTE;
         this.AVATAR_PATH= sAVATAR_PATH;
         this.VISIBLE_BIT= sVISIBLE_BIT;
         this.CREATED_DATE= sCREATED_DATE;
         this.CREATED_BY= sCREATED_BY;
         this.EDITED_DATE= sEDITED_DATE;
         this.EDITED_BY= sEDITED_BY;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static ND_THONG_TIN_ND Create_ND_THONG_TIN_ND ( string sID  ){
    DataTable dt=SearchByID(sID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new ND_THONG_TIN_ND(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM ND_THONG_TIN_ND AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public ND_THONG_TIN_ND( DataView dv,int pos)
{
         this.ID= dv[pos][0].ToString();
         this.NAME= dv[pos][1].ToString();
         this.MEM_GROUP_ID= dv[pos][2].ToString();
         this.ADDRESS= dv[pos][3].ToString();
         this.BIRTH_DAY= dv[pos][4].ToString();
         this.SEX= dv[pos][5].ToString();
         this.PHONE= dv[pos][6].ToString();
         this.FAX= dv[pos][7].ToString();
         this.EMAIL= dv[pos][8].ToString();
         this.WEBSITE= dv[pos][9].ToString();
         this.YAHOO= dv[pos][10].ToString();
         this.SKYPE= dv[pos][11].ToString();
         this.TAX_CODE= dv[pos][12].ToString();
         this.NOTE= dv[pos][13].ToString();
         this.AVATAR_PATH= dv[pos][14].ToString();
         this.VISIBLE_BIT= dv[pos][15].ToString();
         this.CREATED_DATE= dv[pos][16].ToString();
         this.CREATED_BY= dv[pos][17].ToString();
         this.EDITED_DATE= dv[pos][18].ToString();
         this.EDITED_BY= dv[pos][19].ToString();
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
 public static DataTable SearchByNAME(string sNAME)
{
          string sqlSelect= s_Select()+ " WHERE NAME  Like N'%"+ sNAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMEM_GROUP_ID(string sMEM_GROUP_ID)
{
          string sqlSelect= s_Select()+ " WHERE MEM_GROUP_ID  ="+ sMEM_GROUP_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByMEM_GROUP_ID(string sMEM_GROUP_ID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE MEM_GROUP_ID"+ sMatch +sMEM_GROUP_ID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByADDRESS(string sADDRESS)
{
          string sqlSelect= s_Select()+ " WHERE ADDRESS  Like N'%"+ sADDRESS + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByBIRTH_DAY(string sBIRTH_DAY)
{
          string sqlSelect= s_Select()+ " WHERE BIRTH_DAY  ="+ sBIRTH_DAY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByBIRTH_DAY(string sBIRTH_DAY,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BIRTH_DAY"+ sMatch +sBIRTH_DAY + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySEX(string sSEX)
{
          string sqlSelect= s_Select()+ " WHERE SEX  ="+ sSEX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySEX(string sSEX,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SEX"+ sMatch +sSEX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByPHONE(string sPHONE)
{
          string sqlSelect= s_Select()+ " WHERE PHONE  Like N'%"+ sPHONE + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByFAX(string sFAX)
{
          string sqlSelect= s_Select()+ " WHERE FAX  Like N'%"+ sFAX + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByEMAIL(string sEMAIL)
{
          string sqlSelect= s_Select()+ " WHERE EMAIL  Like N'%"+ sEMAIL + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByWEBSITE(string sWEBSITE)
{
          string sqlSelect= s_Select()+ " WHERE WEBSITE  Like N'%"+ sWEBSITE + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByYAHOO(string sYAHOO)
{
          string sqlSelect= s_Select()+ " WHERE YAHOO  Like N'%"+ sYAHOO + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchBySKYPE(string sSKYPE)
{
          string sqlSelect= s_Select()+ " WHERE SKYPE  Like N'%"+ sSKYPE + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByTAX_CODE(string sTAX_CODE)
{
          string sqlSelect= s_Select()+ " WHERE TAX_CODE  Like N'%"+ sTAX_CODE + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByNOTE(string sNOTE)
{
          string sqlSelect= s_Select()+ " WHERE NOTE  Like N'%"+ sNOTE + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByAVATAR_PATH(string sAVATAR_PATH)
{
          string sqlSelect= s_Select()+ " WHERE AVATAR_PATH  Like N'%"+ sAVATAR_PATH + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable SearchByVISIBLE_BIT(string sVISIBLE_BIT)
{
          string sqlSelect= s_Select()+ " WHERE VISIBLE_BIT  Like N'%"+ sVISIBLE_BIT + "%'"; 
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
 public static DataTable Search( string sID
            , string sNAME
            , string sMEM_GROUP_ID
            , string sADDRESS
            , string sBIRTH_DAY
            , string sSEX
            , string sPHONE
            , string sFAX
            , string sEMAIL
            , string sWEBSITE
            , string sYAHOO
            , string sSKYPE
            , string sTAX_CODE
            , string sNOTE
            , string sAVATAR_PATH
            , string sVISIBLE_BIT
            , string sCREATED_DATE
            , string sCREATED_BY
            , string sEDITED_DATE
            , string sEDITED_BY
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sID!=null && sID!="") 
            sqlselect +=" AND ID =" + sID ;
      if (sNAME!=null && sNAME!="") 
            sqlselect +=" AND NAME LIKE N'%" + sNAME +"%'" ;
      if (sMEM_GROUP_ID!=null && sMEM_GROUP_ID!="") 
            sqlselect +=" AND MEM_GROUP_ID =" + sMEM_GROUP_ID ;
      if (sADDRESS!=null && sADDRESS!="") 
            sqlselect +=" AND ADDRESS LIKE N'%" + sADDRESS +"%'" ;
      if (sBIRTH_DAY!=null && sBIRTH_DAY!="") 
            sqlselect +=" AND BIRTH_DAY LIKE '%" + sBIRTH_DAY +"%'" ;
      if (sSEX!=null && sSEX!="") 
            sqlselect +=" AND SEX =" + sSEX ;
      if (sPHONE!=null && sPHONE!="") 
            sqlselect +=" AND PHONE LIKE N'%" + sPHONE +"%'" ;
      if (sFAX!=null && sFAX!="") 
            sqlselect +=" AND FAX LIKE N'%" + sFAX +"%'" ;
      if (sEMAIL!=null && sEMAIL!="") 
            sqlselect +=" AND EMAIL LIKE N'%" + sEMAIL +"%'" ;
      if (sWEBSITE!=null && sWEBSITE!="") 
            sqlselect +=" AND WEBSITE LIKE N'%" + sWEBSITE +"%'" ;
      if (sYAHOO!=null && sYAHOO!="") 
            sqlselect +=" AND YAHOO LIKE N'%" + sYAHOO +"%'" ;
      if (sSKYPE!=null && sSKYPE!="") 
            sqlselect +=" AND SKYPE LIKE N'%" + sSKYPE +"%'" ;
      if (sTAX_CODE!=null && sTAX_CODE!="") 
            sqlselect +=" AND TAX_CODE LIKE N'%" + sTAX_CODE +"%'" ;
      if (sNOTE!=null && sNOTE!="") 
            sqlselect +=" AND NOTE LIKE N'%" + sNOTE +"%'" ;
      if (sAVATAR_PATH!=null && sAVATAR_PATH!="") 
            sqlselect +=" AND AVATAR_PATH LIKE N'%" + sAVATAR_PATH +"%'" ;
      if (sVISIBLE_BIT!=null && sVISIBLE_BIT!="") 
            sqlselect +=" AND VISIBLE_BIT LIKE N'%" + sVISIBLE_BIT +"%'" ;
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
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static ND_THONG_TIN_ND Insert_Object(
string  sNAME
            ,string  sMEM_GROUP_ID
            ,string  sADDRESS
            ,string  sBIRTH_DAY
            ,string  sSEX
            ,string  sPHONE
            ,string  sFAX
            ,string  sEMAIL
            ,string  sWEBSITE
            ,string  sYAHOO
            ,string  sSKYPE
            ,string  sTAX_CODE
            ,string  sNOTE
            ,string  sAVATAR_PATH
            ,string  sVISIBLE_BIT
            ,string  sCREATED_DATE
            ,string  sCREATED_BY
            ,string  sEDITED_DATE
            ,string  sEDITED_BY
            ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sMEM_GROUP_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_GROUP_ID,"bigint");
              string tem_sADDRESS=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sADDRESS,"nvarchar");
              string tem_sBIRTH_DAY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBIRTH_DAY,"datetime");
              string tem_sSEX=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSEX,"int");
              string tem_sPHONE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPHONE,"nvarchar");
              string tem_sFAX=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sFAX,"nvarchar");
              string tem_sEMAIL=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEMAIL,"nvarchar");
              string tem_sWEBSITE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sWEBSITE,"nvarchar");
              string tem_sYAHOO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYAHOO,"nvarchar");
              string tem_sSKYPE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSKYPE,"nvarchar");
              string tem_sTAX_CODE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTAX_CODE,"nvarchar");
              string tem_sNOTE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOTE,"nvarchar");
              string tem_sAVATAR_PATH=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sAVATAR_PATH,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"bigint");
              string tem_sEDITED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_DATE,"datetime");
              string tem_sEDITED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_BY,"bigint");

             string sqlSave=" INSERT INTO ND_THONG_TIN_ND("+
                   "NAME," 
        +                   "MEM_GROUP_ID," 
        +                   "ADDRESS," 
        +                   "BIRTH_DAY," 
        +                   "SEX," 
        +                   "PHONE," 
        +                   "FAX," 
        +                   "EMAIL," 
        +                   "WEBSITE," 
        +                   "YAHOO," 
        +                   "SKYPE," 
        +                   "TAX_CODE," 
        +                   "NOTE," 
        +                   "AVATAR_PATH," 
        +                   "VISIBLE_BIT," 
        +                   "CREATED_DATE," 
        +                   "CREATED_BY," 
        +                   "EDITED_DATE," 
        +                   "EDITED_BY) VALUES("
 +tem_sNAME+","
 +tem_sMEM_GROUP_ID+","
 +tem_sADDRESS+","
 +tem_sBIRTH_DAY+","
 +tem_sSEX+","
 +tem_sPHONE+","
 +tem_sFAX+","
 +tem_sEMAIL+","
 +tem_sWEBSITE+","
 +tem_sYAHOO+","
 +tem_sSKYPE+","
 +tem_sTAX_CODE+","
 +tem_sNOTE+","
 +tem_sAVATAR_PATH+","
 +tem_sVISIBLE_BIT+","
 +tem_sCREATED_DATE+","
 +tem_sCREATED_BY+","
 +tem_sEDITED_DATE+","
 +tem_sEDITED_BY +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          ND_THONG_TIN_ND newND_THONG_TIN_ND= new ND_THONG_TIN_ND();
                 newND_THONG_TIN_ND.ID=GetTable( " SELECT TOP 1 ID FROM ND_THONG_TIN_ND ORDER BY ID DESC ").Rows[0][0].ToString();
              newND_THONG_TIN_ND.NAME=sNAME;
              newND_THONG_TIN_ND.MEM_GROUP_ID=sMEM_GROUP_ID;
              newND_THONG_TIN_ND.ADDRESS=sADDRESS;
              newND_THONG_TIN_ND.BIRTH_DAY=sBIRTH_DAY;
              newND_THONG_TIN_ND.SEX=sSEX;
              newND_THONG_TIN_ND.PHONE=sPHONE;
              newND_THONG_TIN_ND.FAX=sFAX;
              newND_THONG_TIN_ND.EMAIL=sEMAIL;
              newND_THONG_TIN_ND.WEBSITE=sWEBSITE;
              newND_THONG_TIN_ND.YAHOO=sYAHOO;
              newND_THONG_TIN_ND.SKYPE=sSKYPE;
              newND_THONG_TIN_ND.TAX_CODE=sTAX_CODE;
              newND_THONG_TIN_ND.NOTE=sNOTE;
              newND_THONG_TIN_ND.AVATAR_PATH=sAVATAR_PATH;
              newND_THONG_TIN_ND.VISIBLE_BIT=sVISIBLE_BIT;
              newND_THONG_TIN_ND.CREATED_DATE=sCREATED_DATE;
              newND_THONG_TIN_ND.CREATED_BY=sCREATED_BY;
              newND_THONG_TIN_ND.EDITED_DATE=sEDITED_DATE;
              newND_THONG_TIN_ND.EDITED_BY=sEDITED_BY;
            return newND_THONG_TIN_ND; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sNAME
                ,string sMEM_GROUP_ID
                ,string sADDRESS
                ,string sBIRTH_DAY
                ,string sSEX
                ,string sPHONE
                ,string sFAX
                ,string sEMAIL
                ,string sWEBSITE
                ,string sYAHOO
                ,string sSKYPE
                ,string sTAX_CODE
                ,string sNOTE
                ,string sAVATAR_PATH
                ,string sVISIBLE_BIT
                ,string sCREATED_DATE
                ,string sCREATED_BY
                ,string sEDITED_DATE
                ,string sEDITED_BY
                ) 
 { 
              string tem_sNAME=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNAME,"nvarchar");
              string tem_sMEM_GROUP_ID=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sMEM_GROUP_ID,"bigint");
              string tem_sADDRESS=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sADDRESS,"nvarchar");
              string tem_sBIRTH_DAY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sBIRTH_DAY,"datetime");
              string tem_sSEX=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSEX,"int");
              string tem_sPHONE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sPHONE,"nvarchar");
              string tem_sFAX=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sFAX,"nvarchar");
              string tem_sEMAIL=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEMAIL,"nvarchar");
              string tem_sWEBSITE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sWEBSITE,"nvarchar");
              string tem_sYAHOO=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sYAHOO,"nvarchar");
              string tem_sSKYPE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sSKYPE,"nvarchar");
              string tem_sTAX_CODE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sTAX_CODE,"nvarchar");
              string tem_sNOTE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sNOTE,"nvarchar");
              string tem_sAVATAR_PATH=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sAVATAR_PATH,"nvarchar");
              string tem_sVISIBLE_BIT=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sVISIBLE_BIT,"char");
              string tem_sCREATED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_DATE,"datetime");
              string tem_sCREATED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sCREATED_BY,"bigint");
              string tem_sEDITED_DATE=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_DATE,"datetime");
              string tem_sEDITED_BY=DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(sEDITED_BY,"bigint");

 string sqlSave=" UPDATE ND_THONG_TIN_ND SET "+"NAME ="+tem_sNAME+","
 +"MEM_GROUP_ID ="+tem_sMEM_GROUP_ID+","
 +"ADDRESS ="+tem_sADDRESS+","
 +"BIRTH_DAY ="+tem_sBIRTH_DAY+","
 +"SEX ="+tem_sSEX+","
 +"PHONE ="+tem_sPHONE+","
 +"FAX ="+tem_sFAX+","
 +"EMAIL ="+tem_sEMAIL+","
 +"WEBSITE ="+tem_sWEBSITE+","
 +"YAHOO ="+tem_sYAHOO+","
 +"SKYPE ="+tem_sSKYPE+","
 +"TAX_CODE ="+tem_sTAX_CODE+","
 +"NOTE ="+tem_sNOTE+","
 +"AVATAR_PATH ="+tem_sAVATAR_PATH+","
 +"VISIBLE_BIT ="+tem_sVISIBLE_BIT+","
 +"CREATED_DATE ="+tem_sCREATED_DATE+","
 +"CREATED_BY ="+tem_sCREATED_BY+","
 +"EDITED_DATE ="+tem_sEDITED_DATE+","
 +"EDITED_BY ="+tem_sEDITED_BY+" WHERE ID="+DK2C.DataAccess.Web.SQLToolWeb.GetSaveValue(this.ID,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.NAME=sNAME;
                this.MEM_GROUP_ID=sMEM_GROUP_ID;
                this.ADDRESS=sADDRESS;
                this.BIRTH_DAY=sBIRTH_DAY;
                this.SEX=sSEX;
                this.PHONE=sPHONE;
                this.FAX=sFAX;
                this.EMAIL=sEMAIL;
                this.WEBSITE=sWEBSITE;
                this.YAHOO=sYAHOO;
                this.SKYPE=sSKYPE;
                this.TAX_CODE=sTAX_CODE;
                this.NOTE=sNOTE;
                this.AVATAR_PATH=sAVATAR_PATH;
                this.VISIBLE_BIT=sVISIBLE_BIT;
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
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET ID='"+ sID+ "' WHERE ID='"+ this.ID+"' ";
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
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET NAME='N"+ sNAME+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NAME=sNAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MEM_GROUP_ID(string sMEM_GROUP_ID)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET MEM_GROUP_ID='"+ sMEM_GROUP_ID+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MEM_GROUP_ID=sMEM_GROUP_ID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ADDRESS(string sADDRESS)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET ADDRESS='N"+ sADDRESS+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ADDRESS=sADDRESS;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BIRTH_DAY(string sBIRTH_DAY)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET BIRTH_DAY='"+ sBIRTH_DAY+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BIRTH_DAY=sBIRTH_DAY;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SEX(string sSEX)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET SEX='"+ sSEX+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SEX=sSEX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PHONE(string sPHONE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET PHONE='N"+ sPHONE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PHONE=sPHONE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_FAX(string sFAX)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET FAX='N"+ sFAX+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.FAX=sFAX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_EMAIL(string sEMAIL)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET EMAIL='N"+ sEMAIL+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.EMAIL=sEMAIL;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_WEBSITE(string sWEBSITE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET WEBSITE='N"+ sWEBSITE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.WEBSITE=sWEBSITE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_YAHOO(string sYAHOO)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET YAHOO='N"+ sYAHOO+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.YAHOO=sYAHOO;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SKYPE(string sSKYPE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET SKYPE='N"+ sSKYPE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SKYPE=sSKYPE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TAX_CODE(string sTAX_CODE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET TAX_CODE='N"+ sTAX_CODE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TAX_CODE=sTAX_CODE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NOTE(string sNOTE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET NOTE='N"+ sNOTE+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NOTE=sNOTE;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_AVATAR_PATH(string sAVATAR_PATH)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET AVATAR_PATH='N"+ sAVATAR_PATH+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.AVATAR_PATH=sAVATAR_PATH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_VISIBLE_BIT(string sVISIBLE_BIT)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET VISIBLE_BIT='N"+ sVISIBLE_BIT+ "' WHERE ID='"+ this.ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.VISIBLE_BIT=sVISIBLE_BIT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CREATED_DATE(string sCREATED_DATE)
{
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET CREATED_DATE='"+ sCREATED_DATE+ "' WHERE ID='"+ this.ID+"' ";
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
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET CREATED_BY='"+ sCREATED_BY+ "' WHERE ID='"+ this.ID+"' ";
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
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET EDITED_DATE='"+ sEDITED_DATE+ "' WHERE ID='"+ this.ID+"' ";
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
    string sqlSave= " UPDATE ND_THONG_TIN_ND SET EDITED_BY='"+ sEDITED_BY+ "' WHERE ID='"+ this.ID+"' ";
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
 public static bool Update_NAME(string sNAME,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET NAME='N"+sNAME+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MEM_GROUP_ID(string sMEM_GROUP_ID,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET MEM_GROUP_ID='"+sMEM_GROUP_ID+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ADDRESS(string sADDRESS,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET ADDRESS='N"+sADDRESS+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BIRTH_DAY(string sBIRTH_DAY,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET BIRTH_DAY='"+sBIRTH_DAY+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SEX(string sSEX,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET SEX='"+sSEX+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PHONE(string sPHONE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET PHONE='N"+sPHONE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_FAX(string sFAX,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET FAX='N"+sFAX+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EMAIL(string sEMAIL,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET EMAIL='N"+sEMAIL+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_WEBSITE(string sWEBSITE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET WEBSITE='N"+sWEBSITE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_YAHOO(string sYAHOO,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET YAHOO='N"+sYAHOO+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SKYPE(string sSKYPE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET SKYPE='N"+sSKYPE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TAX_CODE(string sTAX_CODE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET TAX_CODE='N"+sTAX_CODE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NOTE(string sNOTE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET NOTE='N"+sNOTE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_AVATAR_PATH(string sAVATAR_PATH,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET AVATAR_PATH='N"+sAVATAR_PATH+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_VISIBLE_BIT(string sVISIBLE_BIT,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET VISIBLE_BIT='N"+sVISIBLE_BIT+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_DATE(string sCREATED_DATE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET CREATED_DATE='"+sCREATED_DATE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CREATED_BY(string sCREATED_BY,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET CREATED_BY='"+sCREATED_BY+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EDITED_DATE(string sEDITED_DATE,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET EDITED_DATE='"+sEDITED_DATE+"' WHERE ID='"+ s_ID+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EDITED_BY(string sEDITED_BY,string s_ID)
{
  string sqlSave= " UPDATE ND_THONG_TIN_ND SET EDITED_BY='"+sEDITED_BY+"' WHERE ID='"+ s_ID+"' ";
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
   string sqlSelect = " SELECT * FROM ND_THONG_TIN_ND";
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
 string sqlSelect = string.Format(" SELECT {0} FROM {1} ", field, "ND_THONG_TIN_ND");
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
   private static DataTable dt_ND_THONG_TIN_ND;
   public static bool Change_dt_ND_THONG_TIN_ND = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_ND_THONG_TIN_ND()
   {
   if (dt_ND_THONG_TIN_ND == null || Change_dt_ND_THONG_TIN_ND == true)
     {
   dt_ND_THONG_TIN_ND = GetTableAll();
         Change_dt_ND_THONG_TIN_ND = true && AllowAutoChange ;
     }
     return dt_ND_THONG_TIN_ND;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 
