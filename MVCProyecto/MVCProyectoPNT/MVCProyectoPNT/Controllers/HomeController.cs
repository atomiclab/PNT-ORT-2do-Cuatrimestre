using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCProyectoPNT.Models;
using MVCProyectoPNT.Service.Implementation;

namespace MVCProyectoPNT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Archivo3DService archivo3DService;
    public HomeController(Archivo3DService archivo3DService,ILogger<HomeController> logger)
    {
        this.archivo3DService = archivo3DService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var archivos = archivo3DService.GetAll();
        foreach (var archivo in archivos)
        {
            archivo.Usuario = archivo3DService.GetUsuarioById(archivo.UsuarioId);
        }
        return View(archivos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}