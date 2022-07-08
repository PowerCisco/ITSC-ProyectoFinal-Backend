namespace biblioteca.Models;

public class Libro{

    
    public int LibroId {get;set;}
    public string? Titulo {get;set;}
    public int AutorId {get;set;}
    public Autor? Autor {get;set;}

}