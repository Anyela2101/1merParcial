using System;
using Entity;
using Datos;

namespace Logica
{
    public class ClienteService
    {
        private readonly connectionManager _conexion;
        private readonly ClienteRepository _repositorio;

        public ClienteService(string Connectionstrings){
            _conexion = new connectionManager(Connectionstrings);
            _repositorio = new PacienteRepository(_conexion);
        }

        public GuardarClienteResponse Guardar(Cliente cliente){
            try{
                _conexion.open();
                _repositorio.Guardar(cliente);
                _conexion.close();
                return new GuardarPacienteResponse(cliente);
            }catch(Exception e){
                return new GuardarPacienteResponse($"Error de la aplicacion: {e.Message}");
            }finally{
                _conexion.close();
            }
        }

        public class GuardarClienteResponse{
            public GuardarClienteResponse(Cliente cliente){
                Error = false;
                Paciente = paciente;
            }

            public GuardarClienteResponse(string mensaje){
                Error=true;
                Mensaje= mensaje; 
            }

            public bool Error {get;set;}
            public string Mensaje {get;set;}
            public Cliente cliente {get;set;}
        }

        public List<Cliente>ConsultarTodos(){
            _conexion.open();
            List<Cliente> clientes =_repositorio.ConsultarTodos();
            _conexion.close();
            return clientes;
        }

    }
}
