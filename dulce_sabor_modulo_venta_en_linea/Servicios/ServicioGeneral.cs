﻿using dulce_sabor_modulo_venta_en_linea.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace dulce_sabor_modulo_venta_en_linea.Servicios
{

    public interface IServicioGeneral
    {
        Task<Cliente> GetCliente();
        Task<IEnumerable<Combo>> ObtenerCombos();
        Task<IEnumerable<PedidoDetalle>> ObtenerDetalleDeVenta();
        Task<IEnumerable<Plato>> ObtenerPlatos();
        Task<IEnumerable<Promocione>> ObtenerPromociones();
    }
    public class ServicioGeneral : IServicioGeneral
    {
        private readonly DulceSaborContext _context;
        private readonly IAutenticacionCliente _autenticacion;

        public ServicioGeneral(DulceSaborContext context, IAutenticacionCliente autenticacion)
        {
            _context = context;
            _autenticacion = autenticacion;
        }

        public static DateTime Hoy()
        {
            var hoy = DateTime.Now;

            return hoy;
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


        public async Task<Cliente> GetCliente()
        {
            int clienteId =  _autenticacion.GetClienteId();

            var cliente = await _context.Clientes.FindAsync(clienteId);

            return cliente;

        }


        public async Task CrearPedido()
        {
            int idCliente = _autenticacion.GetClienteId();

            var nuevoPedido = new Pedido()
            {
                ClienteId = idCliente,
                Fecha = Hoy(),
                IdEstado = 1,
            };

            await _context.AddAsync(nuevoPedido);
            await _context.SaveChangesAsync();
        }

        public async Task<int> ObtenerPedido()
        {
            int clienteId = _autenticacion.GetClienteId();

            var pedido = await _context.Pedidos.Where(x => x.ClienteId == clienteId && x.IdEstado ==1)
                                               .OrderByDescending(X => X.PedidoId)
                                               .FirstOrDefaultAsync();

            int idPedido = pedido.PedidoId;

            return idPedido;
        }


        public async Task<int> AgregarPlatoDetalle(int productoId)
        {
            var producto = await _context.Platos.FindAsync(productoId);
            var idPedido = await ObtenerPedido();
            var pedido = await _context.Pedidos.FindAsync(idPedido);

            PedidoDetalle platoAgregado = new()
            {
                PedidoId = pedido.PedidoId,
                PlatoId = producto.PlatoId,
                Pedido = pedido,
                Plato = producto,
            };

            await _context.PedidoDetalles.AddAsync(platoAgregado);

            await _context.SaveChangesAsync();

            int idDetalle = platoAgregado.DetallePedidoId;

            return idDetalle;
        }


        public async Task<int> AgregarComboDetalle(int productoId)
        {
            var producto = await _context.Combos.FindAsync(productoId);
            var idPedido = await ObtenerPedido();
            var pedido = await _context.Pedidos.FindAsync(idPedido);

            PedidoDetalle platoAgregado = new()
            {
                PedidoId = pedido.PedidoId,
                ComboId = producto.ComboId,
                Pedido = pedido,
                Combo = producto,

            };

            await _context.PedidoDetalles.AddAsync(platoAgregado);

            await _context.SaveChangesAsync();

            int idDetalle = platoAgregado.DetallePedidoId;

            return idDetalle;
        }


        public async Task<int> AgregarPromoDetalle(int productoId)
        {
            var prducto = await _context.Promociones.FindAsync(productoId);
            var idPedido = await ObtenerPedido();
            var pedido = await _context.Pedidos.FindAsync(idPedido);

            PedidoDetalle platoAgregado = new()
            {
                PedidoId = pedido.PedidoId,
                PromoId = prducto.PromocionId,
                Pedido = pedido,
                Promo = prducto,
            };

            await _context.PedidoDetalles.AddAsync(platoAgregado);

            await _context.SaveChangesAsync();

            int idDetalle = platoAgregado.DetallePedidoId;

            return idDetalle;
        }


        public async Task<IEnumerable<PedidoDetalle>> ObtenerDetalleDeVenta()
        {
            var cliente = await GetCliente();
            var pedido = await _context.Pedidos.Where(x => x.ClienteId == cliente.ClienteId && x.IdEstado == 1).FirstOrDefaultAsync();

            if (pedido == null)
            {
                
                return new List<PedidoDetalle>();
            }

            var detallesDePedido = await _context.PedidoDetalles
                                .Where(p => p.PedidoId == pedido.PedidoId)
                                .Include(c => c.Combo)
                                .Include(y => y.Plato)
                                .Include(z => z.Promo)
                                .ToListAsync();
            return detallesDePedido;
        }


    }
}
