using Bike.API.Infrastructure;
using Bike.Infrastructure.Garmin.Application.Database.DataSeed;
using Bike.Infrastructure.Garmin.Application.IoC;
using Bike.Shared.Domain;

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
    .AddGarminIntegrationApplication()
    .AddSingleton<IUserContext, FakeUserContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Services
    .SeedGarminData();

app.Run();
