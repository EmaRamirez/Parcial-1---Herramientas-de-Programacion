using Parcial1.Models;

namespace Parcial1.ViewModels;

public class IndexViewModel
{
    public IndexViewModel()
    {

    }
    public List<Alumno> ListAlumn { get; set; } = new List<Alumno>();

    public string FilterName { get; set; }


}