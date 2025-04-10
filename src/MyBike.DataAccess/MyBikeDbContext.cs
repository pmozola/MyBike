using Microsoft.EntityFrameworkCore;
using MyBike.Domain;

namespace MyBike.DataAccess;

public class MyBikeDbContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
}