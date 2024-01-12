using Parcial1.Models;

namespace Parcial1.ViewModels;

public class CIndexViewModel
{

    public CIndexViewModel()
    {

    }
    public CIndexViewModel(List<Carrera> carreras)
    {
        this.carreras = carreras;
    }
    public List<Carrera> carreras { get; set; }

    public string FilterName { get; set; }
}