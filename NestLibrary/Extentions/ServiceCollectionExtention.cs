using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace NestLibrary.Extentions
{
    public static class ServiceCollectionExtention
    {

        public static IServiceCollection AddElasticSearch(this IServiceCollection services,IConfiguration configuration)
        {

            var section = configuration.GetSection("Elastic");
            var settings = new ElasticsearchClientSettings(new Uri(section["Url"]!))
                .Authentication(new BasicAuthentication(section["Username"]!, section["Password"]!));
            return services.AddSingleton(new ElasticsearchClient(settings));
        }

    }
}
