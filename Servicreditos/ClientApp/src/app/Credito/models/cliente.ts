export class Cliente {
    Identificacion:string;
    Nombres: string;
    Apellidos: string;
    CapitalInicial:number;
    TasaInteres:number;
    Tiempocredito:number;
    Totalpagar:number;

    Calcularvalortotalapagar():void{
        var Porcentaje=this.TasaInteres/100;
        var Suma=1+Porcentaje;
        var Interes=Math.pow(Suma,this.Tiempocredito);
        this.Totalpagar=this.CapitalInicial*Interes;
    }
}

