using Garmin.Connect;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bike.Infrastructure.Garmin.Application
{
    public partial class GarminClientExtension : GarminConnectClient
    {
        private readonly GarminConnectContext context;
        private const string ActivitiesUrl = "/proxy/gear-service/gear/stats/";

        public GarminClientExtension(GarminConnectContext context) : base(context)
        {
            this.context = context;
        }

        public Task<GearDetail> GetBikeDetail(string bikeuuid)
        {
            var activitiesUrl = $"{ActivitiesUrl}{bikeuuid}";
            return context.GetAndDeserialize<GearDetail>(activitiesUrl);
        }
    }

    public record GearDetail
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; init; }

        [JsonPropertyName("gearPk")]
        public int GearPk { get; init; }

        [JsonPropertyName("updateDate")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? UpdateDate { get; init; }

        [JsonPropertyName("totalDistance")]
        public double TotalDistance { get; init; }

        [JsonPropertyName("totalActivities")]
        public int TotalActivities { get; init; }
    }

    public class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.UnixEpoch.AddMilliseconds(reader.GetInt64());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue((value - DateTime.UnixEpoch).TotalMilliseconds + "000");
        }
    }
}
