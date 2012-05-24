<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="chiase.web.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/treeview.js">

    </script>
    <style type="text/css">
        .treeview ul
        {
            /*CSS for Simple Tree Menu*/
            margin: 0;
            padding: 0;
        }
        .treeview li
        {
            /*Style for LI elements in general (excludes an LI that contains sub lists)*/
            background: white url(../images/list.gif) no-repeat left center;
            list-style-type: none;
            padding-left: 22px;
            margin-bottom: 3px;
        }
        .treeview li.submenu
        {
            /* Style for LI that contains sub lists (other ULs). */
            background: white url(../images/closed.gif) no-repeat left 1px;
            cursor: hand !important;
            cursor: pointer !important;
        }
        .treeview li.submenu ul
        {
            /*Style for ULs that are children of LIs (submenu) */
            display: none; /*Hide them by default. Don't delete. */
        }
        .treeview .submenu ul li
        {
            /*Style for LIs of ULs that are children of LIs (submenu) */
            cursor: default;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <a href="javascript:ddtreemenu.flatten('treemenu1', 'expand')">Mở rộng</a> | <a href="javascript:ddtreemenu.flatten('treemenu1', 'contact')">
        Thu hẹp</a>
    <ul id="treemenu1" class="treeview">
        <li>Folder 1
            <ul>
                <li><a href="#">Sub Item 1.1</a></li>
                <li><a href="#">Sub Item 1.2</a></li>
            </ul>
        </li>
        <li>Folder 2
            <ul>
                <li><a href="#">Sub Item 2.1</a></li>
                <li><a href="#">Sub Item 2.2</a></li>
                <li><a href="#">Sub Item 2.3</a></li>
                <li><a href="#">Sub Item 2.4</a></li
                <li><input type="text" /></li>
            </ul>
        </li>
        <li>Folder 3
            <ul>
                <li>Sub Item 3.1</li>
                <li>Folder 3.1
                    <ul rel="open">
                        <li>Sub Item 3.1.1</li>
                        <li>Sub Item 3.1.2</li>
                        <li>Folder 3.1.1
                            <ul>
                                <li>Sub item 3.1.1.1</li>
                                <li>Sub item 3.1.1.2</li>
                                <li>Sub item 3.1.1.3</li>
                                <li>Sub item 3.1.1.4</li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
        </li>
        <li>Item 4</li>
    </ul>
    <script type="text/javascript">
        ddtreemenu.createTree("treemenu1", true) // nếu bạn muốn khi load trang, menu ở dạng thu gọn thì thay TRUE thành FALSE
    </script>
    </form>
</body>
</html>
