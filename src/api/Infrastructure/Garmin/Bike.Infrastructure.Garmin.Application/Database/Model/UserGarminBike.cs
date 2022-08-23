namespace Bike.Infrastructure.Garmin.Application.Database.Model
{
    public class UserGarminBike
    {
        public int Id { get; set; }
        public string? GarminUuid { get; set; }
        public int BikeOwnerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BikeFullName { get; set; }
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
