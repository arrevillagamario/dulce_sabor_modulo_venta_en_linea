using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class Plato
{
    public int PlatoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public bool? Disponible { get; set; }

    public int? CategoriaId { get; set; }

    public bool? EsBebida { get; set; }

    public string? Imagen { get; set; }

    public virtual CategoriasPlato? Categoria { get; set; }

    public virtual ICollection<Combo> Combos { get; set; } = new List<Combo>();

    public virtual ICollection<Promocione> Promocions { get; set; } = new List<Promocione>();
}
