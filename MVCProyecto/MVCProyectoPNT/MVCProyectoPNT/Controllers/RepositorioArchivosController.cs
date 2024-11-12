using Microsoft.AspNetCore.Mvc;
using MVCProyectoPNT.Entity;
using MVCProyectoPNT.Service.Implementation;

namespace MVCProyectoPNT.Controllers;

public class RepositorioArchivosController : Controller
{
    private readonly RepositorioArchivosService repositorioService;

    public RepositorioArchivosController(RepositorioArchivosService repositorioService)
    {
        this.repositorioService = repositorioService;
    }

    public IActionResult Index()
    {
        var repositorios = repositorioService.GetAll();
        return View(repositorios);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(RepositorioArchivos repositorio)
    {
        if (repositorioService.ExistsByName(repositorio.Nombre))
        {
            ModelState.AddModelError("Nombre", "El repositorio ya existe.");
        }

        if (ModelState.IsValid)
        {
            repositorioService.Create(repositorio);
            return RedirectToAction(nameof(Index));
        }
        return View(repositorio);
    }

    public IActionResult Edit(int id)
    {
        var repositorio = repositorioService.GetById(id);
        if (repositorio == null)
        {
            return NotFound();
        }
        return View(repositorio);
    }

    [HttpPost]
    public IActionResult Edit(RepositorioArchivos repositorio)
    {
        if (ModelState.IsValid)
        {
            repositorioService.Update(repositorio);
            return RedirectToAction(nameof(Index));
        }
        return View(repositorio);
    }

    public IActionResult Delete(int id)
    {
        var repositorio = repositorioService.GetById(id);
        if (repositorio == null)
        {
            return NotFound();
        }
        return View(repositorio);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        repositorioService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        var repositorio = repositorioService.GetById(id);
        if (repositorio == null)
        {
            return NotFound();
        }
        return View(repositorio);
    }
}