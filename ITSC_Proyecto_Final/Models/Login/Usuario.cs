
namespace ITSC_Proyecto_Final.Models;


public class Usuario
{
    public int UsuarioId {get; set;}
    public string PNombre {get; set;}
    public string? SNombre {get; set;}
    public string PApellido {get; set;}
    public string? SApellido {get; set;}
    public string NombreUsuario {get; set;}
    public string Contrasena {get; set;}
    public string Email {get; set;}
    public Rol FkRol {get; set;}

}