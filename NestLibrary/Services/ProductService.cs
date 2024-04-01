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
            return (await _productRepository.SaveAsync(request.ToProduct()))?.ToProductResponseDto();
        }
        public async Task<IReadOnlyCollection<ProductResponseDto>> GetAllAsync()
        {
            var response = await _productRepository.GetAllAsync();
            return response.Select(x => x.ToProductResponseDto()).ToList();
        } 
        public async Task<ProductResponseDto> GetById(string id)
        {
            return (await _productRepository.GetById(id)).ToProductResponseDto();
        }
        public async Task UpdateAsync(ProductUpdateDto product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _productRepository.DeleteAsync(id);
        }

    }
}
