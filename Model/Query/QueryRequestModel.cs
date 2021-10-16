using System;
using Newtonsoft.Json;
namespace EarthQuake.Model
{
    public sealed record QueryRequestModel
    {
        [JsonProperty("lat")]
        public string Latitude { get; init; }
        [JsonProperty("long")]
        public string Longitude { get; init; }
        [JsonProperty("start_date")]
        public DateTime StartDate { get; init; }
        [JsonProperty("end_date")]
        public DateTime EndDate { get; init; }
    }
}