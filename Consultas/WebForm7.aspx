﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="Consultas.WebForm7" %>

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
        <div class="m-4">
            <h3 class="mb-3">Tabla Categories</h3>
            <div class="d-flex justify-content-between w-50">
                <div>
                    <p>CategoryID:<asp:TextBox runat="server" ID="txtCategoryID" class="form-control" Style="width: 200px" /></p>
                    <p>CategoryName:<asp:TextBox runat="server" ID="txtCategoryName" class="form-control" Style="width: 200px" /></p>
                    <p>Description:<asp:TextBox runat="server" ID="txtDescription" class=" form-control" Style="width: 200px" /></p>
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
                <asp:GridView runat ="server" id="gvCategories" class="table mt-3 table-dark table-striped table-bordered"></asp:GridView>
            </p>
        </div>
    </form>
</body>
</html>
