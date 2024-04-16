using dulce_sabor_modulo_venta_en_linea.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class ClienteController : Controller
    {
        private readonly UserManager<Cliente> _userManager;

        public ClienteController(UserManager<Cliente> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Crear() 
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Crear(RegistroViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            Cliente cliente = new Cliente()
            {
                Nombre = model.nombre,
                Apellido = model.apellido,
                Direccion = model.direccion,
                Telefono = model.telefono
            };

            var resultado = await _userManager.CreateAsync(cliente, password: model.contraseña);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
