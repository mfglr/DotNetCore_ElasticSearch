﻿using Nest;
using NestLibrary.Exceptions;
using NestLibrary.Models;
using System.Net;

namespace NestLibrary.Repositories
{
    public class ProductRepository
    {

        private readonly ElasticClient _client;
        private const string _indexName = "products";

        public ProductRepository(ElasticClient client)
        {
            _client = client;
        }

        public async Task<Product> SaveAsync(Product product)
        {
            product.SetCreatedDate();

            var response = await _client.IndexAsync(product,x => x.Index(_indexName).Id(Guid.NewGuid().ToString()));
            if (!response.IsValid) throw new AppException("The product couldn't be saved!",HttpStatusCode.InternalServerError);
            product.Id = response.Id;
            return product;
        }

        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Product>(x => x.Index(_indexName).Query(x => x.MatchAll()));
            
            if(!result.IsValid) throw new AppException("error",HttpStatusCode.InternalServerError);

            return result
                .Hits
                .Select(x => { x.Source.Id = x.Id; return x.Source;})
                .ToList();
        }

        public async Task<Product> GetById(string id)
        {
            var result = await _client.GetAsync<Product>(id, x => x.Index(_indexName));
            
            if (!result.IsValid) throw new AppException("error", (HttpStatusCode)result.ApiCall.HttpStatusCode!);

            result.Source.Id = result.Id;
            return result.Source;
        }


    }
}
