using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultas
{
    public partial class WebForm6 : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                gvProducts.DataSource = Listar();
                gvProducts.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ProductName = txtProductName.Text.Trim();
            products.SupplierID = Convert.ToInt32(txtSupplierID.Text);
            products.CategoryID = Convert.ToInt32(txtCategoryID.Text.Trim());
            products.QuantityPerUnit = txtQuantityPerUnit.Text.Trim();
            products.UnitPrice = Convert.ToInt32(txtUnitPrice.Text.Trim());
            products.UnitsInStock = Convert.ToInt16(txtUnitsInStock.Text.Trim());
            products.UnitsOnOrder = Convert.ToInt16(txtUnitsOnOrder.Text.Trim());
            products.ReorderLevel = Convert.ToInt16(txtReorderLevel.Text.Trim());
            products.Discontinued = Convert.ToBoolean(txtDiscontinued.Text);

            northwind.Products.InsertOnSubmit(products);
            try
            {
                northwind.SubmitChanges(); // Confirmar la transaccion
                gvProducts.DataSource = Listar();
                gvProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Products products = northwind.Products.Single(P => P.ProductID.Equals(txtProductID.Text));
            products.ProductName = txtProductName.Text.Trim();
            products.SupplierID = Convert.ToInt32(txtSupplierID.Text);
            products.CategoryID = Convert.ToInt32(txtCategoryID.Text.Trim());
            products.QuantityPerUnit = txtQuantityPerUnit.Text.Trim();
            products.UnitPrice = Convert.ToInt32(txtUnitPrice.Text.Trim());
            products.UnitsInStock = Convert.ToInt16(txtUnitsInStock.Text.Trim());
            products.UnitsOnOrder = Convert.ToInt16(txtUnitsOnOrder.Text.Trim());
            products.ReorderLevel = Convert.ToInt16(txtReorderLevel.Text.Trim());
            products.Discontinued = Convert.ToBoolean(txtDiscontinued.Text);

            try
            {
                northwind.SubmitChanges();
                gvProducts.DataSource = Listar();
                gvProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var ProductEliminado = (from P in northwind.Products
                                     where P.ProductID.Equals(txtProductID.Text)
                                    select P).First();
            northwind.Products.DeleteOnSubmit(ProductEliminado);
            try
            {
                northwind.SubmitChanges();
                gvProducts.DataSource = Listar();
                gvProducts.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var query = from P in northwind.Products
                        where P.ProductID.Equals(txtProductID.Text)
                        select P;

            gvProducts.DataSource = query;
            gvProducts.DataBind();

            txtProductName.Text = gvProducts.Rows[0].Cells[1].Text;
            txtSupplierID.Text = gvProducts.Rows[0].Cells[2].Text;
            txtCategoryID.Text = gvProducts.Rows[0].Cells[3].Text;
            txtQuantityPerUnit.Text = gvProducts.Rows[0].Cells[4].Text;
            txtUnitPrice.Text = gvProducts.Rows[0].Cells[5].Text;
            txtUnitsInStock.Text = gvProducts.Rows[0].Cells[6].Text;
            txtUnitsOnOrder.Text = gvProducts.Rows[0].Cells[7].Text;
            txtReorderLevel.Text = gvProducts.Rows[0].Cells[8].Text;
            txtDiscontinued.Text = gvProducts.Rows[0].Cells[9].Text;
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            gvProducts.DataSource = Listar();
            gvProducts.DataBind();
        }
    }
}