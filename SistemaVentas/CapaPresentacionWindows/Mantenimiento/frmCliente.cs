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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(txtCodCliente.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese codigo a eliminar");
                txtCodCliente.Focus();
            }
            else
            {
                string codCliente = txtCodCliente.Text.Trim();
                ClienteBL clienteBL = new ClienteBL();
                if (clienteBL.Eliminar(codCliente))
                {
                    MessageBox.Show("Cliente eliminado correctamente");
                    Listar();
                }
                else
                    MessageBox.Show("Error: No se elimino cliente");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCodCliente.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese codigo a Actualizar");
                txtCodCliente.Focus();
            }
            else if (txtApellidos.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese Apellido a Actualizar");
                txtApellidos.Focus();
            }
            else if (txtNombres.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese Nombre a Actualizar");
                txtNombres.Focus();
            }
            else if (txtDireccion.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese Direccion a Actualizar");
                txtDireccion.Focus();
            }
            else
            {
                Cliente cliente = new Cliente();
                ClienteBL clienteBL = new ClienteBL();
                cliente.CodCliente = txtCodCliente.Text.Trim();
                cliente.Apellidos = txtApellidos.Text.Trim();
                cliente.Nombres = txtNombres.Text.Trim();
                cliente.Direccion = txtDireccion.Text.Trim();

                if (clienteBL.Actualizar(cliente))
                {
                    MessageBox.Show("Cliente Actualizado correctamente");
                    Listar();
                    txtCodCliente.Text = "";
                    txtApellidos.Text = "";
                    txtNombres.Text = "";
                    txtDireccion.Text = "";
                    txtCodCliente.Focus();
                }
                else
                    MessageBox.Show("Error: No se Actualizo el cliente");
            }
        }

        private void DgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la fila seleccionada
            DataGridViewRow filaSeleccionada = dgvCliente.Rows[e.RowIndex];

            // Obtener los datos de la fila seleccionada y asignarlos a los cuadros de texto
            txtCodCliente.Text = filaSeleccionada.Cells["CodCliente"].Value.ToString();
            txtApellidos.Text = filaSeleccionada.Cells["Apellidos"].Value.ToString();
            txtNombres.Text = filaSeleccionada.Cells["Nombres"].Value.ToString();
            txtDireccion.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                txtBuscar.Focus();
                MessageBox.Show("Ingrese un Codigo a Buscar: Busqueda exacta");
                Listar();
            }
            else
            {
                ClienteBL clienteBL = new ClienteBL();
                dgvCliente.DataSource = clienteBL.Buscar(txtBuscar.Text.Trim());
                txtBuscar.Focus();
                txtBuscar.Text = "";
            }
        }
    }
}
