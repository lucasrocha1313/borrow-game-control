using AutoMapper;
using GameLoanApi.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace GameLoanApi.Extensions
{
    public static class GameLoanMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperCopnfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(o =>
            {
                o.AddProfile(new GameLoanProfile());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
