using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class Estadopedido
{
    public int IdEstado { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
