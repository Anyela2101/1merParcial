using System;
using System.Data.SqlClient;

namespace Datos
{
    public class ConnectionManager
    {
        internal SqlConnection _conexion;
        public connectionManager (string connectionstring){
            _conexion = new SqlConnection(connectionstring);
        }

        public void open(){
            _conexion.Open();
        }
        public void close(){
            _conexion.Close();
        }
    }
}
