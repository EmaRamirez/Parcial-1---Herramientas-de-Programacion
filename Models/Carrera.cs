
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Parcial1.Utils;

namespace Parcial1.Models;

public class Carrera
{

    [Column("Id")]
    [Key]
    public int CarreraId { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Turno")]
    public Turno Turno { get; set; }
    [ForeignKey("CarreraId")]
    public virtual List<Alumno> Alumnos { get; set; } = new List<Alumno>();

}