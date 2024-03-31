using Nest;
using NestLibrary.Dtos;

namespace NestLibrary.Models
{
    public class Product
    {
        [PropertyName("_id")]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ProductFeature? Feature { get; set; }



        public ProductResponseDto ToProductResponseDto()
        {
            return new(Id, Name, Price, Stock, CreatedDate, UpdatedDate, Feature == null ? null : new(Feature.Width, Feature.Height, Feature.Color));
        }



    }
}
