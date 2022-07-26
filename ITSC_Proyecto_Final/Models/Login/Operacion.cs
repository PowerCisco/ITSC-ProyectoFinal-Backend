 
 
 namespace ITSC_Proyecto_Final.Models;

 public class Operacion
 {
   public int Id {get; set;}
   public string NombreOperacion {get; set;}
   public Modulo FkModulo {get; set;}
 }