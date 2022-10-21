<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="Consultas.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager id="smPageManager" ScriptMode="Release" runat="server">
            <scripts>
                <asp:ScriptReference Path="~/js/jquery-3.4.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
            </scripts>
        </asp:ScriptManager>
        <div>
            <asp:Button Text="Otra" runat="server" ID="btnOtra" class="btn btn-warning px-4" OnClick="btnOtra_Click"/>
        </div>
    </form>
</body>
</html>
