using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCProyectoPNT.Models;
using MVCProyectoPNT.Service.Implementation;

namespace MVCProyectoPNT.Controllers;

/// Controlador principal para manejar acciones relacionadas con la página de inicio y funcionalidades generales del sistema.

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Archivo3DService archivo3DService;
    /// Constructor del controlador, inicializando las dependencias requeridas.

    public HomeController(Archivo3DService archivo3DService,ILogger<HomeController> logger)
    {
        this.archivo3DService = archivo3DService;
        _logger = logger;
    }
    /// Acción para mostrar la página principal con una lista agrupada de repositorios que contienen archivos 3D.
    /// <returns>Vista con la lista de repositorios y archivos 3D.</returns>
    public IActionResult Index()
    {
        var archivos = archivo3DService.GetAll();
        foreach (var archivo in archivos)
        {
            archivo.Usuario = archivo3DService.GetUsuarioById(archivo.UsuarioId);
            archivo.RepositorioArchivos = archivo3DService.GetRepositorioArchivosById(archivo.RepositorioArchivosId);
        }

        var repositoriosConArchivos = archivos
            .GroupBy(a => a.RepositorioArchivos)
            .Where(g => g.Any())
            .ToList();

        return View(repositoriosConArchivos);
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
    /// Acción para buscar archivos 3D por nombre.
    /// <returns>Vista con la lista de repositorios que contienen los archivos 3D encontrados.</returns>

    [HttpGet]
    public IActionResult Search(string query)
    {
        var archivos = archivo3DService.SearchByName(query);
        foreach (var archivo in archivos)
        {
            archivo.Usuario = archivo3DService.GetUsuarioById(archivo.UsuarioId); //busco el usuario
            archivo.RepositorioArchivos = archivo3DService.GetRepositorioArchivosById(archivo.RepositorioArchivosId); //busco el repositorio
        }

        var repositoriosConArchivos = archivos 
            .GroupBy(a => a.RepositorioArchivos)// agrupo por repositorio
            .Where(g => g.Any()) //filtro vacios
            .ToList(); //convierto a lista

        return View("Index", repositoriosConArchivos); //devuelvo la vista index con los archivos encontrados
    }
}


//voy con el tp como armamos el proyecto, donde esta UML