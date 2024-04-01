using System.Text.Json.Serialization;

namespace NestLibrary.Models.ECommerceModel
{
    public class ECommorce
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("customer_first_name")]
        public string CustomerFirstName { get; set; } = null!;
        
        [JsonPropertyName("customer_last_name")]
        public string CustomerLastName { get; set; } = null!;
        
        [JsonPropertyName("customer_full_name")]
        public string CustomerFullName { get; set; } = null!;

        [JsonPropertyName("category")]
        public List<string> Category { get; set; } = null!;
        
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("order_date")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("product_id")]
        public long Id { get; set; }

        [JsonPropertyName("product_name")]
        public string ProductName { get; set; } = null!;
    }
}
