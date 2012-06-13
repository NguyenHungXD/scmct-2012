using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using DK2C.DataAccess.Web;
using System.Web.Caching;
namespace chiase
{

    /// <summary>
    /// Summary description for DataProcess
    /// </summary>
    /// 
    public class DataProcess : IUDCollections
    {
        public DataProcess(string TableName)
            : base(TableName)
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string Paging()
        {
            string html = "";
            html += "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'><table border=0><tr><td style=color:white>Trang:&nbsp</td><td>";
            for (int i = 1; i <= this.TotalRowPaging(); i++)
            {
                if (int.Parse(this.Page) != i)
                {
                    html += "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"Find(this,'" + i + "')\">" + i + "</a>";
                }
                else
                {
                    html += "<span style='float:left;color:white'>" + i + "</span>";
                }
            }
            html += "</td></tr></table></div>";
            return html;
        }
        public string Paging(string tableName)
        {
            string html = "";
            html += "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'><table border=0><tr><td style=color:blue>Trang:&nbsp</td><td>";
            for (int i = 1; i <= this.TotalRowPaging(); i++)
            {
                if (int.Parse(this.Page) != i)
                {
                    html += "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"loadTableAjax" + tableName + "($.mkv.queryString('idkhoachinh'),'" + i + "')\">" + i + "</a>";
                }
                else
                {
                    html += "<span style='float:left;color:blue'>" + i + "</span>";
                }
            }
            html += "</td></tr></table></div>";
            return html;
        }

    }
    public class IUDCollections
    {
        private bool _enablePaging;
        private readonly List<ObjectIud> _listData;
        private readonly List<ObjectIud> _listDataOther;
        private readonly DataTable _spColumns;
        private readonly DataTable _spKey;
        private string _sqlExec;
        private string _sqlSelect;
        private string _sqlSelectP;
        private readonly string _tablename;
        public string NumberRow;
        public string Page;

        protected IUDCollections()
        {
            this.NumberRow = "100";
            this.Page = "1";
            this._enablePaging = true;
            this._sqlExec = "";
            this._sqlSelect = "";
            this._sqlSelectP = "";
        }

        public IUDCollections(string tableName)
        {
            this.NumberRow = "100";
            this.Page = "1";
            this._enablePaging = true;
            this._sqlExec = "";
            this._sqlSelect = "";
            this._sqlSelectP = "";
            this._tablename = tableName;
            if (!string.IsNullOrEmpty(tableName))
            {
                this._listData = new List<ObjectIud>();
                this._listDataOther = new List<ObjectIud>();
                this._spColumns = this.CacheTable("sp_columns" + tableName, "sp_columns " + tableName);
                this._spKey = this.CacheTable("sp_pkeys" + tableName, "sp_pkeys " + tableName);
                this._tablename = tableName;
            }
        }

        private DataTable CacheTable(string key, string SqlSelect)
        {
            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Insert(key, SQLConnectWeb.GetTable(SqlSelect), null, DateTime.Now.AddMinutes(30.0), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);
            }
            return (DataTable)HttpRuntime.Cache[key];
        }

        public ObjectIud data(string tencot, string dulieu)
        {
            if ((this._spKey.Rows.Count < 1) || (this._spKey == null))
            {
                throw new ArgumentException("PrimaryKey kh\x00f4ng c\x00f3 !");
            }
            if ((this._spColumns.Rows.Count < 1) || (this._spColumns == null))
            {
                return null;
            }
            if ((dulieu == null) || string.IsNullOrEmpty(tencot))
            {
                return null;
            }
            int num = this._listData.FindIndex(delegate(ObjectIud o)
            {
                return (o != null) && (o.getColName == tencot.Trim().ToLower());
            });
            if (num != -1)
            {
                this._listData[num].setData = dulieu.Trim();
                return this._listData[num];
            }
            DataRow[] rowArray = this._spColumns.Select("COLUMN_NAME = '" + tencot + "'");
            if (rowArray.Length != 1)
            {
                this.dataOther(tencot, dulieu);
                return null;
            }
            ObjectIud item = new ObjectIud(tencot.Trim().ToLower(), dulieu.Trim(), rowArray[0]["TYPE_NAME"].ToString());
            this._listData.Add(item);
            return item;
        }

