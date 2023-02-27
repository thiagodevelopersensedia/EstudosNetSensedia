using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sensedia.Core.Entities;
using Sensedia.Infrastructure.Context;
using Sensedia.Infrastructure.Extensions;

namespace Sensedia.Infrastructure.Factory
{
    public class BuildFactoryFake
    {
        private static List<Product> fakerProductList = new List<Product>();
        private static List<ProductBrand> fakerProductBrandList = new List<ProductBrand>();
        private static List<ProductType> fakerProductTypeList = new List<ProductType>();
        private const string PATH_SEED = @"../Sensedia.Infrastructure/Seed/DataFaker";
        private static string FILE_JSON_PRODUCT = $@"{PATH_SEED}/Products.json";
        private static string FILE_JSON_PRODUCT_BRANDS = $@"{PATH_SEED}/ProductBrands.json";
        private static string FILE_JSON_PRODUCT_TYPE = $@"{PATH_SEED}/ProductTypes.json";


        public static async Task BuildFactoryAsync(SensediaContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!Directory.Exists(PATH_SEED))
                {
                    Directory.CreateDirectory(PATH_SEED);
                }


                await GenerateBuildFactoryProductBrand(context,loggerFactory);
                await GenerateBuildFactoryProductType(context,loggerFactory);
                await GenerateBuildFactoryProduct(context,loggerFactory);

            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BuildFactoryFake>();
                logger.LogError(ex.Message);
            }
        }

        private async static Task GenerateBuildFactoryProductBrand(SensediaContext context, ILoggerFactory loggerFactory)
        {
            Task.Run(() =>
            {

                try
                {
                    if (!context.DbSet<ProductBrand>().Any())
                    {

                        if (File.Exists(FILE_JSON_PRODUCT_BRANDS))
                        {
                            File.Delete(FILE_JSON_PRODUCT_BRANDS);
                        }
                        Randomizer.Seed = new Random(2675309);

                        var productBrandIds = 1;
                        var productBrand = new Faker<ProductBrand>("pt_BR")
                            .RuleFor(p => p.Name, p => p.Commerce.Product())
                            .Generate(100);

                        fakerProductBrandList.AddRange(productBrand);

                        using var file = File.CreateText(FILE_JSON_PRODUCT_BRANDS);
                        var serializer = new JsonSerializer();
                            serializer.Serialize(file, fakerProductBrandList);


                    }

                }
                catch (System.Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<BuildFactoryFake>();
                    logger.LogError(ex.Message);
                }

            }).Wait();
        }


        private async static Task GenerateBuildFactoryProductType(SensediaContext context, ILoggerFactory loggerFactory)
        {
            Task.Run(() =>
            {

                try
                {
                    if (!context.DbSet<ProductType>().Any())
                    {

                        if (File.Exists(FILE_JSON_PRODUCT_TYPE))
                        {
                            File.Delete(FILE_JSON_PRODUCT_TYPE);
                        }
                        Randomizer.Seed = new Random(2675309);

                        var productTypeIds = 1;
                        var productType = new Faker<ProductType>("pt_BR")
                            .RuleFor(p => p.Name, p => p.Commerce.Product())
                            .Generate(100);

                        fakerProductTypeList.AddRange(productType);

                        using var file = File.CreateText(FILE_JSON_PRODUCT_TYPE);
                        var serializer = new JsonSerializer();
                        serializer.Serialize(file, fakerProductTypeList);


                    }

                }
                catch (System.Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<BuildFactoryFake>();
                    logger.LogError(ex.Message);
                }

            }).Wait();
        }

        private async static Task GenerateBuildFactoryProduct(SensediaContext context, ILoggerFactory loggerFactory)
        {
            Task.Run(() =>
            {
                
                try
                {
                    if (!context.DbSet<Product>().Any())
                    {

                        if (File.Exists(FILE_JSON_PRODUCT))
                        {
                            File.Delete(FILE_JSON_PRODUCT);
                        }
                        Randomizer.Seed = new Random(2675309);

                        var productIds = 1;
                        var productList = new Faker<Product>("pt_BR")
                            .RuleFor(p => p.Name, p => p.Commerce.Product())
                            .RuleFor(p => p.Description, p => $"{p.Commerce.ProductName()} {p.Commerce.Ean8()}")
                            .RuleFor(p => p.Price, p => p.Random.Decimal(10, 150))
                            .RuleFor(p => p.PictureUrl, p => p.Image.LoremFlickrUrl())
                            .RuleFor(p => p.ProductBrandId, p => new Random().Next(1, context.DbSet<ProductBrand>().Count()))
                            .RuleFor(p => p.ProductTypeId, p => new Random().Next(1, context.DbSet<ProductType>().Count()))
                            .Generate(100);


                        fakerProductList.AddRange(productList);

                        using var file = File.CreateText(FILE_JSON_PRODUCT);
                        var serializer = new JsonSerializer();
                        serializer.Serialize(file, fakerProductList);


                    }

                }
                catch (System.Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<BuildFactoryFake>();
                    logger.LogError(ex.Message);
                }

            }).Wait();
        }
    }
}
