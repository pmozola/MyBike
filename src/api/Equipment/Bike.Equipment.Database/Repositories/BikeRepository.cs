
using Bike.Equipment.Domain.Bike;
using Microsoft.EntityFrameworkCore;

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

        public Task<BikeAggregate?> GetAsync(int id, CancellationToken cancellationToken) => _dbContext.Bike
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public Task UpdateAsync(BikeAggregate bike, CancellationToken cancellationToken)
        {
            _dbContext.Bike.Update(bike);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
