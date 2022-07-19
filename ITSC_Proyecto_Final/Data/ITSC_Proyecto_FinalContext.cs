using Microsoft.EntityFrameworkCore;
using ITSC_Proyecto_Final.Models;

namespace ITSC_Proyecto_Final.Data;

public class ITSC_Proyecto_FinalContext : DbContext
{
    public DbSet<Atencion> Atenciones => Set<Atencion>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public ITSC_Proyecto_FinalContext(DbContextOptions<ITSC_Proyecto_FinalContext> options)
    : base(options)
    {
    }

}