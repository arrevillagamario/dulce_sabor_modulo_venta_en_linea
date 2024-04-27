using dulce_sabor_modulo_venta_en_linea.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class ComboController : Controller
    {
        private readonly IServicioGeneral servicioGeneral;

        public ComboController(IServicioGeneral servicioGeneral)
        {
            this.servicioGeneral = servicioGeneral;
        }
        public async Task<IActionResult> Index()
        {
            var combo = await servicioGeneral.ObtenerCombos();
            return View(combo);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarACarrito(int idProducto)
        {
            await servicioGeneral.AgregarComboDetalle(idProducto);
            return View();
        }
    }
}
