namespace Talabat.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static WebApplication SwaggerMiddleWare(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }

    }
}
