using SistemaAlmacen.Models.spModels;
using SistemaAlmacen.Repository;

namespace SistemaAlmacen.Service;

public class AccountService
{
    StoredProcedureExecRepository _storedProcedureExecRepository;
    public AccountService()
    {
        _storedProcedureExecRepository = new StoredProcedureExecRepository();
    }
    
    public pValidarInicioSesion? ValidarInicioSesion(string nombreUsuario, string contraseña)
    {
        return _storedProcedureExecRepository.ObtenerProductos(nombreUsuario, contraseña);
    }
}