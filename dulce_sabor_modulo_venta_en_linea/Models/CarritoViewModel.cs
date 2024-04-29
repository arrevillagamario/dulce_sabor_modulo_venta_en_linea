namespace dulce_sabor_modulo_venta_en_linea.Models
{
    public class CarritoViewModel
    {
        public Cliente? Cliente { get; set; }

        public int? Pedido { get; set; }
        public IEnumerable<PedidoDetalle>? Detalles { get; set; }

        public decimal? PrecioTotal { get; set; }
    }
}
