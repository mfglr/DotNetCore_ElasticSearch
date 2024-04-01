using NestLibrary.Models;

namespace NestLibrary.Dtos
{
    public record ProductFeatureDto(int Height, int Width,Color Color)
    {
        public ProductFeature ToProductFeature()
        {
            return new()
            {
                Height = Height,
                Width = Width,
                Color = Color
            };
        }
    }
}
