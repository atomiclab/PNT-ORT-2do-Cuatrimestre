using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProyectoPNT.Entity;
using MVCProyectoPNT.Service.Implementation;
using Microsoft.Extensions.Logging;

namespace MVCProyectoPNT.Controllers;

public class Archivo3DController : Controller
{
    private readonly Archivo3DService archivo3DService;
    private readonly ILogger<Archivo3DController> logger;
    private readonly IWebHostEnvironment hostingEnvironment;

    public Archivo3DController(Archivo3DService archivo3DService, ILogger<Archivo3DController> logger, IWebHostEnvironment hostingEnvironment)
    {
        this.archivo3DService = archivo3DService;
        this.logger = logger;
        this.hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index()
    {
        var archivos = archivo3DService.GetAll();
        return View(archivos);
    }

    public IActionResult Create()
    {
        logger.LogInformation("Entering Create GET method.");
        var usuarios = archivo3DService.GetUsuarios()
            .Select(u => new { u.Id, u.Email })
            .ToList();
        var repositorios = archivo3DService.GetAllRepositorios()
            .OrderBy(r => r.Nombre)
            .ToList();
        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Email");
        ViewBag.Repositorios = new SelectList(repositorios, "Id", "Nombre");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Archivo3D archivo3D, IFormFile Foto, IFormFile Documento)
    {
        logger.LogInformation("Entering Create POST method.");
        try
        {
            // STL u OBJ solamente
            var allowedExtensions = new[] { ".stl", ".obj" };

            if (Documento != null)
            {
                var extension = Path.GetExtension(Documento.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Documento", "Solo se permiten archivos STL o OBJ.");
                    return View(archivo3D);
                }
            }

            var uploadsPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            if (Foto != null)
            {
                var fotoFileName = Path.GetFileName(Foto.FileName);
                var fotoPath = Path.Combine(uploadsPath, fotoFileName);
                using (var stream = new FileStream(fotoPath, FileMode.Create))
                {
                    await Foto.CopyToAsync(stream);
                }
                archivo3D.FotoRuta = Path.Combine("uploads", fotoFileName);
            }

            if (Documento != null)
            {
                var documentoFileName = Path.GetFileName(Documento.FileName);
                var documentoPath = Path.Combine(uploadsPath, documentoFileName);
                using (var stream = new FileStream(documentoPath, FileMode.Create))
                {
                    await Documento.CopyToAsync(stream);
                }
                archivo3D.DocumentoRuta = Path.Combine("uploads", documentoFileName);
            }

            archivo3D.Usuario = archivo3DService.GetUsuarioById(archivo3D.UsuarioId);
            archivo3D.RepositorioArchivos = archivo3DService.GetRepositorioArchivosById(archivo3D.RepositorioArchivosId);

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

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo == null)
        {
            return NotFound();
        }
        return View(archivo);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Archivo3D updatedArchivo, IFormFile Foto, IFormFile Documento)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo == null)
        {
            return NotFound();
        }

        
            var uploadsPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            if (Foto != null)
            {
                var fotoFileName = Path.GetFileName(Foto.FileName);
                var fotoPath = Path.Combine(uploadsPath, fotoFileName);
                using (var stream = new FileStream(fotoPath, FileMode.Create))
                {
                    await Foto.CopyToAsync(stream);
                }
                archivo.FotoRuta = Path.Combine("uploads", fotoFileName);
            }

            if (Documento != null)
            {
                var documentoFileName = Path.GetFileName(Documento.FileName);
                var documentoPath = Path.Combine(uploadsPath, documentoFileName);
                using (var stream = new FileStream(documentoPath, FileMode.Create))
                {
                    await Documento.CopyToAsync(stream);
                }
                archivo.DocumentoRuta = Path.Combine("uploads", documentoFileName);
            }

            archivo.Nombre = updatedArchivo.Nombre;
            archivo.Descripcion = updatedArchivo.Descripcion;
            archivo.Formato = updatedArchivo.Formato;
            archivo.Tamano = updatedArchivo.Tamano;
            archivo.Ruta = updatedArchivo.Ruta;

            archivo3DService.update(archivo);
            return RedirectToAction(nameof(Index));
        
    }

    [HttpGet]
    [Route("Archivo3D/Delete/{id}")]
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
    [Route("Archivo3D/DeleteConfirmed/{id}")]
    public IActionResult DeleteConfirmed(int id)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo != null)
        {
            archivo3DService.delete(archivo);
            archivo3DService.SaveChanges();
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

    public bool Save(Archivo3D archivo3D)
    {
        return archivo3DService.save(archivo3D);
    }

    public IActionResult Delete(Archivo3D archivo3D)
    {
        archivo3DService.delete(archivo3D);
        archivo3DService.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public bool DeleteById(int id)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo != null)
        {
            archivo3DService.delete(archivo);
            archivo3DService.SaveChanges(); // Ensure changes are committed to the database
            return true;
        }
        return false;
    }

    public bool Update(Archivo3D archivo3D)
    {
        return archivo3DService.update(archivo3D);
    }

    [HttpGet]
    public IActionResult Search(string query)
    {
        var archivos = archivo3DService.SearchByName(query);
        return View("Index", archivos);
    }
}