using dulce_sabor_modulo_venta_en_linea.Models;
using dulce_sabor_modulo_venta_en_linea.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IAutenticacionCliente _autenticacionCliente;
        private readonly IServicioGeneral _servicioGeneral;

        public PedidoController(IAutenticacionCliente autenticacionCliente, IServicioGeneral servicioGeneral)
        {
            _autenticacionCliente = autenticacionCliente;
            _servicioGeneral = servicioGeneral;
        }
        public async Task<IActionResult> Index()
        {
            var productosEnCarrito = await _servicioGeneral.ObtenerDetalleDeVenta();

            
            if (productosEnCarrito == null || productosEnCarrito.Count() == 0)
            {
                
                var carritoVacio = new CarritoViewModel
                {
                    Cliente = await _servicioGeneral.GetCliente(),
                    Detalles = null, 
                    PrecioTotal = 0, 
                };

                return View(carritoVacio);
            }

            
            var totalPrecio = productosEnCarrito.Where(x => true)
                .Select(x => x.Plato?.Precio ?? 0 + x.Combo?.Precio ?? 0 + x.Promo?.Descuento ?? 0)
                .Sum();

            var carrito = new CarritoViewModel
            {
                Cliente = await _servicioGeneral.GetCliente(),
                Detalles = productosEnCarrito,
                PrecioTotal = totalPrecio,
            };

            return View(carrito);
        }

        public IActionResult Historial()
        {
            return View();
        }
    }
}
