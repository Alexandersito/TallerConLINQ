using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultas
{
    public partial class WebForm2 : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                gvProyeccion.DataSource = Listar();
                gvProyeccion.DataBind();
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            gvProyeccion.DataSource = Listar();
            gvProyeccion.DataBind();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var consulta = northwind.Employees.Where(E => E.City == "London");
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            var consulta = northwind.Employees.Where(E => E.ReportsTo > 2);
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }

        protected void Unnamed3_Click1(object sender, EventArgs e)
        {
            var consulta = northwind.Employees.Where(E => E.FirstName.Length == 5);
            gvProyeccion.DataSource = consulta;
            gvProyeccion.DataBind();
        }
    }
}