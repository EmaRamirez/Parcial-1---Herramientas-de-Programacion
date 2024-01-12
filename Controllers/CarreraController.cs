
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Parcial1.Data;
using Parcial1.Models;
using Parcial1.Utils;
using Parcial1.ViewModels;

namespace Parcial1.Controllers;

public class CarreraController : Controller
{
    private readonly ApliContext _context;

    public CarreraController(ApliContext context)
    {
        this._context = context;
    }

    public IActionResult Index(string FilterName)
    {
        var listCarrera = _context.Carreras.Include(x => x.Alumnos).ToList();

        if (!string.IsNullOrEmpty(FilterName))
        {
            listCarrera = listCarrera.Where(x => (x.Name.ToUpper()).Contains((FilterName.ToUpper()))).ToList();
        }
        var ViewModels = new CIndexViewModel(listCarrera);


        return View(ViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Carrera obj)
    {
        //obj.Alumnos = _context.Alumnos.Where(x => x.CarreraId == obj.CarreraId).ToList();

        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        _context.Carreras.Add(obj);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        if (id == null)
        {
            return RedirectToAction("index");
        }

        var detais = _context.Carreras.FirstOrDefault(x => x.CarreraId == id);
        var alumnos = from alu in _context.Alumnos
                      where alu.CarreraId == detais.CarreraId
                      select alu.Name + " " + alu.Surname;

        var viewmodel = new CDetailsViewModel(detais, alumnos.ToList());
        return View(viewmodel);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var editar = _context.Carreras.FirstOrDefault(x => x.CarreraId == id);
        var viewmodel = new CEditViewModel();
        viewmodel.carrera = editar;
        return View(viewmodel);
    }
    [HttpPost]
    public IActionResult Edit(CEditViewModel obj)
    {
        
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit");
        }

        var borrar = _context.Carreras.First(x => x.CarreraId == obj.carrera.CarreraId);
        _context.Carreras.Remove(borrar);

        _context.Carreras.Add(obj.carrera);

        _context.SaveChanges();

        return RedirectToAction("Index");

    }
    public IActionResult Delete(int id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }

        var borrar = _context.Carreras.First(x => x.CarreraId == id);
        _context.Carreras.Remove(borrar);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }








}
