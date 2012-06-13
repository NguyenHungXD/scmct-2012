using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DK2C.DataAccess.Web;
namespace chiase
{
    public partial class search_result : System.Web.UI.Page
    {
        public static DateTime start_datetime;//= DateTime.Now;
        public static DateTime end_datetime ;//= DateTime.Now;
        public static int cnt_bvs = 0;
        public static int cnt_ycs = 0;
        public static int cnt_hinhs = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["vmode"]=="search_options")
                    {
                        Session["search_all"] = Request.QueryString["search_all"];
                        Session["search_news"] = Request.QueryString["search_news"];
                        Session["search_request"] = Request.QueryString["search_request"];
                        Session["search_album"] = Request.QueryString["search_album"];

                    }else
                    {
                        start_datetime = DateTime.Now;
                        Session["current_link"] = "<a href='default.aspx' title='Trang chủ'>Trang chủ</a> >> <a href='search_result.aspx?str_search=" + Request.QueryString["str_search"] + "' title='Tìm kiếm'>Tìm kiếm</a> ";
                        display();
                    }
                    
                }
            }
            catch
            { 
            }
        }
        public void display()
        {
            try
            {
            string str_search = Request.QueryString["str_search"];
            if (str_search == "" || str_search.Length < 3)
            {

                lbl_result.Text = "Khoảng <b>0</b> kết quả trong <b>0.000000</b> giây";
                lbl_error.Text = "Bạn phải nhập TỪ KHÓA tìm kiếm lớn hơn 3 ký tự";
            }
            else
            {
                int bv = 0;
                int yc = 0;
                int hinh = 0;
                if (Session["search_all"].Equals("checked")) //chk_all.Checked == true
                {
                    bv = 1;
                    yc = 1;
                    hinh = 1;
                    chk_all.Checked = true;
                    chk_bv.Checked = true;
                    chk_yc.Checked = true;
                    chk_hinh.Checked = true;
                }
                else
                {
                    //lbl_error.Text = "Test:_" + (string)Session["search_all"] +"_"+ (string)Session["search_news"] +"_"+ (string)Session["search_request"] +"_"+ (string)Session["search_album"];
                if (Session["search_news"].Equals("checked"))
                {
                    bv = 1;
                    chk_bv.Checked = true;
                }
                    if (Session["search_request"].Equals("checked"))
                    {
                        yc = 1;
                        chk_yc.Checked = true;
                    }
                    if (Session["search_album"].Equals("checked"))
                    {
                        hinh = 1;
                        chk_hinh.Checked = true;
                    }
                    if (Session["search_album"].Equals("checked") && Session["search_album"].Equals("checked") && Session["search_news"].Equals("checked"))
                    {
                        chk_all.Checked = true;
                    }
                }

                int cnt = 0;
                if(bv==1)
                {
                    string query = @"select count(*) as cnt from bv_bai_viet where (tieu_de like N'%" + str_search + "%' or noi_dung like N'%" + str_search + "%') and deleted is null and trang_thai_id=1 and bai_viet_cha_id is null";
                    DataTable table = SQLConnectWeb.GetData(query);
                    int cnt_bv = (int)table.Rows[0]["cnt"];
                    if (cnt_bv > 0)
                    {
                        //If found then get the data to show;
                        String sql = @"SELECT a.*,case when a.du_an_id is null then 'post_show_details.aspx?news_id=' + convert(nvarchar,a.bai_viet_id) +'&subjectID='+ convert(nvarchar,a.chu_de_id) else 'post_show_details.aspx?news_id=' + convert(nvarchar,a.bai_viet_id) +'&projectID='+ convert(nvarchar,a.du_an_id) end as url, replace(replace(substring(a.noi_dung,CHARINDEX(N'" + str_search + "',a.noi_dung)-30,100),N'" + str_search + "',N'<b><font color=red>" + str_search + "</font></b>'),'<','...') as content1,replace(substring(a.tieu_de,CHARINDEX(N'" + str_search + "',a.tieu_de)-30,100),N'" + str_search + "',N'<font color=red><b>" + str_search + "</font></b>') as content2,b.USERNAME,case when c.avatar_path is null then 'default_img.gif' else c.avatar_path end as avatar_path FROM BV_BAI_VIET a INNER JOIN  ND_THONG_TIN_DN b ON  a.NGUOI_TAO=b.MEM_ID INNER JOIN  ND_THONG_TIN_ND c ON  a.NGUOI_TAO=c.ID WHERE (a.tieu_de like N'%" + str_search + "%' or a.noi_dung like N'%" + str_search + "%') and a.deleted is null and a.trang_thai_id=1 and a.bai_viet_cha_id is null";
                        DataTable baiviet = SQLConnectWeb.GetTable(sql);
                        showListPost.DataSource = baiviet;
                        showListPost.DataBind();
                        cnt = cnt+ cnt_bv;
                        cnt_bvs = cnt_bv;
                    }
                }
                if (yc == 1)
                {
                    string query = @"select count(*) as cnt from yc_yeu_cau where (tieu_de like N'%" + str_search + "%' or noi_dung like N'%" + str_search + "%') and deleted is null";
                    DataTable table = SQLConnectWeb.GetData(query);
                    int cnt_yc = (int)table.Rows[0]["cnt"];
                    if (cnt_yc > 0)
                    {
                        string sql = @"select a.yeu_cau_id,a.ngay_yeu_cau,e.username, replace(replace(substring(a.noi_dung,CHARINDEX(N'" + str_search + "',a.noi_dung)-30,100),N'" + str_search + "',N'<b><font color=red>" + str_search + "</font></b>'),'<','...') as content1,replace(substring(a.tieu_de,CHARINDEX(N'" + str_search + "',a.tieu_de)-30,100),N'" + str_search + "',N'<font color=red><b>" + str_search + "</font></b>') as content2,e.USERNAME,case when d.avatar_path is null then 'default_img.gif' else d.avatar_path end as avatar_path from yc_yeu_cau a inner join YC_DM_TRANG_THAI_YEU_CAU b on a.trang_thai_id = b.id inner join YC_DM_LOAI_YEU_CAU c on a.loai_yc_id = c.id left join ND_THONG_TIN_ND d on d.id = a.nguoi_yeu_cau left join ND_THONG_TIN_DN e on e.mem_id = a.nguoi_yeu_cau where (a.tieu_de like N'%" + str_search + "%' or a.noi_dung like N'%" + str_search + "%') and a.deleted is null";
                        DataTable table_request = SQLConnectWeb.GetData(sql);
                        showLisYC.DataSource = table_request;
                        showLisYC.DataBind();
                        cnt = cnt + cnt_yc;
                        cnt_ycs = cnt_yc; 
                        
                    }
                }
                if (hinh == 1)
                {
                    string query = @"select count(*) as cnt from IMG_album where (album_name like N'%" + str_search + "%' or description like N'%" + str_search + "%') and deleted is null";
                    DataTable table = SQLConnectWeb.GetData(query);
                    int cnt_hinh = (int)table.Rows[0]["cnt"];

                    String sql = @"select a.*,b.name,c.username,replace(replace(substring(a.description,CHARINDEX(N'" + str_search + "',a.description)-30,100),N'" + str_search + "',N'<b><font color=red>" + str_search + "</font></b>'),'<','...') as content1,replace(substring(a.album_name,CHARINDEX(N'" + str_search + "',a.album_name)-30,100),N'" + str_search + "',N'<font color=red><b>" + str_search + "</font></b>') as content2,case when b.avatar_path is null then 'default_img.gif' else b.avatar_path end as avatar_path from IMG_album a inner join ND_THONG_TIN_ND b on a.created_by = b.ID inner join ND_THONG_TIN_DN c on c.mem_id = b.ID where a.deleted is null and (album_name like N'%" + str_search + "%' or description like N'%" + str_search + "%') order by album_id";
                    
                    DataTable tables = SQLConnectWeb.GetData(sql);
                    showList_album.DataSource = tables;
                    showList_album.DataBind();
                    cnt_hinhs = cnt_hinh;
                    cnt = cnt + cnt_hinhs;
                }
                end_datetime = DateTime.Now;
                double seconds = (double)(end_datetime - start_datetime).TotalMilliseconds/1000;
                
                if (cnt > 0)
                {
                    lbl_result.Text = "Khoảng <b><font size=3 color=Yellow>" + cnt.ToString() + "</font></b> kết quả trong <font size=3 color=Yellow> " + seconds.ToString("N4") + " </font> giây cho từ khóa <b><font size=3 color=Yellow>" + str_search + "</font></b>";
                }
                else
                {
                    lbl_result.Text = "Khoảng <b><font size=3 color=Yellow>0</font></b> kết quả trong <b><font size=3 color=Yellow>0.00</font></b> giây cho từ khóa <b><font size=3 color=Yellow>" + str_search + "</font></b>";
                }
                
            }


            }
            catch (Exception ex)
            {
                lbl_error.Text = ex.ToString();
            }
        }
    }
}