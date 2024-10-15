using Microsoft.AspNetCore.Mvc;
using MVCProyectoPNT.Entity;
using MVCProyectoPNT.Service.Implementation;

namespace MVCProyectoPNT.Controllers;

public class RepositorioArchivosController : Controller
{
    private RepositorioArchivosService repositorioService = new RepositorioArchivosService();

    public List<Archivo3D> BuscarArchivo(string nombre)
    {
        return repositorioService.BuscarArchivo(nombre);
    }

    public bool BorrarArchivoDeLista(int id)
    {
        return repositorioService.BorrarArchivoDeLista(id);
    }

    public List<Archivo3D> ListarArchivos(int usuarioId)
    {
        return repositorioService.ListarArchivos(usuarioId);
    }
}