        protected virtual void dataOther(string tencot, string dulieu)
        {
            int num = this._listDataOther.FindIndex(delegate(ObjectIud o)
            {
                return (o != null) && (o.getColName == tencot.Trim().ToLower());
            });
            if (num != -1)
            {
                this._listDataOther[num].setData = dulieu.Trim();
            }
            else
            {
                ObjectIud item = new ObjectIud(tencot.Trim().ToLower(), dulieu.Trim(), null);
                this._listDataOther.Add(item);
            }
        }

        public virtual bool Delete()
        {
            try
            {
                if (this._listData.Count < 1)
                {
                    return false;
                }
                string strCommandText = "";
                for (int i = 0; i < this._listData.Count; i++)
                {
                    if (this._listData[i].getColName == this._spKey.Rows[0][3].ToString().ToLower())
                    {
                        strCommandText = this._listData[i].getColName + "=" + sGetSaveValue(this._listData[i].getData, this._listData[i].getStyleData) + " and ";
                        break;
                    }
                    string str2 = strCommandText;
                    strCommandText = str2 + this._listData[i].getColName + "=" + sGetSaveValue(this._listData[i].getData, this._listData[i].getStyleData) + " and ";
                }
                strCommandText = strCommandText.Substring(0, strCommandText.LastIndexOf("and"));
                if (this._listData.FindIndex(delegate(ObjectIud o)
                {
                    return (o != null) && (o.getColName == "status");
                }) != -1)
                {
                    strCommandText = "Update " + this._tablename + " set status=0 where " + strCommandText;
                }
                else
                {
                    strCommandText = "Delete " + this._tablename + " where " + strCommandText;
                }
                this._sqlExec = strCommandText;
                return (SQLConnectWeb.Exec(strCommandText) >= 1);
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(exception.Message);
                return false;
            }
        }

        public virtual string getData(string tencot)
        {
            int num;
            for (num = 0; num < this._listData.Count; num++)
            {
                if ((tencot != null) && (this._listData[num].getColName == tencot.ToLower()))
                {
                    return this._listData[num].getData;
                }
            }
            for (num = 0; num < this._listDataOther.Count; num++)
            {
                if ((tencot != null) && (this._listDataOther[num].getColName == tencot.ToLower()))
                {
                    return this._listDataOther[num].getData;
                }
            }
            return null;
        }

