using Microsoft.AspNetCore.Mvc;
using SistemaAlmacen.Models;
using SistemaAlmacen.Models.Dto.Response;
using SistemaAlmacen.Repository;

namespace SistemaAlmacen.Service
{
    public class ProductoService
    {
        private ProductoRepository _productoRepository;
        private CategoriaRepository _categoriaRepository;
        public ProductoService() 
        { 
            _productoRepository = new ProductoRepository();
            _categoriaRepository = new CategoriaRepository();
        }

        public List<ProductoDto> Get()
        {
            var categorias = _categoriaRepository.Get();

            var producto = _productoRepository.Get().Select(x => new ProductoDto
            {
                ProductoId = x.ProductoId,
                CategoriaId = x.CategoriaId,
                Codigo = x.Codigo,
                Nombre = x.Nombre,
                UnidadDeMedida = x.UnidadDeMedida,
                Categoria = categorias.First(c => c.CategoriaId.Equals(x.CategoriaId)).Nombre
            }).ToList();

            return producto;
        }

        public void Save(Producto producto)
        {
            if (producto.ProductoId == 0) { 
                _productoRepository.Add(producto);
            }
            else
            {
                _productoRepository.Update(producto);
            }
        }

        public void Delete(int id)
        {
            _productoRepository.Delete(id);
        }

        public List<DropDownDto> GetDropCategorias()
        {
            return _categoriaRepository.Get().Select(x => new DropDownDto
            {
                Value = x.CategoriaId.ToString(),
                Text = x.Nombre
            }).ToList();
        }
    }
}
