using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using MVCProyectoPNT.Entity;
using MVCProyectoPNT.Service.Implementation;
using Microsoft.Extensions.Logging;

namespace MVCProyectoPNT.Controllers;

public class Archivo3DController : Controller
{
    private readonly Archivo3DService archivo3DService;
    private readonly ILogger<Archivo3DController> logger;

    public Archivo3DController(Archivo3DService archivo3DService, ILogger<Archivo3DController> logger)
    {
        this.archivo3DService = archivo3DService;
        this.logger = logger;
    }

    // Métodos con la vista
    public IActionResult Index()
    {
        var archivos = archivo3DService.GetAll();
        return View(archivos);
    }

    public IActionResult Create()
    {
        logger.LogInformation("Entering Create GET method.");
        var usuarios = archivo3DService.GetUsuarios(); 
        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Id"); 
        return View();
    }

    [HttpPost]
    public IActionResult Create(Archivo3D archivo3D)
    {
        logger.LogInformation("Entering Create POST method.");
        try
        {
            archivo3D.Usuario = archivo3DService.GetUsuarioById(archivo3D.UsuarioId);

            archivo3D.RepositorioArchivos =
                archivo3DService.GetRepositorioArchivosById(archivo3D.RepositorioArchivosId);


            logger.LogInformation("Model state is valid. Adding archivo3D to service.");
            archivo3DService.save(archivo3D);
            logger.LogInformation("Archivo3D saved successfully.");
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating Archivo3D.");
            ModelState.AddModelError(string.Empty, "An error occurred while creating the archivo. Please try again.");
        } 
        return View(archivo3D);
}
    public IActionResult Edit(int id)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo == null)
        {
            return NotFound();
        }
        return View((object)archivo); // Correcta forma de llamar al view para evitar ambigüedad
    }

    [HttpPost]
    public IActionResult Edit(Archivo3D archivo3D)
    {
        if (ModelState.IsValid)
        {
            archivo3DService.update(archivo3D);
            return RedirectToAction(nameof(Index));
        }
        return View(archivo3D);
    }

    public IActionResult Delete(int id)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo == null)
        {
            return NotFound();
        }
        return View(archivo);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo != null)
        {
            archivo3DService.delete(archivo);
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        try
        {
            var archivo = archivo3DService.GetById(id);
            if (archivo == null)
            {
                return NotFound();
            }
            
            archivo.Usuario = archivo3DService.GetUsuarioById(archivo.UsuarioId);

            return View(archivo);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ocurrio un error al recibir los detalles de un Archivo3D.");
            return StatusCode(500, "Internal server error");
        }
    }

    // Métodos antes de implementar la vista
    public bool Save(Archivo3D archivo3D)
    {
        return archivo3DService.save(archivo3D);
    }

    public bool Delete(Archivo3D archivo3D)
    {
        return archivo3DService.delete(archivo3D);
    }

    public bool DeleteById(int id)
    {
        return archivo3DService.deleteById(id);
    }

    public bool Update(Archivo3D archivo3D)
    {
        return archivo3DService.update(archivo3D);
    }
    
}
