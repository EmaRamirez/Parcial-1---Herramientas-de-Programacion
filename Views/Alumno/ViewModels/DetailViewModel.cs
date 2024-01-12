using Parcial1.Models;

namespace Parcial1.ViewModels;

public class DetailViewModel
{
    public DetailViewModel()
    {

    }
    public DetailViewModel(Alumno alum)
    {
        this.alumno = alum;
    }
    public Alumno alumno { get; set; }

}