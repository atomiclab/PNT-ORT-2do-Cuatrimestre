using ProyectoPNT.Context;
using ProyectoPNT.Entity;

namespace ProjectoPNT.Service.implementation;

public class Archivo3DService
{
    private AppDbContext context = new AppDbContext();
    
    public bool save(Archivo3D archivo3D)
    {
        bool estado = false;
        if (archivo3D!=null)
        {
            context.Archivos3D.Add(archivo3D);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
    
    public bool update(Archivo3D archivo3d)
    {
        bool estado = false;
        if (archivo3d!=null)
        {
            context.Archivos3D.Update(archivo3d);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
    public bool deleteById(int id) // borrado por id
    {
        bool estado = false;
        Archivo3D archivo3D = context.Archivos3D.FirstOrDefault(x => x.Id == id);
        if (archivo3D!=null)
        {
            context.Archivos3D.Remove(archivo3D);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }  
        
        
    
    public bool delete(Archivo3D archivo3D)
    {
        bool estado = false;
        if (archivo3D!=null)
        {
            context.Archivos3D.Remove(archivo3D);
            context.SaveChanges();
            estado = true;
        }   
        return estado;
    }
}