using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProyectoPNT.Entity;
using MVCProyectoPNT.Service.Implementation;
using Microsoft.Extensions.Logging;

namespace MVCProyectoPNT.Controllers;

/// Controlador para gestionar operaciones CRUD relacionadas con la entidad Archivo3D.

public class Archivo3DController : Controller
{
    private readonly Archivo3DService archivo3DService;
    private readonly ILogger<Archivo3DController> logger;
    private readonly IWebHostEnvironment hostingEnvironment;
    /// Constructor para inicializar dependencias del controlador.

    public Archivo3DController(Archivo3DService archivo3DService, ILogger<Archivo3DController> logger, IWebHostEnvironment hostingEnvironment)
    {
        this.archivo3DService = archivo3DService;
        this.logger = logger;
        this.hostingEnvironment = hostingEnvironment;
    }
    /// Acción para mostrar una lista de todos los archivos 3D disponibles.
    /// <returns>Vista con la lista de archivos 3D.</returns>

    public IActionResult Index()
    {
        var archivos = archivo3DService.GetAll();
        return View(archivos);
    }
    /// Acción para mostrar el formulario de creación de un nuevo archivo 3D.
    /// <returns>Vista para crear un nuevo archivo 3D.</returns>
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
    /// Acción para manejar la creación de un nuevo archivo 3D a través de un formulario.
    /// <returns>Redirecciona a Index o muestra la vista de error.</returns>

    [HttpPost]
    public async Task<IActionResult> Create(Archivo3D archivo3D, IFormFile Foto, IFormFile Documento)
    {
        logger.LogInformation("Entering Create POST method.");
        try
        {
            // STL u OBJ solamente
            // Validar extensiones permitidas para el archivo 3D
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
            // Configurar rutas de subida de archivos
            var uploadsPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }
            // Guardar la imagen si existe
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
            // Guardar el documento si existe
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
    /// Acción para mostrar el formulario de edición de un archivo 3D existente.
    /// <returns>Vista para editar un archivo 3D.</returns>

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
    /// Acción para manejar la edición de un archivo 3D existente.
    /// <returns>Redirecciona a Index o muestra la vista de error.</returns>

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Archivo3D updatedArchivo, IFormFile Foto, IFormFile Documento)
    {
        var archivo = archivo3DService.GetById(id);
        if (archivo == null)
        {
            return NotFound();
        }
        // Configuración de rutas y guardado similar a Create
            var uploadsPath = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }
            // Guardar la imagen si existe

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
            // Guardar el documento si existe

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
            // Actualizar propiedades del archivo

            archivo.Nombre = updatedArchivo.Nombre;
            archivo.Descripcion = updatedArchivo.Descripcion;
            archivo.Formato = updatedArchivo.Formato;
            archivo.Tamano = updatedArchivo.Tamano;
            archivo.Ruta = updatedArchivo.Ruta;

            archivo3DService.update(archivo);
            return RedirectToAction(nameof(Index));
        
    }
    /// Acción para mostrar la vista de confirmación de eliminación de un archivo 3D.
    /// <returns>Vista de confirmación de eliminación.</returns>

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
    /// Acción para eliminar un archivo 3D confirmado.
    /// <returns>Redirecciona a Index.</returns>

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
    /// Acción para mostrar los detalles de un archivo 3D específico.
    /// <returns>Vista con los detalles del archivo.</returns>

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
            archivo3DService.SaveChanges(); // Guardar cambios
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