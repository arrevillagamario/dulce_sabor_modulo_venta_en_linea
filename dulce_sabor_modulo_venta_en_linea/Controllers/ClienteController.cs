using dulce_sabor_modulo_venta_en_linea.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dulce_sabor_modulo_venta_en_linea.Controllers
{
    public class ClienteController : Controller
    {
        private readonly UserManager<Cliente> _userManager;
        private readonly SignInManager<Cliente> _signIn;

        public ClienteController(UserManager<Cliente> userManager, SignInManager<Cliente> signIn)
        {
            _userManager = userManager;
            _signIn = signIn;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var resultado = await _signIn.PasswordSignInAsync(model.Telefono, model.Contraseña, model.Recuerdame, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Plato");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o password incorrecto.");
                return View(model);
            }
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

            Cliente cliente = new ()
            {
                Nombre = model.nombre,
                Apellido = model.apellido,
                Direccion = model.direccion,
                Telefono = model.telefono
            };

            var resultado = await _userManager.CreateAsync(cliente, password: model.contraseña);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Plato");
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

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
