using ProjectoPNT.Entity;

namespace ProjectoPNT.service;

public class UserService
{
    List<Usuario> usuarios = new List<Usuario>();
    public bool save(Usuario usuario)
    {
        bool estado = false;
        if (usuario!=null)
        {
            usuarios.Add(usuario);
            estado = true;
        }   
        return estado;
    }
    
    public bool delete(Usuario usuario)
    {
        bool estado = false;
        if (usuario!=null)
        {
            usuarios.Remove(usuario);
            estado = true;
        }   
        return estado;
    }
    
}