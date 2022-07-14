using System.Text.Json.Serialization;

namespace biblioteca.Models;


public class Medico
{
    public int MedicoId { get; set; }
    public string? PNombre { get; set; }
    public string? SNombre { get; set; }
    public string? PApellido { get; set; }
    public string? SApellido { get; set; }
    public string? Especialidad { get; set; }

    [JsonIgnore]
    public List<Atencion>? Atenciones { get; set; }
}