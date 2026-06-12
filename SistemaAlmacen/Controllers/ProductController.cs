using Microsoft.AspNetCore.Mvc;
using SistemaAlmacen.Models;
using SistemaAlmacen.Service;

namespace SistemaAlmacen.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductoService _productoService;
        public ProductController() 
        {
            _productoService = new ProductoService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productoService.Get();
            return Json(products);
        }


        [HttpPost]
        public IActionResult SaveChangeProducts([FromBody]Producto producto)
        {
            _productoService.Save(producto);
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            _productoService.Delete(productId);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetDropCategorias() => Json(_productoService.GetDropCategorias());

    }
}