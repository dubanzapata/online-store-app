using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OlineStore.Contrats.Interfaces.Repositories;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Models;
using OlineStore.Dto.Request;
using OlineStore.Dto.Response;

namespace OlineStore.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> AddProduct(ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            await _productRepository.Add(product);
            return _mapper.Map<ProductResponse>(product);


        }

        public async Task<ProductResponse> DeleteProduct(int productId)
        {
            var product = await _productRepository.FindBy(x => x.IdProduct == productId).FirstOrDefaultAsync();
            await _productRepository.Delete(product!);
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> GetProduct(int productId)
        {
            var product = await _productRepository.FindBy(x => x.IdProduct == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductResponse>(product);

        }

        public async Task<IEnumerable<ProductResponse>> ListProduct()
        {
            var customer = await _productRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<ProductResponse>>(customer);
        }

        public async Task<ProductResponse> UpdateProduct(ProductRequest productRequest, int productId)
        {
            var product = await _productRepository.FindBy(x => x.IdProduct == productId).FirstOrDefaultAsync();
            _mapper.Map(productRequest, product);
            await _productRepository.Update(product!);
            return _mapper.Map<ProductResponse>(product);

        }
    }
}
