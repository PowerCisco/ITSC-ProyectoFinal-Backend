using System.Text.Json.Serialization;

namespace ITSC_Proyecto_Final.Models;


public class Medico
{
    public int MedicoId { get; set; }
    public string? PNombre { get; set; }
    public string? SNombre { get; set; }
    public string? PApellido { get; set; }
    public string? SApellido { get; set; }
    public string? Especialidad { get; set; }
    public string? Email { get; set; }

    [JsonIgnore]
    public List<Atencion>? Atenciones { get; set; }
}