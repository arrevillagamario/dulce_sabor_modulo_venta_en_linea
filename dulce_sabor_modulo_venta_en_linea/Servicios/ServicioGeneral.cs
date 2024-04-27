using dulce_sabor_modulo_venta_en_linea.Models;
using Microsoft.EntityFrameworkCore;

namespace dulce_sabor_modulo_venta_en_linea.Servicios
{

    public interface IServicioGeneral
    {
        Task<IEnumerable<Combo>> ObtenerCombos();
        Task<IEnumerable<Plato>> ObtenerPlatos();
        Task<IEnumerable<Promocione>> ObtenerPromociones();
    }
    public class ServicioGeneral : IServicioGeneral
    {
        private readonly DulceSaborContext _context;

        public ServicioGeneral(DulceSaborContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plato>> ObtenerPlatos()
        {
            var platos = await _context.Platos.ToListAsync();

            return platos;
        }

        public async Task<IEnumerable<Combo>> ObtenerCombos()
        {
            var combos = await _context.Combos.ToListAsync();

            return combos;
        }

        public async Task<IEnumerable<Promocione>> ObtenerPromociones()
        {
            var promos = await _context.Promociones.ToListAsync();

            return promos;
        }
    }
}
