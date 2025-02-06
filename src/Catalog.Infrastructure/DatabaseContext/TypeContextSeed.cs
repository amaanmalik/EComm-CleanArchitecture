using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.DatabaseContext
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkTypes = typeCollection.Find(b => true).Any();
            string path = Path.Combine(AppContext.BaseDirectory, "SeedData", "types.json");

            if (!checkTypes)
            {
               var typesData = File.ReadAllText(path);
                //var typesData = File.ReadAllText("../Catalog.Infrastructure/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        typeCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}