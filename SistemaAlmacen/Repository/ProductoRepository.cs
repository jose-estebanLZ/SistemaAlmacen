using Microsoft.AspNetCore.Mvc;
using SistemaAlmacen.Models;

namespace SistemaAlmacen.Repository
{
    public class ProductoRepository
    {
        public List<Producto> Get()
        {
            using (var context = new SistemaAlmacenDbContext())
            {
                return context.Productos.ToList();
            }
        }

        public void Add(Producto producto) 
        {
            using (var context = new SistemaAlmacenDbContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
            }
        }

        public void Update(Producto producto)
        {
            using (var context = new SistemaAlmacenDbContext())
            {
                context.Productos.Update(producto);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new SistemaAlmacenDbContext())
            {
                var product = context.Productos.Find(id);

                context.Productos.Remove(product);
                context.SaveChanges();
            }
        }        
    }
}
