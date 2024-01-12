using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Parcial1.Utils;

namespace Parcial1.Models;

public class Alumno
{
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Apellido")]
    public string? Surname { get; set; }
    [Display(Name = "Documento")]
    public int Dni { get; set; }
    [Display(Name = "Nacionalidad")]

    public Nationality Nationality { get; set; }

    [Display(Name = "Carrera")]
    public int CarreraId { get; set; }

    public virtual Carrera carrera { get; set; }
}