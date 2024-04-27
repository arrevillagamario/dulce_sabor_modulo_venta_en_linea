using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class Combo
{
    public int ComboId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public bool? Disponible { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();

    public virtual ICollection<Plato> Platos { get; set; } = new List<Plato>();
}