        public virtual bool Insert()
        {
            try
            {
                int num;
                DataRow[] rowArray;
                if (this._listData.Count < 1)
                {
                    return false;
                }
                string strCommandText = " INSERT INTO " + this._tablename + "(";
                string str2 = "";
                string str3 = "";
                bool flag = false;
                for (num = 0; num < this._listData.Count; num++)
                {
                    if (this._listData[num].getStyleData.IndexOf("identity") != -1)
                    {
                        flag = true;
                    }
                    else
                    {
                        str2 = str2 + this._listData[num].getColName + ",";
                        if (this._listData[num].getColName == this._spKey.Rows[0][3].ToString().ToLower())
                        {
                            if (this._listData[num].getData.Trim() == "")
                            {
                                str3 = str3 + sGetSaveValue(SQLConnectWeb.GetTable("SELECT TOP 1 ISNULL(MAX(" + this._listData[num].getColName + ")+1,1) FROM " + this._tablename + "").Rows[0][0].ToString(), this._listData[num].getStyleData) + ",";
                            }
                            else
                            {
                                str3 = str3 + sGetSaveValue(this._listData[num].getData, this._listData[num].getStyleData) + ",";
                            }
                            flag = true;
                        }
                        else
                        {
                            str3 = str3 + sGetSaveValue(this._listData[num].getData, this._listData[num].getStyleData) + ",";
                        }
                    }
                }
                if (!flag)
                {
                    rowArray = this._spColumns.Select("COLUMN_NAME = '" + this._spKey.Rows[0][3] + "'");
                    if (rowArray[0]["TYPE_NAME"].ToString().IndexOf("identity") < 0)
                    {
                        str2 = str2 + rowArray[0]["COLUMN_NAME"] + ",";
                        str3 = str3 + sGetSaveValue(SQLConnectWeb.GetTable(string.Concat(new object[] { "SELECT TOP 1 ISNULL(MAX(", rowArray[0]["COLUMN_NAME"], ")+1,1) FROM ", this._tablename, "" })).Rows[0][0].ToString(), rowArray[0]["TYPE_NAME"].ToString()) + ",";
                    }
                }
                if (str2 == "")
                {
                    return false;
                }
                str2 = str2.Substring(0, str2.LastIndexOf(","));
                str3 = str3.Substring(0, str3.LastIndexOf(","));
                string str5 = strCommandText;
                strCommandText = str5 + str2 + ") values(" + str3 + ")";
                this._sqlExec = strCommandText;
                bool flag2 = SQLConnectWeb.Exec(strCommandText) >= 1;
                if (flag2)
                {
                    this._listData.Clear();
                    string str4 = SQLConnectWeb.GetTable(string.Concat(new object[] { " SELECT TOP 1 ", this._spKey.Rows[0][3], " FROM ", this._tablename, " ORDER BY ", this._spKey.Rows[0][3], " DESC " })).Rows[0][0].ToString();
                    DataTable table = SQLConnectWeb.GetTable(string.Concat(new object[] { "select top 1 * from ", this._tablename, " where ", this._spKey.Rows[0][3], " = ", str4 }));
                    for (num = 0; num < table.Columns.Count; num++)
                    {
                        rowArray = this._spColumns.Select("COLUMN_NAME = '" + table.Columns[num] + "'");
                        this._listData.Add(new ObjectIud(table.Columns[num].ToString().ToLower(), table.Rows[0][num].ToString(), rowArray[0]["TYPE_NAME"].ToString()));
                    }
                }
                return flag2;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(exception.Message);
                return false;
            }
        }

        public virtual string Pagingfunc(string functionClick)
        {
            return this.sPagingFunc(functionClick, 0x13);
        }

        public virtual string Pagingfunc(string functionClick, int numberPages)
        {
            return this.sPagingFunc(functionClick, numberPages);
        }

        private string s_Search()
        {
            if (string.IsNullOrEmpty(this.Page))
            {
                this.Page = "1";
            }
            if (string.IsNullOrEmpty(this.NumberRow))
            {
                this.NumberRow = "100";
            }
            this._sqlSelect = this.SQLSelect();
            this._sqlSelectP = this.SQL_Paging(this._sqlSelect);
            return this._sqlSelectP;
        }

        private string s_Search(string sql)
        {
            this._sqlSelect = string.IsNullOrEmpty(sql) ? this.SQLSelect() : sql;
            if (string.IsNullOrEmpty(this.Page))
            {
                this.Page = "1";
            }
            if (string.IsNullOrEmpty(this.NumberRow))
            {
                this.NumberRow = "100";
            }
            this._sqlSelectP = this.SQL_Paging(this._sqlSelect);
            return this._sqlSelectP;
        }

        public virtual DataTable Search()
        {
            return SQLConnectWeb.GetTable(this.s_Search());
        }

        public virtual DataTable Search(string sql)
        {
            return SQLConnectWeb.GetTable(this.s_Search(sql));
        }

