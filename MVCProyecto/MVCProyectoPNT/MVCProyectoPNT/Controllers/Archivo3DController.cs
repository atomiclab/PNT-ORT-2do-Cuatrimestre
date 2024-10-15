using Microsoft.AspNetCore.Mvc;
using MVCProyectoPNT.Entity;
using MVCProyectoPNT.Service.Implementation;

namespace MVCProyectoPNT.Controllers;

public class Archivo3DController : Controller
{
    Archivo3DService archivo3DService = new Archivo3DService();
    
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