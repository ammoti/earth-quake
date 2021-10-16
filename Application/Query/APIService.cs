using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using EarthQuake.Model;

using Newtonsoft.Json;

namespace EarthQuake.Application
{
    public class APIService : IAPIService
    {
        public async Task<ResponseModel>
        QueryEarthQuakeData(QueryRequestModel model)
        {
            var validation = new QueryRequestModelValidator().Validate(model);
            if (!validation.IsValid)
            {
                return new ResponseModel(false, validation.Errors[0].ErrorMessage);
            }
            var client = new HttpClient();
            var response =
                await client
                    .GetAsync($"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&starttime={model.StartDate}&endtime={model.EndDate}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<EarthquakeModel>(json);
            var resultList = new List<Feature>();
            //I need to every data.Properties.Mag multiple 100 to get the correct value and
            foreach (var item in data.Features)
            {
                var EdgeMiles = item.Properties.Mag * 100;

                // Get GetHaversinDistance distance and
                var Distance =
                    Calculation
                        .GetHaversinDistance(new Coordinate(item
                                .Geometry.Coordinates[1],
                            item.Geometry.Coordinates[0]),
                        new Coordinate(double.Parse(model.Latitude),
                            double.Parse(model.Longitude)));
                if (EdgeMiles >= Distance)
                {
                    resultList.Add(item);
                }
            }
            resultList = resultList.OrderByDescending(x => x.Properties.Time).Take(10).ToList();
            return new ResponseModel(true, "Success", resultList);
        }

        public Task<int> USGSPing()
        {
            var client = new HttpClient();
            var response =
                client
                    .GetAsync("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&starttime=2020-01-01&endtime=2020-01-01")
                    .Result;
            return Task.FromResult(response.StatusCode.GetHashCode());
        }
    }
}
