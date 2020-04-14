using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Servicreditos.Models;
using static Servicreditos.Models.ClienteModel;

namespace Servicreditos.Controllers
{[Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteservice;
        public IConfiguration Configuration {get;}

        public ClienteController(IConfiguration configuration){
            Configuration=configuration;
            string ConnectionStrings = Configuration["ConnectionStrings:DefaultConnection"];
            _clienteservice =new ClienteService(ConnectionStrings);
        }

        [HttpPost]
        public ActionResult<ClienteViewModel> Post(ClienteInputModel clienteInput){
            Cliente cliente = Mapear(clienteInput);
            var response = _clienteservice.Guardar(cliente);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Cliente);
        }

        private Cliente Mapear(ClienteInputModel clienteInput){
            var cliente =new Cliiente{
                Identificacion=clienteInput.Identificacion,
                Nombres = clienteInput.Nombres,
                Apellidos =clienteInput.Apellidos,
                CapitalInicial=clienteInput.CapitalInicial,
                TasaInteres = clienteInput.TasaInteres,
                Tiempocredito = clienteInput.Tiempocredito,
                Totalpagar = clienteInput.Totalpagar
            };
            return cliente;
        }

        [HttpGet]
        public IEnumerable <ClienteViewModel> Gets(){
            var clientes = _clienteservice.ConsultarTodos().Select(p=>new PacienteViewModel(p));
            return clientes;
        }
    }

}