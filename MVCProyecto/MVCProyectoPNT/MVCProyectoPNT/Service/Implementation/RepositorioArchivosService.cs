using MVCProyectoPNT.Context;
using MVCProyectoPNT.Entity;

namespace MVCProyectoPNT.Service.Implementation;

public class RepositorioArchivosService
{
    private readonly AppDbContext context;

    public RepositorioArchivosService(AppDbContext context)
    {
        this.context = context;
    }

    public List<RepositorioArchivos> GetAll()
    {
        return context.RepositorioArchivos.ToList();
    }

    public RepositorioArchivos GetById(int id)
    {
        return context.RepositorioArchivos.FirstOrDefault(r => r.Id == id);
    }

    public void Create(RepositorioArchivos repositorio)
    {
        context.RepositorioArchivos.Add(repositorio);
        context.SaveChanges();
    }

    public void Update(RepositorioArchivos repositorio)
    {
        context.RepositorioArchivos.Update(repositorio);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var repositorio = GetById(id);
        if (repositorio != null)
        {
            context.RepositorioArchivos.Remove(repositorio);
            context.SaveChanges();
        }
    }
    public bool ExistsByName(string nombre)
    {
        return context.RepositorioArchivos.Any(r => r.Nombre == nombre);
    }
}