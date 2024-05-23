using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionWindows.Mantenimiento
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            ClienteBL clienteBL = new ClienteBL();
            dgvCliente.DataSource = clienteBL.Listar();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar un cliente a la base de datos
            Cliente cliente = new Cliente();
            ClienteBL clienteBL = new ClienteBL();
            cliente.CodCliente = txtCodCliente.Text.Trim();
            cliente.Apellidos = txtApellidos.Text.Trim();
            cliente.Nombres = txtNombres.Text.Trim();
            cliente.Direccion = txtDireccion.Text.Trim();

            if (clienteBL.Agregar(cliente))
            {
                MessageBox.Show("Datos Agregados Correctamente");
                Listar();
            }
            else
                MessageBox.Show("Error al Agregar Cliente");
        }
    }
}
