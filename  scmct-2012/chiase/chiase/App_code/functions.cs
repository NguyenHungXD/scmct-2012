using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chiase.Objects;

namespace chiase
{
    public static class functions
    {

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

            int i = 0;
            if (table.Rows.Count > 0)
            {
                obj.Items.Clear();
                foreach (DataRow dr in table.Rows)
                {
                    String valValue = dr[v_Index].ToString();
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

        #region Khanhdtn
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

            gridLookup.Columns.Add(colMa);
            gridLookup.Columns.Add(colTenDA);
            gridLookup.Columns.Add(colNgayTao);
            gridLookup.Columns.Add(colNgayBD);
            gridLookup.Columns.Add(colNgayKT);
            gridLookup.Columns.Add(colTrangThai);

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
            nd.[NAME] NGUOI_YC
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

          

            gridLookup.Columns.Add(colTieuDe);
            gridLookup.Columns.Add(colNgayYC);
            gridLookup.Columns.Add(colNguoiYC);
            gridLookup.Columns.Add(colLoaiYC);
            gridLookup.Columns.Add(colTTYC);
            

         //   gridLookup.GridView.Settings.ShowFilterRow = true;
            AddEmptyRow(dtYC, YC_YEU_CAU.cl_YEU_CAU_ID);
            gridLookup.DataSource = dtYC;
            gridLookup.KeyFieldName = YC_YEU_CAU.cl_YEU_CAU_ID;
            gridLookup.DataBind();

        }
        #endregion
    }
}