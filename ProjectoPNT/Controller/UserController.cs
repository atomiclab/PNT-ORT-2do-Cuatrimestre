using ProyectoPNT.Entity;
using ProyectoPNT.Service.implementation;

namespace ProyectoPNT.Controller;

public class UserController
{
    UserService userService = new UserService();
    
    public bool Registrarse(Usuario usuario)
    {
        return userService.save(usuario);
    }

    public bool IniciarSesion(String email, String password)
    {
        return true;
    }

    public bool CerrarSesion()
    {
       return true;
    }
}