using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Dto.Models;

namespace OnlineStore.Infraestructura.Repositories
{
    public class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(GestoresDbContext context):base(context)
        {

        }

    }
}