        public virtual DataTable Search_Object(string columnName)
        {
            Predicate<ObjectIud> match = null;
            try
            {
                string str4;
                if (match == null)
                {
                    match = delegate(ObjectIud o)
                    {
                        return ((o != null) && (columnName != null)) && (o.getColName == columnName.Trim().ToLower());
                    };
                }
                ObjectIud iud = this._listData.Find(match);
                if (iud == null)
                {
                    return null;
                }
                string sql = string.Concat(new object[] { " SELECT STT= row_number() over (order by ", this._spKey.Rows[0][3], "),T.* FROM ", this._tablename, " AS T WHERE 1=1 " });
                string getData = iud.getData;
                bool flag = false;
                string str3 = iud.getStyleData.ToLower();
                if (((((str3.IndexOf("int") != -1) || (str3.IndexOf("num") != -1)) || ((str3.IndexOf("double") != -1) || (str3.IndexOf("float") != -1))) || (str3.IndexOf("deci") != -1)) || (str3.IndexOf("bit") != -1))
                {
                    flag = true;
                }
                if (!flag)
                {
                    if (str3.IndexOf("date") != -1)
                    {
                        str4 = sql;
                        sql = str4 + " AND T." + iud.getColName + " >= '" + getData + "' AND T." + iud.getColName + " <= '" + getData + " 23:59:59'";
                    }
                    else
                    {
                        str4 = sql;
                        sql = str4 + " AND T." + iud.getColName + " LIKE N'%" + getData + "%'";
                    }
                }
                else if (str3.IndexOf("bit") != -1)
                {
                    if (((getData.ToLower() == "y") || (getData.ToLower() == "true")) || (getData == "1"))
                    {
                        getData = "1";
                    }
                    else
                    {
                        getData = "0";
                    }
                    if (getData != "")
                    {
                        str4 = sql;
                        sql = str4 + " AND ISNULL(T." + iud.getColName + ",0) = " + getData + "";
                    }
                }
                else
                {
                    str4 = sql;
                    sql = str4 + " AND T." + iud.getColName + " = '" + getData + "'";
                }
                if (this._listData.FindIndex(delegate(ObjectIud o)
                {
                    return (o != null) && (o.getColName == "status");
                }) != -1)
                {
                    sql = sql + " AND T.status = 1";
                }
                return SQLConnectWeb.GetTable(this.s_Search(sql));
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(exception.Message);
                return null;
            }
        }

        public static string sGetSaveValue(string sValue, string sValueType)
        {
            if (((sValue == null) || (sValue.Trim() == "")) || (sValue.ToUpper() == "NULL"))
            {
                return "NULL";
            }
            if (sValueType != null)
            {
                if (((((sValueType.IndexOf("int") != -1) || (sValueType.IndexOf("num") != -1)) || ((sValueType.IndexOf("double") != -1) || (sValueType.IndexOf("float") != -1))) || (sValueType.IndexOf("deci") != -1)) || (sValueType.IndexOf("bit") != -1))
                {
                    if (sValueType.IndexOf("bit") != -1)
                    {
                        if (((sValue.ToLower() == "y") || (sValue.ToLower() == "true")) || (sValue == "1"))
                        {
                            return "1";
                        }
                        return "0";
                    }
                    return sValue.Replace(",", "");
                }
                if (sValueType.IndexOf("date") != -1)
                {
                    if (sValue.IndexOf(":") != -1)
                    {
                        string str = sValue.Substring(sValue.IndexOf(":") - 2, (sValue.LastIndexOf(":") + 3) - (sValue.IndexOf(":") - 2));
                        string str2 = (sValue.IndexOf("/") != -1) ? sValue.Substring(sValue.IndexOf("/") - 2, sValue.Length - (str.Length + 1)) : "NULL";
                        return ((str2.IndexOf("/") != -1) ? ("'" + str2.Split(new char[] { '/' })[1] + "/" + str2.Split(new char[] { '/' })[0] + "/" + str2.Split(new char[] { '/' })[2] + " " + str + "'") : "NULL");
                    }
                    return ((sValue.IndexOf("/") != -1) ? ("'" + sValue.Split(new char[] { '/' })[1] + "/" + sValue.Split(new char[] { '/' })[0] + "/" + sValue.Split(new char[] { '/' })[2] + "'") : "NULL");
                }
            }
            return ("N'" + sValue + "'");
        }

