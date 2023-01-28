using Ecommerce.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic.Data
{
     public class EcommerceDbContextData
    {
        public static async Task CargarDataAsync(EcommerceDbContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Brand.Any())
                {
                    var brandData = File.ReadAllText("../Ecommerce.BusinessLogic/CargarData/marca.json");

                    var brands = JsonSerializer.Deserialize<List<Brand>>(brandData);

                    foreach (var br in brands)
                    {

                        context.Brand.Add(br);

                    }
                    await context.SaveChangesAsync();

                }

                if (!context.Category.Any())
                {
                    var CategoryData =
                    File.ReadAllText("../Ecommerce.BusinessLogic/CargarData/categoria.json");

                    var categorys = 
                        JsonSerializer.Deserialize<List<Category>>(CategoryData);

                    foreach (var ct in categorys)
                    {

                        context.Category.Add(ct);

                    }
                    await context.SaveChangesAsync();

                }

                if (!context.Product.Any())
                {
                    var productoData = File.ReadAllText("../Ecommerce.BusinessLogic/CargarData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Product>>(productoData);

                    foreach (var producto in productos)
                    {
                        context.Product.Add(producto);
                    }

                    await context.SaveChangesAsync();
                }




            }
            catch (Exception e)
            {

                var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();

                logger.LogError(e.Message);

            }
        }

    }


}
