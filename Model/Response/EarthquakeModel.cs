namespace EarthQuake.Model
{
    // This file I generated from quicktype
    using System;
    using System.Collections.Generic;

    using System.Globalization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EarthquakeModel
    {
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }

    public partial class Feature
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public partial class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }
    public partial class Properties
    {
        [JsonProperty("mag")]
        public double Mag { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("time")]
        private long time { get; set; }
        public DateTime Time { get { return DateTimeOffset.FromUnixTimeMilliseconds(time).DateTime; } }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("tz")]
        public object Tz { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("detail")]
        public Uri Detail { get; set; }

        [JsonProperty("felt")]
        public long? Felt { get; set; }

        [JsonProperty("cdi")]
        public double? Cdi { get; set; }

        [JsonProperty("mmi")]
        public double? Mmi { get; set; }

        [JsonProperty("alert")]
        public string Alert { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tsunami")]
        public long Tsunami { get; set; }

        [JsonProperty("sig")]
        public long Sig { get; set; }

        [JsonProperty("net")]
        public string Net { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("ids")]
        public string Ids { get; set; }

        [JsonProperty("sources")]
        public string Sources { get; set; }

        [JsonProperty("types")]
        public string Types { get; set; }

        [JsonProperty("nst")]
        public long? Nst { get; set; }

        [JsonProperty("dmin")]
        public double? Dmin { get; set; }

        [JsonProperty("rms")]
        public double Rms { get; set; }

        [JsonProperty("gap")]
        public double? Gap { get; set; }

        [JsonProperty("magType")]
        public string MagType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}