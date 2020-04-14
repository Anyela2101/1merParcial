using Entity;

namespace Servicreditos.Models
{
    public class ClienteModel
    {
        public class ClienteInputModel{
            public string Identificacion {get;set;}
            public string Nombres {get;set;}
            public string Apellidos {get;set;}
            public double CapitalInicial {get;set;}
            public double TasaInteres {get;set;}
            public number Tiempocredito {get;set;}
            public double Totalpagar {get;set;}

        }

        public class ClienteViewModel: ClienteInputModel{
            public ClienteViewModel(){

            }

            public ClienteViewModel(Cliente cliente){
                Identificacion=cliente.Identificacion;
                Nombres = cliente.Nombres;
                Apellidos =cliente.Apellidos;
                CapitalInicial = cliente.CapitalInicial;
                TasaInteres =cliente.TasaInteres;
                Tiempocredito = cliente.Tiempocredito;
                Totalpagar = cliente.Totalpagar;
            }
        }
    }
}