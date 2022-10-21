using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        northwind_DataContext northwind = new northwind_DataContext();
        private IList<Products> Listar()
        {
            var consulta = from P in northwind.Products
                           select P;
            return consulta.ToList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargar solo una vez los vendedores
            if (!IsPostBack)
            {
               gvProyeccion.DataSource = Listar();
               gvProyeccion.DataBind();
            }
        }

        protected void btnProyeccion1_Click(object sender, EventArgs e)
        {
            var consulta = from P in northwind.Products
                           select new
                           {
                               Producto = P.ProductName,
                               PrecioUnitario = P.UnitPrice
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void btnProyeccion2_Click(object sender, EventArgs e)
        {
            var consulta = from P in northwind.Products
                           select new
                           {
                               Producto = P.ProductName,
                               Stock = P.UnitsInStock,
                               PrecioUnitario = P.UnitPrice,
                               Categoria = P.Categories.CategoryName
                           };
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            gvProyeccion.DataSource = Listar();
            gvProyeccion.DataBind();
        }
    }
}