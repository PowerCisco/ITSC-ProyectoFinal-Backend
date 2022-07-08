using Microsoft.EntityFrameworkCore;
using biblioteca.Models;

namespace biblioteca.Data;

public class BibliotecaContext : DbContext
{
    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
    : base(options)
    {
    }

}