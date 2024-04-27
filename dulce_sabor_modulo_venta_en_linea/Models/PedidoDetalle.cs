using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class PedidoDetalle
{
    public int DetallePedidoId { get; set; }

    public int PedidoId { get; set; }

    public int? PlatoId { get; set; }

    public int? ComboId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;
}
