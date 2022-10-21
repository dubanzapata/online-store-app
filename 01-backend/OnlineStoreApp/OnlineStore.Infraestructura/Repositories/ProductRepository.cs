using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Dto.Models;

namespace OnlineStore.Infraestructura.Repositories
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(GestoresDbContext context):base(context)
        {

        }
    }
}
