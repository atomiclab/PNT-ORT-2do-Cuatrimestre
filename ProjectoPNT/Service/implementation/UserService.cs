using ProyectoPNT.Context;
using ProyectoPNT.Entity;

namespace ProyectoPNT.Service.implementation;

public class UserService
{
   // List<Usuario> usuarios = new List<Usuario>();
   private AppDbContext context = new AppDbContext();
    public bool save(Usuario usuario)
    {
        bool estado = false;
        if (usuario!=null)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
    
    public bool update(Usuario usuario)
    {
        bool estado = false;
        if (usuario!=null)
        {
            context.Usuarios.Update(usuario);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
    public bool deleteById(int id) // borrado por id
    {
        bool estado = false;
        Usuario usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);
        if (usuario!=null)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }  
        
        
    
    public bool delete(Usuario usuario)
    {
        bool estado = false;
        if (usuario!=null)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
    
}