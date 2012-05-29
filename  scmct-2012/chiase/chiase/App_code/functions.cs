﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;
using System.Collections;
using System.Text;

namespace chiase
{
   
    public static class functions
    {
        public static System.Web.UI.Page pages;
        public static void add_date_to_dropd(DropDownList objday, DropDownList objmonth, DropDownList objyear, int addyear)
        {
            //Day
            int i;
            string val;
            for (i = 1; i <= 31; i++)
            {

                val = i.ToString();
                objday.Items.Insert(i - 1, new ListItem(val, val));
            }

            //Month
            for (i = 1; i <= 12; i++)
            {
                val = i.ToString();
                objmonth.Items.Insert(i - 1, new ListItem(val, val));
            }

            //Year
            for (i = 0; i < 90; i++)
            {
                int year = DateTime.Now.Year + addyear;
                objyear.Items.Insert(i, new ListItem((year - i).ToString(), (year - i).ToString()));
            }

        }
        public static void fill_DropdownList(DropDownList obj, DataTable table, int v_Index, int v_Text)
        {

            int i = 1;
            obj.Items.Clear();
            obj.Items.Insert(0, new ListItem("Chọn", "None"));
            if (table.Rows.Count > 0)
            {
                
                foreach (DataRow dr in table.Rows)
                {
                    String valValue = dr[v_Index].ToString();
                    String valText = dr[v_Text].ToString();
                    obj.Items.Insert(i, new ListItem(valText, valValue));
                    i++;
                }

            }


        }
        public static void fill_DropdownList(DropDownList obj, DataTable table, int v_Index, int v_Text,string addMore)
        {

            int i = 1;
            obj.Items.Clear();
            obj.Items.Insert(0, new ListItem("Chọn", "None"));
            if (table.Rows.Count > 0)
            {

                foreach (DataRow dr in table.Rows)
                {
                    String valValue = String.Format("{0};{1}", addMore, dr[v_Index]);
                    String valText = dr[v_Text].ToString();
                    obj.Items.Insert(i, new ListItem(valText, valValue));
                    i++;
                }

            }


        }
        public static int selectedDropdown(DropDownList obj, String val)
        {
            int indexInt = 0;
            foreach (ListItem lst in obj.Items)
            {
                if (lst.Value == val)
                {
                    obj.SelectedIndex = indexInt;
                    return indexInt;
                }
                indexInt++;
            }
            return 0;
        }
        /// <summary>
        /// Return login Member ID (NOT UserID)
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string LoginMemID(System.Web.UI.Page page)
        {
            DataTable table = (DataTable)page.Session["ThanhVien"];
            if (table == null || table.Rows.Count == 0) return "";
            return table.Rows[0][ND_THONG_TIN_DN.cl_MEM_ID].ToString();
        }
        public static string LoginMemIDs()
        {
            DataTable table = (DataTable)pages.Session["ThanhVien"];
            if (table == null || table.Rows.Count == 0) return "";
            return table.Rows[0][ND_THONG_TIN_DN.cl_MEM_ID].ToString();
        }
        /// <summary>
        /// Return login USer ID
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string LoginUserID(System.Web.UI.Page page)
        {
            DataTable table = (DataTable)page.Session["ThanhVien"];
            if (table == null || table.Rows.Count == 0) return "";
            return table.Rows[0][ND_THONG_TIN_DN.cl_USERID].ToString();
        }
        /// <summary>
        /// retutn string "yyyy-MM-dd hh:mm:ss" form datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetStringDatetime(DateTime date)
        {
            return date.ToString("yyyy-MM-dd hh:mm:ss");
        }
        /// <summary>
        /// return string "yyyy-MM-dd hh:mm:ss" current datetime
        /// </summary>
        /// <returns></returns>
        public static string GetStringDatetime()
        {
            return GetStringDatetime(DateTime.Now);
        }
        /// <summary>
        /// return string "yyyy-MM-dd" form datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetStringDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// return string "yyyy-MM-dd" current datetime
        /// </summary>
        /// <returns></returns>
        public static string GetStringDate()
        {
            return GetStringDate(DateTime.Now);
        }

