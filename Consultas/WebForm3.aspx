<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Consultas.WebForm3" %>

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
                <h2 class="mb-3">Clases Parciales</h2>
                    
                    <div class="d-flex justify-content-between">
                        <div class="d-flex mb-3">
                            <h4 class="m-4">Tabla Employees</h4>
                            <asp:Button Text="Nombres Completos y Ubicacion"  runat="server" 
                            class="btn btn-dark" OnClick="Unnamed1_Click"/>
                        </div>

                        <div class="d-flex mb-3">
                            <h4 class="m-4">Tabla Suppliers</h4>
                            <asp:Button Text="Nombre y Ubicacion"  runat="server" 
                            class="btn btn-dark" OnClick="Unnamed2_Click" />
                        </div>

                        <div class="d-flex mb-3">
                            <h4 class="m-4">Tabla Products</h4>
                            <asp:Button Text="Control de Stock"  runat="server" 
                            class="btn btn-dark" OnClick="Unnamed3_Click" />
                        </div>
                    </div>
                    
                    <asp:GridView runat ="server" id="gvProyeccion" class="table mt-3 table-dark table-striped table-bordered"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
