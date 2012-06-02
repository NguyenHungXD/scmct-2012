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
            //Check LogIn session
            functions.checkLogIn(this, functions.LoginMemID(this), functions.LoginSession(this), functions.LoginIPaddress(this));

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
            string[] list_soluong = Request.QueryString["list_soluong"].TrimStart('~').Split('~');
            string[] list_dongia = Request.QueryString["list_dongia"].TrimStart('~').Split('~');
            string[] list_thanhtien = Request.QueryString["list_thanhtien"].TrimStart('~').Split('~');
            string result="Fail";
            if (string.IsNullOrEmpty(idPhieuNhapKho) || idPhieuNhapKho == "-1")//Insert
            {
                KH_PHIEU_NHAP_KHO nk = KH_PHIEU_NHAP_KHO.Insert_Object("PNK" + DateTime.Now.ToString("yyMMddhhmmss"),
                    nguoinhap, functions.CheckDate(ngaynhap), nguoinhap, DateTime.Today.ToString("yyyy-MM-dd"),
                    nhaptu, khonhap, duan, loainhap, yeucau, chungtu, ghichu);
                if (nk != null)
                {
                    result = "Success";
                    for (int i = 0; i < list_pnkctid.Length; i++)
                    {
                        string hh_id = list_hhid[i];

                        if (string.IsNullOrEmpty(hh_id) || hh_id == "-1")
                        {
                            DM_HANG_HOA hh = DM_HANG_HOA.Insert_Object(list_mahh[i], list_hhname[i], list_hhChungloaiID[i], "Thêm từ phiếu nhập " + nk.MA_PNK, "Y");
                            if (hh == null)
                            {
                                result = "Fail";
                                break;
                            }

                        }
                        if (result == "Success")
                        {
                            KH_PHIEU_NHAP_KHO_CT ct = KH_PHIEU_NHAP_KHO_CT.Insert_Object(nk.PNK_ID, hh_id, list_soluong[i],
                                list_dongia[i], list_thanhtien[i], "");
                            if (ct == null)
                            {
                                result = "Fail";
                                SQLConnectWeb.ExecSQL(string.Format("delete from {0} where {1}={2}", KH_PHIEU_NHAP_KHO.sTableName, KH_PHIEU_NHAP_KHO.cl_PNK_ID, nk.PNK_ID));
                                break;
                            }
                        }
                    }

                }

            }
            else //Udate
            {
                string ncn = functions.LoginMemID(this);
                if (ncn == "") ncn = "NULL";
                else ncn = "'" + ncn + "'";
                string sqlSave = " UPDATE KH_PHIEU_NHAP_KHO SET "
             + "NGUOI_NHAP ='" + nguoinhap + "',"
             + "NGAY_NHAP ='" + functions.CheckDate(ngaynhap) + "',"
             + "NGUOI_CAP_NHAT =" +ncn + ","
             + "NGAY_CAP_NHAT ='" + DateTime.Today.ToString("yyyy-MM-dd") + "',"
             + "MEM_ID ='" + nhaptu + "',"
             + "KHO_ID ='" + khonhap + "',"
             + "DU_AN_ID ='" + duan + "',"
             + "LY_DO_NHAP_ID ='" + loainhap + "',"
             + "YEU_CAU_ID ='" + yeucau + "',"
             + "CHUNG_TU =N'" + chungtu + "',"
             + "GHI_CHU =N'" + ghichu + "' WHERE PNK_ID=" + idPhieuNhapKho;
              
                if (SQLConnectWeb.ExecSQL(sqlSave))
                {
                    result = "Success";
                    string idpnkcts = "-1,";
                    for (int i = 0; i < list_pnkctid.Length; i++)
                    {
                        string hh_id = list_hhid[i];

                        if (string.IsNullOrEmpty(hh_id) ||hh_id=="null"|| hh_id == "-1")
                        {
                            DM_HANG_HOA hh = DM_HANG_HOA.Insert_Object(list_mahh[i], list_hhname[i], list_hhChungloaiID[i], "", "Y");
                            if (hh == null)
                            {
                                result = "Fail";
                                break;
                            }
                            else hh_id = hh.ID;

                        }
                        if (result == "Success")
                        {
                            string sl = list_soluong[i];
                            if (sl == "" || sl == "null") sl = "NULL";
                            string dg = list_dongia[i];
                            if (dg == "" || dg == "null") dg = "NULL";
                            string tt = list_thanhtien[i];
                            if (tt == "" || tt == "null") tt = "NULL";
                            if (int.Parse(list_pnkctid[i]) > 0)
                            {
                                idpnkcts += list_pnkctid[i] + ",";

                                string sqlUCT = " UPDATE KH_PHIEU_NHAP_KHO_CT SET "
                                 + "HH_ID ='" + hh_id + "',"
                                 + "SO_LUONG =" + sl + ","
                                 + "DON_GIA =" + dg + ","
                                 + "THANH_TIEN =" + tt
                                 + " WHERE PNK_CT_ID=" + list_pnkctid[i];
                                if (SQLConnectWeb.ExecSQL(sqlUCT) == false)
                                {
                                    result = "Fail";
                                    break;
                                }
                            }
                            else
                            {

                                KH_PHIEU_NHAP_KHO_CT ct = KH_PHIEU_NHAP_KHO_CT.Insert_Object(idPhieuNhapKho, hh_id, sl,
                                   dg, tt, "");
                                if (ct == null)
                                {
                                    result = "Fail";
                                    break;
                                }
                                else
                                {
                                    idpnkcts += ct.PNK_CT_ID + ",";
                                }
                            }
                        }
                    }
                    if (result == "Success")
                    {
                        idpnkcts=idpnkcts.TrimEnd(',');
                        string sqldelete = string.Format("delete from KH_PHIEU_NHAP_KHO_CT where pnk_id={0} and PNK_CT_ID not in ({1})", idPhieuNhapKho, idpnkcts);
                        SQLConnectWeb.ExecSQL(sqldelete);
                       
                    }
                    
                }
            }



         
            Response.Write(result);
        }
    }
}