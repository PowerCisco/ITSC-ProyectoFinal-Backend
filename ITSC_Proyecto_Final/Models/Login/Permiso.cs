

namespace ITSC_Proyecto_Final.Models;

public class Permiso
{
    public int Id { get; set; }
    public Rol FkRol { get; set; }
    public Modulo FkModulo { get; set; }
}