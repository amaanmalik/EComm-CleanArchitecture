using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.DatabaseContext
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(b => true).Any();
            string path = Path.Combine(AppContext.BaseDirectory, "SeedData", "brands.json");

            if (!checkBrands)
            {
                var brandsData = File.ReadAllText(path);
                //var brandsData = File.ReadAllText("../Catalog.Infrastructure/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null)
                {
                    foreach (var item in brands)
                    {
                        brandCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}