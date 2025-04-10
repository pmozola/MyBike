using Microsoft.Extensions.DependencyInjection;
using MyBike.Application.Handlers.Queries.Bike.GetUserBike;

namespace MyBike.Application.IoC;

public  static class MyBikeApplicationIoC
{
    public static IServiceCollection AddMyBikeApplication(this IServiceCollection services)
    {
        services.
            AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetUserQuery>());
        return services;
    }
}