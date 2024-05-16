using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
namespace CapaPresentacionWeb
{
    public partial class wfCliente : System.Web.UI.Page
    {
        private void Listar()
        {
            ClienteBL clienteBL = new ClienteBL();
            GridView1.DataSource = clienteBL.Listar();
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}