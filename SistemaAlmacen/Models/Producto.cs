using System;
using System.Collections.Generic;

namespace SistemaAlmacen.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Codigo { get; set; }

    public int? UnidadDeMedida { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categorium Categoria { get; set; } = null!;
}
