using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace RaroLabs.Cep.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
