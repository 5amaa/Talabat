using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.Repository.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Talabat.Api.Extensions
{
    public static class DBExtension
    {
        public static IServiceCollection AddDBServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(options =>
            {

                options.UseSqlServer(config.GetConnectionString("Default"));

            });
            
            
            return services;
        }
        //public static IConnectionMultiplexer AddRedisServices(this IServiceCollection services, IConfiguration config)
        //{
            
            
            
            
        //}
       
    }
}