        public static string getNo(string currentNo,int vmode)
        {
            string result = "";
            int nextNo = 0;
            //Phieu thu : PT-NO.000001,PT-NO.000002,....
            if (vmode == 1)
            { 
                string[] vTemp = currentNo.Split('.');
                nextNo = Convert.ToInt32(vTemp[1]);
                nextNo += 1;
                string temp = "000000" + nextNo;
                result = "PT-NO." + temp.Substring(1, 6);
            }
            //Phieu thu : PC-NO.000001,PC-NO.000002,....
            if (vmode == 2) 

            {
                string[] vTemp = currentNo.Split('.');
                nextNo = Convert.ToInt32(vTemp[1]);
                nextNo += 1;
                string temp = "000000" + nextNo;
                result = "PC-NO." + temp.Substring(1, 6);
            }
            return result;
        }

         

        public static string conVertToText(double number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            double decS = 0;
            try
            {
                decS = Convert.ToDouble(s);
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = String.Format("{0} {1}", so[donvi], str);
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = String.Format("{0} mươi {1}", so[chuc], str);
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = String.Format("{0} trăm {1}", so[tram], str);
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
                return str + "đồng chẵn.";
        }



        #region Khanhdtn

        public static string CheckDate(string strDate)
        {
            if (strDate == null || strDate == "")
            {
                return "";
            }
            string[] arrDDMMYY;
            arrDDMMYY = strDate.Split('/');
            int intDay;
            int intMonth;
            int intYear;
            try
            {
                intDay = System.Convert.ToInt32(arrDDMMYY[0]);
                intMonth = System.Convert.ToInt32(arrDDMMYY[1]);
                intYear = System.Convert.ToInt32(arrDDMMYY[2]);
                //    DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
                if (intMonth > 12)
                {
                    int temp = intMonth;
                    intMonth = intDay;
                    intDay = temp;
                }
                return intYear + "/" + intMonth + "/" + intDay;
                //return intMonth + "/" + intDay + "/" + intYear;
            }
            catch (Exception)
            {
                return "";
            }
        }


        public static void AddEmptyRow(DataTable dtSource, string KeyFieldNam)
        {
            DataRow r = dtSource.NewRow();
            r[KeyFieldNam] = -1;
           
            dtSource.Rows.InsertAt(r, 0);
        }
        
        /// <summary>
        /// Khởi tạo datasoucre cho control ASPxComboBox
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="dtSource"></param>
        /// <param name="ValueField"></param>
        /// <param name="DislpayField"></param>
        public static void InitCombobox(DevExpress.Web.ASPxEditors.ASPxComboBox cbo,
           DataTable dtSource, string ValueField, string DislpayField)
        {
            AddEmptyRow(dtSource, ValueField);
            cbo.DataSource = dtSource;
            cbo.ValueField = ValueField;
            cbo.TextField = DislpayField;
            cbo.DataBind();

        }

        public static void InitGridLookup(DevExpress.Web.ASPxGridLookup.ASPxGridLookup gridLookup,
            DataTable dtSource, string ValueField, string DisplayField, string[] Columns, string[] Caption)
        {
            AddEmptyRow(dtSource, ValueField);
            if (Columns != null && Columns.Length > 0)
            {
                if (Caption == null) Caption = new string[0];

                for (int i = 0; i < Columns.Length; i++)
                {
                    DevExpress.Web.ASPxGridView.GridViewDataTextColumn col = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
                    col.Caption = i < Caption.Length ? Caption[i] : Columns[i];
                    col.FieldName = Columns[i];
                    gridLookup.Columns.Add(col);
                    
                }
            }
            gridLookup.KeyFieldName = ValueField;

            gridLookup.DataSource = dtSource;
            gridLookup.DataBind();
        }


        /// <summary>
        /// KHởi tạo danh sách người dùng vào control
        /// </summary>
        /// <param name="cbo">Control ASPxComboBox</param>
        /// <param name="idMemberGroup"></param>
        /// <param name="IsAdd"></param>
        public static void InitListNguoiDung(DevExpress.Web.ASPxEditors.ASPxComboBox cbo, long idMemberGroup, bool? IsAdd)
        {
            string where = "1=1";
            if (idMemberGroup > 0)
            {
                where = ND_THONG_TIN_ND.cl_MEM_GROUP_ID + "=" + idMemberGroup;
            }
            if (IsAdd == true)
            {
                where += " AND " + ND_THONG_TIN_ND.cl_VISIBLE_BIT + "='Y'";
            }
            DataTable dt = ND_THONG_TIN_ND.GetTableFields(where, new string[] { ND_THONG_TIN_ND.cl_NAME }, ND_THONG_TIN_ND.cl_ID, ND_THONG_TIN_ND.cl_NAME);
            InitCombobox(cbo, dt, ND_THONG_TIN_ND.cl_ID, ND_THONG_TIN_ND.cl_NAME);
        }
        /// <summary>
        /// Khởi tạo danh sách kho vào control
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="IsAdd"></param>
        public static void InitListKho(DevExpress.Web.ASPxEditors.ASPxComboBox cbo, bool? IsAdd)
        {
            string where = "";
            if (IsAdd == true)
            {
                where += KH_DM_KHO.cl_VISIBLE_BIT + "='Y'";
            }

            DataTable dt = KH_DM_KHO.GetTableFields(where, new string[] { KH_DM_KHO.cl_NAME }, KH_DM_KHO.cl_ID, KH_DM_KHO.cl_NAME);
            InitCombobox(cbo, dt, KH_DM_KHO.cl_ID, KH_DM_KHO.cl_NAME);
        }
        /// <summary>
        /// Khởi tạo danh sách lý do xuất kho vào control
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="IsAdd"></param>
        public static void InitListLyDoXuat(DevExpress.Web.ASPxEditors.ASPxComboBox cbo, bool? IsAdd)
        {
            string where = "";
            if (IsAdd == true)
            {
                where += KH_DM_LY_DO_XUAT_KHO.cl_VISIBLE_BIT + "='Y'";
            }

            DataTable dt = KH_DM_LY_DO_XUAT_KHO.GetTableFields(where, new string[] { KH_DM_LY_DO_XUAT_KHO.cl_NAME }, KH_DM_LY_DO_XUAT_KHO.cl_ID, KH_DM_LY_DO_XUAT_KHO.cl_NAME);
            InitCombobox(cbo, dt, KH_DM_LY_DO_XUAT_KHO.cl_ID, KH_DM_LY_DO_XUAT_KHO.cl_NAME);
        }
        /// <summary>
        /// Khởi tạo danh sách lý do nhập kho vào control
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="IsAdd"></param>
        public static void InitListLyDoNhap(DevExpress.Web.ASPxEditors.ASPxComboBox cbo, bool? IsAdd)
        {
            string where = "";
            if (IsAdd == true)
            {
                where += KH_DM_LY_DO_NHAP_KHO.cl_VISIBLE_BIT + "='Y'";
            }

            DataTable dt = KH_DM_LY_DO_NHAP_KHO.GetTableFields(where, new string[] { KH_DM_LY_DO_NHAP_KHO.cl_NAME }, KH_DM_LY_DO_NHAP_KHO.cl_ID, KH_DM_LY_DO_NHAP_KHO.cl_NAME);
            InitCombobox(cbo, dt, KH_DM_LY_DO_NHAP_KHO.cl_ID, KH_DM_LY_DO_NHAP_KHO.cl_NAME);
        }
        public static void InitListDuAn(DevExpress.Web.ASPxGridLookup.ASPxGridLookup gridLookup, bool? IsAdd)
        {

            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colMa = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colMa.Caption = "Mã dự án";
            colMa.FieldName = DA_DU_AN.cl_MA_DU_AN;

            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colTenDA = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colTenDA.Caption = "Tên dự án";
            colTenDA.FieldName = DA_DU_AN.cl_TEN_DU_AN;

            DevExpress.Web.ASPxGridView.GridViewDataDateColumn colNgayTao = new DevExpress.Web.ASPxGridView.GridViewDataDateColumn();
            colNgayTao.Caption = "Ngày tạo";
            colNgayTao.FieldName = DA_DU_AN.cl_NGAY_TAO;

            DevExpress.Web.ASPxGridView.GridViewDataDateColumn colNgayBD = new DevExpress.Web.ASPxGridView.GridViewDataDateColumn();
            colNgayBD.Caption = "Ngày bắt đầu";
            colNgayBD.FieldName = DA_DU_AN.cl_NGAY_BAT_DAU;

            DevExpress.Web.ASPxGridView.GridViewDataDateColumn colNgayKT = new DevExpress.Web.ASPxGridView.GridViewDataDateColumn();
            colNgayKT.Caption = "Ngày kết thúc";
            colNgayKT.FieldName = DA_DU_AN.cl_NGAY_KET_THUC;


            DataTable dtTrangThai = DA_DM_TRANG_THAI_DU_AN.GetTableAll();
            DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn colTrangThai = new DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn();
            colTrangThai.PropertiesComboBox.DataSource = dtTrangThai;
            colTrangThai.PropertiesComboBox.ValueField = DA_DM_TRANG_THAI_DU_AN.cl_ID;
            colTrangThai.PropertiesComboBox.TextField = DA_DM_TRANG_THAI_DU_AN.cl_NAME;
            colTrangThai.Caption = "Trạng thái dự án";
            colTrangThai.FieldName = DA_DU_AN.cl_TRANG_THAI_ID;


            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colID = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colID.Caption = "ID";
            colID.FieldName = DA_DU_AN.cl_ID;
            colID.Visible = false;

            gridLookup.Columns.Clear();
            gridLookup.Columns.Add(colMa);
            gridLookup.Columns.Add(colTenDA);
            gridLookup.Columns.Add(colNgayTao);
            gridLookup.Columns.Add(colNgayBD);
            gridLookup.Columns.Add(colNgayKT);
            gridLookup.Columns.Add(colTrangThai);
            gridLookup.Columns.Add(colID);

          //  gridLookup.GridView.Settings.ShowFilterRow = true;


            DataTable dtDA= DA_DU_AN.GetTableAll();
            AddEmptyRow(dtDA, DA_DU_AN.cl_ID);
            gridLookup.DataSource = dtDA;
            gridLookup.KeyFieldName = DA_DU_AN.cl_ID;            
            gridLookup.DataBind();
            
        }
        public static void InitListPhieuYeuCau(DevExpress.Web.ASPxGridLookup.ASPxGridLookup gridLookup, bool? IsAdd)
        {

            //DevExpress.Web.ASPxGridView.GridViewDataTextColumn colMa = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            //colMa.Caption = "Mã dự án";
            //colMa.FieldName = DA_DU_AN.cl_MA_DU_AN;
            DataTable dtYC = YC_YEU_CAU.GetTable(@"SELECT yc.YEU_CAU_ID,
            yc.TIEU_DE,yc.NGAY_YEU_CAU,
            lyc.TEN_LOAI_YC,
            ttyc.[NAME] TRANG_THAI_YC,
            nd.[NAME] NGUOI_YC,yc.NGUOI_YEU_CAU
            FROM YC_YEU_CAU yc
            LEFT JOIN ND_THONG_TIN_ND nd ON nd.ID=yc.NGUOI_YEU_CAU
            LEFT JOIN YC_DM_LOAI_YEU_CAU lyc ON lyc.ID=yc.LOAI_YC_ID
            LEFT JOIN YC_DM_TRANG_THAI_YEU_CAU ttyc ON ttyc.ID = yc.TRANG_THAI_ID", YC_YEU_CAU.sTableName
            );
            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colTieuDe = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colTieuDe.Caption = "Phiếu yêu cầu";
            colTieuDe.FieldName = YC_YEU_CAU.cl_TIEU_DE;

            DevExpress.Web.ASPxGridView.GridViewDataDateColumn colNgayYC = new DevExpress.Web.ASPxGridView.GridViewDataDateColumn();
            colNgayYC.Caption = "Ngày yêu cầu";
            colNgayYC.FieldName = YC_YEU_CAU.cl_NGAY_YEU_CAU;

            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colNguoiYC = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colNguoiYC.Caption = "Người yêu cầu";
            colNguoiYC.FieldName = "NGUOI_YC";

            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colLoaiYC = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colLoaiYC.Caption = "Loại yêu cầu";
            colLoaiYC.FieldName = "TEN_LOAI_YC";


            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colTTYC = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colLoaiYC.Caption = "Trạng thái";
            colLoaiYC.FieldName = "TRANG_THAI_YC";

            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colID = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colID.Caption = "ID";
            colID.FieldName = YC_YEU_CAU.cl_YEU_CAU_ID;
            colID.Visible = false;

            DevExpress.Web.ASPxGridView.GridViewDataTextColumn colNguoiYCID = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            colNguoiYCID.Caption = "NGUOI_YC_ID";
            colNguoiYCID.FieldName = YC_YEU_CAU.cl_NGUOI_YEU_CAU;
            colNguoiYCID.Visible = false;

            gridLookup.Columns.Clear();
            gridLookup.Columns.Add(colTieuDe);
            gridLookup.Columns.Add(colNgayYC);
            gridLookup.Columns.Add(colNguoiYC);
            gridLookup.Columns.Add(colLoaiYC);
            gridLookup.Columns.Add(colTTYC);
            gridLookup.Columns.Add(colID);
            gridLookup.Columns.Add(colNguoiYCID);
         //   gridLookup.GridView.Settings.ShowFilterRow = true;
            AddEmptyRow(dtYC, YC_YEU_CAU.cl_YEU_CAU_ID);
            gridLookup.DataSource = dtYC;
            gridLookup.KeyFieldName = YC_YEU_CAU.cl_YEU_CAU_ID;
            gridLookup.DataBind();

        }        
      
        private static Hashtable m_executingPages = new Hashtable();

        public static void ShowMessage(string sMessage)
        {
            // If this is the first time a page has called this method then
            if (!m_executingPages.Contains(HttpContext.Current.Handler))
            {
                // Attempt to cast HttpHandler as a Page.
                Page executingPage = HttpContext.Current.Handler as Page;
                if (executingPage != null)
                {
                    // Create a Queue to hold one or more messages.
                    Queue messageQueue = new Queue();

                    // Add our message to the Queue
                    messageQueue.Enqueue(sMessage);

                    // Add our message queue to the hash table. Use our page reference
                    // (IHttpHandler) as the key.
                    m_executingPages.Add(HttpContext.Current.Handler, messageQueue);

                    // Wire up Unload event so that we can inject some JavaScript for the alerts.
                    executingPage.Unload += new EventHandler(ExecutingPage_Unload);
                }
            }
            else
            {
                // If were here then the method has allready been called from the executing Page.
                // We have allready created a message queue and stored a reference to it in our hastable. 
                Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

                // Add our message to the Queue
                queue.Enqueue(sMessage);
            }
        }

        // Our page has finished rendering so lets output the JavaScript to produce the alert's
        private static void ExecutingPage_Unload(object sender, EventArgs e)
        {
            // Get our message queue from the hashtable
            Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

            if (queue != null)
            {
                StringBuilder sb = new StringBuilder();

                // How many messages have been registered?
                int iMsgCount = queue.Count;

                // Use StringBuilder to build up our client slide JavaScript.
                sb.Append("<script language='javascript'>");

                // Loop round registered messages
                string sMsg;
                while (iMsgCount-- > 0)
                {
                    sMsg = (string)queue.Dequeue();
                    sMsg = sMsg.Replace("\n", "\\n");
                    sMsg = sMsg.Replace("\"", "'");
                    sb.Append(@"alert( """ + sMsg + @""" );");
                }

                // Close our JS
                sb.Append(@"</script>");

                // Were done, so remove our page reference from the hashtable
                m_executingPages.Remove(HttpContext.Current.Handler);

                // Write the JavaScript to the end of the response stream.
                HttpContext.Current.Response.Write(sb.ToString());
            }
        }
        #endregion


    }
}