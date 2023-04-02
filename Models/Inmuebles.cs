
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inmobiliaria.Models;



public class Inmuebles
{   
    [Display(Name="codigo")]
    public int Id { get; set; }
    public String ? Tipo { get ; set;}
    public String ? Direccion { get ; set;}
    public String ? Uso { get ; set;}
    public int Cantidad_Ambientes { get ; set;}
    public int Superficie { get ; set;}
    public Double Latitud { get ; set;}
    public Double Longitud { get ; set;}

    public int IdPropietadio{get ; set;}
    

    
    
   




    public Inmuebles(){
     


    }
}
