using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using NestLibrary.Models.ECommerceModel;
using System.Collections.Immutable;

namespace NestLibrary.Repositories
{
    public class ECommerceRespository
    {

        private readonly ElasticsearchClient _client;
        private const string indexName = "kibana_sample_data_ecommerce";
        private const int numberOfRecordPerPage = 10;

        public ECommerceRespository(ElasticsearchClient client)
        {
            _client = client;
        }


        public async Task<ImmutableList<ECommorce>> TermQuery(string firstName,int page)
        {
            //var result = await _client.SearchAsync<ECommorce>(
            //    x => x
            //        .Index(indexName)
            //        .Query(x => x.Term(x => x.Field("customer_first_name.keyword").Value(firstName)))
            //        .From(page * numberOfRecordPerPage)
            //        .Size(numberOfRecordPerPage)
            //    );

            var result = await _client.SearchAsync<ECommorce>(
                x => x
                    .Index(indexName)
                    .Query(x => x.Term(x => x.CustomerFirstName.Suffix("keyword"), firstName))
                    .From(page * numberOfRecordPerPage)
                    .Size(numberOfRecordPerPage)
                );

            if (!result.IsSuccess())
                throw new Exception("error");
            return result.Hits.Select(x => {x.Source!.Id = x.Id;return x.Source;}).ToImmutableList();

        }
        public async Task<ImmutableList<ECommorce>> GetByNames(List<string> names, int page)
        {

            //var termsQuery = new TermsQuery()
            //{
            //    Field = "customer_first_name.keyword",
            //    Terms = new TermsQueryField(names.Select(x => FieldValue.String(x)).ToList().AsReadOnly())
            //};

            //var result = await _client.SearchAsync<ECommorce>(
            //    x => x
            //    .Index(indexName)
            //    .Query(termsQuery)
            //    .From(page * numberOfRecordPerPage)
            //    .Size(numberOfRecordPerPage)
            //);


            var result = await _client.SearchAsync<ECommorce>(
                x => x
                    .Index(indexName)
                    .Query(
                        x => x
                            .Terms(
                                x => x
                                    .Field(x => x.CustomerFirstName.Suffix("keyword"))
                                    .Terms(new TermsQueryField(names.Select(x => FieldValue.String(x)).ToList().AsReadOnly()))
                            )
                    )
                    .From(page * numberOfRecordPerPage)
                    .Size(numberOfRecordPerPage)
            );


            if (!result.IsSuccess())
                throw new Exception("error");
            return result.Hits.Select(x => { x.Source!.Id = x.Id; return x.Source; }).ToImmutableList();

        }

        public async Task<ImmutableList<ECommorce>> Prefix(string text,int page)
        {
            var result = await _client
                .SearchAsync<ECommorce>(
                    x => x.Index(indexName).Query(x => x.Prefix(x => x.Field(f => f.CustomerFirstName.Suffix("keyword")).Value(text)))
                );

            if (!result.IsSuccess())
                throw new Exception("error");
            return result.Hits.Select(x => { x.Source!.Id = x.Id; return x.Source; }).ToImmutableList();
        }

        public async Task<ImmutableList<ECommorce>> RangeQueryAsync(double from , double to)
        {
            var result = await _client
                .SearchAsync<ECommorce>(
                    x => x
                        .Index(indexName)
                        .Query(x => x.Range(x => x.NumberRange(x => x.Field(x => x.TaxfulTotalPrice).Gte(from).Lte(to))))
                );
            if (!result.IsSuccess())
                throw new Exception("error");
            return result.Hits.Select(x => { x.Source!.Id = x.Id; return x.Source; }).ToImmutableList();
        }



    }
}
