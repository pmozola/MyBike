using Bike.API.Infrastructure;
using Bike.API.Middleware;
using Bike.Equipment.Application.IoC;
using Bike.Equipment.Database.DataSeed;
using Bike.Infrastructure.Emails.Application.IoC;
using Bike.Infrastructure.Garmin.Application.BackgroundServices;
using Bike.Infrastructure.Garmin.Application.Database.DataSeed;
using Bike.Infrastructure.Garmin.Application.IoC;
using Bike.Infrastructure.ImageStore.Application.IoC;
using Bike.Infrastructure.PushNotification.Application.IoC;
using Bike.Infrastructure.Strava.Application.IoC;
using Bike.Shared.Domain;
using Bike.Wishlist.Application.IoC;
using Bike.Wishlist.Database.DataSeed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddBikeEquipmentApplication()
    .AddGarminIntegrationApplication()
    .AddImageStoreApplication()
    .AddStravaApplication()
    .AddEmailsApplication()
    .AddPushNotificationApplication()
    .AddWishlistApplication()
    .AddSingleton<IUserContext, FakeUserContext>();

builder.Services.AddHostedService<UpdateBikeTotalDistanceBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("default");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Services
    .SeedEquipmentData()
    .SeedWishlistData()
    .SeedGarminData();

app.Run();
