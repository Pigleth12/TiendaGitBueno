using Entidades;
using LogicaProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaGit
{
    public partial class FrmProductos : Form
    {
        private ProductosLogica _productoslogica;
        private string banderaGuardar = "";
        private int idp = 0;
        public FrmProductos()
        {
            InitializeComponent();
            _productoslogica = new ProductosLogica();
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ControlarBotones(true, false, false, true, true);
            ControlCuadros(false);
            LlenarProductos("");
        }
        private void LlenarProductos(string valor)
        {
            dtgProductos.DataSource = _productoslogica.ObtenerProductos(valor);
        }
        private void GuardarProductos()
        {
            Productos nuevosproductos = new Productos();
            nuevosproductos.idProducto = 0;
            nuevosproductos.nombre = txtNombre.Text;
            nuevosproductos.descripcion = rtxtDescripcion.Text;
            nuevosproductos.precio = decimal.Parse(txtPrecio.Text);
         

            var validar = _productoslogica.ValidarProductos(nuevosproductos);
            if (validar.Item1)
            {
                _productoslogica.GuardarProductos(nuevosproductos);
                LlenarProductos("");
                LimpiarCuadros();
                ControlarBotones(true, false, false, true, true);
                ControlCuadros(true);
                
            }
            else
                MessageBox.Show(validar.Item2, "Error de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }
        private void ControlarBotones(Boolean nuevo, Boolean guardar, Boolean cancelar, Boolean cerrar,
            Boolean eliminar)
        {
            btnNuevo.Enabled = nuevo;
            btnAlta.Enabled = guardar;
            btnBaja.Enabled = eliminar;
            btnCancelar.Enabled = cancelar;
            btnCerrar.Enabled = cerrar;
        }
        private void ControlCuadros(Boolean estado)
        {
            txtNombre.Enabled = estado;
            rtxtDescripcion.Enabled = estado;
            txtPrecio.Enabled = estado;
        }
        private void LimpiarCuadros()
        {
            txtNombre.Text = "";
            rtxtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
       private void btnNuevo_Click(object sender, EventArgs e)
        {
            ControlarBotones(false,true,true,false,false);
            ControlCuadros(true);
            txtNombre.Focus();
            banderaGuardar = "guardar";

        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (banderaGuardar == "guardar")
            {
                GuardarProductos();
                LlenarProductos("");
            }
            else if (banderaGuardar == "actualizar")
            {
                actualizarProductos();
                LlenarProductos("");
            }
        }
        private void actualizarProductos()
        {
            Productos nuevosproductos = new Productos();
            nuevosproductos.idProducto = idp;
            nuevosproductos.nombre = txtNombre.Text;
            nuevosproductos.descripcion = rtxtDescripcion.Text;
            nuevosproductos.precio = decimal.Parse(txtPrecio.Text);

            var validar = _productoslogica.ValidarProductos(nuevosproductos);
            if (validar.Item1)
            {
                _productoslogica.ActualizarProductos(nuevosproductos);
                LlenarProductos("");
                LimpiarCuadros();
                ControlarBotones(true, false, false, true, true);
                ControlCuadros(true);
            }
            else
            {
                MessageBox.Show(validar.Item2, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlarBotones(true, false, false, true, true);
            ControlCuadros(false);
            LimpiarCuadros();
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            Eliminar();
            LlenarProductos("");
        }

        public void Eliminar()
        {
            if (MessageBox.Show("¿Desea dar de baja permanentemente el producto seleccionado?", "Baja", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var idproducto = int.Parse(dtgProductos.CurrentRow.Cells["idProducto"].Value.ToString());
                _productoslogica.EliminarProductos(idproducto);
            }
        }
        private void dtgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ControlarBotones(false, true, true, false, false);
            ControlCuadros(true);
            txtNombre.Focus();

            txtNombre.Text = dtgProductos.CurrentRow.Cells["nombre"].Value.ToString();
            rtxtDescripcion.Text = dtgProductos.CurrentRow.Cells["descripcion"].Value.ToString();
            txtPrecio.Text = dtgProductos.CurrentRow.Cells["precio"].Value.ToString();

            idp = int.Parse(dtgProductos.CurrentRow.Cells["idProducto"].Value.ToString());

            banderaGuardar = "actualizar";
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
