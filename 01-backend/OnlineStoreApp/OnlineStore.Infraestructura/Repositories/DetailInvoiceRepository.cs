using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Dto.Models;

namespace OnlineStore.Infraestructura.Repositories
{
    public class DetailInvoiceRepository:BaseRepository<DetailInvoice>, IDetailInvoiceRepository
    {
        public DetailInvoiceRepository(GestoresDbContext context):base(context)
        {
                
        }
    }
}
