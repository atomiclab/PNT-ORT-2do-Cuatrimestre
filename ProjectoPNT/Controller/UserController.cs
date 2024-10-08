using ProjectoPNT.Service.implementation;
using ProyectoPNT.Entity;

namespace ProyectoPNT.Controller;

public class UserController
{
    UserService userService = new UserService();
    Archivo3DService archivo3DService = new Archivo3DService();
    
    public bool Registrarse(Usuario usuario)
    {
        return userService.save(usuario);
    }
    public bool Delete(Usuario usuario)
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
    }
    public bool Update(Usuario usuario)
    {
        return userService.update(usuario);
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