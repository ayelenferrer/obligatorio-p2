using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string nombre, string password)
        {
            Usuario usuario = _sistema.Login(nombre, password);
            HttpContext.Session.SetString("username", nombre);
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "");
            return RedirectToAction("Index");
        }
    }
}
