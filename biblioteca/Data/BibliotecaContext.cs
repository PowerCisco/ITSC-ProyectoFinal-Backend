using Microsoft.EntityFrameworkCore;
using biblioteca.Models;

namespace biblioteca.Data;

public class BibliotecaContext : DbContext
{
    public DbSet<Atencion> Atenciones => Set<Atencion>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
    : base(options)
    {
    }

}