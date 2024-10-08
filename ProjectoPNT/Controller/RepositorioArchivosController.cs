using ProjectoPNT.Service.implementation;
using ProyectoPNT.Entity;

namespace ProjectoPNT.Controller
{
    public class RepositorioArchivosController
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
}