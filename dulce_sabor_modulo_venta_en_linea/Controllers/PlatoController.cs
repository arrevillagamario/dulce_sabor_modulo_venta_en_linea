using dulce_sabor_modulo_venta_en_linea.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class PlatoController : Controller
    {
        private readonly IServicioGeneral servicioGeneral;

        public PlatoController(IServicioGeneral servicioGeneral)
        {
            this.servicioGeneral = servicioGeneral;
        }

        public async Task<IActionResult> Index()
        {
            var platos = await servicioGeneral.ObtenerPlatos();

            return View(platos);
        }

        public IActionResult AgregarAcarrito()
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AgregarACarrito(int plato)
        {
            _ = await servicioGeneral.AgregarPlatoDetalle(plato);
            return RedirectToAction("Index");
        }
    }
}
