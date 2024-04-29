using dulce_sabor_modulo_venta_en_linea.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly IServicioGeneral servicioGeneral;

        public PromocionesController(IServicioGeneral servicioGeneral)
        {
            this.servicioGeneral = servicioGeneral;
        }
        public async Task<IActionResult> Index()
        {
            var promos = await servicioGeneral.ObtenerPromociones(); 

            return View(promos);
        }

        public IActionResult AgregarACarrrito()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AgregarACarrito(int promo)
        {
            await servicioGeneral.AgregarPromoDetalle(promo);
            return RedirectToAction("Index");
        }
    }
}
