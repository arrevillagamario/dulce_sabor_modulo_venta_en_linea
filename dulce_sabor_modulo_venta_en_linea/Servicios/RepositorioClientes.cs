using dulce_sabor_modulo_venta_en_linea.Models;
using Microsoft.EntityFrameworkCore;

namespace dulce_sabor_modulo_venta_en_linea.Servicios
{
    public interface IRepositorioClientes
    {
        Task<Cliente> BuscarClientePorNumeroTel(string numero);
        Task<int> CrearCliente(Cliente cliente);
    }
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly DulceSaborContext _context;

        public RepositorioClientes(DulceSaborContext context)
        {
           _context = context;
        }



        public async Task<int> CrearCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentException("Error al recibir los datos del usuario");
            }

            DateOnly hoy = DateOnly.FromDateTime(dateTime: DateTime.Now);

            Cliente clienteNuevo = new Cliente()
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                Contraseña = cliente.Contraseña,
                FechaCreacion = hoy
            };

            await _context.AddAsync(clienteNuevo);
            await _context.SaveChangesAsync();

            int Id = cliente.ClienteId;

            return Id;

        }

        public async Task<Cliente> BuscarClientePorNumeroTel(string numero)
        {
            if (numero == null)
            {
                throw new ArgumentException("Error al enviar el numero de telefono");
            }

            var cliente = await _context.Clientes.Where(c => c.Telefono == numero).
                SingleOrDefaultAsync();

            return cliente;
        }
    }
}
