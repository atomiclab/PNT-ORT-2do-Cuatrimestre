using MVCProyectoPNT.Context;
using MVCProyectoPNT.Entity;

namespace MVCProyectoPNT.Service.Implementation;

public class UserService
{
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
    public Usuario GetById(int id)
    {
        return context.Usuarios.FirstOrDefault(u => u.Id == id);
    }

    public bool DeleteById(int id)
    {
        var usuario = GetById(id);
        if (usuario != null)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return true;
        }
        return false;
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
    
    public List<Usuario> GetAllUsuarios()
    {
        return context.Usuarios.ToList();
    }
}