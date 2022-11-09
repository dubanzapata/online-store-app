using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Core.Service;
using OnlineStore.Infraestructura;
using OnlineStore.Infraestructura.Repositories;

namespace OnlineStoreApp.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {


            #region Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDetailInvoiceRepository,DetailInvoiceRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();

            #endregion


            #region  Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDetailInvoiceService, DetailInvoiceService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProviderService, ProviderService>();
            

            #endregion

            return services;
        }
    }
}