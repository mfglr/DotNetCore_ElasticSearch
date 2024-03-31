using NestLibrary.Models;

namespace NestLibrary.Dtos
{
    public record ProductResponseDto(string Id, string Name, decimal Price, int Stock, DateTime CreatedDate, DateTime? UpdatedDate, ProductFeatureDto? Feature)
    {
    }
}
