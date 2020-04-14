using System;

namespace Entity
{
    public class Cliente
    {
        public string Identificacion {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public double CapitalInicial {get;set;}
        public double TasaInteres {get;set;}
        public double Tiempocredito {get;set;}
        public double Totalpagar {get;set;}

        public void CalcularCredito(){
            public double porcentaje =TasaInteres/100;
            public double suma = 1+porcentaje;
            public double Interes = Math.pow(suma,Tiempocredito);
            this.Totalpagar=this.CapitalInicial*Interes;
        }

    }
}
