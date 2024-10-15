using Microsoft.AspNetCore.Mvc;

namespace _8OctMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index() //metodos que estan adentro de un controllador se llaman acciones
        {
            string mensaje = "Hola Mundo";
            
            ViewData["edad"]= 25; //ViewData le podes poner cualquier tipo de dato 
            ViewBag.edad = 55; //ViewBag solo acepta string

            return View("Index",mensaje); // pasar dato por modelo a la vista
        }

    }
}
