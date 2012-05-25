<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="chiase.web.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/treeview.js">

    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <a href="javascript:ddtreemenu.flatten('treemenu1', 'expand')">Mở rộng</a> | <a href="javascript:ddtreemenu.flatten('treemenu1', 'contact')">
        Thu hẹp</a>
    <ul id="treemenu1" class="treeview">
        <li><a>Folder 1</a>
            <ul>
                <li><a href="#">Sub Item 1.1</a></li>
                <li><a href="#">Sub Item 1.2</a></li>
            </ul>
        </li>
        <li>Folder 2
            <ul>
                <li><a href="#" style="background-image:'../images/close.gif'" >Sub Item 2.1</a></li>
                <li><a href="#">Sub Item 2.2</a></li>
                <li><a href="#">Sub Item 2.3</a></li>
                <li><a href="#">Sub Item 2.4</a></li>
             
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
