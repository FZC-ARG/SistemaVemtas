using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; // Driver de SQL Server
using System.Data; //Buffer de memorias
using System.Configuration; // Extraer la cadena de conexion de la CPW (CapaPresentacionWindows)
using CapaEntidad;

namespace CapaNegocio
{
    public class ClienteBL : Interface.ICliente
    {
        //Extraer la cadena de conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TCliente";
                //Llevar la consulta a la base de datos y traer los registros de la tabla
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(Cliente cliente)
        {
            //Aperturar la conexion con la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "insert into Tcliente values(@codCliente,@Apellidos,@Nombres,@Direccion)";
                //Comando para ejecutar la consulta
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //Enviar parametros
                comando.Parameters.AddWithValue("@CodCliente", cliente.CodCliente);
                comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                //Abrir la conexion con la base de datos
                conexion.Open();
                //Ejecutar la consulta
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public DataTable Buscar(string codCliente)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string codCliente)
        {
            throw new NotImplementedException();
        }

        
    }
}
