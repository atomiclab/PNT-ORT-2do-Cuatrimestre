using Microsoft.AspNetCore.Mvc;
using MVCProyectoPNT.Entity;
using MVCProyectoPNT.Service.Implementation;

namespace MVCProyectoPNT.Controllers;

public class UserController : Controller
{
    private readonly UserService userService;
    private readonly Archivo3DService archivo3DService;
    private readonly ILogger<UserController> logger;

    public UserController(UserService userService, Archivo3DService archivo3DService, ILogger<UserController> logger)
    {
        this.userService = userService;
        this.archivo3DService = archivo3DService;
        this.logger = logger;
    }
    public IActionResult Index()
    {
        var usuarios = userService.GetAllUsuarios();
        return View(usuarios);
    }
    //Version NO HTTPPost
   public bool Registrarse(Usuario usuario)
    {
        return userService.save(usuario);
    }
   //Version HTTPPost
   
   public IActionResult Create()
   {
       return View();
   }
   [HttpPost]
   public IActionResult Create(Usuario usuario)
   {
       logger.LogInformation("Iniciando la creación de un nuevo usuario.");

       if (ModelState.IsValid)
       {
           logger.LogInformation("El modelo de usuario es válido.");
           bool result = userService.save(usuario);

           if (result)
           {
               logger.LogInformation("Usuario creado exitosamente con ID: {Id}", usuario.Id);
               return RedirectToAction(nameof(Index));
           }
           else
           {
               logger.LogError("Error al guardar el usuario en la base de datos.");
           }
       }
       else
       {
           logger.LogWarning("El modelo de usuario no es válido. Información recibida: Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Password: {Password}", 
               usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Password);
       }

       return View(usuario);
   }
   //Version HTTPPost con ID
   public IActionResult Edit(int id)
   {
       var usuario = userService.GetById(id);
       if (usuario == null)
       {
           return NotFound();
       }
       return View(usuario);
   }
   //Version HTTPPost con ID
   [HttpPost]
public IActionResult Edit(Usuario usuario)
{
    // Remove the Password field from model state validation
    ModelState.Remove("Password");

    if (ModelState.IsValid)
    {
        var existingUser = userService.GetById(usuario.Id);
        if (existingUser != null)
        {
            logger.LogInformation("Iniciando la edición del usuario con ID: {Id}", usuario.Id);

            existingUser.Nombre = usuario.Nombre;
            existingUser.Apellido = usuario.Apellido;
            existingUser.Email = usuario.Email;

            // No actualizar la contraseña si no se proporciona
            if (!string.IsNullOrEmpty(usuario.Password))
            {
                existingUser.Password = usuario.Password;
                logger.LogInformation("Contraseña actualizada para el usuario con ID: {Id}", usuario.Id);
            }
            else
            {
                logger.LogInformation("Contraseña no proporcionada, no se actualizará para el usuario con ID: {Id}", usuario.Id);
            }

            bool result = userService.update(existingUser);
            if (result)
            {
                logger.LogInformation("Usuario con ID: {Id} actualizado exitosamente.", usuario.Id);
            }
            else
            {
                logger.LogError("Error al actualizar el usuario con ID: {Id}.", usuario.Id);
            }

            return RedirectToAction(nameof(Index));
        }
        else
        {
            logger.LogWarning("Usuario con ID: {Id} no encontrado.", usuario.Id);
        }
    }
    else
    {
        logger.LogWarning("El modelo de usuario no es válido. Información recibida: Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}",
            usuario.Nombre, usuario.Apellido, usuario.Email);
    }

    return View(usuario);
}
   
  //Version no httpPost del Delete
   /* public bool Delete(Usuario usuario)
    {
        return userService.delete(usuario);
    }
    
    public bool DeleteById(int id)
    {
        var usuario = userService.GetById(id);
        if (usuario != null)
        {
            // Delete associated Archivo3D records
            var archivos = archivo3DService.GetByUsuarioId(id);
            foreach (var archivo in archivos)
            {
                archivo3DService.Delete(archivo);
            }

            // Delete the user
            return userService.DeleteById(id);
        }
        return false;
    }*/
    //Version httpPost del Delete
    
    public IActionResult Delete(int id)
    {
        var usuario = userService.GetById(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

   
    [HttpPost, ActionName("DeleteById")]
    public IActionResult DeleteById(int id)
    {
        var usuario = userService.GetById(id);
        if (usuario != null)
        {
            logger.LogInformation("Iniciando la eliminación del usuario con ID: {Id}", id);

            var archivos = archivo3DService.GetByUsuarioId(id);
            foreach (var archivo in archivos)
            {
                archivo3DService.Delete(archivo);
                logger.LogInformation("Archivo3D con ID: {ArchivoId} eliminado.", archivo.Id);
            }

            bool result = userService.DeleteById(id);
            if (result)
            {
                logger.LogInformation("Usuario con ID: {Id} eliminado exitosamente.", id);
            }
            else
            {
                logger.LogError("Error al eliminar el usuario con ID: {Id}.", id);
            }
        }
        else
        {
            logger.LogWarning("Usuario con ID: {Id} no encontrado.", id);
        }
        return RedirectToAction(nameof(Index));
    }
    
   //Version no httpPost del Update
    public bool Update(Usuario usuario)
    {
        return userService.update(usuario);
    }
    //Version httpPost para details
    public IActionResult Details(int id)
    {
        var usuario = userService.GetById(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    
    public bool IniciarSesion(String email, String password)
    {
        return true;
    }

    public bool CerrarSesion()
    {
        return true;
    }
    public List<Usuario> GetAllUsuarios()
    {
        return userService.GetAllUsuarios();
    }
}