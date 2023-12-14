using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbcontext)
        {
            if(!dbcontext.ProductBrands.Any())
            {
                var brandData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                if(brands?.Count > 0)
                {
                    foreach (var brand in brands)
                    {
                        await dbcontext.AddAsync<ProductBrand>(brand);  
 
                    }await dbcontext.SaveChangesAsync();


                }
            }

            if (!dbcontext.ProductTypes.Any())
            {
                var typeData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                if (types?.Count > 0)
                {
                    foreach (var type in types)
                    {
                        await dbcontext.AddAsync<ProductType>(type);

                    }
                    await dbcontext.SaveChangesAsync();


                }
            }

            if (!dbcontext.Products.Any())
            {
                var productData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);

                if (products?.Count > 0)
                {
                    foreach (var product in products)
                    {
                        await dbcontext.AddAsync<Product>(product);
                    }
                    await dbcontext.SaveChangesAsync();
                }
            }
            var x = 10;
        }

    }
}
