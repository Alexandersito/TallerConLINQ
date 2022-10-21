using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultas
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        northwind_DataContext northwind = new northwind_DataContext();
        private IList<Categories> Listar()
        {
            var consulta = from P in northwind.Categories
                           select P;
            return consulta.ToList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvCategories.DataSource = Listar();
                gvCategories.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.CategoryName = txtCategoryName.Text.Trim();
            categories.Description = txtDescription.Text.Trim();
            northwind.Categories.InsertOnSubmit(categories);
            try
            {
                northwind.SubmitChanges(); // Confirmar la transaccion
                gvCategories.DataSource = Listar();
                gvCategories.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Categories categories = northwind.Categories.Single(C => C.CategoryID.Equals(txtCategoryID.Text));
            categories.CategoryName = txtCategoryName.Text.Trim();
            categories.Description = txtDescription.Text.Trim();

            try
            {
                northwind.SubmitChanges();
                gvCategories.DataSource = Listar();
                gvCategories.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var CategoriaEliminado = (from C in northwind.Categories
                                    where C.CategoryID.Equals(txtCategoryID.Text)
                                    select C).First();
            northwind.Categories.DeleteOnSubmit(CategoriaEliminado);
            try
            {
                northwind.SubmitChanges();
                gvCategories.DataSource = Listar();
                gvCategories.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var query = from C in northwind.Categories
                        where C.CategoryID.Equals(txtCategoryID.Text)
                        select C;

            gvCategories.DataSource = query;
            gvCategories.DataBind();

            txtCategoryName.Text = gvCategories.Rows[0].Cells[1].Text;
            txtDescription.Text = gvCategories.Rows[0].Cells[2].Text;
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            gvCategories.DataSource = Listar();
            gvCategories.DataBind();
        }
    }
}