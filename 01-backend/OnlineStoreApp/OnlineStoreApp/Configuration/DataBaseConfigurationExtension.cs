using Microsoft.EntityFrameworkCore;
using OnlineStore.Infraestructura;

namespace OnlineStoreApp.Configuration
{
    public static class  DataBaseConfigurationExtension
    {
        public static IServiceCollection DataBaseConfiguration(this IServiceCollection buider)
        {
            buider.AddDbContext<GestoresDbContext>(x => x.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")));

            return buider;
        }
    }
}
