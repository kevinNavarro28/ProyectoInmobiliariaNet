namespace Inmobiliaria.Models;

public class Contratos

{
    public int id {get ; set;}
    public DateOnly Fecha_Inicio {get ; set;}

    public DateOnly Fecha_Fin {get ; set;}

    public Double Monto {get ; set;}

    public int IdInmueble {get;set;}
    public int IdInquilino{get;set;}



    public Contratos(){
     


    }
}
