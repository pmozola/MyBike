using Bike.Equipment.Database;
using Bike.Shared.Domain.Contracts;
using Garmin.Connect;
using Garmin.Connect.Auth;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bike.Infrastructure.Garmin.Application.BackgroundServices
{
    public class UpdateBikeTotalDistanceBackgroundService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly int TwoHoursInMs = 60000;

        public UpdateBikeTotalDistanceBackgroundService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TwoHoursInMs, stoppingToken);
                    Console.WriteLine("Start Retriving gear information...");
                    using IServiceScope scope = serviceProvider.CreateScope();
                    var database = scope.ServiceProvider.GetRequiredService<GarminDbContext>();

                    foreach (var userGarminBike in database.UserGarminBikes)
                    {
                        var authParameters = new BasicAuthParameters(userGarminBike.UserName, userGarminBike.Password);
                        var client = new GarminClientExtension(new GarminConnectContext(new HttpClient(), authParameters));

                        //Get First Time Equipment Uuid
                        if (userGarminBike.GarminUuid == null)
                        {
                            var uuidResponse = await GetBikeUuid(client, userGarminBike);
                            if (uuidResponse == null) break;
                            userGarminBike.GarminUuid = uuidResponse;
                        }

                        var bikeDetailResponse = await client.GetBikeDetail(userGarminBike.GarminUuid);

                        //Skip Updating if update date is the same
                        if (bikeDetailResponse.TotalActivities == userGarminBike.TotalActivities &&
                            bikeDetailResponse.TotalDistance == userGarminBike.TotalDistance)
                        {
                            Console.WriteLine($"Nothing change, last update: {userGarminBike.LastUpdate}");
                            break;
                        }

                        //send message to queue
                        var bikeInformationUpdate = new NewBikeActivitiesIntegrationEvent(
                            userGarminBike.BikeId,
                            bikeDetailResponse.TotalDistance,
                            bikeDetailResponse.TotalActivities,
                            userGarminBike.TotalDistance,
                            userGarminBike.TotalActivities);

                        await scope.ServiceProvider.GetRequiredService<IPublisher>().Publish(bikeInformationUpdate, stoppingToken);

                        Console.WriteLine($"TotalDistance: {bikeDetailResponse.TotalDistance}, new distance {bikeInformationUpdate.NewDistance} in meters");
                        Console.WriteLine($"TotalActivity: {bikeDetailResponse.TotalActivities}, new activities {bikeInformationUpdate.NewActivities}");
                        Console.WriteLine($"Last Update: {userGarminBike.LastUpdate}");

                        //Save info to database
                        userGarminBike.UpdateInforation(bikeDetailResponse);
                        database.Update(userGarminBike);
                        await database.SaveChangesAsync(stoppingToken);

                        Console.WriteLine($"Finish retriving information for {userGarminBike.BikeFullName} for user {userGarminBike.UserName}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR...");

                    Console.WriteLine(ex);
                }
            }
        }

        private static async Task<string?> GetBikeUuid(GarminClientExtension client, Database.Model.UserGarminBike userGarminBike)
        {
            Console.WriteLine($"Retriving bike garmin uuid for user {userGarminBike.UserName} and bike {userGarminBike.BikeFullName}");
            var gears = await client.GetUserGears(107113049);

            Console.WriteLine("user have:");

            foreach (var gear in gears)
            {
                Console.WriteLine($"* {gear.DisplayName}");
            }
            var bike = gears.FirstOrDefault(x => x.CustomMakeModel == userGarminBike.BikeFullName);

            if (bike == null)
            {
                Console.WriteLine($"cannot find bike {userGarminBike.BikeFullName} skipping...");
                return null;
            }
            Console.WriteLine($"uuid for bike {userGarminBike.BikeFullName} is {bike.Uuid}");

            return bike.Uuid;
        }
    }
}
