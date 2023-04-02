namespace Inmobiliaria.Models;

public class Pagos
{
    public int NumDePago { get; set; }
    public DateOnly Fecha_Pago { get ; set;}
    public Double Importe { get ; set;}
    
    public int idContrato {get; set;}


    public Pagos(){
     


    }
}
