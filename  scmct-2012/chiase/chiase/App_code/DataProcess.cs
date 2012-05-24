using System;
using System.Data;
using System.Configuration;
using System.Web;
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
            html += "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'>";
            for (int i = 1; i <= this.TotalRowPaging(); i++)
            {
                if (int.Parse(this.Page) != i)
                {
                    html += "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"Find(this,'" + i + "')\">" + i + "</a>";
                }
                else
                {
                    html += "<span style='float:left;color:red'>" + i + "</span>";
                }
            }
            html += "</div>";
            return html;
        }
        public string Paging(string tableName)
        {
            string html = "";
            html += "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'>";
            for (int i = 1; i <= this.TotalRowPaging(); i++)
            {
                if (int.Parse(this.Page) != i)
                {
                    html += "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"loadTableAjax" + tableName + "($.mkv.queryString('idkhoachinh'),'" + i + "')\">" + i + "</a>";
                }
                else
                {
                    html += "<span style='float:left;color:red'>" + i + "</span>";
                }
            }
            html += "</div>";
            return html;
        }

    }
}