using NestLibrary.Models;

namespace NestLibrary.Dtos
{
    public record ProductCreateDto(string Name,decimal Price,int Stock,ProductFeatureDto Feature)
    {
        public Product ToProduct()
        {
            return new()
            {
                Name = Name,
                Price = Price,
                Stock = Stock,
                Feature = new()
                {
                    Color = Feature.Color,
                    Height = Feature.Height,
                    Width = Feature.Width,
                }
            };
        }
    }
}
