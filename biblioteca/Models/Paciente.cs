using System.Text.Json.Serialization;

namespace biblioteca.Models;


public class Paciente
{
    public int PacienteId { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? TipoPaciente { get; set; }

    public string? Carrera { get; set; }
    public string? Matricula { get; set; }
    public string? Departamento { get; set; }
    public string? Telefono { get; set; }
    public string? Sexo { get; set; }

    [JsonIgnore]
    public List<Atencion>? Atenciones { get; set; }

}