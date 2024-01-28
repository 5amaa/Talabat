using Microsoft.EntityFrameworkCore;
using Talabat.Repository.Data;

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
    }
}
