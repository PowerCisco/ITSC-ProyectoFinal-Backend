using Microsoft.EntityFrameworkCore;
using ITSC_Proyecto_Final.Models;

namespace ITSC_Proyecto_Final.Data;

public class ITSC_Proyecto_FinalContext : DbContext
{
    //LOGIN
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<Permiso> Permisos => Set<Permiso>();
    public DbSet<Modulo> Modulos => Set<Modulo>();
    public DbSet<Operacion> Operaciones => Set<Operacion>();

    //FUNCIONALIDADES
    public DbSet<Atencion> Atenciones => Set<Atencion>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();

    public ITSC_Proyecto_FinalContext(DbContextOptions<ITSC_Proyecto_FinalContext> options)
    : base(options)
    {
    }

}