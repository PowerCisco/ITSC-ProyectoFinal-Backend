using biblioteca.Models;
using biblioteca.Data;
using Microsoft.EntityFrameworkCore;

namespace biblioteca.Services;

public class LibroService
{

    private readonly BibliotecaContext _context;

    public LibroService(BibliotecaContext context)
    {
        _context = context;
    }

    public IEnumerable<Libro> GetAll()
    {

        return _context.Libros
        .AsNoTracking()
        .Include(l => l.Autor)
        .ToList();
    }

    public Libro? GetById(int id)
    {
        
        return _context.Libros
        .AsNoTracking()
        .Include(l => l.Autor)
        .SingleOrDefault(l => l.LibroId == id);
    }

    public Libro Create(Libro newLibro)
    {
        _context.Libros!.Add(newLibro);
        _context.SaveChanges();

        return newLibro;
    }

    public void Update(int id, Libro libro)
    {
        var libroToUpdate = _context.Libros.Find(id);

        if (libroToUpdate is not null)
        {
            libroToUpdate.Titulo = libro.Titulo;

            _context.SaveChanges();
        }

    }

    public void Delete(int id)
    {
        var libroToDelete = _context.Libros.Find(id);

        if (libroToDelete is not null)
        {
            _context.Libros.Remove(libroToDelete);
            _context.SaveChanges();
        }
    }

}