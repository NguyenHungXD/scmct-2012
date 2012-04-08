namespace chiase.Objects {
 public class TBLS{
 public enum tbl_ND_TEN_NHOM_ND{
            GROUPID,
            GROUPNAME
}
//──────────────────────────────────────────────────
 public enum tbl_ND_NHOM_ND{
            GROUPID,
            USERID
}
//──────────────────────────────────────────────────
 public enum tbl_KH_PHIEU_CHUYEN_KHO_CT{
            PCK_CT_ID,
            PCK_ID,
            HH_ID,
            SO_LUONG,
            DON_GIA,
            THANH_TIEN,
            GHI_CHU,
            PNK_CT_ID
}
//──────────────────────────────────────────────────
 public enum tbl_PQ_CHUC_NANG{
            ID,
            NAME,
            DESCRIPTION,
            VISIBLE_BIT,
            ISREAD,
            ISINSERT,
            ISDELETE,
            ISUPDATE,
            PARENT_ID
}
//──────────────────────────────────────────────────
 public enum tbl_KH_PHIEU_NHAP_KHO_CT{
            PNK_CT_ID,
            PNK_ID,
            HH_ID,
            SO_LUONG,
            DON_GIA,
            THANH_TIEN,
            GHI_CHU
}
//──────────────────────────────────────────────────
 public enum tbl_DA_NHAN_SU{
            DATV_ID,
            DU_AN_ID,
            MEM_ID,
            NGAY_THAM_GIA,
            NGAY_KET_THUC,
            GHI_CHU
}
//──────────────────────────────────────────────────
 public enum tbl_PQ_NHOM_DN_CHUC_NANG{
            FEATUREID,
            GROUPID,
            ISREAD_BIT,
            ISINSERT_BIT,
            ISUPDATE_BIT,
            ISDELETE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_TC_PHIEU_THU{
            PT_ID,
            MA_PT,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            NGUOI_THU,
            NGAY_THU,
            TONG_TIEN,
            CHUNG_TU_GOC,
            NOI_DUNG_THU,
            DU_AN_ID,
            DOI_TUONG_THU,
            MEM_ID,
            YEU_CAU_ID
}
//──────────────────────────────────────────────────
 public enum tbl_ND_THONG_TIN_NHOM_ND{
            ID,
            CODE,
            NAME,
            PARENT_ID,
            ROOT_ID,
            DESCRIPTION,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_KH_PHIEU_XUAT_KHO_CT{
            PXK_CT_ID,
            PXK_ID,
            HH_ID,
            SO_LUONG,
            DON_GIA,
            THANH_TIEN,
            GHI_CHU,
            PNK_CT_ID
}
//──────────────────────────────────────────────────
 public enum tbl_DA_DU_AN{
            ID,
            MA_DU_AN,
            TEN_DU_AN,
            NGAY_TAO,
            NGUOI_TAO,
            NGAY_BAT_DAU,
            NGAY_KET_THUC,
            CHI_TIET,
            TRANG_THAI_ID,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            GHI_CHU,
            ENABLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_TAP_TIN_DINH_KEM{
            TTDK_ID,
            TEN_TAP_TIN,
            PATH,
            SO_LUOT_TAI,
            BAI_VIET_ID
}
//──────────────────────────────────────────────────
 public enum tbl_YC_DM_LOAI_YEU_CAU{
            ID,
            TEN_LOAI_YC,
            NGUOI_TAO,
            NGAY_TAO,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            GHI_CHU,
            ENABLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_DM_HANG_HOA{
            ID,
            MA_HH,
            NAME,
            NHH_ID,
            MO_TA,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_KH_DM_LY_DO_XUAT_KHO{
            ID,
            NAME,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_YC_YEU_CAU{
            YEU_CAU_ID,
            TIEU_DE,
            NOI_DUNG,
            TRANG_THAI_ID,
            LOAI_YC_ID,
            NGUOI_YEU_CAU,
            NGAY_YEU_CAU,
            NGUOI_CAP_NHAT,
            NGAYC_CAP_NHAT
}
//──────────────────────────────────────────────────
 public enum tbl_KH_DM_LY_DO_NHAP_KHO{
            ID,
            NAME,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_DA_DM_TRANG_THAI_DU_AN{
            ID,
            NAME,
            ENABLE_BIT,
            CREATED_DATE,
            CREATED_BY
}
//──────────────────────────────────────────────────
 public enum tbl_KH_DM_KHO{
            ID,
            NAME,
            DIA_CHI,
            DIEN_THOAI,
            NGUOI_QUAN_LY,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_YC_DM_TRANG_THAI_YEU_CAU{
            ID,
            NAME,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_KH_PHIEU_XUAT_KHO{
            PXK_ID,
            MA_PXK,
            NGUOI_XUAT,
            NGAY_XUAT,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            NGUOI_NHAN,
            MEM_ID,
            KHO_ID,
            DU_AN_ID,
            LY_DO_XUAT_ID,
            CHUNG_TU,
            GHI_CHU,
            YEU_CAU_ID
}
//──────────────────────────────────────────────────
 public enum tbl_DM_HANG_HOA_NHOM{
            ID,
            NAME,
            PARENT_ID,
            ROOT_ID,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_BV_DM_CHU_DE_BV{
            ID,
            TITLE,
            VISIBLE_BIT,
            SORT,
            STATUS,
            DESCRIPTION,
            CREATED_DATE,
            CREATED_BY,
            EDITED_DATE,
            EDITED_BY
}
//──────────────────────────────────────────────────
 public enum tbl_BV_BAI_VIET{
            BAI_VIET_ID,
            TIEU_DE,
            NGUOI_TAO,
            NGAY_TAO,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            NOI_DUNG,
            TRANG_THAI_ID,
            BAI_VIET_CHA_ID,
            DU_AN_ID,
            CHU_DE_ID,
            SORT,
            XEM
}
//──────────────────────────────────────────────────
 public enum tbl_TC_PHIEU_CHI{
            PC_ID,
            MA_PC,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            NGUOI_CHI,
            NGAY_CHI,
            TONG_TIEN,
            CHUNG_TU_GOC,
            NOI_DUNG_CHI,
            DU_AN_ID,
            DOI_TUONG_CHI,
            MEM_ID
}
//──────────────────────────────────────────────────
 public enum tbl_BV_DM_TRANG_THAI_BAI_VIET{
            ID,
            NAME,
            VISIBLE_BIT
}
//──────────────────────────────────────────────────
 public enum tbl_ND_THONG_TIN_DN{
            USERID,
            USERNAME,
            PWD,
            PWD1,
            PWD2,
            BLAST,
            LASTED_ACCESS,
            CREATED_BY,
            CREATED_DATE,
            EDITED_BY,
            EDITED_DATE,
            ISCHANGEPWD_BIT,
            ISACTIVE_BIT,
            MEM_ID
}
//──────────────────────────────────────────────────
 public enum tbl_ND_THONG_TIN_ND{
            ID,
            NAME,
            MEM_GROUP_ID,
            ADDRESS,
            BIRTH_DAY,
            SEX,
            PHONE,
            FAX,
            EMAIL,
            WEBSITE,
            YAHOO,
            SKYPE,
            TAX_CODE,
            NOTE,
            AVATAR_PATH,
            VISIBLE_BIT,
            CREATED_DATE,
            CREATED_BY,
            EDITED_DATE,
            EDITED_BY,
            HEART
}
//──────────────────────────────────────────────────
 public enum tbl_TC_PHIEU_CHI_CT{
            PCCT_ID,
            PC_ID,
            DIEN_GIAI,
            SO_TIEN,
            GHI_CHU
}
//──────────────────────────────────────────────────
 public enum tbl_TC_PHIEU_THU_CT{
            PTCT_ID,
            PT_ID,
            DIEN_GIAI,
            SO_TIEN,
            GHI_CHU
}
//──────────────────────────────────────────────────
 public enum tbl_KH_PHIEU_NHAP_KHO{
            PNK_ID,
            MA_PNK,
            NGUOI_NHAP,
            NGAY_NHAP,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            MEM_ID,
            KHO_ID,
            DU_AN_ID,
            LY_DO_NHAP_ID,
            YEU_CAU_ID,
            CHUNG_TU,
            GHI_CHU
}
//──────────────────────────────────────────────────
 public enum tbl_KH_PHIEU_CHUYEN_KHO{
            PCK_ID,
            MA_PCK,
            NGUOI_CAP_NHAT,
            NGAY_CAP_NHAT,
            NGUOI_CHUYEN,
            NGAY_CHUYEN,
            KHO_XUAT_ID,
            KHO_NHAP_ID,
            DU_AN_ID,
            GHI_CHU
}
//──────────────────────────────────────────────────
 public enum TBL_NAME
 {
    ND_TEN_NHOM_ND
,    ND_NHOM_ND
,    KH_PHIEU_CHUYEN_KHO_CT
,    PQ_CHUC_NANG
,    KH_PHIEU_NHAP_KHO_CT
,    DA_NHAN_SU
,    PQ_NHOM_DN_CHUC_NANG
,    TC_PHIEU_THU
,    ND_THONG_TIN_NHOM_ND
,    KH_PHIEU_XUAT_KHO_CT
,    DA_DU_AN
,    TAP_TIN_DINH_KEM
,    YC_DM_LOAI_YEU_CAU
,    DM_HANG_HOA
,    KH_DM_LY_DO_XUAT_KHO
,    YC_YEU_CAU
,    KH_DM_LY_DO_NHAP_KHO
,    DA_DM_TRANG_THAI_DU_AN
,    KH_DM_KHO
,    YC_DM_TRANG_THAI_YEU_CAU
,    KH_PHIEU_XUAT_KHO
,    DM_HANG_HOA_NHOM
,    BV_DM_CHU_DE_BV
,    BV_BAI_VIET
,    sysdiagrams
,    TC_PHIEU_CHI
,    BV_DM_TRANG_THAI_BAI_VIET
,    ND_THONG_TIN_DN
,    ND_THONG_TIN_ND
,    TC_PHIEU_CHI_CT
,    TC_PHIEU_THU_CT
,    KH_PHIEU_NHAP_KHO
,    KH_PHIEU_CHUYEN_KHO
 } 
}// end class 
}// end name space 
