using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class CategoriasPlato
{
    public int CategoriaId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Plato> Platos { get; set; } = new List<Plato>();
}
