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
    }
}
