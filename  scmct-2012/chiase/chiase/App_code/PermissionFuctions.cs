using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chiase
{
    #region Kiểm tra quyền phiếu nhập kho
    public enum AppModules
    {
        NhapKho = 50,
        XuatKho = 51,
        ChuyenKho = 52,
        DMKho = 53,
        DMHangHoa = 54
    }

    public class PermissionNhapKho
    {     

        public static bool IsAdd(System.Web.UI.Page page)
        {         
            return functions.checkPrivileges( AppModules.NhapKho.GetHashCode().ToString(), functions.LoginMemID(page), "C");//Create
        }
        public static bool IsView(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.NhapKho.GetHashCode().ToString(), functions.LoginMemID(page), "V");
        }
        public static bool IsEdit(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.NhapKho.GetHashCode().ToString(), functions.LoginMemID(page), "E");
        }
        public static bool IsDelete(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.NhapKho.GetHashCode().ToString(), functions.LoginMemID(page), "D");
        }
        public static bool IsLock(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.NhapKho.GetHashCode().ToString(), functions.LoginMemID(page), "L");
        }

    }
    #endregion

    #region Kiểm tra quyền phiếu xuất kho
    public class PermissionXuatKho
    {
      

        public static bool IsAdd(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.XuatKho.GetHashCode().ToString(), functions.LoginMemID(page), "C");//Create
        }
        public static bool IsView(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.XuatKho.GetHashCode().ToString(), functions.LoginMemID(page), "V");
        }
        public static bool IsEdit(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.XuatKho.GetHashCode().ToString(), functions.LoginMemID(page), "E");
        }
        public static bool IsDelete(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.XuatKho.GetHashCode().ToString(),functions.LoginMemID(page), "D");
        }
        public static bool IsLock(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.XuatKho.GetHashCode().ToString(), functions.LoginMemID(page), "L");
        }
    
    }
    #endregion

    #region Kiểm tra quyền phiếu chuyển  kho
    public class PermissionChuyenKho
    {

        public static bool IsAdd(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.ChuyenKho.GetHashCode().ToString(), functions.LoginMemID(page), "C");//Create
        }
        public static bool IsView(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.ChuyenKho.GetHashCode().ToString(), functions.LoginMemID(page), "V");
        }
        public static bool IsEdit(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.ChuyenKho.GetHashCode().ToString(), functions.LoginMemID(page), "E");
        }
        public static bool IsDelete(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.ChuyenKho.GetHashCode().ToString(), functions.LoginMemID(page), "D");
        }
        public static bool IsLock(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.ChuyenKho.GetHashCode().ToString(), functions.LoginMemID(page), "L");
        }

    }
    #endregion

    #region Kiểm tra quyền Danh mục kho
    public class PermissionDMKho
    {
       

        public static bool IsAdd(System.Web.UI.Page page)
        {
           
            return functions.checkPrivileges(AppModules.DMKho.GetHashCode().ToString(), functions.LoginMemID(page), "C");//Create
        }
        public static bool IsView(System.Web.UI.Page page)
        {
           
            return functions.checkPrivileges(AppModules.DMKho.GetHashCode().ToString(), functions.LoginMemID(page), "V");
        }
        public static bool IsEdit(System.Web.UI.Page page)
        {           
            return functions.checkPrivileges(AppModules.DMKho.GetHashCode().ToString(), functions.LoginMemID(page), "E");
        }
        public static bool IsDelete(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.DMKho.GetHashCode().ToString(), functions.LoginMemID(page), "D");
        }
        public static bool IsLock(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.DMKho.GetHashCode().ToString(), functions.LoginMemID(page), "L");
        }

    }
    #endregion

    #region Kiểm tra quyền Danh mục hàng hóa
    public class PermissionDMHangHoa
    {

        public static bool IsAdd(System.Web.UI.Page page)
        {
           
            return functions.checkPrivileges(AppModules.DMHangHoa.GetHashCode().ToString(), functions.LoginMemID(page), "C");//Create
        }
        public static bool IsView(System.Web.UI.Page page)
        {
           
            return functions.checkPrivileges(AppModules.DMHangHoa.GetHashCode().ToString(), functions.LoginMemID(page), "V");
        }
        public static bool IsEdit(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.DMHangHoa.GetHashCode().ToString(), functions.LoginMemID(page), "E");
        }
        public static bool IsDelete(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.DMHangHoa.GetHashCode().ToString(), functions.LoginMemID(page), "D");
        }
        public static bool IsLock(System.Web.UI.Page page)
        {
            return functions.checkPrivileges(AppModules.DMHangHoa.GetHashCode().ToString(), functions.LoginMemID(page), "L");
        }

    }
    #endregion
}