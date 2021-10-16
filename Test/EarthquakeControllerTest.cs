using System;
using EarthQuake.API.Controllers;
using EarthQuake.Application;
using EarthQuake.Model;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Test
{
    public class EarthquakeControllerTest
    {
        [Fact]
        public async void Service_API_Should_Call_Once()
        {
            var MockServices = new Mock<IAPIService>();
            var MockLogs = new Mock<ILogger<EarthquakeController>>();
            var Controller =
                new EarthquakeController(MockLogs.Object, MockServices.Object);

            // arrange
            MockServices
                .Setup(usgs =>
                    usgs.QueryEarthQuakeData(It.IsAny<QueryRequestModel>()))
                .ReturnsAsync(new ResponseModel(true, "Success"));

            await Controller.QueryEarthquakes(It.IsAny<QueryRequestModel>());

            // assert
            MockServices
                .Verify(usgs =>
                    usgs.QueryEarthQuakeData(It.IsAny<QueryRequestModel>()),
                Times.Once);
        }

        [Fact]
        public async void Is_USGS_API_Work()
        {
            var mock = new Mock<IAPIService>();
            mock.Setup(x => x.USGSPing()).ReturnsAsync(200);
            await mock.Object.USGSPing();
            mock.Verify(x => x.USGSPing(), Times.Once);
        }
    }
}
