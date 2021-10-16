using System;
using Moq;
using EarthQuake.Application;
using EarthQuake.Model;
using Xunit;
namespace Test
{
    public class APITest
    {
        #region CONSTANT
        public Coordinate FIRST_POINT =new(41.507483,-99.436554);
        public Coordinate SECOND_POINT = new(38.504048,-98.315949);
        #endregion
        
        [Fact]
        public void Is_Haversine_Formula_Works(){
           var distance =  Calculation.GetHaversinDistance(FIRST_POINT,SECOND_POINT);
           Assert.Equal(Math.Round(215.802215),Math.Round(distance));
        }
    }
}
