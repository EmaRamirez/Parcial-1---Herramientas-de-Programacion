using Parcial1.Models;

namespace Parcial1.ViewModels;

public class CDetailsViewModel
{
    public CDetailsViewModel()
    {

    }
    public CDetailsViewModel(Carrera car, List<string> list)
    {
        this.carrera = car;
        this.alumnos = list;
    }
    public Carrera carrera { get; set; }

    public List<string> alumnos { get; set; }
}