using Bike.API.Infrastructure;
using Bike.Equipment.Application.IoC;
using Bike.Equipment.Database.DataSeed;
using Bike.Infrastructure.ImageStore.Application.IoC;
using Bike.Infrastructure.PushNotification.Application.IoC;
using Bike.Infrastructure.Strava.Application.IoC;
using Bike.Shared.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddBikeEquipmentApplication()
    .AddImageStoreApplication()
    .AddStravaApplication()
    .AddEmailsApplication()
    .AddPushNotificationApplication()
    .AddSingleton<IUserContext, FakeUserContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Services.SeedEquipmentData();

app.Run();
