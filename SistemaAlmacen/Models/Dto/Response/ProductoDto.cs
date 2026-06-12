namespace SistemaAlmacen.Models.Dto.Response
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Codigo { get; set; }

        public int? UnidadDeMedida { get; set; }

        public int CategoriaId { get; set; }
        public string Categoria { get; set; }

    }
}
