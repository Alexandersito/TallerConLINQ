using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultas
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        northwind_DataContext northwind = new northwind_DataContext();
        private IList<Employees> Listar()
        {
            var consulta = from E in northwind.Employees
                           select E;
            return consulta.ToList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var consulta = from E in northwind.Employees
                           select new
                           {
                               Codigo = E.EmployeeID,
                               NombreCompleto = E.NombreCompleto(),
                               Ubicacion = E.Ubicacion()
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
            //this.gvProyeccion.Attributes.Add("class", "w-25 table mt-3 table-dark table-striped table-bordered");

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            var consulta = from S in northwind.Suppliers
                           select new
                           {
                               Codigo = S.SupplierID,
                               Nombre = S.CompanyName,
                               Ubicacion = S.Ubiacion()
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            var consulta = from P in northwind.Products
                           select new
                           {
                               Codigo = P.ProductID,
                               Nombre = P.ProductName,
                               Stock = P.Stock()
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }
    }
}