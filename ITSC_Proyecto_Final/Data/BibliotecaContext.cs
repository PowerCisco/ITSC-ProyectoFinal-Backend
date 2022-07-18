using Microsoft.EntityFrameworkCore;
using ITSC_Proyecto_Final.Models;

namespace ITSC_Proyecto_Final.Data;

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