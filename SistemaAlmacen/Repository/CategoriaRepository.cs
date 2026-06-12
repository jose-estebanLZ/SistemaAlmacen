using SistemaAlmacen.Models;

namespace SistemaAlmacen.Repository
{
    public class CategoriaRepository
    {
        public List<Categorium> Get()
        {
            using (var context = new SistemaAlmacenDbContext())
            {
                return context.Categoria.ToList();
            }
        }
    }
}
