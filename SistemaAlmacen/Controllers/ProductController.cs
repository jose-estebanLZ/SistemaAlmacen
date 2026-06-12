using Microsoft.AspNetCore.Mvc;
using SistemaAlmacen.Models;
using SistemaAlmacen.Models.Dto.Request;
using SistemaAlmacen.Service;

namespace SistemaAlmacen.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _productoService.Get();
            return Json(products);
        }


        [HttpPost("SaveChangeProducts")]
        public IActionResult SaveChangeProducts([FromBody] ProductRequest producto)
        {
            _productoService.Save(producto);
            return Ok();
        }

        [HttpPost("DeleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            _productoService.Delete(productId);
            return Ok();
        }

        [HttpGet("GetDropCategorias")]
        public IActionResult GetDropCategorias() => Json(_productoService.GetDropCategorias());

    }
}