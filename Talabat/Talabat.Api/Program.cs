using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Talabat.Api.Extensions;
using Talabat.Api.Helpers;
using Talabat.Core.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Repository;

namespace Talabat.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();

            //SERVICES

            builder.Services.AddSwaggerServices();
            builder.Services.AddDBServices(builder.Configuration);
            builder.Services.AddApplicationServices();

           

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {

                var dbcontext = services.GetRequiredService<StoreContext>();
               
                await dbcontext.Database.MigrateAsync();

                await StoreContextSeed.SeedAsync(dbcontext);



            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error during Migragtion");

            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.SwaggerMiddleWare();
            }

            app.UseHttpsRedirection();


            //3shan ysha8al el wwwroot 
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}