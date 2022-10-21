using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ventasDataContext ventas = new ventasDataContext();

        private IList<Vendedor> Listar()
        {
            var consulta = from V in ventas.Vendedor
                           select V;
            return consulta.ToList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargar solo una vez los vendedores
            if (!IsPostBack)
            {
                gvVendedor.DataSource = Listar();
                gvVendedor.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.CodVendedor = txtCodVendedor.Text.Trim();
            vendedor.Apellidos = txtApellidos.Text.Trim();
            vendedor.Nombres = txtNombres.Text.Trim();
            ventas.Vendedor.InsertOnSubmit(vendedor);
            try
            {
                ventas.SubmitChanges(); // Confirmar la transaccion
                gvVendedor.DataSource = Listar();
                gvVendedor.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var VendedorEliminado = (from V in ventas.Vendedor
                                     where V.CodVendedor.Contains(txtCodVendedor.Text)
                                     select V).First();
            ventas.Vendedor.DeleteOnSubmit(VendedorEliminado);
            try
            {
                ventas.SubmitChanges();
                gvVendedor.DataSource = Listar();
                gvVendedor.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = ventas.Vendedor.Single(V  => V.CodVendedor == txtCodVendedor.Text);
            vendedor.Apellidos = txtApellidos.Text;
            vendedor.Nombres = txtNombres.Text;
            try
            {
                ventas.SubmitChanges();
                gvVendedor.DataSource = Listar();
                gvVendedor.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}