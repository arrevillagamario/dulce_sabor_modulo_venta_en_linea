using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace dulce_sabor_modulo_venta_en_linea.Servicios
{
    public interface IAutenticacionCliente
    {
        int GetClienteId();
    }

    public class AutenticacionCliente : IAutenticacionCliente
    {
        private readonly HttpContext _httpContext;

        public AutenticacionCliente(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext.HttpContext;
        }


       public int GetClienteId()
        {
            if (_httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = _httpContext.User
                        .Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                var id = int.Parse(idClaim.Value);
                return id;
            }
            else
            {
                throw new ApplicationException("El usuario no está autenticado");
            }
        }
    }
}
