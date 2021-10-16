using System.Threading.Tasks;
using EarthQuake.Application;
using EarthQuake.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EarthQuake.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EarthquakeController : ControllerBase
    {
        private readonly ILogger<EarthquakeController> _logger;

        private readonly IAPIService _apiService;

        public EarthquakeController(
            ILogger<EarthquakeController> logger,
            IAPIService apiService
        )
        {
            _logger = logger;
            _apiService = apiService;
        }

        [HttpGet("Ping")]
        public async Task<ActionResult> PingUSGS()
        {
            var result = await _apiService.USGSPing();
            if(result ==200)
            {
                return Ok("Pong");
            }
            return BadRequest("USGS API has problem");
        }

        [HttpPost("Query")]
        public async Task<ActionResult<ResponseModel>>
        QueryEarthquakes([FromBody] QueryRequestModel model)
        {
            var response = await _apiService.QueryEarthQuakeData(model);
            if (!response.IsSuccess)
            {
                _logger.LogError("Query Problem");

                return BadRequest(response.Message);
            }
            else
            {
                if (response.Data?.Count == 0)
                {
                    _logger.LogInformation("QueryEarthquakes No Data");
                    return NotFound(new ResponseModel(false, "No Data"));
                }
                _logger.LogInformation("Query Earthquakes Success");
                return Ok(response);
            }
        }
    }
}
