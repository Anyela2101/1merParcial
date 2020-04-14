using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
using System;

namespace Datos
{
    
    public class ClienteteRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Cliente> clientes = new List<Cliente>();
        public ClienteRepository(connectionManager connection){
            _connection = connection._conexion;
        }

        public void Guardar(Cliente cliente){
            using (var command = _connection.CreateCommand()){
                 using (var command = _connection.CreateCommand()){
                command.CommandText = @"Insert Into creditos (Identificacion,Nombres,Apellidos,CapitalInicial,TasaInteres,Tiempocredito,Totalpagar)
                                       values (@Identificacion,@Nombres,@Apellidos,@CapitalInicial,@TasaInteres,@Tiempocredito,@Totalpagar)";
                 command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                 command.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                 command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                 command.Parameters.AddWithValue("@CapitalInicial",cliente.CapitalInicial);
                 command.Parameters.AddWithValue("@TasaInteres", cliente.TasaInteres);
                 command.Parameters.AddWithValue("@Tiempocredito", cliente.Tiempocredito);
                 command.Parameters.AddWithValue("@Totalpagar", cliente.Totalpagar);
                 var filas = command.ExecuteNonQuery();
            }
            }
        }

        public List<clientes> ConsultarTodos(){
            SqlDataReader dataReader;
            List<Cliente> clientes = new List<Cliente>();
            using ( var command = _connection.CreateCommand()){
                command.CommandText ="select *from creditos";
                dataReader = command.ExecuteReader();
                if(dataReader.HasRows){
                    while(dataReader.Read()){
                        Cliente cliente = DatareaderMap(dataReader);
                        clientes.Add(paciente);
                    }
                }
            }
            return clientes;            

        }

        private Cliente DatareaderMap(SqlDataReader dataReader){
           if(!dataReader.HasRows) return null;
            Cliente cliente = new Cliente();
            cliente.Identificacion = (string)dataReader["Identificacion"];
            cliente.Nombres=(string)dataReader["Nombres"];
            cliente.Apellidos=(decimal)dataReader["Apellidos"];
            cliente.CapitalInicial=(decimal)dataReader["CapitalInicial"];
            cliente.TasaInteres=(decimal)dataReader["TasaInteres"];
            cliente.Tiempocredito=(int)dataReader["Tiempocredito"];
            cliente.Totalpagar=(decimal)dataReader["Totalpagar"];
            return cliente;
            
        }
    }
        
    
}