﻿using Bike.Equipment.Database.Configuration;
using Bike.Equipment.Domain.Bike;
using Bike.Equipment.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Bike.Equipment.Database
{
    public class BikeEquipmentDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BikeEquipmentDbContext(DbContextOptions<BikeEquipmentDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Equipment");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BikeAggregateConfiguration).Assembly);
        }

        public DbSet<BikeAggregate> Bike { get; set; }
        public DbSet<BikeImage> BikeImages { get; set; }
        public DbSet<DistanceMeasure> DistanceMeasures { get; set; }
    }
}
