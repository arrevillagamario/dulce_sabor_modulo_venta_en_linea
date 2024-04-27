using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public int ClienteId { get; set; }

    public string Ubicacion { get; set; } = null!;

    public decimal Total { get; set; }

    public DateOnly Fecha { get; set; }

    public bool Estado { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
