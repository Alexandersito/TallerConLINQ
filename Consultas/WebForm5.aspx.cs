using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultas
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        northwind_DataContext northwind = new northwind_DataContext();
        private IList<Suppliers> Listar()
        {
            var consulta = from S in northwind.Suppliers
                           select S;
            return consulta.ToList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargar solo una vez los vendedores
            if (!IsPostBack)
            {
                gvSuppliers.DataSource = Listar();
                gvSuppliers.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.CompanyName = txtCompanyName.Text.Trim();
            suppliers.ContactName = txtContactName.Text.Trim();
            suppliers.ContactTitle = txtContactTitle.Text.Trim();
            suppliers.Address = txtAddress.Text.Trim();
            suppliers.City = txtCity.Text.Trim();
            suppliers.Region = txtRegion.Text.Trim();
            suppliers.PostalCode = txtPostalCode.Text.Trim();
            suppliers.Country = txtCountry.Text.Trim();
            suppliers.Phone = txtPhone.Text.Trim();
            suppliers.Fax = txtFax.Text.Trim();
            suppliers.HomePage = txtHomePage.Text.Trim();
            northwind.Suppliers.InsertOnSubmit(suppliers);
            try
            {
                northwind.SubmitChanges(); // Confirmar la transaccion
                gvSuppliers.DataSource = Listar();
                gvSuppliers.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var SupplierEliminado = (from S in northwind.Suppliers
                                     where S.SupplierID.Equals(txtSupplierID.Text)
                                     select S).First();
            northwind.Suppliers.DeleteOnSubmit(SupplierEliminado);
            try
            {
                northwind.SubmitChanges();
                gvSuppliers.DataSource = Listar();
                gvSuppliers.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = northwind.Suppliers.Single(S => S.SupplierID.Equals(txtSupplierID.Text));
            suppliers.CompanyName = txtCompanyName.Text;
            suppliers.ContactName = txtContactName.Text;
            suppliers.ContactTitle = txtContactTitle.Text;
            suppliers.Address = txtAddress.Text;
            suppliers.City = txtCity.Text;
            suppliers.Region = txtRegion.Text;
            suppliers.PostalCode = txtPostalCode.Text;
            suppliers.Country = txtCountry.Text;
            suppliers.Phone = txtPhone.Text;
            suppliers.Fax = txtFax.Text;
            suppliers.HomePage = txtHomePage.Text;
            try
            {
                northwind.SubmitChanges();
                gvSuppliers.DataSource = Listar();
                gvSuppliers.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var query = from S in northwind.Suppliers
                        where S.SupplierID.Equals(txtSupplierID.Text)
                        select S;
           
            gvSuppliers.DataSource = query;
            gvSuppliers.DataBind();

            txtCompanyName.Text = gvSuppliers.Rows[0].Cells[1].Text;
            txtContactName.Text = gvSuppliers.Rows[0].Cells[2].Text;
            txtContactTitle.Text = gvSuppliers.Rows[0].Cells[3].Text;
            txtAddress.Text = gvSuppliers.Rows[0].Cells[4].Text;
            txtCity.Text = gvSuppliers.Rows[0].Cells[5].Text;
            txtRegion.Text = gvSuppliers.Rows[0].Cells[6].Text;
            txtPostalCode.Text = gvSuppliers.Rows[0].Cells[7].Text;
            txtCountry.Text = gvSuppliers.Rows[0].Cells[8].Text;
            txtPhone.Text = gvSuppliers.Rows[0].Cells[9].Text;
            txtFax.Text = gvSuppliers.Rows[0].Cells[10].Text;
            txtHomePage.Text = gvSuppliers.Rows[0].Cells[11].Text;
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            gvSuppliers.DataSource = Listar();
            gvSuppliers.DataBind();
        }
    }
}