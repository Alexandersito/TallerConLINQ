<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Consultas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server" class="bg-warning">
        <asp:ScriptManager id="smPageManager" ScriptMode="Release" runat="server">
            <scripts>
                <asp:ScriptReference Path="~/js/jquery-3.4.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
            </scripts>
        </asp:ScriptManager>
        <div class="pt-3 p-4 ">
            <h2 class="mb-3">Proyecciones - Tabla Products</h2>
            <div class="d-flex justify-content-between w-50">
                <asp:Button Text="(ProductName - UnitPrice)" runat="server" ID="btnProyeccion1" OnClick="btnProyeccion1_Click" 
                    class="btn btn-dark"/>
                <asp:Button Text="(ProductName - UnitsInStock - UnitPrice - Category)" runat="server" ID="btnProyeccion2" 
                    class="btn btn-dark" OnClick="btnProyeccion2_Click"/>
                <asp:Button Text="Listar" runat="server" class="btn btn-dark" OnClick="Unnamed1_Click"/>
            </div>
            <asp:GridView runat ="server" id="gvProyeccion" class="w-50 table mt-3 table-dark table-striped table-bordered"></asp:GridView>
        </div>
    </form>
    
</body>
</html>
