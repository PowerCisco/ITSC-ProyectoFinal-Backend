using biblioteca.Models;
using biblioteca.Data;
using Microsoft.EntityFrameworkCore;

namespace biblioteca.Services;

public class LibroService
{

    private readonly LibroContext _context;

    public LibroService(LibroContext context)
    {
        _context = context;
    }

    public IEnumerable<Libro> GetAll()
    {

        return _context.Libros
        .AsNoTracking()
        .ToList();
    }

    public Libro? GetById(int id){
        return _context.Libros
        .AsNoTracking()
        .SingleOrDefault(l => l.Id == id);
    }


}