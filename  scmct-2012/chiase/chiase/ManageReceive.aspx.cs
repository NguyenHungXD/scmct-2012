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

namespace chiase
{
    public partial class ManageReceive : System.Web.UI.Page
    {
        DataSet dsSoucrceHH = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                InitControlOnPopUp();
                InitGridOnPopUp();
                LoadDataControlOnPopUp();
                LoadDataGridOnPopUp("-1");
            }
            else
            {
                dsSoucrceHH = (DataSet)Session[KH_PHIEU_NHAP_KHO_CT.sTableName];

            }
        }
      
    
        protected void btn_CreateNew_Click(object sender, EventArgs e)
        {
            //pcPhieuNhap.ShowOnPageLoad = true;
           
            
           
           
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
        private void LoadDataControlOnPopUp()
        {
            
        }
        private void LoadDataGridOnPopUp(string idPhieuNhap)
        {
            string  where =" where "+ KH_PHIEU_NHAP_KHO_CT.cl_PNK_ID + "=" + (string.IsNullOrEmpty(idPhieuNhap) ? "-1" : idPhieuNhap);
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

        private bool Validate()
        {
            return true;
        }
  
        protected void btn_SavePX_Click(object sender, EventArgs e)
        {
            if (Validate() == false)
                return;

            
        }

        protected void gridViewHangHoa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
         

            DataSet ds = (DataSet)Session[KH_PHIEU_NHAP_KHO_CT.sTableName];
            ASPxGridView gridView = (ASPxGridView)sender;
            
            if (ds.Tables.Count > 0)
            {
                DataTable dataTable = ds.Tables[0];
                if (gridViewHangHoa.VisibleRowCount == 0) dataTable.Rows.Clear();
                DataRow row = dataTable.NewRow();
                e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID] = GetNewId(ds);
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
                if (Math.Abs( Convert.ToInt64(table.Rows[i][ KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID])) > max)
                    max =Math.Abs(Convert.ToInt32(table.Rows[i][KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID]));
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
            DataTable dtChungLoai=DM_HANG_HOA_NHOM.GetTableAll();
            ds.Tables.Add(dtChungLoai);
            ASPxTreeList treeList=sender as ASPxTreeList;
            treeList.DataSource=ds;
            treeList.DataMember=DM_HANG_HOA_NHOM.sTableName;
            treeList.KeyFieldName=DM_HANG_HOA_NHOM.cl_ID;
            treeList.ParentFieldName=DM_HANG_HOA_NHOM.cl_PARENT_ID;
            treeList.DataBind();
        }
        protected void gridViewDMHH_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {


            //DataSet ds = (DataSet)Session[KH_PHIEU_NHAP_KHO_CT.sTableName];
            ASPxGridView gridView = (ASPxGridView)sender;

            //if (ds.Tables.Count > 0)
            //{
                //DataTable dataTable = ds.Tables[0];
                //if (gridViewHangHoa.VisibleRowCount == 0) dataTable.Rows.Clear();
                //DataRow row = dataTable.NewRow();
                //e.NewValues[KH_PHIEU_NHAP_KHO_CT.cl_PNK_CT_ID] = GetNewId(ds);
                //IDictionaryEnumerator enumerator = e.NewValues.GetEnumerator();
                //enumerator.Reset();
                //while (enumerator.MoveNext())
                //    row[enumerator.Key.ToString()] = enumerator.Value == null ? DBNull.Value : enumerator.Value;

                gridView.CancelEdit();
                e.Cancel = true;
            //    dataTable.Rows.Add(row);
            //    gridViewHangHoa.DataSource = ds;
            //    gridViewHangHoa.DataBind();
            //    gridViewHangHoa.AddNewRow();

            //}
        }
    }
}