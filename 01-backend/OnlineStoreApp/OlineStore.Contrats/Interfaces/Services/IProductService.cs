using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Contrats.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> ListProduct();
        Task<ProductResponse> GetProduct(int productId);
        Task<ProductResponse> AddProduct(ProductRequest productRequest);
        Task<ProductResponse> UpdateProduct(ProductRequest productRequest, int productId);
        Task<ProductResponse> DeleteProduct(int productId);
    }
}
