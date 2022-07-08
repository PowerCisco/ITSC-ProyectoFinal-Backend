using System.Text.Json.Serialization;
namespace biblioteca.Models;


public class Paciente{

    
    public int PacienteId {get;set;}
    public DateTime FechaNacimiento {get;set;}
    public string? Nombre {get;set;}
    public string? Apellido{get;set;}

}