﻿using Elastic.Clients.Elasticsearch;
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
            var result = await _client.SearchAsync<ECommorce>(
                x => x
                    .Index(indexName)
                    .Query(x => x.Term(x => x.Field("customer_first_name.keyword").Value(firstName)))
                    .From(page * numberOfRecordPerPage)
                    .Size(numberOfRecordPerPage)
                );

            if (!result.IsSuccess())
                throw new Exception("error");
            return result.Hits.Select(x => {x.Source!.Id = x.Id;return x.Source;}).ToImmutableList();

        }

    }
}
