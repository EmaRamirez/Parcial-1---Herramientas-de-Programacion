using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Parcial1.Models;

namespace Parcial1.Controllers;

public class HomeController : Controller
{
 
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

   
}
