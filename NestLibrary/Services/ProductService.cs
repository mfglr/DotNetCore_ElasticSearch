using NestLibrary.Dtos;
using NestLibrary.Repositories;

namespace NestLibrary.Services
{
    public class ProductService
    {

        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponseDto?> SaveAsync(ProductCreateDto request)
        {
            var response = await _productRepository.SaveAsync(request.ToProduct());
            return response?.ToProductResponseDto();
        }


    }
}
