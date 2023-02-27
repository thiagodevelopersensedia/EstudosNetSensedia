using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sensedia.Core.Entities;
using Sensedia.Infrastructure.Context;
using Sensedia.Infrastructure.Extensions;


namespace Sensedia.Infrastructure.Seed
{
    public class SensediaContextSeed
    {
        private static List<Product> fakerProductList = new List<Product>();
        private static List<ProductBrand> fakerProductBrandList = new List<ProductBrand>();
        private static List<ProductType> fakerProductTypeList = new List<ProductType>();
        private const string PATH_SEED = @"../Sensedia.Infrastructure/Seed/DataFaker";
        private static string FILE_JSON_PRODUCT = $@"{PATH_SEED}/Products.json";
        private static string FILE_JSON_PRODUCT_BRANDS = $@"{PATH_SEED}/ProductBrands.json";
        private static string FILE_JSON_PRODUCT_TYPE = $@"{PATH_SEED}/ProductTypes.json";

        public static async Task SeedAsync(SensediaContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                    await GenerateBuildFakerProductBrand(context, loggerFactory);
                    await GenerateBuildFakerProductType(context, loggerFactory);
                    await GenerateBuildFakerProduct(context, loggerFactory);



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static async Task GenerateBuildFakerProductBrand(SensediaContext context, ILoggerFactory loggerFactory)
        {


                if (!context.DbSet<ProductBrand>().Any())
                {
                    try
                    {
                        var productBrandList = File.ReadAllText(FILE_JSON_PRODUCT_BRANDS);

                        fakerProductBrandList = JsonConvert.DeserializeObject<List<ProductBrand>>(productBrandList);

                        context.DbSet<ProductBrand>().AddRange(fakerProductBrandList);

                    await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        var logger = loggerFactory.CreateLogger<SensediaContextSeed>();
                        logger.LogError(ex, "An error occured during seed Client db");
                    }
                }

        }

        private static async Task GenerateBuildFakerProductType(SensediaContext context, ILoggerFactory loggerFactory)
        {

                if (!context.DbSet<ProductType>().Any())
                {
                    try
                    {
                        var productTypeList = File.ReadAllText(FILE_JSON_PRODUCT_TYPE);

                        fakerProductTypeList = JsonConvert.DeserializeObject<List<ProductType>>(productTypeList);

                        context.DbSet<ProductType>().AddRange(fakerProductTypeList);

                    await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        var logger = loggerFactory.CreateLogger<SensediaContextSeed>();
                        logger.LogError(ex, "An error occured during seed Client db");
                    }
                }

        }

        private static async Task GenerateBuildFakerProduct(SensediaContext context, ILoggerFactory loggerFactory)
        {
                if (!context.DbSet<Product>().Any())
                {
                    try
                    {
                        var productList = File.ReadAllText(FILE_JSON_PRODUCT);

                        fakerProductList = JsonConvert.DeserializeObject<List<Product>>(productList);

                    context.DbSet<Product>().AddRange(fakerProductList);

                    await context.SaveChangesAsync();

                }
                    catch (Exception ex)
                    {
                        var logger = loggerFactory.CreateLogger<SensediaContextSeed>();
                        logger.LogError(ex, "An error occured during seed Client db");
                    }
                }

        }
    }
}
