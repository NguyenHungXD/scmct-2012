using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using chiase.Objects;
using DevExpress.Web.ASPxEditors;
using System.Data;
using System.Collections;
using System.Drawing;
using DK2C.DataAccess.Web;

using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.Data;
using System.Globalization;

namespace chiase
{
    public partial class ManageReceive : System.Web.UI.Page
    {
        DataSet dsSoucrceHH = null;
        DataSet dsPNK = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                InitGridManage();
                InitControlManage();               
            }
            else
            {
                dsSoucrceHH = (DataSet)Session[KH_PHIEU_NHAP_KHO_CT.sTableName];
                dsPNK = (DataSet)Session[KH_PHIEU_NHAP_KHO.sTableName];
             
            }
            Search();
        }

        private void Search()
        {
            string where="";
            if (txtMaPhieuNhap_M.Text != "")
                where += " AND PN.MA_PNK like N'%" + txtMaPhieuNhap_M.Text + "%'";
            if (txtChungTu_M.Text != "")
                where += " AND PN.CHUNG_TU like N'%" + txtChungTu_M.Text + "%'";
            if (dtNgayNhapTu_M.Text != "")
                where += " AND PN.NGAY_NHAP >= '" + dtNgayNhapTu_M.Date.ToString("yyyy-MM-dd")+"'";
            if (dtNgayNhapDen_M.Text != "")
                where += " AND PN.NGAY_NHAP <= '" + dtNgayNhapDen_M.Date.ToString("yyyy-MM-dd") + " 23:59:59'";
            if (cboNguoiNhap_M.Value != null && cboNguoiNhap_M.Value.ToString() != "" && cboNguoiNhap_M.Value.ToString() != "-1")
                where += " AND PN.NGUOI_NHAP=" + cboNguoiNhap_M.Value;
            if (cboKhoNhap_M.Value != null && cboKhoNhap_M.Value.ToString() != "" && cboKhoNhap_M.Value.ToString() != "-1")
                where += " AND PN.KHO_ID=" + cboKhoNhap_M.Value;
            if (cboLoaiNhap_M.Value != null && cboLoaiNhap_M.Value.ToString() != "" && cboLoaiNhap_M.Value.ToString() != "-1")
                where += " AND PN.LY_DO_NHAP_ID=" + cboLoaiNhap_M.Value;
            if (grlDuAn_M.Value != null && grlDuAn_M.Value.ToString() != "" && grlDuAn_M.Value.ToString() != "-1")
                where += " AND PN.DU_AN=" + grlDuAn_M.Value;
            if (grlYeuCau_M.Value != null && grlYeuCau_M.Value.ToString() != "" && grlYeuCau_M.Value.ToString() != "-1")
                where += " AND PN.YEU_CAU_ID=" + grlYeuCau_M.Value;

            string sql = @"SELECT PN.MA_PNK, CONVERT(VARCHAR(10), PN.NGAY_NHAP,103) NGAY_NHAP, PN.GHI_CHU, PN.CHUNG_TU,NN.[NAME] NGUOI_NHAP,
            LN.[NAME] LY_DO_NHAP_ID,DA.TEN_DU_AN DU_AN_ID,
            NT.[NAME] MEM_ID, YC.TIEU_DE YEU_CAU_ID, KH.[NAME] KHO_ID, PN.PNK_ID
            FROM KH_PHIEU_NHAP_KHO PN
            LEFT JOIN ND_THONG_TIN_ND NN ON PN.NGUOI_NHAP=NN.ID
            LEFT JOIN KH_DM_LY_DO_NHAP_KHO LN ON LN.ID=PN.LY_DO_NHAP_ID
            LEFT JOIN DA_DU_AN DA ON DA.ID=PN.DU_AN_ID
            LEFT JOIN ND_THONG_TIN_ND NT ON NT.ID=PN.MEM_ID
            LEFT JOIN YC_YEU_CAU YC ON YC.YEU_CAU_ID=PN.YEU_CAU_ID
            LEFT JOIN KH_DM_KHO KH ON KH.ID=PN.KHO_ID
            where 1=1 " + where;
            DataTable dt = SQLConnectWeb.GetTable(sql, KH_PHIEU_NHAP_KHO.sTableName);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            gridViewManage.DataSource = ds;
            gridViewManage.DataMember = KH_PHIEU_NHAP_KHO.sTableName;
            gridViewManage.KeyFieldName = KH_PHIEU_NHAP_KHO.cl_PNK_ID;
            gridViewManage.DataBind();
            
            Session[KH_PHIEU_NHAP_KHO.sTableName] = ds;
        }
        private void InitGridManage()
        {
            GridViewDataTextColumn colMaPhieuNhap = (GridViewDataTextColumn)gridViewManage.Columns["colMaPhieuNhap"];
            colMaPhieuNhap.FieldName = KH_PHIEU_NHAP_KHO.cl_MA_PNK;


            GridViewDataTextColumn colNgayNhap = (GridViewDataTextColumn)gridViewManage.Columns["colNgayNhap"];
            colNgayNhap.FieldName = KH_PHIEU_NHAP_KHO.cl_NGAY_NHAP;

            GridViewDataTextColumn colNguoiNhap = (GridViewDataTextColumn)gridViewManage.Columns["colNguoiNhap"];
            colNguoiNhap.FieldName = KH_PHIEU_NHAP_KHO.cl_NGUOI_NHAP;

            GridViewDataTextColumn colLoaiNhap = (GridViewDataTextColumn)gridViewManage.Columns["colLoaiNhap"];
            colLoaiNhap.FieldName = KH_PHIEU_NHAP_KHO.cl_LY_DO_NHAP_ID;

            GridViewDataTextColumn colKhoNhap = (GridViewDataTextColumn)gridViewManage.Columns["colKhoNhap"];
            colKhoNhap.FieldName = KH_PHIEU_NHAP_KHO.cl_KHO_ID;

            GridViewDataTextColumn colDuAn = (GridViewDataTextColumn)gridViewManage.Columns["colDuAn"];
            colDuAn.FieldName = KH_PHIEU_NHAP_KHO.cl_DU_AN_ID;

            GridViewDataTextColumn colYeuCau = (GridViewDataTextColumn)gridViewManage.Columns["colYeuCau"];
            colYeuCau.FieldName = KH_PHIEU_NHAP_KHO.cl_YEU_CAU_ID;

            GridViewDataTextColumn colNhapTu = (GridViewDataTextColumn)gridViewManage.Columns["colNhapTu"];
            colNhapTu.FieldName = KH_PHIEU_NHAP_KHO.cl_MEM_ID;

            GridViewDataTextColumn colChungTu = (GridViewDataTextColumn)gridViewManage.Columns["colChungTu"];
            colChungTu.FieldName = KH_PHIEU_NHAP_KHO.cl_CHUNG_TU;

            GridViewDataTextColumn colGhiChu = (GridViewDataTextColumn)gridViewManage.Columns["colGhiChu"];
            colGhiChu.FieldName = KH_PHIEU_NHAP_KHO.cl_GHI_CHU;

            GridViewDataTextColumn colPNKID = (GridViewDataTextColumn)gridViewManage.Columns["colPNKID"];
            colPNKID.FieldName = KH_PHIEU_NHAP_KHO.cl_PNK_ID;

        }
        private void InitControlManage()
        {
            functions.InitListNguoiDung(cboNguoiNhap_M, -1, true);
            functions.InitListNguoiDung(cboNhapTu_M, -1, true);
            functions.InitListKho(cboKhoNhap_M, true);
            functions.InitListLyDoNhap(cboLoaiNhap_M, true);
            functions.InitListDuAn(grlDuAn_M, true);
            functions.InitListPhieuYeuCau(grlYeuCau_M, true);

            dtNgayNhapDen_M.Date = DateTime.Today;
            dtNgayNhapTu_M.Date = DateTime.Today.AddDays(-7);
        }

        private void InitDataPopup(string id)
        {
            InitControlOnPopUp();
            InitGridOnPopUp();
            LoadDataControlOnPopUp(id);
            LoadDataGridOnPopUp(id);
        }
        protected void btn_CreateNew_Click(object sender, EventArgs e)
        {

            InitDataPopup("-1");
            pcPhieuNhap.ShowOnPageLoad = true;




        }
        private void InitControlOnPopUp()
        {
            functions.InitListNguoiDung(cboNguoiNhap, -1, true);
            functions.InitListNguoiDung(cboNhapTu, -1, true);
            functions.InitListKho(cboKhoNhap, true);
            functions.InitListLyDoNhap(cboLoaiNhap, true);
            functions.InitListDuAn(grlDuAn, true);
            functions.InitListPhieuYeuCau(grlPhieuYeuCau, true);

            
        }

        private void InitGridOnPopUp()
        {


            GridViewDataTextColumn colPNKCT_ID = (GridViewDataTextColumn)gridViewHangHoa.Columns["colPNKCT_ID"];
            colPNKCT_ID.FieldName = KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID;


            GridViewDataTextColumn colPNK_ID = (GridViewDataTextColumn)gridViewHangHoa.Columns["colPNK_ID"];
            colPNKCT_ID.FieldName = KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID;


            GridViewDataTextColumn colHH_ID = (GridViewDataTextColumn)gridViewHangHoa.Columns["colHH_ID"];
            colPNKCT_ID.FieldName = KH_PHIEU_NHAP_KHO_CT.cl_HH_ID;

            GridViewDataDropDownEditColumn colTenHangHoa = (GridViewDataDropDownEditColumn)gridViewHangHoa.Columns["colTenHangHoa"];
            colTenHangHoa.FieldName = DM_HANG_HOA.cl_NAME;


            GridViewDataSpinEditColumn colSoLuong = (GridViewDataSpinEditColumn)gridViewHangHoa.Columns["colSoLuong"];
            colSoLuong.FieldName = KH_PHIEU_NHAP_KHO_CT.cl_SO_LUONG;

            GridViewDataSpinEditColumn colDonGia = (GridViewDataSpinEditColumn)gridViewHangHoa.Columns["colDonGia"];
            colDonGia.FieldName = KH_PHIEU_NHAP_KHO_CT.cl_DON_GIA;

            GridViewDataSpinEditColumn colThanhTien = (GridViewDataSpinEditColumn)gridViewHangHoa.Columns["colThanhTien"];
            colThanhTien.FieldName = KH_PHIEU_NHAP_KHO_CT.cl_THANH_TIEN;

            GridViewDataTextColumn colChungLoaiID = (GridViewDataTextColumn)gridViewHangHoa.Columns["colChungLoaiID"];
            colChungLoaiID.FieldName = DM_HANG_HOA.cl_NHH_ID;

            GridViewDataDropDownEditColumn colChungLoaiName = (GridViewDataDropDownEditColumn)gridViewHangHoa.Columns["colChungLoaiName"];
            colChungLoaiName.FieldName = "NHH_NAME";

            GridViewDataTextColumn colMaHangHoa = (GridViewDataTextColumn)gridViewHangHoa.Columns["colMaHangHoa"];
            colMaHangHoa.FieldName = DM_HANG_HOA.cl_MA_HH;
        }
        private void LoadDataControlOnPopUp(string ID)
        {
            lblIDPhieuNhap.Text = ID;
            if (ID == "-1")
            {
                txtMaNhap.Text = "";
                txtChungTu.Text = "";
                cboKhoNhap.Value = null;
                cboLoaiNhap.Value = null;
                cboNguoiNhap.Value = null;
                cboNhapTu.Value = null;
                grlDuAn.Value = null;
                grlPhieuYeuCau.Value = null;
                txtGhiChu.Text = "";
                dtNgayNhap.Value = DateTime.Today;

                if (gridViewHangHoa.IsEditing == false)
                    gridViewHangHoa.AddNewRow();
            }
            else
            {
                DataTable dtKHo = KH_PHIEU_NHAP_KHO.GetTableAll(KH_PHIEU_NHAP_KHO.cl_PNK_ID + "=" + ID);
                KH_PHIEU_NHAP_KHO k = new KH_PHIEU_NHAP_KHO(dtKHo, 0);
                txtMaNhap.Text = k.MA_PNK;
                txtChungTu.Text = k.CHUNG_TU;
                cboKhoNhap.Value = k.KHO_ID;
                cboLoaiNhap.Value = k.LY_DO_NHAP_ID;
                cboNguoiNhap.Value = k.NGUOI_NHAP;
                cboNhapTu.Value = k.MEM_ID;
                grlDuAn.Value = k.DU_AN_ID;
                grlPhieuYeuCau.Value = k.YEU_CAU_ID;
                txtGhiChu.Text = k.GHI_CHU;
                if (string.IsNullOrEmpty(k.NGAY_NHAP) == false)
                {
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "dd/MM/yyyy";
                    dtNgayNhap.Value = DateTime.Parse(k.NGAY_NHAP, dtfi);
                }
            }
        }
        private void LoadDataGridOnPopUp(string idPhieuNhap)
        {
            string where = " where " + KH_PHIEU_NHAP_KHO_CT.cl_PNK_ID + "=" + (string.IsNullOrEmpty(idPhieuNhap) ? "-1" : idPhieuNhap);
            string sql = string.Format(@"select ct.*,hh.NAME,hh.MA_HH, hh.NHH_ID, nhh.name NHH_NAME 
            from KH_PHIEU_NHAP_KHO_CT ct
            left join dm_hang_hoa hh on hh.id=ct.hh_id
            left join dm_hang_hoa_nhom nhh on nhh.id=hh.nhh_id
            {0}", where);
            DataTable dtChietTietHangHoa = SQLConnectWeb.GetTable(sql, KH_PHIEU_CHUYEN_KHO_CT.sTableName);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtChietTietHangHoa);
            gridViewHangHoa.DataSource = ds;
            gridViewHangHoa.DataMember = dtChietTietHangHoa.TableName;
            gridViewHangHoa.KeyFieldName = KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID;
            dtChietTietHangHoa.PrimaryKey = new DataColumn[] { dtChietTietHangHoa.Columns[KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID] };
            gridViewHangHoa.DataBind();

            Session[KH_PHIEU_NHAP_KHO_CT.sTableName] = ds;
        }


        protected void gridViewHangHoa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            DataSet ds = (DataSet)Session[KH_PHIEU_NHAP_KHO_CT.sTableName];
            ASPxGridView gridView = (ASPxGridView)sender;

            if (ds.Tables.Count > 0)
            {
                DataTable dataTable = ds.Tables[0];
                if (gridView.VisibleRowCount == 0) dataTable.Rows.Clear();
                DataRow row = dataTable.NewRow();
                e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID] = GetNewId(ds);
                string temp = string.IsNullOrEmpty(txtTemp.Text) ? "@" : txtTemp.Text;
                string[] obja = temp.Split('@');

                e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_HH_ID] = (obja[0] == "" || obja[0] == "null" || obja[0] == "undefined") ? null : obja[0];
                e.NewValues[DM_HANG_HOA.cl_NHH_ID] = (obja[1] == "" || obja[1] == "null" || obja[1] == "undefined") ? null : obja[0];
                if (e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_SO_LUONG] != null && e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_DON_GIA] != null
                    && e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_SO_LUONG].ToString() != "" && e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_DON_GIA].ToString() != "")
                {
                    e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_THANH_TIEN] = decimal.Parse(e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_SO_LUONG].ToString()) * decimal.Parse(e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_DON_GIA].ToString());
                }

                IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
                enumerator.Reset();
                while (enumerator.MoveNext())
                    row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;

                gridView.CancelEdit();
                e.Cancel = true;
                dataTable.Rows.Add(row);
                gridViewHangHoa.DataSource = ds;
                gridViewHangHoa.DataBind();
                gridViewHangHoa.AddNewRow();

            }
        }

        protected void gridViewHangHoa_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
           
            DataSet ds = (DataSet)Session[KH_PHIEU_NHAP_KHO_CT.sTableName];
            ASPxGridView gridView = (ASPxGridView)sender;
            DataTable dataTable = ds.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID]);
            IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
                row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;
            gridView.CancelEdit();
            e.Cancel = true;
            gridViewHangHoa.DataSource = ds;
            gridViewHangHoa.DataBind();
        }

        protected void gridViewHangHoa_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            DataSet ds = (DataSet)Session[KH_PHIEU_NHAP_KHO_CT.sTableName];
            ds.Tables[0].Rows.Remove(ds.Tables[0].Rows.Find(e.Keys[KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID]));
            gridViewHangHoa.DataSource = ds;
            gridViewHangHoa.DataBind();
        }
        private long GetNewId(DataSet ds)
        {

            DataTable table = ds.Tables[0];
            if (table.Rows.Count == 0) return -1;
            long max = Math.Abs(Convert.ToInt64(table.Rows[0][KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID]));
            for (int i = 1; i < table.Rows.Count; i++)
            {
                if (Math.Abs(Convert.ToInt64(table.Rows[i][KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID])) > max)
                    max = Math.Abs(Convert.ToInt32(table.Rows[i][KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID]));
            }
            return -(max + 1);
        }


        protected void gridViewDMHH_OnInit(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sql = @"select hh.*, nhh.name NHH_NAME from dm_hang_hoa hh
            left join dm_hang_hoa_nhom nhh on hh.nhh_id=nhh.id";
            DataTable dtHangHoa = SQLConnectWeb.GetTable(sql, DM_HANG_HOA.sTableName);
            functions.AddEmptyRow(dtHangHoa, DM_HANG_HOA.cl_ID);
            ds.Tables.Add(dtHangHoa);
            ASPxGridView gridViewDMHH = sender as ASPxGridView;
            gridViewDMHH.DataSource = ds;
            gridViewDMHH.DataMember = DM_HANG_HOA.sTableName;
            gridViewDMHH.KeyFieldName = DM_HANG_HOA.cl_ID;
            gridViewDMHH.DataBind();
        }
        protected void treeListChungLoai_OnInit(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtChungLoai = DM_HANG_HOA_NHOM.GetTableAll();
            ds.Tables.Add(dtChungLoai);
            ASPxTreeList treeList = sender as ASPxTreeList;
            treeList.DataSource = ds;
            treeList.DataMember = DM_HANG_HOA_NHOM.sTableName;
            treeList.KeyFieldName = DM_HANG_HOA_NHOM.cl_ID;
            treeList.ParentFieldName = DM_HANG_HOA_NHOM.cl_PARENT_ID;
            treeList.DataBind();
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {

           // Search();
        }

        protected void gridViewManage_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            string pnkID = e.Keys[KH_PHIEU_NHAP_KHO.cl_PNK_ID].ToString();

            string sql = string.Format("delete from {0} where {1}={2}", KH_PHIEU_NHAP_KHO.sTableName, KH_PHIEU_NHAP_KHO.cl_PNK_ID, pnkID);
            SQLConnectWeb.ExecSQL(sql);
            Search();


        }




        protected void gridViewManage_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            InitDataPopup(e.KeyValue.ToString());
            pcPhieuNhap.ShowOnPageLoad = true;

        }

        protected void gridViewHangHoa_RowValidating(object sender, ASPxDataValidationEventArgs e)
        {
            
            foreach (GridViewColumn column in gridViewHangHoa.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (dataColumn.FieldName == DM_HANG_HOA.cl_NAME || dataColumn.FieldName ==DM_HANG_HOA.cl_MA_HH ||
                    dataColumn.FieldName == "NHH_NAME" ||dataColumn.FieldName==KH_PHIEU_NHAP_KHO_CT.cl_SO_LUONG)
                {
                    if (e.NewValues[dataColumn.FieldName] == null)
                        e.Errors[dataColumn] = "Vui lòng vào thông tin \"" + dataColumn.Caption + "\"";
                }
                if (dataColumn.FieldName == KH_PHIEU_NHAP_KHO_CT.cl_DON_GIA)
                {
                    if (e.NewValues[dataColumn.FieldName] != null && decimal.Parse(e.NewValues[dataColumn.FieldName].ToString()) <= 0)
                    {
                        e.Errors[dataColumn] = "Vui lòng vào thông tin \"" + dataColumn.Caption + "\" >0";
                    }
                }
            }
            // Displays the error row if there is at least one error.
            if (e.Errors.Count > 0) e.RowError = "Vui lòng vào thông tin hợp lệ theo hướng dẫn";
        }
      
        protected void gridViewHangHoa_StartRowEditing(object sender, ASPxStartRowEditingEventArgs e)
        {
            object[] objs = (object[])gridViewHangHoa.GetRowValuesByKeyValue(e.EditingKeyValue, KH_PHIEU_NHAP_KHO_CT.cl_HH_ID, DM_HANG_HOA.cl_NHH_ID);
            if (objs != null && objs.Length > 0)
            {
                txtTemp.Value =(objs[0] == null ? "" : objs[0].ToString()) + "@" + (objs[1] == null ? "" : objs[1].ToString());              
            }
        }



    }


}
