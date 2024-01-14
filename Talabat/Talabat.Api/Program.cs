using Microsoft.EntityFrameworkCore;
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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            builder.Services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>)); //inject IGenaricRepository


            //inject the AutoMapper from the MappingProfiles class

            builder.Services.AddAutoMapper(typeof(MappingProfiles));

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
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}