namespace Bike.Infrastructure.Garmin.Application.Database.Model
{
    public class UserGarminBike
    {
        public int Id { get; set; }
        public string? GarminUuid { get; set; }
        public int BikeOwnerId { get; set; }
        public int BikeId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string BikeFullName { get; set; } = string.Empty;
        public DateTime? LastUpdate { get; set; }
        public int TotalActivities { get; set; }
        public double TotalDistance { get; set; }

        public void UpdateInforation(GearDetail gearDetail)
        {
            TotalActivities = gearDetail.TotalActivities;
            TotalDistance = gearDetail.TotalDistance;
            LastUpdate = gearDetail.UpdateDate;
        }
    }
}
