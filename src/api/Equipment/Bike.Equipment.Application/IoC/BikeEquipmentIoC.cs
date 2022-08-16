using Bike.Equipment.Application.Beheviours;
using Bike.Equipment.Application.CommandHandlers.UserBike;
using Bike.Equipment.Database;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bike.Equipment.Application.IoC
{
    public static class BikeEquipmentIoC
    {
        public static IServiceCollection AddBikeEquipmentApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(CreateBikeCommandHandler).Assembly)
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
                .AddValidatorsFromAssemblyContaining<CreateBikeCommandValidator>();

            services.AddDbContext<BikeEquipmentDbContext>(
                options => options.UseInMemoryDatabase("Bike"));

            return services;
        }
    }
}
