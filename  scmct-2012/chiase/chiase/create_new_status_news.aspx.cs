﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class create_new_status_news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    display();
                }
            }
        }
        public void display()
        {
            try
            {
                string sql = @"select id,name from BV_DM_TRANG_THAI_BAI_VIET where id =@id";
                DataTable table = SQLConnectWeb.GetData(sql, "@id",Request.QueryString["id"]);
                txt_name.Text = table.Rows[0]["name"].ToString();
            }
            catch
            { }

        
        }
        protected void btn_saves_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_check = @"select name from BV_DM_TRANG_THAI_BAI_VIET where upper(name) = upper(@name)";
                DataTable table = SQLConnectWeb.GetData(sql_check,"@name",txt_name.Text);

                if (table.Rows.Count == 0)
                {

                    if (Request.QueryString["id"] != null)
                    {
                        string sql = @"update BV_DM_TRANG_THAI_BAI_VIET set name=@name,edited_by=@edited_by,edited_date=@edited_date where id =@id ";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@name", txt_name.Text,
                        "@edited_by", functions.LoginMemID(this),
                        "@edited_date", functions.GetStringDatetime(),
                        "@id", Request.QueryString["id"]);
                        lbl_error.Text = String.Format("Cập nhật trạng thái [<b>{0}</b>] thành công", txt_name.Text);
                    }
                    else
                    {
                        string sql = @"insert into BV_DM_TRANG_THAI_BAI_VIET (name,created_by,created_date,VISIBLE_BIT) values(@name,@created_by,@created_date,@VISIBLE_BIT)";
                        SQLConnectWeb.ExecuteNonQuery(sql,
                        "@name", txt_name.Text,
                        "@created_by", functions.LoginMemID(this),
                        "@created_date", functions.GetStringDatetime(),
                        "@VISIBLE_BIT",'Y');
                        lbl_error.Text = String.Format("Lưu trạng thái [<b>{0}</b>] thành công", txt_name.Text);

                    }


                }else
                    lbl_error.Text = String.Format("Lưu trạng thái [<b>{0}</b>] đã tồn tại", txt_name.Text);

            }
            catch
            {
                lbl_error.Text = String.Format("Lưu trạng thái [<b>{0}</b>] không thành công", txt_name.Text);
            }
        }
    }
}