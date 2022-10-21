using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Dto.Models;

namespace OnlineStore.Infraestructura.Repositories
{
    public class InvoiceRepository:BaseRepository<Invoice>,IInvoiceRepository
    {
        public InvoiceRepository(GestoresDbContext context):base(context)
        {
                
        }

    }
}
