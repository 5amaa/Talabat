using Microsoft.EntityFrameworkCore;
using Talabat.Api.Helpers;
using Talabat.Core.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Repository;

namespace Talabat.Api.Extensions
{
    public static class ApplicationServicesExtension
    {
        // hna b3ml clean up ll main bgm3 kol el services fe extensiion method
        // //IsevicesCollection de el container btart el services
        // this de keyword b3rfo an deh Extension Method ll IServicesCollection
        //the return type bt3ha IserviceCollection 3shan lw 3ayza aktb dot w akml ay method gahza tania zay .AddScope();

        public static IServiceCollection AddApplicationServices(this IServiceCollection services )
        {
            
            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>)); //inject IGenaricRepository
            services.AddScoped(typeof(IBasketRepository),typeof(BasketRepository)); //inject IBasketRepository

            //inject the AutoMapper from the MappingProfiles class

            services.AddAutoMapper(typeof(MappingProfiles));


            return services;
        }
    }
}
