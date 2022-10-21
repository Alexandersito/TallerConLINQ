<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Consultas.WebForm2" %>

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
            <div class="pt-3 p-4 ">
                <h2 class="mb-3">Expresiones Landa - Tabla Employees</h2>
                <div class="d-flex justify-content-between w-50">
                    <asp:Button Text="Empleados de Londom" runat="server" 
                        class="btn btn-dark" OnClick="Unnamed1_Click"/>
                    <asp:Button Text="+ 2 reports" runat="server" 
                        class="btn btn-dark" OnClick="Unnamed2_Click" />
                    <asp:Button Text="nombre con 5 letras" runat="server" 
                        class="btn btn-dark" OnClick="Unnamed3_Click1"/>
                    <asp:Button Text="Listar" runat="server" class="btn btn-dark" OnClick="Unnamed3_Click"/>
                </div>
                    <asp:GridView runat ="server" id="gvProyeccion" class="table mt-3 table-dark table-striped table-bordered"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
