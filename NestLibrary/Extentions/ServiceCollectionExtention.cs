using Elasticsearch.Net;
using Nest;

namespace NestLibrary.Extentions
{
    public static class ServiceCollectionExtention
    {

        public static IServiceCollection AddElasticSearch(this IServiceCollection services,IConfiguration configuration)
        {

            var section = configuration.GetSection("Elastic");

            var pool = new SingleNodeConnectionPool(new Uri(section["Url"]!));
            var settings = new ConnectionSettings(pool);
            //settings.BasicAuthentication(section["Username"], section["Password"]);
            var client = new ElasticClient(settings);
            
            return services.AddSingleton(client);
        }

    }
}
