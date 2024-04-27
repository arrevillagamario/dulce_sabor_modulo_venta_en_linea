using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
