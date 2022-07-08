using System.Text.Json.Serialization;
namespace biblioteca.Models;


public class Autor{

    
    public int AutorId {get;set;}
    public string? Nombre {get;set;}
    public string? WebUrl{get;set;}

    [JsonIgnore]
    public List<Libro>? Libros { get; set; }

}