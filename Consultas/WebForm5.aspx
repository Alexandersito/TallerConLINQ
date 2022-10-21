<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="Consultas.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server" >
        <asp:ScriptManager id="smPageManager" ScriptMode="Release" runat="server">
            <scripts>
                <asp:ScriptReference Path="~/js/jquery-3.4.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
            </scripts>
        </asp:ScriptManager>
        <div class="m-4">
            <h3 class="mb-3">Tabla Suppliers</h3>
            <div class="d-flex justify-content-between w-50">
                <div>
                    <p>SupplierID:<asp:TextBox runat="server" Id ="txtSupplierID" class="form-control" style="width:200px"/></p>
                    <p>CompanyName:<asp:TextBox runat="server" Id ="txtCompanyName" class="form-control" style="width:200px"/></p>
                    <p>ContacName:<asp:TextBox runat="server" Id ="txtContactName" class=" form-control" style="width:200px"/></p>
                    <p>ContactTitle:<asp:TextBox runat="server" Id ="txtContactTitle" class="form-control" style="width:200px"/></p>
                </div>
                <div>
                    <p>Address:<asp:TextBox runat="server" Id ="txtAddress" class="form-control" style="width:200px"/></p>
                    <p>City:<asp:TextBox runat="server" Id ="txtCity" class="form-control" style="width:200px"/></p>
                    <p>Region:<asp:TextBox runat="server" Id ="txtRegion" class="form-control" style="width:200px"/></p>
                    <p>PostalCode:<asp:TextBox runat="server" Id ="txtPostalCode" class="form-control" style="width:200px"/></p>
                </div>
                <div>
                    <p>Country:<asp:TextBox runat="server" Id ="txtCountry" class="form-control" style="width:200px"/></p>
                    <p>Phone:<asp:TextBox runat="server" Id ="txtPhone" class="form-control" style="width:200px"/></p>
                    <p>Fax:<asp:TextBox runat="server" Id ="txtFax" class="form-control" style="width:200px"/></p>
                    <p>HomePage:<asp:TextBox runat="server" Id ="txtHomePage" class="form-control" style="width:200px"/></p>
                </div>
            </div>

            <p class="mt-3 mb-4 d-flex justify-content-between w-50">
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar"  class="btn btn-warning px-4" OnClick="btnAgregar_Click"/>
                <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" class="btn btn-warning px-4" OnClick="btnActualizar_Click"/>
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" class="btn btn-warning px-4" OnClick="btnEliminar_Click"/>
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" class="btn btn-warning px-4" OnClick="btnBuscar_Click"/>
                <asp:Button Text="Listar" runat="server" ID="btnListar" class="btn btn-warning px-4" OnClick="btnListar_Click"/>
            </p>
            <p >
                <asp:GridView runat ="server" id="gvSuppliers" class="table mt-3 table-dark table-striped table-bordered"></asp:GridView>
            </p>
        </div>
    </form>
</body>
</html>
