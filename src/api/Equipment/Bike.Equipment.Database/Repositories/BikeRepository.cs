using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bike.Equipment.Domain.Bike;

namespace Bike.Equipment.Database.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly BikeEquipmentDbContext _dbContext;

        public BikeRepository(BikeEquipmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(BikeAggregate bike, CancellationToken cancellationToken)
        {
            _dbContext.Add(bike);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
