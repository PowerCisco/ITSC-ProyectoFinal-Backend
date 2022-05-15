using Microsoft.EntityFrameworkCore;
using biblioteca.Models;

namespace biblioteca.Data;

public class LibroContext : DbContext
{
    public DbSet<Libro> Libros => Set<Libro>();
    public LibroContext(DbContextOptions<LibroContext> options)
    : base(options)
    {
    }

}