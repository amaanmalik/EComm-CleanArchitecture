using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.Infrastructure.DatabaseContext
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection, IMongoCollection<ProductBrand> brandCollection, IMongoCollection<ProductType> typeCollection)
        {
            SeedProducts(productCollection);
            SeedBrands(brandCollection);
            SeedTypes(typeCollection);
        }

        private static void SeedProducts(IMongoCollection<Product> productCollection)
        {
            bool checkProducts = productCollection.Find(p => true).Any();
            if (!checkProducts)
            {
                var products = new List<Product>
                {
                    new Product { Id = "602d2149e773f2a3990b47f5", Name = "Adidas Quick Force Indoor Badminton Shoes", Price = 3500, Summary = "Adidas Quick Force Indoor Badminton Shoes", ImageFile = "images/products/adidas_shoe-1.png", Types = new ProductType { Id = "63ca5d4bc3a8a58f47299f97", Name = "Shoes" }, Brands = new ProductBrand { Id = "63ca5e40e0aa3968b549af53", Name = "Adidas" } },
                    new Product { Id = "602d2149e773f2a3990b47f6", Name = "Adidas Quick Force Indoor Badminton Shoes", Price = 3375, Summary = "Adidas Quick Force Indoor Badminton Shoes", ImageFile = "images/products/adidas_shoe-2.png", Types = new ProductType { Id = "63ca5d4bc3a8a58f47299f97", Name = "Shoes" }, Brands = new ProductBrand { Id = "63ca5e40e0aa3968b549af53", Name = "Adidas" } },
                    new Product { Id = "602d2149e773f2a3990b47f8", Name = "Asics Gel Rocket 8 Indoor Court Shoes", Price = 4249, Summary = "Asics Gel Rocket 8 Indoor Court Shoes", ImageFile = "images/products/asics_shoe-1.png", Types = new ProductType { Id = "63ca5d4bc3a8a58f47299f97", Name = "Shoes" }, Brands = new ProductBrand { Id = "63ca5e4c455900b990b43bc1", Name = "ASICS" } },
                    new Product { Id = "932d2149e773f2a3990b47fa", Name = "Puma 19 FH Rubber Spike Cricket Shoes", Price = 4999, Summary = "Puma 19 FH Rubber Spike Cricket Shoes", ImageFile = "images/products/puma_shoe-1.png", Types = new ProductType { Id = "63ca5d4bc3a8a58f47299f97", Name = "Shoes" }, Brands = new ProductBrand { Id = "63ca5e728c4cff9708ada2a6", Name = "Puma" } },
                    new Product { Id = "992d2149e773f2a3990b47fa", Name = "Yonex VCORE Pro 100 A Tennis Racquet (270gm, Strung)", Price = 6099, Summary = "Yonex VCORE Pro 100 A Tennis Racquet (270gm, Strung)", ImageFile = "images/products/yonex-racket-1.png", Types = new ProductType { Id = "63ca5d6d958e43ee1cd375fe", Name = "Rackets" }, Brands = new ProductBrand { Id = "63ca5e655ec1fdc49bd9327d", Name = "Yonex" } }
                };

                productCollection.InsertMany(products);
            }
        }

        private static void SeedBrands(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(b => true).Any();
            if (!checkBrands)
            {
                var brands = new List<ProductBrand>
                {
                    new ProductBrand { Id = "63ca5e40e0aa3968b549af53", Name = "Adidas" },
                    new ProductBrand { Id = "63ca5e4c455900b990b43bc1", Name = "ASICS" },
                    new ProductBrand { Id = "63ca5e59065163c16451bd73", Name = "Victor" },
                    new ProductBrand { Id = "63ca5e655ec1fdc49bd9327d", Name = "Yonex" },
                    new ProductBrand { Id = "63ca5e728c4cff9708ada2a6", Name = "Puma" },
                    new ProductBrand { Id = "63ca5e7ec90ff5c8f44d5ac8", Name = "Nike" },
                    new ProductBrand { Id = "63ca5e8d6110a9c56ee7dc48", Name = "Babolat" }
                };

                brandCollection.InsertMany(brands);
            }
        }

        private static void SeedTypes(IMongoCollection<ProductType> typeCollection)
        {
            bool checkTypes = typeCollection.Find(t => true).Any();
            if (!checkTypes)
            {
                var types = new List<ProductType>
                {
                    new ProductType { Id = "63ca5d4bc3a8a58f47299f97", Name = "Shoes" },
                    new ProductType { Id = "63ca5d6d958e43ee1cd375fe", Name = "Rackets" },
                    new ProductType { Id = "63ca5d7d380402dce7f06ebc", Name = "Football" },
                    new ProductType { Id = "63ca5d8849bc19321b8be5f1", Name = "Kit Bags" }
                };

                typeCollection.InsertMany(types);
            }
        }
    }
}
