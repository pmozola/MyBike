using Bike.API.Infrastructure;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services
    .AddWishlistApplication()
    .AddSingleton<IUserContext, FakeUserContext>();

app.UseCors("default");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Services
    .SeedWishlistData();
app.Run();
