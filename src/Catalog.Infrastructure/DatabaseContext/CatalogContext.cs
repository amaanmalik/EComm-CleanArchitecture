using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.DatabaseContext
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> Types { get; }

        public CatalogContext(IConfiguration configuration)
        {
            // Get connection details
            var connectionString = configuration["DatabaseSettings:ConnectionString"];
            var databaseName = configuration["DatabaseSettings:DatabaseName"];

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentNullException("MongoDB configuration values cannot be null");
            }

            // Initialize MongoDB Client
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Initialize Collections
            Brands = database.GetCollection<ProductBrand>(configuration["DatabaseSettings:BrandsCollection"]);
            Types = database.GetCollection<ProductType>(configuration["DatabaseSettings:TypesCollection"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            CatalogContextSeed.SeedData(Products, Brands, Types);
        }
    }
}
