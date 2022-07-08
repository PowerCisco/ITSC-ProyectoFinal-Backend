using biblioteca.Models;
using biblioteca.Data;
using Microsoft.EntityFrameworkCore;

namespace biblioteca.Services;

public class AutorService
{

    private readonly BibliotecaContext _context;

    public AutorService(BibliotecaContext context)
    {
        _context = context;
    }

    public IEnumerable<Autor> GetAll()
    {

        return _context.Autores
        .AsNoTracking()
        .Include(a => a.Libros)
        .ToList();
    }

    public Autor? GetById(int id)
    {
        return _context.Autores
        .AsNoTracking()
        .Include(a => a.Libros)
        .SingleOrDefault(l => l.AutorId == id);
    }

    public Autor Create(Autor newAutor)
    {
        _context.Autores!.Add(newAutor);
        _context.SaveChanges();

        return newAutor;
    }

    public void Update(int id, Autor Autor){
        var AutorToUpdate = _context.Autores.Find(id);

        if (AutorToUpdate is not null){
            AutorToUpdate.Nombre = Autor.Nombre;
            AutorToUpdate.WebUrl = Autor.WebUrl;
            
            _context.SaveChanges();
        }

    }

    public void Delete(int id){
        var AutorToDelete = _context.Autores.Find(id);

        if (AutorToDelete is not null){
            _context.Autores.Remove(AutorToDelete);
            _context.SaveChanges();
        }
    }

}