<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUD.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>CodVendedor:<asp:TextBox runat="server" Id ="txtCodVendedor"/></p>
            <p>Apellidos:<asp:TextBox runat="server" Id ="txtApellidos"/></p>
            <p>Nombres:<asp:TextBox runat="server" Id ="txtNombres"/></p>
            <p>
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" />
                <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" OnClick="btnActualizar_Click" />

            </p>
            <p>
                <asp:GridView runat ="server" id="gvVendedor"></asp:GridView>
            </p>
        </div>
    </form>
</body>
</html>
