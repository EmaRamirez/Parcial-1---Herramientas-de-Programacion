using Microsoft.AspNetCore.Mvc.Rendering;
using Parcial1.Models;

namespace Parcial1.ViewModels;

public class EditViewModel
{
    public Alumno alumno { get; set; }

    public SelectList? carreras { get; set; }


}