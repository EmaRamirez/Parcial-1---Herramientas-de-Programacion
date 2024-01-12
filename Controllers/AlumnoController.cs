using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data;
using Parcial1.Models;
using Parcial1.Utils;
using Parcial1.ViewModels;

namespace Parcial1.Controllers;

public class AlumnoController : Controller
{
    private readonly ApliContext _context;

    public AlumnoController(ApliContext context)
    {
        this._context = context;
    }

    public IActionResult Index(string FilterName)
    {
        var query = _context.Alumnos.Include(x => x.carrera).ToList();

        if (!string.IsNullOrEmpty(FilterName))
        {
            query = query.Where(x => (x.Name.ToUpper()).Contains(FilterName.ToUpper())).ToList();
        }
        var viewModel = new IndexViewModel();
        viewModel.ListAlumn = query;


        return View(viewModel);
    }

    public IActionResult Create()
    {
        ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Alumno value)
    {
        value.carrera = _context.Carreras.First(x => x.CarreraId == value.CarreraId);
        ModelState.Remove("Carrera");
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }

        _context.Alumnos.Add(value);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var borrar = _context.Alumnos.FirstOrDefault(x => x.Id == id);

        _context.Alumnos.Remove(borrar);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }


    public IActionResult Details(int id)
    {
        var detail = _context.Alumnos.Include(x => x.carrera).First(x => x.Id == id);
        var DetailModel = new DetailViewModel(detail);


        return View(DetailModel);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var detail = _context.Alumnos.Include(x => x.carrera).First(x => x.Id == id);

        var EditModel = new EditViewModel();
        EditModel.alumno = detail;
        EditModel.carreras = new SelectList(_context.Carreras, "CarreraId", "Name");

        return View(EditModel);
    }
    [HttpPost]
    public IActionResult Edit(UpdateViewModel obj)
    {
        obj.alumno.carrera = _context.Carreras.First(x => x.CarreraId == obj.alumno.CarreraId);

        ModelState.Remove("alumno.carrera");
        

        if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit");
        }
        var borrar = _context.Alumnos.First(x => x.Id == obj.alumno.Id);
        _context.Alumnos.Remove(borrar);
        _context.Alumnos.Add(obj.alumno);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}