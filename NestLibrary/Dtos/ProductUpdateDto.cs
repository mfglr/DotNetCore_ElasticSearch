using NestLibrary.Models;

namespace NestLibrary.Dtos
{
    public record ProductUpdateDto(string Id,string? Name, decimal? Price, int? Stock, ProductFeatureDto? Feature)
    {
    }
}
