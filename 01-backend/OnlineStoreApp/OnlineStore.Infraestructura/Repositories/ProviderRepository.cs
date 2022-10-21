using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Dto.Models;

namespace OnlineStore.Infraestructura.Repositories
{
    public class ProviderRepository:BaseRepository<Provider>,IProviderRepository
    {
        public ProviderRepository(GestoresDbContext context):base(context)
        {

        }
    }
}
