using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chiase.Objects;
using DK2C.DataAccess.Web;

namespace chiase
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["do"];
            switch (action)
            {
                //Dang ky thang nam lam viec
                case "LuuPhieuNhapKho": LuuPhieuNhapKho(); break;
                    

            }
        }
        private void LuuPhieuNhapKho()
        {
            string idPhieuNhapKho = Request.QueryString["idphieunhapkho"];
            string nguoinhap = Request.QueryString["nguoinhap"];
            string ngaynhap = Request.QueryString["ngaynhap"];
            string loainhap = Request.QueryString["loainhap"];
            string khonhap = Request.QueryString["khonhap"];
            string duan = Request.QueryString["duan"];
            string yeucau = Request.QueryString["yeucau"];
            string nhaptu = Request.QueryString["nhaptu"];
            string chungtu = Request.QueryString["chungtu"];
            string ghichu = Request.QueryString["ghichu"];


            string[] list_pnkctid = Request.QueryString["list_pnkctid"].TrimStart('~').Split('~');
            string[] list_hhid = Request.QueryString["list_hhid"].TrimStart('~').Split('~');
            string[] list_mahh = Request.QueryString["list_mahh"].TrimStart('~').Split('~');
            string[] list_hhname = Request.QueryString["list_hhname"].TrimStart('~').Split('~');
            string[] list_hhChungloaiID = Request.QueryString["list_hhChungloaiID"].TrimStart('~').Split('~');
            string[] list_hhChungloaiName = Request.QueryString["list_hhChungloaiName"].TrimStart('~').Split('~');
            string[] list_soluong = Request.QueryString["list_soluong"].TrimStart('~').Split('~');
            string[] list_dongia = Request.QueryString["list_dongia"].TrimStart('~').Split('~');
            string[] list_thanhtien = Request.QueryString["list_thanhtien"].TrimStart('~').Split('~');
            char result='0';
            if (string.IsNullOrEmpty(idPhieuNhapKho) || idPhieuNhapKho == "-1")//Insert
            {
                KH_PHIEU_NHAP_KHO nk = KH_PHIEU_NHAP_KHO.Insert_Object("PNK" + DateTime.Now.ToString("yyMMddhhmmss"),
                    nguoinhap, functions.CheckDate(ngaynhap), nguoinhap, DateTime.Today.ToString("yyyy-MM-dd"), 
                    nhaptu, khonhap, "", loainhap, "", chungtu, ghichu);
                if (nk != null)
                {
                     result = '1';
                    for (int i = 0; i < list_pnkctid.Length; i++)
                    {
                        string hh_id = list_hhid[i];

                        if (string.IsNullOrEmpty(hh_id) || hh_id == "-1")
                        {
                            DM_HANG_HOA hh = DM_HANG_HOA.Insert_Object(list_mahh[i], list_hhname[i], list_hhChungloaiID[i], "Thêm từ phiếu nhập " + nk.MA_PNK, "Y");
                            if (hh == null)
                            {
                                result = '0';
                                break;
                            }

                        }
                        if (result == '1')
                        {
                            KH_PHIEU_NHAP_KHO_CT ct = KH_PHIEU_NHAP_KHO_CT.Insert_Object(nk.PNK_ID, hh_id, list_soluong[i],
                                list_dongia[i], list_thanhtien[i], "");
                            if (ct == null)
                            {
                                result = '0';
                                SQLConnectWeb.ExecSQL(string.Format("delete from {0} where {1]={2}", KH_PHIEU_NHAP_KHO.sTableName, KH_PHIEU_NHAP_KHO.cl_PNK_ID, nk.PNK_ID));
                                break;
                            }
                        }
                    }

                }
               
            }
            else //Udate
            {

            }



         
            Response.Write(result);
        }
    }
}