using ITSC_Proyecto_Final.Data;
using Microsoft.EntityFrameworkCore;
using ITSC_Proyecto_Final.Services;


namespace ITSC_Proyecto_Final.Models;


public class Reporte
{

    public string? Fecha { get; set; }
    public string? NombreCompleto { get; set; }
    public int? Edad { get; set; }
    public string? Telefono { get; set; }
    public string? Diagnostico { get; set; }
    public string? Tratamiento { get; set; }
    public string? Medico { get; set; }


}