        public static string sGetValidValue(string sValue, string sValueType)
        {
            if (((sValue == null) || (sValue.Trim() == "")) || (sValue.ToUpper() == "NULL"))
            {
                return null;
            }
            if (sValueType != null)
            {
                if (((((sValueType.IndexOf("int") != -1) || (sValueType.IndexOf("num") != -1)) || ((sValueType.IndexOf("double") != -1) || (sValueType.IndexOf("float") != -1))) || (sValueType.IndexOf("deci") != -1)) || (sValueType.IndexOf("bit") != -1))
                {
                    if (sValueType.IndexOf("bit") != -1)
                    {
                        if (((sValue.ToLower() == "y") || (sValue.ToLower() == "true")) || (sValue == "1"))
                        {
                            return "1";
                        }
                        return "0";
                    }
                    return sValue.Replace(",", "");
                }
                if (sValueType.IndexOf("date") != -1)
                {
                    if (sValue.IndexOf(":") != -1)
                    {
                        string str = sValue.Substring(sValue.IndexOf(":") - 2, (sValue.LastIndexOf(":") + 3) - (sValue.IndexOf(":") - 2));
                        string str2 = (sValue.IndexOf("/") != -1) ? sValue.Substring(sValue.IndexOf("/") - 2, sValue.Length - (str.Length + 1)) : "NULL";
                        return ((str2.IndexOf("/") != -1) ? (str2 + " " + str + "") : null);
                    }
                    return ((sValue.Split(new char[] { '/' }).Length > 2) ? sValue : null);
                }
            }
            return ("" + sValue + "");
        }

        protected virtual string sPagingFunc(string functionClick, int numberPages)
        {
            if (string.IsNullOrEmpty(this.Page))
            {
                this.Page = "1";
            }
            double num = this.TotalRowPaging();
            string str = "";
            str = str + "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'>";
            if ((int.Parse(this.Page) - numberPages) > 1)
            {
                str = str + "<span style='float:left;color:green'>...</span>";
            }
            for (int i = int.Parse(this.Page) - numberPages; i <= (int.Parse(this.Page) + numberPages); i++)
            {
                if ((i > 0) && (i <= num))
                {
                    object obj2;
                    if (int.Parse(this.Page) != i)
                    {
                        obj2 = str;
                        str = string.Concat(new object[] { obj2, "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"", functionClick, "\">", i, "</a>" });
                    }
                    else
                    {
                        obj2 = str;
                        str = string.Concat(new object[] { obj2, "<span style='float:left;color:red'>", i, "</span>" });
                    }
                }
            }
            if ((int.Parse(this.Page) + numberPages) < num)
            {
                str = str + "<span style='float:left;color:green'>...</span>";
            }
            return (str + "</div>");
        }

        private string SQL_Paging(string sql)
        {
            if (this._enablePaging)
            {
                return string.Format("select * from({0}) abc where stt between ({1}-1)*{2}+1 and {3} * {4}", new object[] { sql, this.Page, this.NumberRow, this.Page, this.NumberRow });
            }
            return sql;
        }

        protected virtual string SQLSelect()
        {
            return string.Concat(new object[] { " SELECT STT= row_number() over (order by ", this._spKey.Rows[0][3], "),T.* FROM ", this._tablename, " AS T WHERE ", this.sWhere() });
        }

