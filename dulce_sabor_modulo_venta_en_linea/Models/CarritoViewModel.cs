using System.ComponentModel.DataAnnotations;

namespace dulce_sabor_modulo_venta_en_linea.Models
{
    public class CarritoViewModel
    {
        public Cliente? Cliente { get; set; }

        public int? Pedido { get; set; }

        [Required (ErrorMessage = "Es necesario que ingrese una dirección para recibir su pedido")]
        public string? Direccion { get; set; }   
        public IEnumerable<PedidoDetalle>? Detalles { get; set; }

        public decimal? PrecioTotal { get; set; }
    }
}
