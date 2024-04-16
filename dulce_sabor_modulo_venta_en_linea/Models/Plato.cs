using System;
using System.Collections.Generic;

namespace dulce_sabor_modulo_venta_en_linea.Models;

public partial class Plato
{
    public int PlatoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Categoria { get; set; }

    public int? Disponible { get; set; }

    public int? CategoriaId { get; set; }
}
