using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaAlmacen.Models;
using SistemaAlmacen.Models.spModels;

namespace SistemaAlmacen.Repository;

public class StoredProcedureExecRepository
{
    public List<pObtenerProductos> ObtenerProductos(int? productoId = null)
    {
        using (var context = new SistemaAlmacenDbContext())
        {
            return context.ObtenerProductos.FromSqlRaw("pObtenerProductos @productoId",
                new SqlParameter("@productoId", productoId ?? (object)DBNull.Value)).ToList();
        } 
    }
    
    public pValidarInicioSesion? ObtenerProductos(string nombreUsuario, string contraseña)
    {
        using (var context = new SistemaAlmacenDbContext())
        {
            return context.ValidarInicioSesion.FromSqlRaw("pValidarInicioSesion @nombreUsuario, @contraseña",
                new SqlParameter("@nombreUsuario", nombreUsuario),
                new SqlParameter("@contraseña", contraseña)).AsEnumerable().FirstOrDefault();
        } 
    }
}