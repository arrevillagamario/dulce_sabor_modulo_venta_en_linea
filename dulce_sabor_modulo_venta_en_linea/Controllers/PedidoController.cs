using Microsoft.AspNetCore.Mvc;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Historial()
        {
            return View();
        }
    }
}
