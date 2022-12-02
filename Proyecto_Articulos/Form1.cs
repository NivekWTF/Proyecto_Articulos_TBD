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
    public partial class frmMenu : Form
    {

       


        public frmMenu()
        {
            InitializeComponent();
            String servidor = txtServidor.Text;
            
            String contraseña = txtPassword.Text;

        }

        public String usuario()
        {
            String usuario = txtUsuario.Text;
            return usuario;
        }

        private void btnCaptura_Click(object sender, EventArgs e)
        {
            frmCaptura capturaVentas = new frmCaptura();
            capturaVentas.ShowDialog();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConsulta consultaVentas = new frmConsulta();
            consultaVentas.ShowDialog();
        }
    }
}
