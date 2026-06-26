using Microsoft.AspNetCore.Mvc;
using SistemaAlmacen.Service;

namespace SistemaAlmacen.Controllers;

public class AccountController : Controller
{
    private AccountService _accountService;
    public AccountController()
    {
        _accountService = new AccountService();
    }
    
    // GET
    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetInt32("userId");
        if (userId != null)
        {
            return RedirectToAction("Index", "Product");
        }
        
        return View();
    }

    [HttpPost]
    public IActionResult ValidarInicioSesion(string nombreUsuario, string contraseña)
    {
        var result = _accountService.ValidarInicioSesion(nombreUsuario, contraseña);

        if (result != null)
        {
            HttpContext.Session.SetInt32("userId", result.UsuarioId);
            return Ok();
        }
        
        return Unauthorized();
    }

    [HttpGet]
    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Remove("userId");

        return RedirectToAction("Index", "Account");
    }
}