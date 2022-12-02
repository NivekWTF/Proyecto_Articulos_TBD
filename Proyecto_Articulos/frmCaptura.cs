using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Articulos
{
    public partial class frmCaptura : Form
    {
        DataTable tabla2;

        public frmCaptura()
        {
            InitializeComponent();
            Clave();
        }

        private void Clave()
        {
            int ClaveArticulo = 0;
            tabla2 = NArticulos.ObtenArticulos();

            ClaveArticulo = Convert.ToInt32(tabla2.Rows.Count) + 1;

            txtClave.Text = Convert.ToString(ClaveArticulo);
        }

        private void frmCaptura_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable data = NArticulos.ObtenArticulos();
                this.dtgVentas.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "ERROR", MessageBoxButtons.OK);
            }

            cmbFamilias.DataSource = NArticulos.ObtenArticulos();
            cmbFamilias.DisplayMember = "Nombre Familia";
            cmbFamilias.ValueMember = "Familia";
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validaTexto (txtClave.Text) &&
                validaTexto(txtNombre.Text) &&
                validaTexto(txtDescripcion.Text)&&
                validaTexto(txtPrecio.Text))
            {
                int clave = Convert.ToInt32(txtClave.Text);
                string NombreArt = txtNombre.Text;
                
                string respuesta = "";

                try
                {
                    //buscar por nombre CAMBIAR
                    respuesta = NArticulos.BuscarNombreArticulo(NombreArt);
                    if (respuesta.Equals("YA EXISTE"))
                    {
                        //AQUI PUEDE USARSE ERRORP
                        MessageBox.Show("Nombre de Articulo duplicado");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                    return;
                }
                string DescripArt = txtDescripcion.Text;
                double Precio = Convert.ToDouble(txtPrecio.Text);
                int FamID = Convert.ToInt32(cmbFamilias.SelectedValue);

                Articulos articulo = new Articulos(clave, NombreArt, DescripArt, Precio, FamID);

                try
                {
                    // Obtener la respuesta del Negocio
                    respuesta = NArticulos.Agregar(articulo);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Articulo agregado");
                        LimpiarCampos();
                        DataTable data = NArticulos.ObtenArticulos();
                        this.dtgVentas.DataSource = data;
                        Clave();
                    }
                    if (respuesta.Equals("YA EXISTE"))
                    {
                        MessageBox.Show("Articulo ya existe");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No puedes dejar en blanco los campos.", "Mensaje",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
}

        private bool validaTexto(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena) || string.IsNullOrEmpty(cadena))
                return false;

            return true;
        }

        private void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            cmbFamilias.SelectedIndex = 0;
            rdbNuevo.Checked = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dtgVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgVentas.CurrentRow.Selected = true;
            txtClave.Text = dtgVentas.Rows[e.RowIndex].Cells["Clave"].Value.ToString();
            txtNombre.Text = dtgVentas.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = dtgVentas.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            txtPrecio.Text = dtgVentas.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            cmbFamilias.SelectedItem= dtgVentas.Rows[e.RowIndex].Cells["Familia"].Value.ToString();
            
        }
    }
}
