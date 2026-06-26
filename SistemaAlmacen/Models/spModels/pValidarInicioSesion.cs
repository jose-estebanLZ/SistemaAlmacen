namespace SistemaAlmacen.Models.spModels;

public class pValidarInicioSesion
{
    public int UsuarioId { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public char RolId { get; set; }
}