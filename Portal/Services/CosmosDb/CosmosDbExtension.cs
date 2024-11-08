using Microsoft.Extensions.Options;

namespace Portal.Services.CosmosDb
{
    public static class CosmosDbExtension
    {
        public static IServiceCollection AddCosmosDbService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CosmosDbOptions>(configuration.GetSection("CosmosDb"));

            services.AddSingleton(sp =>
            {
                return new CosmosDbService(sp.GetRequiredService<IOptions<CosmosDbOptions>>().Value);
            });

            return services;
        }
    }
}