        private bool sUpdate(string whereColumn)
        {
            try
            {
                int num;
                if (this._listData.Count < 1)
                {
                    return false;
                }
                string strCommandText = " Update " + this._tablename + " set ";
                string str2 = "";
                string str3 = "";
                for (num = 0; num < this._listData.Count; num++)
                {
                    bool flag = false;
                    if (!string.IsNullOrEmpty(whereColumn))
                    {
                        if (this._listData[num].getColName == whereColumn.Trim().ToLower())
                        {
                            flag = true;
                        }
                    }
                    else if (this._listData[num].getColName == this._spKey.Rows[0][3].ToString().ToLower())
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        string str4 = str2;
                        str2 = str4 + this._listData[num].getColName + "=" + sGetSaveValue(this._listData[num].getData, this._listData[num].getStyleData) + ",";
                    }
                    else
                    {
                        str3 = " where " + this._listData[num].getColName + "=" + sGetSaveValue(this._listData[num].getData, this._listData[num].getStyleData);
                    }
                }
                if (str3 == "")
                {
                    return false;
                }
                if (str2 == "")
                {
                    return false;
                }
                str2 = str2.Substring(0, str2.LastIndexOf(","));
                strCommandText = strCommandText + str2 + str3;
                this._sqlExec = strCommandText;
                bool flag2 = SQLConnectWeb.Exec(strCommandText) >= 1;
                if (flag2)
                {
                    this._listData.Clear();
                    DataTable table = SQLConnectWeb.GetTable("select top 1 * from " + this._tablename + str3);
                    for (num = 0; num < table.Columns.Count; num++)
                    {
                        DataRow[] rowArray = this._spColumns.Select("COLUMN_NAME = '" + table.Columns[num] + "'");
                        this._listData.Add(new ObjectIud(table.Columns[num].ToString().ToLower(), table.Rows[0][num].ToString(), rowArray[0]["TYPE_NAME"].ToString()));
                    }
                }
                return flag2;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write(exception.Message);
                return false;
            }
        }

        public virtual string sWhere()
        {
            string str = " 1=1 ";
            for (int i = 0; i < this._listData.Count; i++)
            {
                string str5;
                string getData = this._listData[i].getData;
                bool flag = false;
                string str3 = this._listData[i].getStyleData.ToLower();
                if (((((str3.IndexOf("int") != -1) || (str3.IndexOf("num") != -1)) || ((str3.IndexOf("double") != -1) || (str3.IndexOf("float") != -1))) || (str3.IndexOf("deci") != -1)) || (str3.IndexOf("bit") != -1))
                {
                    flag = true;
                }
                if (!flag)
                {
                    if (getData != "")
                    {
                        if (str3.IndexOf("date") != -1)
                        {
                            str5 = str;
                            str = str5 + " AND T." + this._listData[i].getColName + " >= '" + getData + "' AND T." + this._listData[i].getColName + " <= '" + getData + " 23:59:59'";
                        }
                        else
                        {
                            str5 = str;
                            str = str5 + " AND T." + this._listData[i].getColName + " LIKE N'%" + getData + "%'";
                        }
                    }
                }
                else if (str3.IndexOf("bit") != -1)
                {
                    if (((getData.ToLower() == "y") || (getData.ToLower() == "true")) || (getData == "1"))
                    {
                        getData = "1";
                    }
                    else
                    {
                        getData = "0";
                    }
                    if (getData != "")
                    {
                        str5 = str;
                        str = str5 + " AND ISNULL(T." + this._listData[i].getColName + ",0) = " + getData + "";
                    }
                }
                else if (((getData != "") && (getData != "0")) && (getData != "0.0"))
                {
                    str5 = str;
                    str = str5 + " AND T." + this._listData[i].getColName + " = " + getData;
                }
            }
            return str;
        }

        public virtual int TotalRowPaging()
        {
            if (string.IsNullOrEmpty(this._sqlSelect))
            {
                return 1;
            }
            int count = SQLConnectWeb.GetTable(this._sqlSelect).Rows.Count;
            if (this.NumberRow != null)
            {
                int num2 = count / int.Parse(this.NumberRow);
                int num3 = count % int.Parse(this.NumberRow);
                if (num3 != 0)
                {
                    num2++;
                }
                return num2;
            }
            return 0;
        }

        public virtual bool Update()
        {
            return this.sUpdate(null);
        }

        public virtual bool Update(string sWhereColumn)
        {
            return this.sUpdate(sWhereColumn);
        }

        public bool EnablePaging
        {
            get
            {
                return this._enablePaging;
            }
            set
            {
                this._enablePaging = value;
            }
        }

        public virtual string s_TableName
        {
            get
            {
                return this._tablename;
            }
        }

        public virtual string SqlExec
        {
            get
            {
                return this._sqlExec;
            }
        }
    }

    public class ObjectIud
    {
        private string _columnname;
        private string _dulieu;
        private string _kieudulieu;

        public ObjectIud()
        {
        }

        public ObjectIud(string columnname, string dulieu, string kieudulieu)
        {
            this._columnname = columnname;
            this._dulieu = dulieu;
            this._kieudulieu = kieudulieu;
        }

        public string getColName
        {
            get
            {
                return this._columnname;
            }
        }

        public string getData
        {
            get
            {
                return this._dulieu;
            }
        }

        public string getStyleData
        {
            get
            {
                return this._kieudulieu;
            }
        }

        public string setColName
        {
            set
            {
                this._columnname = value;
            }
        }

        public string setData
        {
            set
            {
                this._dulieu = value;
            }
        }

        public string setStyleData
        {
            set
            {
                this._kieudulieu = value;
            }
        }
    }
}