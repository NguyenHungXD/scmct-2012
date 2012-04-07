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

namespace chiase
{
    public partial class ListOfShipments : System.Web.UI.Page
    {
        DataSet dsSoucrceHH = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                InitControlOnPopUp();
                InitGridOnPopUp();
                LoadDataControlOnPopUp();
                LoadDataGridOnPopUp();
            }
            else
            {
                dsSoucrceHH = (DataSet)Session[KH_PHIEU_XUAT_KHO_CT.sTableName];

                    
            }
        }
        protected void btn_CreateNew_Click(object sender, EventArgs e)
        {
            //pcPhieuXuat.ShowOnPageLoad = true;
           
            
           
           
        }
        private void InitControlOnPopUp()
        {
            functions.InitListNguoiDung(cboNguoiXuat, -1, true);
            functions.InitListNguoiDung(cboXuatCho, -1, true);
            functions.InitListKho(cboKhoXuat, true);
            functions.InitListLyDoXuat(cboLoaiXuat, true);
            functions.InitListDuAn(grlDuAn, true);
            functions.InitListPhieuYeuCau(grlPhieuYeuCau, true);
        }
        private void InitGridOnPopUp()
        {
            #region Cột mã hàng hóa            
            
            GridViewDataComboBoxColumn colMaHangHoa = (GridViewDataComboBoxColumn)gridViewHangHoa.Columns["colMaHangHoa"];
            DataTable dtHangHoa = DM_HANG_HOA.GetTableAll();
            functions.AddEmptyRow(dtHangHoa, DM_HANG_HOA.cl_ID);
            //ListBoxColumn colHH_MaHH = colMaHangHoa.PropertiesComboBox.Columns.Add();
            //colHH_MaHH.FieldName = DM_HANG_HOA.cl_MA_HH;
            //colHH_MaHH.Caption = "Mã hàng hóa";

            //ListBoxColumn colHH_TenHH = colMaHangHoa.PropertiesComboBox.Columns.Add();
            //colHH_TenHH.FieldName = DM_HANG_HOA.cl_NAME;
            //colHH_TenHH.Caption = "Tên hàng hóa";
            colMaHangHoa.PropertiesComboBox.DataSource = dtHangHoa;
            colMaHangHoa.PropertiesComboBox.ValueField = DM_HANG_HOA.cl_ID;
            colMaHangHoa.PropertiesComboBox.TextField = DM_HANG_HOA.cl_NAME;            
            colMaHangHoa.FieldName = KH_PHIEU_XUAT_KHO_CT.cl_HH_ID;
            #endregion
            GridViewDataSpinEditColumn colSoLuong = (GridViewDataSpinEditColumn)gridViewHangHoa.Columns["colSoLuong"];
            colSoLuong.FieldName = KH_PHIEU_XUAT_KHO_CT.cl_SO_LUONG;

            GridViewDataSpinEditColumn colDonGia = (GridViewDataSpinEditColumn)gridViewHangHoa.Columns["colDonGia"];
            colDonGia.FieldName = KH_PHIEU_XUAT_KHO_CT.cl_DON_GIA;

            GridViewDataSpinEditColumn colThanhTien= (GridViewDataSpinEditColumn)gridViewHangHoa.Columns["colThanhTien"];
            colThanhTien.FieldName = KH_PHIEU_XUAT_KHO_CT.cl_THANH_TIEN;

            GridViewDataTextColumn colChungLoai = (GridViewDataTextColumn)gridViewHangHoa.Columns["colChungLoai"];
            colChungLoai.FieldName = KH_PHIEU_XUAT_KHO_CT.cl_GHI_CHU;


            GridViewDataTextColumn colTenHangHoa = (GridViewDataTextColumn)gridViewHangHoa.Columns["colTenHangHoa"];
            colTenHangHoa.FieldName = KH_PHIEU_XUAT_KHO_CT.cl_GHI_CHU;

            GridViewDataTextColumn colMaPhieuNhap = (GridViewDataTextColumn)gridViewHangHoa.Columns["colMaPhieuNhap"];
            colMaPhieuNhap.FieldName = KH_PHIEU_XUAT_KHO_CT.cl_GHI_CHU;
        }
        private void LoadDataControlOnPopUp()
        {
        }
        private void LoadDataGridOnPopUp()
        {
            DataTable dtChietTietHangHoa = KH_PHIEU_XUAT_KHO_CT.GetTableAll();
            DataSet ds = new DataSet();
            ds.Tables.Add(dtChietTietHangHoa);
            gridViewHangHoa.DataSource = ds;
            gridViewHangHoa.DataMember = dtChietTietHangHoa.TableName;
            gridViewHangHoa.KeyFieldName = KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID;
            dtChietTietHangHoa.PrimaryKey = new DataColumn[] { dtChietTietHangHoa.Columns[KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID] };
            gridViewHangHoa.DataBind();
            Session[KH_PHIEU_XUAT_KHO_CT.sTableName] = ds;
        }

  
        protected void btn_SavePX_Click(object sender, EventArgs e)
        {
            
        }

        protected void gridViewHangHoa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
         

            DataSet ds = (DataSet)Session[KH_PHIEU_XUAT_KHO_CT.sTableName];
            ASPxGridView gridView = (ASPxGridView)sender;
            
            if (ds.Tables.Count > 0)
            {
                DataTable dataTable = ds.Tables[0];
                if (gridViewHangHoa.VisibleRowCount == 0) dataTable.Rows.Clear();
                DataRow row = dataTable.NewRow();
                e.NewValues[KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID] = GetNewId(ds);
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

            DataSet ds = (DataSet)Session[KH_PHIEU_XUAT_KHO_CT.sTableName];
            ASPxGridView gridView = (ASPxGridView)sender;
            DataTable dataTable = ds.Tables[0];
            DataRow row = dataTable.Rows.Find(e.Keys[KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID]);
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
            DataSet ds = (DataSet)Session[KH_PHIEU_XUAT_KHO_CT.sTableName];
            ds.Tables[0].Rows.Remove(ds.Tables[0].Rows.Find(e.Keys[KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID]));
            gridViewHangHoa.DataSource = ds;
            gridViewHangHoa.DataBind();
        }
        private long GetNewId(DataSet ds)
        {

            DataTable table = ds.Tables[0];
            if (table.Rows.Count == 0) return -1;
            long max = Math.Abs(Convert.ToInt64(table.Rows[0][KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID]));
            for (int i = 1; i < table.Rows.Count; i++)
            {
                if (Math.Abs( Convert.ToInt64(table.Rows[i][ KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID])) > max)
                    max =Math.Abs(Convert.ToInt32(table.Rows[i][KH_PHIEU_XUAT_KHO_CT.cl_PXK_CT_ID]));
            }
            return -(max + 1);
        }

        
    }
}