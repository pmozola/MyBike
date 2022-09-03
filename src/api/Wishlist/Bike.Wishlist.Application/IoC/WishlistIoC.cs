using Bike.Wishlist.Application.Beheviours;
using Bike.Wishlist.Application.CommandHandlers;
using Bike.Wishlist.Database;
using Bike.Wishlist.Database.DataSeed;
using Bike.Wishlist.Database.Repositories;
using Bike.Wishlist.Domain.Wish;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bike.Wishlist.Application.IoC
{
    public static class WishlistIoC
    {
        public static IServiceCollection AddWishlistApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(CreateWishCommandHandler).Assembly)
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
                .AddValidatorsFromAssemblyContaining<CreateWishCommandHandlerValidator>();

            services.AddDbContext<WishlistDbContext>(
                options => options.UseInMemoryDatabase("Bike"));

            services
                .AddTransient<WishlistTestDataSeeder>()
                 .AddTransient<IWishRepository, WishRepository>()
                 .AddTransient<IUserCategoryRepository, UserCategoryRepository>();

            return services;
        }
    }
}
