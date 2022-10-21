using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultas
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        northwind_DataContext northwind = new northwind_DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click1(object sender, EventArgs e)
        {
            var consulta = from S in northwind.Suppliers
                           join P in northwind.Products on S.SupplierID equals P.SupplierID
                           join C in northwind.Categories on P.CategoryID equals C.CategoryID
                           join O in northwind.Order_Details on P.ProductID equals O.ProductID
                           select new
                           {
                               Producto = P.ProductName,
                               Categoria = C.CategoryName,
                               Proveedor = S.CompanyName,
                               O.OrderID,
                               O.Quantity
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            var consulta = from E in northwind.Employees
                           join ET in northwind.EmployeeTerritories on E.EmployeeID equals ET.EmployeeID
                           join T in northwind.Territories on ET.TerritoryID equals T.TerritoryID
                           join R in northwind.Region on T.RegionID equals R.RegionID
                           select new
                           {
                               Empleado = E.FirstName + " " + E.LastName,
                               Territorio = T.TerritoryDescription,
                               Region = R.RegionDescription,
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            var consulta = from C in northwind.Customers
                           join O in northwind.Orders on C.CustomerID equals O.CustomerID
                           join OD in northwind.Order_Details on O.OrderID equals OD.OrderID
                           join E in northwind.Employees on O.EmployeeID equals E.EmployeeID
                           select new
                           {
                               Cliente = C.CompanyName,
                               O.OrderDate,
                               OD.UnitPrice,
                               Empleado = E.FirstName + " " + E.LastName,
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            var consulta = from C in northwind.Customers
                           join O in northwind.Orders on C.CustomerID equals O.CustomerID
                           join OD in northwind.Order_Details on O.OrderID equals OD.OrderID
                           join E in northwind.Employees on O.EmployeeID equals E.EmployeeID
                           join ET in northwind.EmployeeTerritories on E.EmployeeID equals ET.EmployeeID
                           join T in northwind.Territories on ET.TerritoryID equals T.TerritoryID
                           where T.TerritoryDescription == "New York"
                           select new
                           {
                               Cliente = C.CompanyName,
                               O.OrderDate,
                               OD.UnitPrice,
                               Empleado = E.FirstName + " " + E.LastName,
                               Territorio = T.TerritoryDescription
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }
    }
}