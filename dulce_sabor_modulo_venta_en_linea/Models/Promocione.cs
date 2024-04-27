using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class Promocione
{
    public int PromocionId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Descuento { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();

    public virtual ICollection<Plato> Platos { get; set; } = new List<Plato>();
}
