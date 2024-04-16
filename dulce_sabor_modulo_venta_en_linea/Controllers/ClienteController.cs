using Microsoft.AspNetCore.Mvc;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Crear() 
        {
            return View();
        }
    }
}
