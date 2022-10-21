using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicativoConLINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        VentasDataContext ventas = new VentasDataContext();

        private void button1_Click(object sender, EventArgs e)
        {
            var consulta = from C in ventas.Cliente
                           select C;
            dgvDatos.DataSource = consulta;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var consulta = from C in ventas.Cliente
                           select new
                           {
                               C.CodCliente,
                               C.Apellidos,
                               C.Nombres
                           };
            dgvDatos.DataSource = consulta;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var consulta = from C in ventas.Cliente
                           select new
                           {
                               Codigo = C.CodCliente,
                               Datos = C.Apellidos + " " + C.Nombres,
                               Direccion = C.Direccion
                           };
            dgvDatos.DataSource = consulta;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Apellidos y Nombres concatenados con clases parciales
            var consulta = from C in ventas.Cliente
                           select new
                           {
                               Codigo = C.CodCliente,
                               Datos = C.NombreCompleto()
                           };
            dgvDatos.DataSource = consulta;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var consulta = from P in ventas.Producto
                           select P;
            dgvDatos.DataSource = consulta;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Restriccion
            var consulta = from P in ventas.Producto
                           where P.Stock > 20 && P.Stock < 50   //Restriccion
                           select new                           //Proyecccion
                           { 
                                P.CodProducto,
                                P.Nombre,
                                P.Stock
                           };
            dgvDatos.DataSource = consulta;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Boletas del segundo semestre
            var consulta = from B in ventas.Boleta
                           where B.Fecha.Year == 2008 && B.Fecha.Month >= 7 && B.Fecha.Month <= 12
                           orderby B.CodVendedor
                           select B;
            dgvDatos.DataSource = consulta;
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Boletas del segundo semestre
            var consulta = from P in ventas.Producto
                           where P.UnidadMedida == cboUnidad.Text
                           select P;
            dgvDatos.DataSource = consulta;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var consulta = (from C in ventas.Cliente
                            select C).Take(5);              //Skip - Take - Order By
            dgvDatos.DataSource = consulta;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var consulta = (from P in ventas.Producto
                            select new
                            {
                                P.UnidadMedida
                            }).Distinct();
            dgvDatos.DataSource = consulta;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var consulta = (from P in ventas.Producto
                            select new
                            {
                                P.UnidadMedida
                            }).Distinct();
            cboUnidad.DataSource = consulta;
            cboUnidad.ValueMember = "UnidadMedida";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Dia en el que coincide el cliente 4 y el 10 en una compra
            var consulta04 = from B in ventas.Boleta
                           where B.Cliente.CodCliente == "C004"
                           select new { B.Fecha };
            var consulta10 = from B in ventas.Boleta
                             where B.Cliente.CodCliente == "C010"
                             select new { B.Fecha };

            var consulta = consulta04.Intersect(consulta10);
            dgvDatos.DataSource = consulta;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Botelas del cliente 3, excepto las que han sido emitidas por el vendedor 1
            var consultaV01 = from B in ventas.Boleta
                              where B.Vendedor.CodVendedor == "V001"
                              select B;
            var consultaC03 = from B in ventas.Boleta
                              where B.Cliente.CodCliente == "C003"
                              select B;
            var consulta = consultaC03.Except(consultaV01);
            dgvDatos.DataSource = consulta;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Botelas del cliente 4,7 y 10
            var consultaC04 = from B in ventas.Boleta
                              where B.Cliente.CodCliente == "C004"
                              select B;
            var consultaC07 = from B in ventas.Boleta
                              where B.Cliente.CodCliente == "C007"
                              select B;
            var consultaC10 = from B in ventas.Boleta
                              where B.Cliente.CodCliente == "C010"
                              select B;

            var consulta = (consultaC04.Union(consultaC07).Union(consultaC10));
            dgvDatos.DataSource = consulta;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Productos cuyo stock sea mayor a 20 (EXP LANDA)
            var consulta = ventas.Producto.Where(P => P.Stock > 20 && P.Stock < 30);
            dgvDatos.DataSource = consulta;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Bolteas que pertenecen al segundo semestre del 2008
            var consulta = ventas.Boleta.Where(B => B.Fecha.Year == 2008 && B.Fecha.Month >= 7 && B.Fecha.Month <= 12);
            dgvDatos.DataSource = consulta;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Recorrer clases con inner join
            //Clientes con fechas de compra
            var consulta = from C in ventas.Cliente
                           join B in ventas.Boleta on C.CodCliente equals B.CodCliente
                           join D in ventas.Detalle on B.NroBoleta equals D.NroBoleta
                           select new
                           {
                               Datos = C.NombreCompleto(),
                               B.Fecha,
                               D.Producto.Nombre,
                               D.Cantidad,
                               D.PrecioUnitario
                           };
            dgvDatos.DataSource = consulta;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Boletas con el total
            var consulta = from D in ventas.Detalle
                           group D by D.Boleta.NroBoleta into B
                           select new
                           {
                               NroBoleta = B.Key,
                               Total = B.Sum(D => D.Cantidad * D.PrecioUnitario)
                           };
            dgvDatos.DataSource = consulta;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Promedio de productos agrupados por categoria
            var consulta = from P in ventas.Producto
                           group P by P.Categoria.CodCategoria into C
                           select new
                           {
                               CodCategoria = C.Key,
                               PromedioPrecioProducto = C.Average(P => P.Precio)
                           };
            dgvDatos.DataSource = consulta;
        }
    }
}
